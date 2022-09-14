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
        }
    }

    public class CurvePainter
    {
        private Graphics Graphics { get; set; }
        private List<Point> Points { get; set; }

        public Control PaintContext
        {
            get => PaintContext;
            set 
            {
                PaintContext = value;
                Graphics = value.CreateGraphics();
            }
        }

        public CurvePainter()
        {
            Points = new List<Point>();
        }

        public void Clear()
        {
            Graphics.Clear(PaintContext.BackColor);
        }

    }
}
