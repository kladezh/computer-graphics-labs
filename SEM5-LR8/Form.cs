using System;
using System.Collections.Generic;
using System.Drawing;
using System.Numerics;
using System.Windows.Forms;

using SEM5_LR8.App.Services;

namespace SEM5_LR8
{
    public partial class Form : System.Windows.Forms.Form
    {
        private Bitmap _bitmap;

        private Painter _painter;

        public Form()
        {
            InitializeComponent();

            _bitmap = new Bitmap(pictureBox.ClientSize.Width, pictureBox.ClientSize.Height);
            pictureBox.DrawToBitmap(_bitmap, pictureBox.ClientRectangle);

            _painter = new Painter
            {
                Context = _bitmap,
                Pen = new Pen(Color.Black, 2f),
            };

            DrawMandelbrotSet();
        }

        private void DrawMandelbrotSet()
        {
            int width = pictureBox.ClientSize.Width;
            int height = pictureBox.ClientSize.Height;

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    double a = (x - (width / 2)) / (double)(width / 4);
                    double b = (y - (height / 2)) / (double)(height / 4);

                    Complex c = new Complex(a, b);
                    Complex z = new Complex(0, 0);

                    bool isBelong = true;
                    for (int i = 0; i < 100; i++)
                    {
                        z = z * z + c;

                        if(z.Magnitude > 2.0)
                        {
                            isBelong = false;
                            break;
                        }
                    }

                    _painter.Pen.Color = isBelong ? Color.Black : Color.White;
                    _painter.DrawPixel(x, y);
                }
            }
        }

        private void pictureBox_Paint(object sender, PaintEventArgs e)
        {
            pictureBox.Image = _bitmap;
        }
    }
}
