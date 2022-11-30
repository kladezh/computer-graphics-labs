using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

using SEM5_LR5.Painters;
using SEM5_LR5.Clippers;

namespace SEM5_LR5
{
    public partial class Form : System.Windows.Forms.Form
    {
        private Graphics _pictureBoxGraphics;

        private readonly Color PainterColorBase = Color.Black;
        private readonly Color PainterColorEdit = Color.Blue;

        private PolygonPainter _painter;

        private PolygonClipper _clipper;

        private List<Point> _basePolygon;
        private List<Point> _editPolygon;

        public Form()
        {
            InitializeComponent();

            _pictureBoxGraphics = pictureBox.CreateGraphics();

            _painter = new PolygonPainter
            {
                Context = _pictureBoxGraphics,
                Pen = new Pen(Color.Black, 2f)
            };

            _clipper = new PolygonClipper(); 
        }

        private void ClearPictureBox()
        {
            _pictureBoxGraphics.Clear(pictureBox.BackColor);
        }

        private void radioButtonBase_CheckedChanged(object sender, EventArgs e)
        {
            _painter.Pen.Color = PainterColorBase;
        }

        private void radioButtonEdit_CheckedChanged(object sender, EventArgs e)
        {
            _painter.Pen.Color = PainterColorEdit;
        }

        private void buttonDrawPolygon_Click(object sender, EventArgs e)
        {            
            _painter.DrawPolygon();

            if (radioButtonBase.Checked)
            {
                _basePolygon = new List<Point>(_painter.Points);
            }
            else if(radioButtonEdit.Checked)
            {
                _editPolygon = new List<Point>(_painter.Points);
            }

            _painter.Clear();       
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            ClearPictureBox();
            _painter.Clear();
        }

        private void buttonClip_Click(object sender, EventArgs e)
        {
            _clipper.Source = _basePolygon;
            _editPolygon = _clipper.ClipPolygon(_editPolygon);

            buttonClear.PerformClick();

            radioButtonBase.PerformClick();
            _painter.DrawPolygonWithPoints(_basePolygon);

            radioButtonEdit.PerformClick();
            _painter.DrawPolygonWithPoints(_editPolygon);        
        }

        private void pictureBox_MouseDown(object sender, MouseEventArgs e) => _painter.OnMouseDown(e);

        private void pictureBox_MouseMove(object sender, MouseEventArgs e) => _painter.OnMouseMove(e);

        private void pictureBox_MouseUp(object sender, MouseEventArgs e) => _painter.OnMouseUp(e);
        
    }
}
