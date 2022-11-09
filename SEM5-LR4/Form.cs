using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SEM5_LR4
{
    public partial class Form : System.Windows.Forms.Form
    {
        private CurvePainter _curvePainter;
        private PolygonPainter _polygonPainter;

        private Painter _activePainter;

        public Form()
        {
            InitializeComponent();

            _curvePainter = new CurvePainter
            {
                PaintContext = pictureBox,
                Pen = new Pen(Color.BlueViolet, 2f)
            };

            _polygonPainter = new PolygonPainter
            {
                PaintContext = pictureBox,
                Pen = new Pen(Color.Black, 2f)
            };

            _activePainter = _curvePainter;
        }


        private void buttonClip_Click(object sender, EventArgs e)
        {
           
        }

        private void radioButtonCurve_CheckedChanged(object sender, EventArgs e)
        {
            _activePainter = _curvePainter;
        }

        private void radioButtonPolygon_CheckedChanged(object sender, EventArgs e)
        {
            _activePainter = _polygonPainter;
        }

        private void buttonDrawPolygon_Click(object sender, EventArgs e)
        {
            if(_activePainter is PolygonPainter p)
            {
                p.DrawPolygon();
            }
        }

        private void buttonClear_Click(object sender, EventArgs e) => _activePainter.Clear();

        private void pictureBox_MouseDown(object sender, MouseEventArgs e) => _activePainter.OnMouseDown(e);

        private void pictureBox_MouseMove(object sender, MouseEventArgs e) => _activePainter.OnMouseMove(e);

        private void pictureBox_MouseUp(object sender, MouseEventArgs e) => _activePainter.OnMouseUp(e);

    }

    public abstract class Painter
    {
        protected Graphics Graphics { get; set; }

        protected Control _paintContext;
        public Control PaintContext
        {
            get => _paintContext;
            set
            {
                _paintContext = value;
                Graphics = value.CreateGraphics();
            }
        }

        public Pen Pen { get; set; }

        public virtual void Clear()
        {
            Graphics.Clear(PaintContext.BackColor);
        }

        public void DrawPixel(int x, int y)
        {
            Graphics.FillRectangle(Pen.Brush, x, y, 3, 3);
        }

        abstract public void OnMouseDown(MouseEventArgs e);
        abstract public void OnMouseMove(MouseEventArgs e);
        abstract public void OnMouseUp(MouseEventArgs e);
    }

    public class CurvePainter : Painter
    {
        private List<Point> Points { get; set; }

        public CurvePainter()
        {
            Points = new List<Point>();
        }

        public override void Clear()
        {
            base.Clear();

            Points.Clear();
        }

        public List<Segment> GetCurveSegments()
        {
            var segments = new List<Segment>();

            for (int i = 0; i < Points.Count - 1; i++)
            {
                segments.Add(new Segment(Points[i], Points[i + 1]));
            }

            return segments;
        }

        public void DrawCurveBySegments(List<Segment> segments)
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

        private void DrawPoint(Point point)
        {
            Rectangle rect = new Rectangle(point, new Size(5, 5));

            Graphics.DrawEllipse(Pen, rect);
            Graphics.FillEllipse(Pen.Brush, rect);
        }

        private void DrawLine(Point first, Point second)
        {
            DrawLineBresenham(first, second);
        }
        private void DrawLineBresenham(Point first, Point second)
        {
            /* 
            * Алгоритм не работает для крутых отрезков
            * (т.е. угол наклона относительно OX больше 45 гр.)
            * и начальная точка считается та, которая левее
            * поэтому приходится точки "менять местами"
            */

            int x1 = first.X, y1 = first.Y;
            int x2 = second.X, y2 = second.Y;

            // проверка отрезка на крутость
            bool isSteep = Math.Abs(y2 - y1) > Math.Abs(x2 - x1);

            // отражаем по диагонали, если крутой
            if (isSteep)
            {
                Swapper.Swap(ref x1, ref y1);
                Swapper.Swap(ref x2, ref y2);
            }

            // меняем местами точки, если отрезок растёт справа налево
            if (x1 > x2)
            {
                Swapper.Swap(ref x1, ref x2);
                Swapper.Swap(ref y1, ref y2);
            }

            int dx = Math.Abs(x2 - x1);
            int dy = Math.Abs(y2 - y1);

            int error = dx / 2;

            // выбор направления роста оси OY
            int ystep = (y1 < y2) ? 1 : -1;

            int y = y1;
            for (int x = x1; x <= x2; x++)
            {
                DrawPixel(
                    x: isSteep ? y : x,
                    y: isSteep ? x : y
                );

                error -= dy;
                if (error < 0)
                {
                    y += ystep;
                    error += dx;
                }
            }
        }

        private void AddPoint(Point point)
        {
            Points.Add(point);

            DrawPoint(point);

            if (Points.Count() <= 1)
                return;

            DrawLine(point, Points[Points.Count() - 2]);
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
            AddPoint(e.Location);
        }
    }

    public class PolygonPainter : Painter
    {
        private List<Point> Points { get; set; }

        public PolygonPainter()
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
        
        public void DrawLine(Point first, Point second)
        {
            Graphics.DrawLine(Pen, first, second);
        }

        public void DrawPolygon()
        {
            var lastPointIndex = Points.Count - 1;

            for (int i = 0; i < lastPointIndex; i++)
            {
                DrawLine(Points[i], Points[i + 1]);
            }

            DrawLine(Points[0], Points[lastPointIndex]);
        }

        private void AddPoint(Point point)
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
            AddPoint(e.Location);
        }
    }

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

    public class Swapper
    {
        static public void Swap<T>(ref T lhs, ref T rhs)
        {
            T temp;
            temp = lhs;
            lhs = rhs;
            rhs = temp;
        }
    }
}
