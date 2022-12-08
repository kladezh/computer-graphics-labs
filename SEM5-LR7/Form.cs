using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using SEM5_LR7.App.Services;

namespace SEM5_LR7
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
                Pen = new Pen(Color.Black, 3f),
            };

        }

        private void DrawKochCurve(PointF pt1, PointF pt2, PointF pt3, int iter)
        {
            if (iter == 0) 
            {
                _painter.DrawLine(pt1, pt2);
                return;
            } 
       
            //средняя треть отрезка
            var pn1 = new PointF((pt2.X + 2 * pt1.X) / 3, (pt2.Y + 2 * pt1.Y) / 3);
            var pn2 = new PointF((2 * pt2.X + pt1.X) / 3, (pt1.Y + 2 * pt2.Y) / 3);

            //координаты вершины угла
            var pc = new PointF((pt2.X + pt1.X) / 2, (pt2.Y + pt1.Y) / 2);
            var pn3 = new PointF((4 * pc.X - pt3.X) / 3, (4 * pc.Y - pt3.Y) / 3);

            //рекурсивно вызываем функцию нужное число раз
            DrawKochCurve(pn1, pn3, pn2, iter - 1);
            DrawKochCurve(pn3, pn2, pn1, iter - 1);
            DrawKochCurve(pt1, pn1, new PointF((2 * pt1.X + pt3.X) / 3, (2 * pt1.Y + pt3.Y) / 3), iter - 1);
            DrawKochCurve(pn2, pt2, new PointF((2 * pt2.X + pt3.X) / 3, (2 * pt2.Y + pt3.Y) / 3), iter - 1);
        }

        private void buttonDraw_Click(object sender, EventArgs e)
        {
            var triangle = new List<PointF>
            {
                new PointF(200, 200),
                new PointF(500, 200),
                new PointF(350, 400)
            };

            int iter = 3;
            DrawKochCurve(triangle[0], triangle[1], triangle[2], iter);
            DrawKochCurve(triangle[1], triangle[2], triangle[0], iter);
            DrawKochCurve(triangle[2], triangle[0], triangle[1], iter);
        }

        private void pictureBox_Paint(object sender, PaintEventArgs e)
        {
            pictureBox.Image = _bitmap;
        }
    }
}
