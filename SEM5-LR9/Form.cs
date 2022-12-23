using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.Windows.Forms;

using Graphics.Services;

namespace SEM5_LR9
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

            DrawJuliaSet();
        }

        private void DrawJuliaSet()
        {
            int width = pictureBox.ClientSize.Width;
            int height = pictureBox.ClientSize.Height;

            double zoom = 0.9;

            /* 
             * определяем форму фрактала Жюлиа
             * 
             * -1.0, 0.0
             * -0.2, 0.75
             * -0.70176, -0.3842
             * 
             * */
            Complex c = new Complex(0.0, 0.0);

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    double a = 1.5 * (x - width / 2) / (zoom * width / 2);
                    double b = (y - height / 2) / (zoom * height / 2);

                    Complex z = new Complex(a, b);

                    int i;
                    for (i = 0; i < 300; i++)
                    {
                        z = z * z + c;

                        if (z.Magnitude > 2.0) break;
                    }

                    _painter.Pen.Color = Color.FromArgb(255, (i * 9) % 255, 0, (i * 9) % 255);
                    _painter.DrawPixel(x, y);
                }
            }  
        }

        private void Form_Paint(object sender, PaintEventArgs e)
        {
            pictureBox.Image = _bitmap;
        }
    }
}
