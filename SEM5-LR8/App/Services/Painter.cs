using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SEM5_LR8.App.Helpers;

namespace SEM5_LR8.App.Services
{
    public class Painter
    {
        private Bitmap _bitmap;
        private Graphics _graphics;

        public Bitmap Context 
        {
            get => _bitmap;
            set
            {
                _bitmap = value;
                _graphics = Graphics.FromImage(value);
            }
        }
        public Pen Pen { get; set; }

        public void Clear()
        {
            _graphics.Clear(Color.White); // hardcode
        }

        public void DrawPixel(int x, int y)
        {
            _graphics.FillRectangle(Pen.Brush, x, y, 1, 1);
        }

        public void DrawPoint(Point point)
        {
            var rect = new Rectangle(point, new Size(2, 2));

            _graphics.DrawEllipse(Pen, rect);
            _graphics.FillEllipse(Pen.Brush, rect);
        }
        public void DrawPoint(PointF point)
        {
            var rect = new RectangleF(point, new Size(2, 2));

            _graphics.DrawEllipse(Pen, rect);
            _graphics.FillEllipse(Pen.Brush, rect);
        }

        public void DrawLine(Point first, Point second)
        {
            _graphics.DrawLine(Pen, first, second);
        }
        public void DrawLine(PointF first, PointF second)
        {
            _graphics.DrawLine(Pen, first, second);
        }

        public void DrawLineBresenham(Point first, Point second)
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

        public void DrawPolygon(List<Point> points)
        {
            if (points.Count <= 1)
                return;

            var lastPointIndex = points.Count - 1;

            for (int i = 0; i < lastPointIndex; i++)
            {
                DrawLine(points[i], points[i + 1]);
            }

            DrawLine(points[0], points[lastPointIndex]);
        }
        public void DrawPolygon(List<PointF> points)
        {
            if (points.Count <= 1)
                return;

            var lastPointIndex = points.Count - 1;

            for (int i = 0; i < lastPointIndex; i++)
            {
                DrawLine(points[i], points[i + 1]);
            }

            DrawLine(points[0], points[lastPointIndex]);
        }
    }
}
