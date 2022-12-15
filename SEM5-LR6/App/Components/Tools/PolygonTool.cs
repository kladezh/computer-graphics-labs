using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

using Graphics.Services;
using SEM5_LR6.App.Interfaces;

namespace SEM5_LR6.App.Components.Tools
{
    public class PolygonTool : ITool
    {
        private readonly int CaptureValue = 10;

        private Point _firstPoint;
        private Point _lastPoint;

        public Painter Painter { get; set; }

        public PolygonTool()
        {
            EmptyPoints();
        }

        public void OnClear()
        {
            EmptyPoints();
        }

        public void OnSwitch()
        {
            if(!IsPolygonCompleted())
                CompletePolygon();
        }

        public void OnMouseUp(MouseEventArgs e)
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

            Painter.DrawPoint(point);

            if (!_lastPoint.IsEmpty)
                Painter.DrawLine(_lastPoint, point);

            _lastPoint = point;
        }
        
        public void OnMouseDown(MouseEventArgs e)
        {
            return;
        }

        public void OnMouseMove(MouseEventArgs e)
        {
            return;
        }
        private void CompletePolygon()
        {
            Painter.DrawLine(_firstPoint, _lastPoint);

            EmptyPoints();
        }

        private bool IsPolygonCompleted()
        {
            return _firstPoint.IsEmpty && _lastPoint.IsEmpty;
        }

        private void EmptyPoints()
        {
            _firstPoint = Point.Empty;
            _lastPoint = Point.Empty;
        }
    }
}
