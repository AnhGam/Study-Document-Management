using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using study_document_manager.UI;

namespace study_document_manager
{
    public enum ToastType
    {
        Success,
        Error,
        Warning,
        Info
    }

    public class ToastNotification : Form
    {
        private static readonly List<ToastNotification> ActiveToasts = new List<ToastNotification>();
        private static readonly object LockObject = new object();
        private static Form _parentForm;
        
        private readonly Timer _closeTimer;
        private readonly Timer _fadeTimer;
        private readonly ToastType _toastType;
        private readonly string _message;
        private const int ToastWidth = 360;
        private const int ToastHeight = 56;
        private const int ToastMargin = 16;
        private const int AnimationInterval = 12;
        private const double FadeStep = 0.15;
        private const int BorderRadius = 12;

        private static readonly Color SuccessBg = Color.FromArgb(240, 253, 244);
        private static readonly Color SuccessAccent = AppTheme.StatusSuccess;
        private static readonly Color SuccessText = Color.FromArgb(21, 128, 61);
        
        private static readonly Color ErrorBg = Color.FromArgb(254, 242, 242);
        private static readonly Color ErrorAccent = AppTheme.StatusError;
        private static readonly Color ErrorText = Color.FromArgb(185, 28, 28);
        
        private static readonly Color WarningBg = Color.FromArgb(255, 251, 235);
        private static readonly Color WarningAccent = AppTheme.StatusWarning;
        private static readonly Color WarningText = Color.FromArgb(180, 83, 9);
        
        private static readonly Color InfoBg = Color.FromArgb(240, 253, 250);
        private static readonly Color InfoAccent = AppTheme.Primary;
        private static readonly Color InfoText = AppTheme.PrimaryDark;

        private static readonly Color CloseButtonColor = AppTheme.TextMuted;

        private ToastNotification(string message, ToastType type, int durationMs = 3000)
        {
            _toastType = type;
            _message = message;
            
            FormBorderStyle = FormBorderStyle.None;
            StartPosition = FormStartPosition.Manual;
            ShowInTaskbar = false;
            TopMost = true;
            Size = new Size(ToastWidth, ToastHeight);
            Opacity = 0;
            BackColor = GetBackgroundColor(type);
            
            SetStyle(ControlStyles.AllPaintingInWmPaint | 
                     ControlStyles.UserPaint | 
                     ControlStyles.OptimizedDoubleBuffer |
                     ControlStyles.ResizeRedraw |
                     ControlStyles.SupportsTransparentBackColor, true);

            _closeTimer = new Timer { Interval = durationMs };
            _closeTimer.Tick += (s, e) =>
            {
                _closeTimer.Stop();
                StartFadeOut();
            };

            _fadeTimer = new Timer { Interval = AnimationInterval };

            Click += (s, e) => StartFadeOut();
        }

        protected override CreateParams CreateParams
        {
            get
            {
                if (IsDisposed) return base.CreateParams;
                
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                cp.ClassStyle |= 0x00020000;
                return cp;
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

            var bounds = new Rectangle(2, 2, Width - 4, Height - 4);
            
            DrawShadow(g, bounds);
            
            using (var path = CreateRoundedRectangle(bounds, BorderRadius))
            {
                Region = new Region(path);
                
                using (var bgBrush = new SolidBrush(GetBackgroundColor(_toastType)))
                {
                    g.FillPath(bgBrush, path);
                }
                
                using (var borderPen = new Pen(Color.FromArgb(30, GetAccentColor(_toastType)), 1))
                {
                    g.DrawPath(borderPen, path);
                }
                
                DrawLeftAccent(g, bounds);
                DrawIcon(g, bounds);
                DrawMessage(g, bounds);
                DrawCloseButton(g, bounds);
            }
        }

        private void DrawShadow(Graphics g, Rectangle bounds)
        {
            for (int i = 4; i > 0; i--)
            {
                int alpha = 8 * (5 - i);
                using (var shadowPath = CreateRoundedRectangle(
                    new Rectangle(bounds.X + i, bounds.Y + i, bounds.Width, bounds.Height), BorderRadius))
                using (var shadowBrush = new SolidBrush(Color.FromArgb(alpha, 0, 0, 0)))
                {
                    g.FillPath(shadowBrush, shadowPath);
                }
            }
        }

        private void DrawLeftAccent(Graphics g, Rectangle bounds)
        {
            var accentColor = GetAccentColor(_toastType);
            var accentRect = new Rectangle(bounds.X, bounds.Y, 5, bounds.Height);
            
            using (var accentBrush = new SolidBrush(accentColor))
            using (var accentPath = CreateRoundedRectangle(accentRect, BorderRadius, true, false, false, true))
            {
                g.FillPath(accentBrush, accentPath);
            }
        }

        private void DrawIcon(Graphics g, Rectangle bounds)
        {
            var accentColor = GetAccentColor(_toastType);
            var iconBgColor = Color.FromArgb(40, accentColor);
            
            int iconSize = 28;
            int iconX = bounds.X + 16;
            int iconY = bounds.Y + (bounds.Height - iconSize) / 2;
            var iconRect = new Rectangle(iconX, iconY, iconSize, iconSize);
            
            using (var iconBgBrush = new SolidBrush(iconBgColor))
            using (var iconPath = CreateRoundedRectangle(iconRect, iconSize / 2))
            {
                g.FillPath(iconBgBrush, iconPath);
            }
            
            var iconText = GetIconText(_toastType);
            using (var iconFont = new Font("Segoe UI", 10, FontStyle.Bold))
            using (var iconBrush = new SolidBrush(accentColor))
            {
                var sf = new StringFormat
                {
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center
                };
                g.DrawString(iconText, iconFont, iconBrush, iconRect, sf);
            }
        }

        private void DrawMessage(Graphics g, Rectangle bounds)
        {
            var textColor = GetTextColor(_toastType);
            var messageRect = new RectangleF(bounds.X + 54, bounds.Y, bounds.Width - 90, bounds.Height);
            
            using (var messageFont = new Font("Segoe UI", 10f, FontStyle.Regular))
            using (var messageBrush = new SolidBrush(textColor))
            {
                var sf = new StringFormat 
                { 
                    Alignment = StringAlignment.Near,
                    LineAlignment = StringAlignment.Center,
                    Trimming = StringTrimming.EllipsisCharacter,
                    FormatFlags = StringFormatFlags.NoWrap
                };
                g.DrawString(_message, messageFont, messageBrush, messageRect, sf);
            }
        }

        private void DrawCloseButton(Graphics g, Rectangle bounds)
        {
            int closeSize = 24;
            var closeRect = new Rectangle(bounds.Right - closeSize - 12, bounds.Y + (bounds.Height - closeSize) / 2, closeSize, closeSize);
            var mousePos = PointToClient(MousePosition);
            bool isHovered = closeRect.Contains(mousePos);
            
            if (isHovered)
            {
                using (var hoverBrush = new SolidBrush(Color.FromArgb(30, GetAccentColor(_toastType))))
                using (var hoverPath = CreateRoundedRectangle(closeRect, closeSize / 2))
                {
                    g.FillPath(hoverBrush, hoverPath);
                }
            }
            
            using (var closeFont = new Font("Segoe UI", 11, FontStyle.Regular))
            using (var closeBrush = new SolidBrush(isHovered ? GetAccentColor(_toastType) : CloseButtonColor))
            {
                var sf = new StringFormat
                {
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center
                };
                g.DrawString("×", closeFont, closeBrush, closeRect, sf);
            }
        }

        private GraphicsPath CreateRoundedRectangle(Rectangle bounds, int radius, 
            bool topLeft = true, bool topRight = true, bool bottomRight = true, bool bottomLeft = true)
        {
            var path = new GraphicsPath();
            var diameter = radius * 2;
            
            if (topLeft)
                path.AddArc(bounds.X, bounds.Y, diameter, diameter, 180, 90);
            else
                path.AddLine(bounds.X, bounds.Y + diameter, bounds.X, bounds.Y);
            
            if (topRight)
                path.AddArc(bounds.Right - diameter, bounds.Y, diameter, diameter, 270, 90);
            else
                path.AddLine(bounds.Right - diameter, bounds.Y, bounds.Right, bounds.Y);
            
            if (bottomRight)
                path.AddArc(bounds.Right - diameter, bounds.Bottom - diameter, diameter, diameter, 0, 90);
            else
                path.AddLine(bounds.Right, bounds.Bottom - diameter, bounds.Right, bounds.Bottom);
            
            if (bottomLeft)
                path.AddArc(bounds.X, bounds.Bottom - diameter, diameter, diameter, 90, 90);
            else
                path.AddLine(bounds.X + diameter, bounds.Bottom, bounds.X, bounds.Bottom);
            
            path.CloseFigure();
            return path;
        }

        private static Color GetBackgroundColor(ToastType type)
        {
            switch (type)
            {
                case ToastType.Success: return SuccessBg;
                case ToastType.Error: return ErrorBg;
                case ToastType.Warning: return WarningBg;
                case ToastType.Info: return InfoBg;
                default: return InfoBg;
            }
        }

        private static Color GetAccentColor(ToastType type)
        {
            switch (type)
            {
                case ToastType.Success: return SuccessAccent;
                case ToastType.Error: return ErrorAccent;
                case ToastType.Warning: return WarningAccent;
                case ToastType.Info: return InfoAccent;
                default: return InfoAccent;
            }
        }

        private static Color GetTextColor(ToastType type)
        {
            switch (type)
            {
                case ToastType.Success: return SuccessText;
                case ToastType.Error: return ErrorText;
                case ToastType.Warning: return WarningText;
                case ToastType.Info: return InfoText;
                default: return InfoText;
            }
        }

        private static string GetIconText(ToastType type)
        {
            switch (type)
            {
                case ToastType.Success: return "✓";
                case ToastType.Error: return "✕";
                case ToastType.Warning: return "!";
                case ToastType.Info: return "i";
                default: return "i";
            }
        }

        private void PositionToast()
        {
            if (IsDisposed) return;
            
            int yOffset;
            
            lock (LockObject)
            {
                int index = ActiveToasts.IndexOf(this);
                if (index < 0) return;
                yOffset = (ToastHeight + ToastMargin) * index;
            }

            if (_parentForm != null && !_parentForm.IsDisposed)
            {
                int x = _parentForm.Left + _parentForm.Width - ToastWidth - ToastMargin;
                int y = _parentForm.Top + ToastMargin + yOffset + 32;
                Location = new Point(x, y);
            }
            else
            {
                var screen = Screen.PrimaryScreen.WorkingArea;
                Location = new Point(
                    screen.Right - ToastWidth - ToastMargin,
                    screen.Top + ToastMargin + yOffset
                );
            }
        }

        private void StartFadeIn()
        {
            _fadeTimer.Tick += FadeIn_Tick;
            _fadeTimer.Start();
        }

        private void FadeIn_Tick(object sender, EventArgs e)
        {
            if (IsDisposed) 
            {
                _fadeTimer.Stop();
                return;
            }
            
            if (Opacity < 1)
            {
                Opacity = Math.Min(1, Opacity + FadeStep);
            }
            else
            {
                Opacity = 1;
                _fadeTimer.Stop();
                _fadeTimer.Tick -= FadeIn_Tick;
                _closeTimer.Start();
            }
        }

        private void StartFadeOut()
        {
            _fadeTimer.Tick -= FadeIn_Tick;
            _fadeTimer.Tick += FadeOut_Tick;
            _fadeTimer.Start();
        }

        private void FadeOut_Tick(object sender, EventArgs e)
        {
            if (IsDisposed)
            {
                _fadeTimer.Stop();
                return;
            }
            
            if (Opacity > 0)
            {
                Opacity = Math.Max(0, Opacity - FadeStep);
            }
            else
            {
                _fadeTimer.Stop();
                _fadeTimer.Tick -= FadeOut_Tick;
                CloseToast();
            }
        }

        private void CloseToast()
        {
            if (IsDisposed) return;
            
            lock (LockObject)
            {
                ActiveToasts.Remove(this);
                RepositionToasts();
            }
            
            _closeTimer?.Stop();
            _fadeTimer?.Stop();
            
            try
            {
                Close();
            }
            catch (ObjectDisposedException)
            {
                // Already disposed, ignore
            }
        }

        private static void RepositionToasts()
        {
            lock (LockObject)
            {
                foreach (var toast in ActiveToasts)
                {
                    if (!toast.IsDisposed)
                    {
                        toast.PositionToast();
                    }
                }
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            Invalidate();
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            Invalidate();
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);
            int closeSize = 24;
            var bounds = new Rectangle(2, 2, Width - 4, Height - 4);
            var closeRect = new Rectangle(bounds.Right - closeSize - 12, bounds.Y + (bounds.Height - closeSize) / 2, closeSize, closeSize);
            if (closeRect.Contains(e.Location))
            {
                StartFadeOut();
            }
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            _closeTimer?.Dispose();
            _fadeTimer?.Dispose();
            base.OnFormClosed(e);
        }

        public static void Show(string message, ToastType type = ToastType.Info, int durationMs = 3000)
        {
            if (Application.OpenForms.Count == 0)
                return;

            _parentForm = Form.ActiveForm ?? Application.OpenForms[0];
            
            if (_parentForm.InvokeRequired)
            {
                _parentForm.BeginInvoke(new Action(() => ShowInternal(message, type, durationMs)));
            }
            else
            {
                ShowInternal(message, type, durationMs);
            }
        }

        private static void ShowInternal(string message, ToastType type, int durationMs)
        {
            var toast = new ToastNotification(message, type, durationMs);
            
            lock (LockObject)
            {
                ActiveToasts.Add(toast);
            }
            
            toast.PositionToast();
            toast.Show(_parentForm);
            toast.StartFadeIn();
        }

        public static void Success(string message, int durationMs = 3000)
        {
            Show(message, ToastType.Success, durationMs);
        }

        public static void Error(string message, int durationMs = 4000)
        {
            Show(message, ToastType.Error, durationMs);
        }

        public static void Warning(string message, int durationMs = 3500)
        {
            Show(message, ToastType.Warning, durationMs);
        }

        public static void Info(string message, int durationMs = 3000)
        {
            Show(message, ToastType.Info, durationMs);
        }

        public static void CloseAll()
        {
            lock (LockObject)
            {
                var toastsToClose = new List<ToastNotification>(ActiveToasts);
                foreach (var toast in toastsToClose)
                {
                    toast.CloseToast();
                }
            }
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // ToastNotification
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Name = "ToastNotification";
            this.Load += new System.EventHandler(this.ToastNotification_Load);
            this.ResumeLayout(false);

        }

        private void ToastNotification_Load(object sender, EventArgs e)
        {

        }
    }
}
