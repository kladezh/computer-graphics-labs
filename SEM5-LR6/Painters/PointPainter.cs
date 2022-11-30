using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace SEM5_LR6.Painters
{
    public class PointPainter : Painter
    {
        public List<Point> Points { get; set; }

        public PointPainter() : base()
        {
            Points = new List<Point>();
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
    }
}
