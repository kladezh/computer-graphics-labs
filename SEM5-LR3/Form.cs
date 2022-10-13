﻿using System;
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
        private Painter _painter;

        public Form()
        {
            InitializeComponent();

            _painter = new CurvePainter
            {
                PaintContext = pictureBox,
                Pen = new Pen(Color.Black, 2f)
            };
        }

        private void buttonClear_Click(object sender, EventArgs e) => _painter.Clear();

        private void pictureBox_MouseDown(object sender, MouseEventArgs e) => _painter.OnMouseDown(e);
        private void pictureBox_MouseMove(object sender, MouseEventArgs e) => _painter.OnMouseMove(e);
        private void pictureBox_MouseUp(object sender, MouseEventArgs e) => _painter.OnMouseUp(e);

        private void radioButtonRectangle_CheckedChanged(object sender, EventArgs e)
        {
            _painter = new RectanglePainter
            {
                PaintContext = pictureBox,
                Pen = new Pen(Color.Black, 2f)
            };
        }

        private void radioButtonCurve_CheckedChanged(object sender, EventArgs e)
        {
            _painter = new CurvePainter
            {
                PaintContext = pictureBox,
                Pen = new Pen(Color.Black, 2f)
            };
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
            Graphics.FillRectangle(Pen.Brush, x, y, 1, 1);
        }

        abstract public void OnMouseDown(MouseEventArgs e);
        abstract public void OnMouseMove(MouseEventArgs e);
        abstract public void OnMouseUp(MouseEventArgs e);
    }

    public class RectanglePainter : Painter
    {
        private Rectangle _rectangle;
        private bool _isMouseDown = false;

        public RectanglePainter()
        {
        }

        private void DrawRectangle()
        {
            Graphics.DrawRectangle(Pen, _rectangle);
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

        private void ConsumeRectangle()
        {
            _rectangle = Rectangle.Empty;
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
                DrawRectangle();
            }
        }

        public override void OnMouseUp(MouseEventArgs e)
        {
            if (_isMouseDown)
            {
                ConsumeRectangle();

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

            DrawLine(Points[Points.Count() - 1], Points[Points.Count() - 2]);
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