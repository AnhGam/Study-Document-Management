using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.ComponentModel;

namespace study_document_manager.UI.Controls
{
    public class ModernPanel : Panel
    {
        // Fields
        private int _borderRadius = 0;
        private float _gradientAngle = 90F;
        private Color _gradientTopColor = Color.White;
        private Color _gradientBottomColor = Color.WhiteSmoke;

        // Constructor
        public ModernPanel()
        {
            this.BackColor = Color.White;
            this.ForeColor = Color.Black;
            this.Size = new Size(350, 200);
        }

        // Properties
        [Category("Modern UI Code")]
        public int BorderRadius
        {
            get { return _borderRadius; }
            set
            {
                _borderRadius = value;
                this.Invalidate();
            }
        }

        [Category("Modern UI Code")]
        public float GradientAngle
        {
            get { return _gradientAngle; }
            set
            {
                _gradientAngle = value;
                this.Invalidate();
            }
        }

        [Category("Modern UI Code")]
        public Color GradientTopColor
        {
            get { return _gradientTopColor; }
            set
            {
                _gradientTopColor = value;
                this.Invalidate();
            }
        }

        [Category("Modern UI Code")]
        public Color GradientBottomColor
        {
            get { return _gradientBottomColor; }
            set
            {
                _gradientBottomColor = value;
                this.Invalidate();
            }
        }

        // Methods
        private GraphicsPath GetFigurePath(RectangleF rect, float radius)
        {
            GraphicsPath path = new GraphicsPath();
            float curveSize = radius * 2F;
            path.StartFigure();
            path.AddArc(rect.X, rect.Y, curveSize, curveSize, 180, 90);
            path.AddArc(rect.Right - curveSize, rect.Y, curveSize, curveSize, 270, 90);
            path.AddArc(rect.Right - curveSize, rect.Bottom - curveSize, curveSize, curveSize, 0, 90);
            path.AddArc(rect.X, rect.Bottom - curveSize, curveSize, curveSize, 90, 90);
            path.CloseFigure();
            return path;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // Gradient
            LinearGradientBrush brush = new LinearGradientBrush(this.ClientRectangle, this._gradientTopColor, this._gradientBottomColor, this._gradientAngle);
            Graphics graphics = e.Graphics;
            graphics.FillRectangle(brush, this.ClientRectangle);

            // BorderRadius
            RectangleF rectF = new RectangleF(0, 0, this.Width, this.Height);
            if (_borderRadius > 2)
            {
                using (GraphicsPath path = GetFigurePath(rectF, _borderRadius))
                {
                    this.Region = new Region(path);
                }
            }
            else
            {
                this.Region = new Region(rectF);
            }
        }
    }
}
