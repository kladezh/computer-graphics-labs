using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

using SEM5_LR6.App.Services;

namespace SEM5_LR6.App.Components.Tools
{
    public class FillTool : ITool
    {
        public Painter Painter { get; set; }

        public void OnClear()
        {
            return;
        }

        public void OnSwitch()
        {
            return;
        }

        public void OnMouseDown(MouseEventArgs e)
        {
            return;
        }

        public void OnMouseMove(MouseEventArgs e)
        {
            return;
        }

        public void OnMouseUp(MouseEventArgs e)
        {
            var point = e.Location;

            var pickColor = Painter.Context.GetPixel(point.X, point.Y);

            FillPixel(point.X, point.Y, pickColor);
        }

        private void FillPixel(int x, int y, Color pick)
        {
            var context = Painter.Context;

            if (x >= context.Width - 1 || y >= context.Height - 1 || x < 1 ||  y < 1)
                return;

            Painter.DrawPixel(x, y);

            if (context.GetPixel(x + 1, y).ToArgb() == pick.ToArgb()) FillPixel(x + 1, y, pick);
            if (context.GetPixel(x - 1, y).ToArgb() == pick.ToArgb()) FillPixel(x - 1, y, pick);
            if (context.GetPixel(x, y + 1).ToArgb() == pick.ToArgb()) FillPixel(x, y + 1, pick);
            if (context.GetPixel(x, y - 1).ToArgb() == pick.ToArgb()) FillPixel(x, y - 1, pick);
        }
    }
}
