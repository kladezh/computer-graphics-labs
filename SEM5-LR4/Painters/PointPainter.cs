using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace SEM5_LR4.Painters
{
    public class PointPainter : Painter
    {
        protected List<Point> Points { get; set; }

        public PointPainter() : base()
        {
            Points = new List<Point>();
        }

        public override void Clear()
        {
            base.Clear();

            Points.Clear();
        }

        public void DrawPoint(Point point)
        {
            Rectangle rect = new Rectangle(point, new Size(5, 5));

            Graphics.DrawEllipse(Pen, rect);
            Graphics.FillEllipse(Pen.Brush, rect);
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
