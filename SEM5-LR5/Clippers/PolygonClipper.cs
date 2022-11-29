using System;
using System.Collections.Generic;
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
            var clipped = new List<Point>(polygon);

            // Sutherland-Hodgman algorithm...

            return clipped;
        }
    }
}
