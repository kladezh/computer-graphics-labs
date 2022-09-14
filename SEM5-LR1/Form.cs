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
                PaintContext = pictureBox
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
            Pen pen = new Pen(Color.Black);

            Rectangle rect = new Rectangle(point, new Size(5, 5));

            Graphics.DrawEllipse(pen, rect);
            Graphics.FillEllipse(pen.Brush, rect);
        }

        public void DrawLine(Point first, Point second)
        {
            // draw by brezenheim algorithm
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
}
