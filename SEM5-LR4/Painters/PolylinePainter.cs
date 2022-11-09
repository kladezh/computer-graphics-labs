using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

using SEM5_LR4.Models.Structures;

namespace SEM5_LR4.Painters
{
    public class PolylinePainter : LinePainter
    {
        public List<Segment> GetPolylineSegments()
        {
            var segments = new List<Segment>();

            for (int i = 0; i < Points.Count - 1; i++)
            {
                segments.Add(new Segment(Points[i], Points[i + 1]));
            }

            return segments;
        }

        public void DrawPolylineBySegments(List<Segment> segments)
        {
            if (!segments.Any())
                return;

            DrawPoint(segments.First().PointA);

            foreach (var segment in segments)
            {
                DrawPoint(segment.PointB);
                DrawLine(segment.PointA, segment.PointB);
            }
        }

        public void DrawPolyline()
        {
            if (Points.Count <= 1)
                return;

            for (int i = 0; i < Points.Count - 1; i++)
            {
                DrawLine(Points[i], Points[i + 1]);
            }
        }
    }
}
