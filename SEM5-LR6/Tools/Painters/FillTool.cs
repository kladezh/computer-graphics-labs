using System;
using System.Collections.Generic;
using System.Diagnostics;
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

            var pickColor = Context.GetPixel(point.X, point.Y);

            FillPixel(point.X, point.Y, pickColor);
        }

        private void FillPixel(int x, int y, Color pick)
        {
            if (x >= Context.Width - 1 || y >= Context.Height - 1 || x < 1 ||  y < 1)
                return;

            DrawPixel(x, y);

            if (Context.GetPixel(x + 1, y).ToArgb() == pick.ToArgb()) FillPixel(x + 1, y, pick);
            if (Context.GetPixel(x - 1, y).ToArgb() == pick.ToArgb()) FillPixel(x - 1, y, pick);
            if (Context.GetPixel(x, y + 1).ToArgb() == pick.ToArgb()) FillPixel(x, y + 1, pick);
            if (Context.GetPixel(x, y - 1).ToArgb() == pick.ToArgb()) FillPixel(x, y - 1, pick);
        }
    }
}
