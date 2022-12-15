using System;
using System.Drawing;
using System.Windows.Forms;

using Graphics.Services;
using SEM5_LR6.App.Interfaces;

namespace SEM5_LR6.App.Components.Tools
{
    public class PolylineTool : ITool
    {
        private Point _lastPoint;

        public Painter Painter { get; set; }

        public PolylineTool()
        {
            _lastPoint = Point.Empty;
        }
         
        public void OnClear()
        {
            _lastPoint = Point.Empty;
        }

        public void OnSwitch()
        {
            _lastPoint = Point.Empty;
        }

        public void OnMouseUp(MouseEventArgs e)
        {
            var point = e.Location;

            Painter.DrawPoint(point);

            if(!_lastPoint.IsEmpty)
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
    }
}
