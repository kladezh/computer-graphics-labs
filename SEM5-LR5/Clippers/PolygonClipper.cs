using SEM5_LR5.Helpers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;

namespace SEM5_LR5.Clippers
{
    public class PolygonClipper
    {
        public List<Point> Source { get; set; }

        public List<Point> ClipPolyline(List<Point> polyline)
        {
            var clipped = new List<Point>(polyline);

            for (int i = 0; i < clipped.Count - 1;)
            {
                var pointA = clipped[i];
                var pointB = clipped[i + 1];

                if (TryClipPolylineSegment(ref pointA, ref pointB))
                {
                    clipped[i] = pointA;
                    clipped[i + 1] = pointB;

                    i++;
                }
                else
                {
                    clipped.RemoveAt(i);
                }
            }

            if (clipped.Count <= 1)
                return null;

            return clipped;
        }

        private bool TryClipPolylineSegment(ref Point pointA, ref Point pointB)
        {
            /*
             * Using Cyrus-Beck algortihm 
             */

            int n = Source.Count; // count of vertices

            var normals = new Point[n];
            for (int i = 0; i < n; i++)
            {
                var normal = normals[i];

                normal.Y = Source[(i + 1) % n].X - Source[i].X;
                normal.X = Source[i].Y - Source[(i + 1) % n].Y;

                normals[i] = normal;
            }

            var pB_pA = new Point(pointB.X - pointA.X,
                                  pointB.Y - pointA.Y
            );

            var pA_pEi = new Point[n];
            for (int i = 0; i < n; i++)
            {
                var item = pA_pEi[i];

                item.X = Source[i].X - pointA.X;
                item.Y = Source[i].Y - pointB.Y;

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

            pointA.X = (int)(Convert.ToDouble(pointA.X) + Convert.ToDouble(pB_pA.X) * temp[0]);
            pointA.Y = (int)(Convert.ToDouble(pointA.Y) + Convert.ToDouble(pB_pA.Y) * temp[0]);

            pointB.X = (int)(Convert.ToDouble(pointA.X) + Convert.ToDouble(pB_pA.X) * temp[1]);
            pointB.Y = (int)(Convert.ToDouble(pointA.Y) + Convert.ToDouble(pB_pA.Y) * temp[1]);

            return true;
        }

        private int Dot(Point a, Point b)
        {
            return a.X * b.X + a.Y * b.Y;
        }

        public List<Point> ClipPolygon(List<Point> polygon)
        {
            // Sutherland–Hodgman algorithm

            var clipped = new List<Point>(polygon);

            for (int i = 0; i < Source.Count; i++)
            {
                int k = (i + 1) % Source.Count;

                ClipPolygonWithEdge(ref clipped, Source[i], Source[k]);
            }

            return clipped;
        }

        private void ClipPolygonWithEdge(ref List<Point> polygon, Point pointA, Point pointB)
        {
            var clipped = new List<Point>();

            for (int i = 0; i < polygon.Count; i++)
            {
                int k = (i + 1) % polygon.Count;

                int ix = polygon[i].X, iy = polygon[i].Y;
                int kx = polygon[k].X, ky = polygon[k].Y;

                int iPos = (pointB.X - pointA.X) * (iy - pointA.Y) - (pointB.Y - pointA.Y) * (ix - pointA.X);
                int kPos = (pointB.X - pointA.X) * (ky - pointA.Y) - (pointB.Y - pointA.Y) * (kx - pointA.X);

                // Case 1 : When both points are inside
                if (iPos < 0 && kPos < 0)
                {
                    // Only second point is added
                    clipped.Add(new Point(kx, ky));
                }

                // Case 2: When only first point is outside
                else if (iPos >= 0 && kPos < 0)
                {
                    // Point of intersection with edge
                    clipped.Add(CalcIntersectPoint(pointA, pointB, polygon[i], polygon[k]));

                    // and the second point is added
                    clipped.Add(new Point(kx, ky));
                }

                // Case 3: When only second point is outside
                else if (iPos < 0 && kPos >= 0)
                {
                    // Only point of intersection with edge is added
                    clipped.Add(CalcIntersectPoint(pointA, pointB, polygon[i], polygon[k]));
                }

                // Case 4: When both points are outside
                else
                {
                    // No points are added
                }
            }

            // Copying new points into original array
            // and changing the no. of vertices
            polygon = clipped;      
        }

        private Point CalcIntersectPoint(Point firstA, Point firstB, Point secondA, Point secondB)
        {
            int num, den;

            var point = new Point();

            num = (firstA.X * firstB.Y - firstA.Y * firstB.X) * (secondA.X - secondB.X) -
                (firstA.X - firstB.X) * (secondA.X * secondB.Y - secondA.Y * secondB.X);

            den = (firstA.X - firstB.X) * (secondA.Y - secondB.Y) - 
                (firstA.Y - firstB.Y) * (secondA.X - secondB.X);

            point.X = num / den;

            num = (firstA.X * firstB.Y - firstA.Y * firstB.X) * (secondA.Y - secondB.Y) -
                (firstA.Y - firstB.Y) * (secondA.X * secondB.Y - secondA.Y * secondB.X);

            point.Y = num / den;

            return point;
        }
    }
}
