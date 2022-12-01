using System;
using System.Drawing;
using System.Windows.Forms;

namespace SEM5_LR6.Tools.Painters
{
    public abstract class PainterTool : ITool
    {
        protected Graphics _graphics;

        private PictureBox _context;
        public PictureBox Context
        {
            get => _context;
            set
            {
                _context = value;
                _graphics = value.CreateGraphics();
            }
        }

        public Pen Pen { get; set; }

        public void DrawPixel(int x, int y)
        {
            _graphics.FillRectangle(Pen.Brush, x, y, 3, 3);
        }

        public abstract void OnClear();
        public abstract void OnSwitch();

        public abstract void OnMouseDown(MouseEventArgs e);
        public abstract void OnMouseMove(MouseEventArgs e);
        public abstract void OnMouseUp(MouseEventArgs e);
    }
}
