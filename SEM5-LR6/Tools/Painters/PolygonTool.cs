using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace SEM5_LR6.Tools.Painters
{
    public class PolygonTool : LineTool
    {
        private readonly int CaptureValue = 10;

        private Point _firstPoint;

        public PolygonTool() : base()
        {
            _firstPoint = Point.Empty;
        }

        public void DrawPolygonWithPoints(List<Point> points)
        {
            if (points.Count <= 1)
                return;

            foreach (var point in points)
                DrawPoint(point);

            var lastPointIndex = points.Count - 1;

            for (int i = 0; i < lastPointIndex; i++)
            {
                DrawLine(points[i], points[i + 1]);
            }

            DrawLine(points[0], points[lastPointIndex]);
        }

        public void FillPolygonWithPoints(List<Point> points)
        {
            _graphics.FillPolygon(Pen.Brush, points.ToArray());
        }

        public override void OnClear()
        {
            base.OnClear();

            _firstPoint = Point.Empty;
        }

        public override void OnSwitch()
        {
            if(!IsPolygonCompleted())
                CompletePolygon();
        }

        public override void OnMouseUp(MouseEventArgs e)
        {
            var point = e.Location;

            if (new Rectangle(point.X - CaptureValue, point.Y - CaptureValue, 
                CaptureValue * 2, CaptureValue * 2)
                .Contains(_firstPoint))
            {
                CompletePolygon();
                return;
            }

            if (_firstPoint.IsEmpty)
                _firstPoint = point;

            base.OnMouseUp(e);
        }
        
        private void CompletePolygon()
        {
            DrawLine(_firstPoint, _lastPoint);

            _firstPoint = Point.Empty;
            _lastPoint = Point.Empty;
        }

        private bool IsPolygonCompleted()
        {
            return _firstPoint.IsEmpty && _lastPoint.IsEmpty;
        }
    }
}
