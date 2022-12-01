using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SEM5_LR6.Tools.Painters
{
    public class FillTool : PainterTool
    {
        public override void OnClear()
        {
            return;
        }

        public override void OnSwitch()
        {
            return;
        }

        public override void OnMouseDown(MouseEventArgs e)
        {
            return;
        }

        public override void OnMouseMove(MouseEventArgs e)
        {
            return;
        }

        public override void OnMouseUp(MouseEventArgs e)
        {
            var point = e.Location;

            var pickColor = PickColor(point);

            var fillColor = Pen.Color;

            // fill algorithm...
        }

        private Color PickColor(Point point)
        {
            var b = (Bitmap)Context.Image;

            int x = point.X * b.Width / Context.ClientSize.Width;
            int y = point.Y * b.Height / Context.ClientSize.Height;

            return b.GetPixel(x, y);
        }
    }
}
