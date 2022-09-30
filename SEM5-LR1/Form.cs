using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SEM5_LR1
{
    public partial class Form : System.Windows.Forms.Form
    {
        private CurvePainter painter;

        public Form()
        {
            InitializeComponent();

            painter = new CurvePainter
            {
                PaintContext = pictureBox,
                Pen = new Pen(Color.Black, 2f)
            };
        }
       

        private void buttonClear_Click(object sender, EventArgs e)
        {
            painter.Clear();
        }

        private void pictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            painter.AddPoint(e.Location);
        }
    }

    public class CurvePainter
    {
        private Graphics Graphics { get; set; }
        private List<Point> Points { get; set; }

        private Control _paintContext;
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

        public CurvePainter()
        {
            Points = new List<Point>();
        }

        public void Clear()
        {
            Points.Clear();

            Graphics.Clear(PaintContext.BackColor);
        }

        public void DrawPoint(Point point)
        {
            Rectangle rect = new Rectangle(point, new Size(5, 5));

            Graphics.DrawEllipse(Pen, rect);
            Graphics.FillEllipse(Pen.Brush, rect);
        }

        public void DrawLine(Point first, Point second)
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
            if(isSteep)
            {
                Swapper.Swap(ref x1, ref y1);
                Swapper.Swap(ref x2, ref y2);
            }

            // меняем местами точки, если отрезок растёт справа налево
            if(x1 > x2)
            {
                Swapper.Swap(ref x1, ref x2);
                Swapper.Swap(ref y1, ref y2);
            }

            int dx = x2 - x1;
            int dy = Math.Abs(y2 - y1);

            int error = dx / 2;

            // выбор направления роста оси OY
            int ystep = (y1 < y2) ? 1 : -1;

            int y = y1;
            for (int x = x1; x <= x2; x++)
            {
                Graphics.FillRectangle(
                    Pen.Brush, 
                    x: isSteep ? y : x, 
                    y: isSteep ? x : y, 
                    width: 1, 
                    height: 1);

                error -= dy;
                if(error < 0)
                {
                    y += ystep;
                    error += dx;
                }
            }
        }

        public void AddPoint(Point point)
        {
            Points.Add(point);

            DrawPoint(point);

            if (Points.Count() <= 1)
                return;

            DrawLine(Points[Points.Count() - 1], Points[Points.Count() - 2]);
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
