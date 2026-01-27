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
        // Quản lý danh sách các Toast đang hiển thị
        private static readonly List<ToastNotification> ActiveToasts = new List<ToastNotification>();
        private static readonly object LockObject = new object();
        private static Form _parentForm;

        private readonly Timer _closeTimer;
        private readonly Timer _fadeTimer;
        private readonly ToastType _toastType;
        private readonly string _message;

        // Kích thước và cấu hình giao diện
        private const int ToastWidth = 380;
        private const int ToastHeight = 68;
        private const int ToastMargin = 16;
        private const int AnimationInterval = 10;
        private const double FadeStep = 0.06; // Fade mượt hơn
        private const int BorderRadius = 12;

        // Palette màu "Clean & Bright" (Lấy cảm hứng từ Modern Dashboard UI)
        // Background
        private static readonly Color BgColor = Color.FromArgb(255, 255, 255); // Trắng tinh khôi

        // Text Colors
        private static readonly Color TextPrimary = Color.FromArgb(30, 41, 59);   // Slate-800
        private static readonly Color TextSecondary = Color.FromArgb(100, 116, 139); // Slate-500

        // Accent Colors (Màu tươi, hiện đại)
        // Success: Emerald-500
        private static readonly Color AccSuccess = Color.FromArgb(16, 185, 129);
        private static readonly Color BgSuccess = Color.FromArgb(236, 253, 245); // Emerald-50

        // Error: Rose-500
        private static readonly Color AccError = Color.FromArgb(244, 63, 94);
        private static readonly Color BgError = Color.FromArgb(255, 241, 242);   // Rose-50

        // Warning: Amber-500
        private static readonly Color AccWarning = Color.FromArgb(245, 158, 11);
        private static readonly Color BgWarning = Color.FromArgb(255, 251, 235); // Amber-50

        // Info: Sky-500
        private static readonly Color AccInfo = Color.FromArgb(14, 165, 233);
        private static readonly Color BgInfo = Color.FromArgb(240, 249, 255);    // Sky-50

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
            BackColor = Color.White; // Nền form trong suốt giả lập bằng White (vì Region sẽ cắt)

            // Cấu hình vẽ chất lượng cao
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

            // Click để đóng
            Click += (s, e) => StartFadeOut();
        }

        // Drop Shadow Effect
        protected override CreateParams CreateParams
        {
            get
            {
                if (IsDisposed) return base.CreateParams;
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= 0x00020000; // CS_DROPSHADOW
                return cp;
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

            var bounds = new Rectangle(0, 0, Width - 1, Height - 1);

            Color accentColor = GetAccentColor(_toastType);
            Color iconBgColor = GetIconBgColor(_toastType);

            // 1. Vẽ nền (Background)
            // Thay vì nền trắng hoàn toàn, ta dùng màu tint nhẹ (BgSuccess, BgError...) để tạo cảm giác mềm mại
            using (var path = CreateRoundedRectangle(bounds, BorderRadius))
            using (var brush = new SolidBrush(Color.White)) // Nền trắng chủ đạo
            {
                g.FillPath(brush, path);

                // Vẽ viền rất nhạt để định hình
                using (var pen = new Pen(Color.FromArgb(226, 232, 240), 1)) // Slate-200
                {
                    g.DrawPath(pen, path);
                }
            }

            // 2. Vẽ Icon
            DrawIcon(g, bounds, accentColor, iconBgColor);

            // 3. Vẽ Nội dung (Message)
            DrawMessage(g, bounds);

            // 4. Vẽ Close Button
            DrawCloseButton(g, bounds);

            // 5. Vẽ thanh Accent nhỏ bên trái (Minimalist)
            var accentRect = new Rectangle(6, 18, 4, Height - 36);
            using (var path = CreateRoundedRectangle(accentRect, 2))
            using (var brush = new SolidBrush(accentColor))
            {
                g.FillPath(brush, path);
            }
        }

        private void DrawIcon(Graphics g, Rectangle bounds, Color accentColor, Color iconBgColor)
        {
            int iconSize = 36;
            int iconX = 24;
            int iconY = (bounds.Height - iconSize) / 2;
            var iconRect = new Rectangle(iconX, iconY, iconSize, iconSize);

            // Vẽ vòng tròn nền icon (Soft Tint)
            using (var brush = new SolidBrush(iconBgColor))
            {
                g.FillEllipse(brush, iconRect);
            }

            // Vẽ Symbol
            string symbol = GetIconSymbol(_toastType);
            using (var font = new Font("Segoe UI Symbol", 13, FontStyle.Bold))
            using (var brush = new SolidBrush(accentColor))
            {
                var sf = new StringFormat
                {
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center
                };
                g.DrawString(symbol, font, brush, iconRect, sf);
            }
        }

        private void DrawMessage(Graphics g, Rectangle bounds)
        {
            // Message Text
            var textRect = new RectangleF(72, 0, Width - 110, Height);

            using (var font = new Font("Segoe UI", 10.5f, FontStyle.Regular))
            using (var brush = new SolidBrush(TextPrimary))
            {
                var sf = new StringFormat
                {
                    Alignment = StringAlignment.Near,
                    LineAlignment = StringAlignment.Center,
                    Trimming = StringTrimming.EllipsisCharacter,
                    FormatFlags = StringFormatFlags.NoWrap
                };
                g.DrawString(_message, font, brush, textRect, sf);
            }
        }

        private void DrawCloseButton(Graphics g, Rectangle bounds)
        {
            int closeSize = 24;
            var closeRect = new Rectangle(bounds.Right - 32, (bounds.Height - closeSize) / 2, closeSize, closeSize);

            var mousePos = PointToClient(MousePosition);
            bool isHovered = closeRect.Contains(mousePos);

            using (var font = new Font("Segoe UI", 11, FontStyle.Regular))
            using (var brush = new SolidBrush(isHovered ? TextPrimary : TextSecondary))
            {
                var sf = new StringFormat
                {
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center
                };
                g.DrawString("✕", font, brush, closeRect, sf);
            }
        }

        private GraphicsPath CreateRoundedRectangle(Rectangle bounds, int radius)
        {
            var path = new GraphicsPath();
            int d = radius * 2;
            path.AddArc(bounds.X, bounds.Y, d, d, 180, 90);
            path.AddArc(bounds.Right - d, bounds.Y, d, d, 270, 90);
            path.AddArc(bounds.Right - d, bounds.Bottom - d, d, d, 0, 90);
            path.AddArc(bounds.X, bounds.Bottom - d, d, d, 90, 90);
            path.CloseFigure();
            return path;
        }

        private static Color GetAccentColor(ToastType type)
        {
            switch (type)
            {
                case ToastType.Success: return AccSuccess;
                case ToastType.Error: return AccError;
                case ToastType.Warning: return AccWarning;
                default: return AccInfo;
            }
        }

        private static Color GetIconBgColor(ToastType type)
        {
            switch (type)
            {
                case ToastType.Success: return BgSuccess;
                case ToastType.Error: return BgError;
                case ToastType.Warning: return BgWarning;
                default: return BgInfo;
            }
        }

        private static string GetIconSymbol(ToastType type)
        {
            switch (type)
            {
                case ToastType.Success: return "✓";
                case ToastType.Error: return "✕";
                case ToastType.Warning: return "!";
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
                int y = _parentForm.Top + ToastMargin + yOffset + 40;
                Location = new Point(x, y);
            }
            else
            {
                var screen = Screen.PrimaryScreen.WorkingArea;
                Location = new Point(screen.Right - ToastWidth - ToastMargin, screen.Top + ToastMargin + yOffset);
            }
        }

        private void StartFadeIn()
        {
            _fadeTimer.Tick += FadeIn_Tick;
            _fadeTimer.Start();
        }

        private void FadeIn_Tick(object sender, EventArgs e)
        {
            if (IsDisposed) { _fadeTimer.Stop(); return; }
            if (Opacity < 1) Opacity = Math.Min(1, Opacity + FadeStep);
            else { Opacity = 1; _fadeTimer.Stop(); _fadeTimer.Tick -= FadeIn_Tick; _closeTimer.Start(); }
        }

        private void StartFadeOut()
        {
            _fadeTimer.Tick -= FadeIn_Tick;
            _fadeTimer.Tick += FadeOut_Tick;
            _fadeTimer.Start();
        }

        private void FadeOut_Tick(object sender, EventArgs e)
        {
            if (IsDisposed) { _fadeTimer.Stop(); return; }
            if (Opacity > 0) Opacity = Math.Max(0, Opacity - FadeStep);
            else { _fadeTimer.Stop(); _fadeTimer.Tick -= FadeOut_Tick; CloseToast(); }
        }

        private void CloseToast()
        {
            if (IsDisposed) return;
            lock (LockObject) { ActiveToasts.Remove(this); RepositionToasts(); }
            _closeTimer?.Stop(); _fadeTimer?.Stop();
            try { Close(); } catch (ObjectDisposedException) { }
        }

        private static void RepositionToasts()
        {
            lock (LockObject)
            {
                foreach (var toast in ActiveToasts)
                    if (!toast.IsDisposed) toast.PositionToast();
            }
        }

        protected override void OnMouseMove(MouseEventArgs e) { base.OnMouseMove(e); Invalidate(); }
        protected override void OnMouseLeave(EventArgs e) { base.OnMouseLeave(e); Invalidate(); }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);
            if (e.X > Width - 50) StartFadeOut();
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            _closeTimer?.Dispose();
            _fadeTimer?.Dispose();
            base.OnFormClosed(e);
        }

        // Static Show Methods
        public static void Show(string message, ToastType type = ToastType.Info, int durationMs = 3000)
        {
            if (Application.OpenForms.Count == 0) return;
            _parentForm = Form.ActiveForm ?? Application.OpenForms[0];

            if (_parentForm.InvokeRequired)
                _parentForm.BeginInvoke(new Action(() => ShowInternal(message, type, durationMs)));
            else
                ShowInternal(message, type, durationMs);
        }

        private static void ShowInternal(string message, ToastType type, int durationMs)
        {
            var toast = new ToastNotification(message, type, durationMs);
            lock (LockObject) { ActiveToasts.Add(toast); }
            toast.PositionToast();
            toast.Show(_parentForm);
            toast.StartFadeIn();
        }

        public static void Success(string message, int durationMs = 3000) => Show(message, ToastType.Success, durationMs);
        public static void Error(string message, int durationMs = 4000) => Show(message, ToastType.Error, durationMs);
        public static void Warning(string message, int durationMs = 3500) => Show(message, ToastType.Warning, durationMs);
        public static void Info(string message, int durationMs = 3000) => Show(message, ToastType.Info, durationMs);

        public static void CloseAll()
        {
            lock (LockObject)
            {
                var toastsToClose = new List<ToastNotification>(ActiveToasts);
                foreach (var toast in toastsToClose) toast.CloseToast();
            }
        }
    }
}
