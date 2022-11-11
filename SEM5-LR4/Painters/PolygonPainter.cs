using System;
using System.Linq;
using System.Collections.Generic;
using System.Drawing;

using SEM5_LR4.Models.Structures;

namespace SEM5_LR4.Painters
{
    public class PolygonPainter : LinePainter
    {
        public void DrawPolygon()
        {
            if (Points.Count <= 1)
                return;

            var lastPointIndex = Points.Count - 1;

            for (int i = 0; i < lastPointIndex; i++)
            {
                DrawLine(Points[i], Points[i + 1]);
            }

            DrawLine(Points[0], Points[lastPointIndex]);
        }

        public void DrawPolygonWithPoints()
        {
            if (Points.Count <= 1)
                return;

            foreach(var point in Points)
                DrawPoint(point);

            DrawPolygon();
        }

        public List<Segment> ClipSegments(List<Segment> segments)
        {
            var clipped = new List<Segment>(segments);

            for (int i = 0; i < clipped.Count;)
            {
                var segment = clipped[i];

                if (TryClipSegment(ref segment))
                {
                    clipped[i] = segment;
                    i++;
                }
                else
                {
                    clipped.RemoveAt(i);
                }
            }

            return clipped;
        }

        private bool TryClipSegment(ref Segment segment)
        {
            return CyrusBeck(ref segment, Points);
        }

        private bool CyrusBeck(ref Segment segment, List<Point> points)
        {
            int n = points.Count; // count of vertices

            var normals = new Point[n];
            for (int i = 0; i < n; i++)
            {
                var normal = normals[i];

                normal.Y = points[(i + 1) % n].X - points[i].X;
                normal.X = points[i].Y - points[(i + 1) % n].Y;

                normals[i] = normal;
            }

            var pB_pA = new Point(segment.PointB.X - segment.PointA.X,
                                  segment.PointB.Y - segment.PointA.Y
            );

            var pA_pEi = new Point[n];
            for (int i = 0; i < n; i++)
            {
                var item = pA_pEi[i];

                item.X = points[i].X - segment.PointA.X;
                item.Y = points[i].Y - segment.PointA.Y;

                pA_pEi[i] = item;
            }

            var numerator = new int[n];
            var denominator = new int[n];

            for (int i = 0; i < n; i++)
            {
                numerator[i] = Dot(normals[i], pA_pEi[i]);
                denominator[i] = Dot(normals[i], pB_pA);
            }

            var t = new double[n];

            var tE = new List<double>(); // t entering
            var tL = new List<double>(); // t leaving

            for (int i = 0; i < n; i++)
            {
                t[i] = Convert.ToDouble(numerator[i]) / Convert.ToDouble(denominator[i]);

                if (denominator[i] > 0)
                    tE.Add(t[i]);
                else
                    tL.Add(t[i]);
            }

            var temp = new double[2];

            tE.Add(0.0);
            temp[0] = tE.Max();

            tL.Add(1.0);
            temp[1] = tL.Min();

            // case when segment is completely outside
            if (temp[0] > temp[1])
            {
                return false;
            }

            var newPA = segment.PointA;
            var newPB = segment.PointB;

            newPA.X = (int)(Convert.ToDouble(segment.PointA.X) + Convert.ToDouble(pB_pA.X) * temp[0]);
            newPA.Y = (int)(Convert.ToDouble(segment.PointA.Y) + Convert.ToDouble(pB_pA.Y) * temp[0]);

            newPB.X = (int)(Convert.ToDouble(segment.PointA.X) + Convert.ToDouble(pB_pA.X) * temp[1]);
            newPB.Y = (int)(Convert.ToDouble(segment.PointA.Y) + Convert.ToDouble(pB_pA.Y) * temp[1]);

            segment.PointA = newPA;
            segment.PointB = newPB;

            return true;
        }

        private int Dot(Point a, Point b)
        {
            return a.X * b.X + a.Y * b.Y;
        }
    }
}
