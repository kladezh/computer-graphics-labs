using System;
using System.Drawing;
using System.Windows.Forms;

using SEM5_LR4.Painters;

namespace SEM5_LR4
{
    public partial class Form : System.Windows.Forms.Form
    {
        private PolylinePainter _PolylinePainter;
        private PolygonPainter _polygonPainter;

        private Painter _activePainter;

        public Form()
        {
            InitializeComponent();

            _PolylinePainter = new PolylinePainter
            {
                PaintContext = pictureBox,
                Pen = new Pen(Color.BlueViolet, 2f)
            };

            _polygonPainter = new PolygonPainter
            {
                PaintContext = pictureBox,
                Pen = new Pen(Color.Black, 2f)
            };

            _activePainter = _PolylinePainter;
        }


        private void buttonClip_Click(object sender, EventArgs e)
        {
           
        }

        private void radioButtonPolyline_CheckedChanged(object sender, EventArgs e)
        {
            _activePainter = _PolylinePainter;
        }

        private void radioButtonPolygon_CheckedChanged(object sender, EventArgs e)
        {
            _activePainter = _polygonPainter;
        }

        private void buttonDrawPolygon_Click(object sender, EventArgs e)
        {
            if(_activePainter is PolygonPainter pgon)
            {
                pgon.DrawPolygon();
                return;
            }

            if(_activePainter is PolylinePainter pline)
            {
                pline.DrawPolyline();
                return;
            }
        }

        private void buttonClear_Click(object sender, EventArgs e) => _activePainter.Clear();

        private void pictureBox_MouseDown(object sender, MouseEventArgs e) => _activePainter.OnMouseDown(e);

        private void pictureBox_MouseMove(object sender, MouseEventArgs e) => _activePainter.OnMouseMove(e);

        private void pictureBox_MouseUp(object sender, MouseEventArgs e) => _activePainter.OnMouseUp(e);

    }
}
