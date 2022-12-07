using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using SEM5_LR6.App.Components.Tools;
using SEM5_LR6.App.Services;

namespace SEM5_LR6
{
    public partial class Form : System.Windows.Forms.Form
    {
        private Bitmap _bitmap;

        private Painter _painter;

        private ITool Tool;

        private PolygonTool _polygonTool;
        private FillTool _fillTool;

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

            // create tools
            _polygonTool = new PolygonTool
            {
                Painter = _painter
            };

            _fillTool = new FillTool
            {
                Painter = _painter
            };

            // set default tool
            Tool = _polygonTool;
        }

        #region EventHandlers

        private void buttonClear_Click(object sender, EventArgs e)
        {
            Tool.OnClear();

            _painter.Clear();
        }

        private void radioButtonPolygon_CheckedChanged(object sender, EventArgs e)
        {
            Tool.OnSwitch();

            Tool = _polygonTool;
        }

        private void radioButtonFill_CheckedChanged(object sender, EventArgs e)
        {
            Tool.OnSwitch();

            Tool = _fillTool;
        }

        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            Tool.OnMouseDown(e);
        }

        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            Tool.OnMouseMove(e);

            // Debug
            label1.Text = e.Location.ToString();
            //
        }

        private void pictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            Tool.OnMouseUp(e);
        }

        #endregion

        private void pictureBox_Paint(object sender, PaintEventArgs e)
        {
            pictureBox.Image = _bitmap;
        }
    }
}
