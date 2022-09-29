using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SEM5_LR2
{
    public partial class Form : System.Windows.Forms.Form
    {
        private EllipsePainter _painter;
        private bool _isMouseDown = false;

        public Form()
        {
            InitializeComponent();

            _painter = new EllipsePainter
            {
                PaintContext = pictureBox,
                Pen = new Pen(Color.Black, 2f)
            };
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            _painter.Clear();
        }

        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            _painter.CreateLayout(e.Location);

            _isMouseDown = true;
        }

        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (_isMouseDown)
            {
                _painter.ScaleLayout(e.Location);
            }
        }

        private void pictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            if(_isMouseDown)
            {
                _painter.ConsumeLayout();

                _isMouseDown = false;
            }
        }
    }
}

public class EllipsePainter
{
    private Rectangle _rectangleLayout;
    private Graphics Graphics { get; set; }

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

    public EllipsePainter()
    {
    }

    public void Clear()
    {
        Graphics.Clear(PaintContext.BackColor);
    }

    public void DrawPixel(int x, int y)
    {
        Graphics.FillRectangle(Pen.Brush, x, y, 1, 1);
    }
    public void DrawPixelQuadrant(int x0, int y0, int x, int y)
    {
        DrawPixel(x0 + x, y0 + y);
        DrawPixel(x0 + x, y0 - y);
        DrawPixel(x0 - x, y0 + y);
        DrawPixel(x0 - x, y0 - y);
    }

    public void DrawEllipse(Rectangle layout)
    {
        DrawEllipseBresenham(layout);
    }

    private void DrawEllipseBresenham(Rectangle rect)
    {
        int a = rect.Width / 2; // большая полуось
        int b = rect.Height / 2; // малая полуось
        int centerX = rect.X + a;
        int centerY = rect.Y + b;

        int x = 0;
        int y = b;
        int a_sqr = a * a;
        int b_sqr = b * b;

        int delta;

        delta = b_sqr - (a_sqr * b) + ( a_sqr / 4);
        while(2 * b_sqr * x < 2 * a_sqr * y)
        {
            x++;

            if(delta < 0)
            {
                delta += 2 * b_sqr * x + b_sqr;
            }
            else
            {
                y--;
                delta += 2 * b_sqr * x - 2 * a_sqr * y;
            }

            DrawPixelQuadrant(centerX, centerY, x, y);
        }

        delta = (int)(b_sqr * (x + .5) * (x + .5) + a_sqr * (y - 1) * (y - 1) - a_sqr * b_sqr);
        while (y > 0)
        {
            y--;

            if(delta > 0)
            {
                delta += a_sqr - 2* a_sqr * y;
            }
            else
            {
                x++;
                delta += a_sqr + 2 * b_sqr * x - 2 * a_sqr * y;
            }

            DrawPixelQuadrant(centerX, centerY, x, y);
        }

        DrawPixelQuadrant(centerX, centerY, x, y);
    }

    private void RedrawLayout()
    {
        Clear();
        Graphics.DrawRectangle(Pen, _rectangleLayout);
    }

    public void CreateLayout(Point location)
    {
        _rectangleLayout = new Rectangle(location, new Size());
    }

    public void ScaleLayout(Point location)
    {
        _rectangleLayout.X = Math.Min(_rectangleLayout.X, location.X);
        _rectangleLayout.Y = Math.Min(_rectangleLayout.Y, location.Y);

        _rectangleLayout.Width = Math.Abs(_rectangleLayout.X - location.X);
        _rectangleLayout.Height = Math.Abs(_rectangleLayout.Y - location.Y);

        RedrawLayout();
    }

    public void ConsumeLayout()
    {
        Clear();

        DrawEllipse(_rectangleLayout);

        _rectangleLayout = Rectangle.Empty;
    }
}
