using System.Drawing;
using System.Windows.Forms;

namespace SEM5_LR4.Painters
{
    public abstract class Painter
    {
        protected Graphics Graphics { get; set; }

        protected Control _paintContext;
        public Control PaintContext
        {
            get => _paintContext;
            set
            {
                _paintContext = value;
                Graphics = value.CreateGraphics();
            }
        }

        public Pen Pen { get; set; }

        public virtual void Clear()
        {
            Graphics.Clear(PaintContext.BackColor);
        }

        public void DrawPixel(int x, int y)
        {
            Graphics.FillRectangle(Pen.Brush, x, y, 3, 3);
        }

        abstract public void OnMouseDown(MouseEventArgs e);
        abstract public void OnMouseMove(MouseEventArgs e);
        abstract public void OnMouseUp(MouseEventArgs e);
    }
}
