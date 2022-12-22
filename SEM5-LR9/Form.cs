using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            // code...
        }

        private void Form_Paint(object sender, PaintEventArgs e)
        {
            pictureBox.Image = _bitmap;
        }
    }
}
