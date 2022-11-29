using System.Drawing;
using System.Windows.Forms;

namespace SEM5_LR5.Painters
{
    public abstract class Painter
    {
        public Graphics Context { get; set; }

        public Pen Pen { get; set; }

        public void DrawPixel(int x, int y)
        {
            Context.FillRectangle(Pen.Brush, x, y, 3, 3);
        }

        abstract public void OnMouseDown(MouseEventArgs e);
        abstract public void OnMouseMove(MouseEventArgs e);
        abstract public void OnMouseUp(MouseEventArgs e);
    }
}
