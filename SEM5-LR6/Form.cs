using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using SEM5_LR6.Painters;

namespace SEM5_LR6
{
    public partial class Form : System.Windows.Forms.Form
    {
        private Graphics _pictureBoxGraphics;

        private PolygonPainter _painter;

        private List<Point> _polygon;

        public Form()
        {
            InitializeComponent();

            _pictureBoxGraphics = pictureBox.CreateGraphics();

            _painter = new PolygonPainter
            {
                Context = _pictureBoxGraphics,
                Pen = new Pen(Color.Black, 2f)
            };
        }

        private void ClearPictureBox()
        {
            _pictureBoxGraphics.Clear(pictureBox.BackColor);
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            ClearPictureBox();

            _painter.Clear();
        }

        private void buttonDraw_Click(object sender, EventArgs e)
        {
            _painter.DrawPolygon();

            _polygon = new List<Point>(_painter.Points);

            _painter.Clear();
        }

        private void buttonFill_Click(object sender, EventArgs e)
        {
            _painter.FillPolygonWithPoints(_polygon);
        }

        private void pictureBox_MouseDown(object sender, MouseEventArgs e) => _painter.OnMouseDown(e);

        private void pictureBox_MouseMove(object sender, MouseEventArgs e) => _painter.OnMouseMove(e);

        private void pictureBox_MouseUp(object sender, MouseEventArgs e) => _painter.OnMouseUp(e);

        
    }
}
