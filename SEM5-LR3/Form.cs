using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SEM5_LR3
{
    public partial class Form : System.Windows.Forms.Form
    {
        private CurvePainter _curvePainter;
        private RectanglePainter _rectanglePainter;

        private Painter _activePainter;

        public Form()
        {
            InitializeComponent();

            _curvePainter = new CurvePainter
            {
                PaintContext = pictureBox,
                Pen = new Pen(Color.Black, 2f)
            };

            _rectanglePainter = new RectanglePainter
            {
                PaintContext = pictureBox,
                Pen = new Pen(Color.Black, 2f)
            };

            _activePainter = _curvePainter;
        }

        private List<Segment> ClipCurveWithRectangle(List<Segment> segments, Rectangle rect)
        {
            for (int i = 0; i < segments.Count; )
            {
                var segment = segments[i];

                if(TryClipSegmentWithRectangle(ref segment, rect))
                {
                    segments[i] = segment;
                    i++;
                }
                else
                {
                    segments.RemoveAt(i);
                }
            }

            return segments;
        }

        private bool TryClipSegmentWithRectangle(ref Segment segment, Rectangle rect)
        {
            const int Left = 1;   // 0001
            const int Right = 2;  // 0010
            const int Bottom = 4; // 0100
            const int Top = 8;    // 1000

            // коды концов отрезка
            int code_a = DefinePointCode(segment.PointA, rect);
            int code_b = DefinePointCode(segment.PointB, rect);

            // пока одна из точек вне прямоугольника
            while (Convert.ToBoolean(code_a | code_b))
            {
                // если обе точки с одной стороны прямоугольника, то отрезок не пересекает прямоугольник
                if (Convert.ToBoolean(code_a & code_b))
                    return false;

                Point point; int code;

                // выбирем точку c с ненулевым кодом
                if (Convert.ToBoolean(code_a))
                {
                    code = code_a;
                    point = segment.PointA;
                }
                else
                {
                    code = code_b;
                    point = segment.PointB;
                }

                // если point левее rect, то передвигаем point на прямую x_min
                if (Convert.ToBoolean(code & Left))
                {
                    point.Y += (segment.PointA.Y - segment.PointB.Y) * (rect.Left - point.X)
                        / (segment.PointA.X - segment.PointB.X);

                    point.X = rect.Left;
                }
                // если point правее rect, то передвигаем point на прямую x_max
                else if (Convert.ToBoolean(code & Right))
                {
                    point.Y += (segment.PointA.Y - segment.PointB.Y) * (rect.Right - point.X)
                        / (segment.PointA.X - segment.PointB.X);

                    point.X = rect.Right;
                }
                // если point ниже rect, то передвигаем point на прямую y_min
                else if (Convert.ToBoolean(code & Bottom))
                {
                    point.X += (segment.PointA.X - segment.PointB.X) * (rect.Top - point.Y)
                        / (segment.PointA.Y - segment.PointB.Y);

                    point.Y = rect.Top;
                }
                // если point выше rect, то передвигаем point на прямую y_max
                else if (Convert.ToBoolean(code & Top))
                {
                    point.X += (segment.PointA.X - segment.PointB.X) * (rect.Bottom - point.Y)
                        / (segment.PointA.Y - segment.PointB.Y);

                    point.Y = rect.Bottom;
                }

                // обновляем код и значения точки
                if (code == code_a)
                {
                    segment.PointA = point;
                    code_a = DefinePointCode(segment.PointA, rect);
                }
                else
                {
                    segment.PointB = point;
                    code_b = DefinePointCode(segment.PointB, rect);
                }
            }

            return true;
        }

        private int DefinePointCode(Point p, Rectangle rect)
        {
            if (p.X < rect.Left)   return 1;
            if (p.X > rect.Right)  return 2;
            if (p.Y < rect.Top)    return 4;
            if (p.Y > rect.Bottom) return 8;

            return 0;
        }

        private void buttonClear_Click(object sender, EventArgs e) => _activePainter.Clear();

        private void pictureBox_MouseDown(object sender, MouseEventArgs e) => _activePainter.OnMouseDown(e);
        private void pictureBox_MouseMove(object sender, MouseEventArgs e) => _activePainter.OnMouseMove(e);
        private void pictureBox_MouseUp(object sender, MouseEventArgs e) => _activePainter.OnMouseUp(e);

        private void radioButtonRectangle_CheckedChanged(object sender, EventArgs e)
        {
            _activePainter = _rectanglePainter;
        }
        private void radioButtonCurve_CheckedChanged(object sender, EventArgs e)
        {
            _activePainter = _curvePainter;
        }

        private void buttonClip_Click(object sender, EventArgs e)
        {
            var rect = _rectanglePainter.Rectangle;

            var clippedCurve = ClipCurveWithRectangle(_curvePainter.GetCurveSegments(), rect);

            _rectanglePainter.Clear();
            _curvePainter.Clear();

            _rectanglePainter.DrawRectangle(rect);
            _curvePainter.DrawCurveBySegments(clippedCurve);
        }
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

    public class RectanglePainter : Painter
    {
        private Rectangle _rectangle;
        private bool _isMouseDown = false;

        public Rectangle Rectangle
        {
            get => _rectangle;
        }

        public RectanglePainter()
        {
        }

        public void DrawRectangle(Rectangle rect)
        {
            Graphics.DrawRectangle(Pen, rect);
        }

        private void CreateRectangle(Point location)
        {
            _rectangle = new Rectangle(location, new Size());
        }

        private void ScaleRectangle(Point location)
        {
            _rectangle.X = Math.Min(_rectangle.X, location.X);
            _rectangle.Y = Math.Min(_rectangle.Y, location.Y);

            _rectangle.Width = Math.Abs(_rectangle.X - location.X);
            _rectangle.Height = Math.Abs(_rectangle.Y - location.Y);
        }

        public override void OnMouseDown(MouseEventArgs e)
        {
            CreateRectangle(e.Location);

            _isMouseDown = true;
        }

        public override void OnMouseMove(MouseEventArgs e)
        {
            if (_isMouseDown)
            {
                ScaleRectangle(e.Location);

                Clear();
                DrawRectangle(_rectangle);
            }
        }

        public override void OnMouseUp(MouseEventArgs e)
        {
            if (_isMouseDown)
            {
                _isMouseDown = false;
            }
        }
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
