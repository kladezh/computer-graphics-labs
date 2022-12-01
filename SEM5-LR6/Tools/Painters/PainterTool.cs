using System;
using System.Drawing;
using System.Windows.Forms;

namespace SEM5_LR6.Tools.Painters
{
    public abstract class PainterTool : ITool
    {
        protected Graphics _graphics;

        private Bitmap _context;
        public Bitmap Context
        {
            get => _context;
            set
            {
                _context = value;
                _graphics = Graphics.FromImage(value);
            }
        }

        public Pen Pen { get; set; }

        public void DrawPixel(int x, int y)
        {
            _graphics.FillRectangle(Pen.Brush, x, y, 1, 1);
        }

        public abstract void OnClear();
        public abstract void OnSwitch();

        public abstract void OnMouseDown(MouseEventArgs e);
        public abstract void OnMouseMove(MouseEventArgs e);
        public abstract void OnMouseUp(MouseEventArgs e);
    }
}
