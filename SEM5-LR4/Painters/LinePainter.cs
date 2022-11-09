using System;
using System.Drawing;

using SEM5_LR4.Classes;

namespace SEM5_LR4.Painters
{
    public class LinePainter : PointPainter
    {
        public void DrawLine(Point first, Point second)
        {
            Graphics.DrawLine(Pen, first, second);
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
    }
}
