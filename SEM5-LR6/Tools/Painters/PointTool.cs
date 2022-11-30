using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace SEM5_LR6.Tools.Painters
{
    public class PointTool : PainterTool
    {
        public List<Point> Points { get; set; }

        public PointTool() : base()
        {
            Points = new List<Point>();
        }
        public override void OnClearClick(EventArgs e)
        {
            return;
        }

        public override void OnDrawClick(EventArgs e)
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
            BuildPoint(e.Location);
        }

        public void Clear()
        {
            Points.Clear();
        }

        public void DrawPoint(Point point)
        {
            Rectangle rect = new Rectangle(point, new Size(5, 5));

            Context.DrawEllipse(Pen, rect);
            Context.FillEllipse(Pen.Brush, rect);
        } 

        private void BuildPoint(Point point)
        {
            Points.Add(point);

            DrawPoint(point);
        }
    }
}
