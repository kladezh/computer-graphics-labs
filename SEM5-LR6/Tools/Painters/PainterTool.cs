using System;
using System.Drawing;
using System.Windows.Forms;

namespace SEM5_LR6.Tools.Painters
{
    public abstract class PainterTool : ITool
    {
        public Graphics Context { get; set; }

        public Pen Pen { get; set; }

        public void DrawPixel(int x, int y)
        {
            Context.FillRectangle(Pen.Brush, x, y, 3, 3);
        }

        public abstract void OnClearClick(EventArgs e);
        public abstract void OnDrawClick(EventArgs e);
        public abstract void OnMouseDown(MouseEventArgs e);
        public abstract void OnMouseMove(MouseEventArgs e);
        public abstract void OnMouseUp(MouseEventArgs e);
    }
}
