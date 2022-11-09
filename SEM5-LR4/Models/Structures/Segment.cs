using System.Drawing;

namespace SEM5_LR4.Models.Structures
{
    public struct Segment
    {
        public Point PointA { get; set; }
        public Point PointB { get; set; }

        public Segment(Point pointA, Point pointB)
        {
            PointA = pointA;
            PointB = pointB;
        }
    }
}
