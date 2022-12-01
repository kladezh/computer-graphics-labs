using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace SEM5_LR6.Tools.Painters
{
    public class PointTool : PainterTool
    {
        public PointTool() : base()
        {
        }

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
            DrawPoint(e.Location);
        }

        public void DrawPoint(Point point)
        {
            Rectangle rect = new Rectangle(point, new Size(5, 5));

            Context.DrawEllipse(Pen, rect);
            Context.FillEllipse(Pen.Brush, rect);
        } 
    }
}
