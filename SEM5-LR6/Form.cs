using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using SEM5_LR6.Tools;
using SEM5_LR6.Tools.Painters;

namespace SEM5_LR6
{
    public partial class Form : System.Windows.Forms.Form
    {
        private Graphics _pictureBoxGraphics;

        private PolygonTool _polygonTool;
        private FillTool _fillTool;

        public ITool Tool { get; set; }

        public Form()
        {
            InitializeComponent();

            _pictureBoxGraphics = pictureBox.CreateGraphics();

            // create tools
            _polygonTool = new PolygonTool
            {
                Context = _pictureBoxGraphics,
                Pen = new Pen(Color.Black, 2f)
            };

            _fillTool = new FillTool
            {
                Context = _pictureBoxGraphics,
                Pen = new Pen(Color.Black, 2f)
            };

            // set default tool
            Tool = _polygonTool;
        }

        #region Helpers

        private void ClearPictureBox()
        {
            _pictureBoxGraphics.Clear(pictureBox.BackColor);
        }

        #endregion

        #region EventHandlers

        private void buttonClear_Click(object sender, EventArgs e)
        {
            ClearPictureBox();

            Tool.OnClearClick(e);
        }

        private void buttonDraw_Click(object sender, EventArgs e)
        {
            Tool.OnDrawClick(e);
        }

        private void radioButtonPolygon_CheckedChanged(object sender, EventArgs e)
        {
            Tool = _polygonTool;
        }

        private void radioButtonFill_CheckedChanged(object sender, EventArgs e)
        {
            Tool = _fillTool;
        }

        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            Tool.OnMouseDown(e);
        }

        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            Tool.OnMouseMove(e);
        }

        private void pictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            Tool.OnMouseUp(e);
        }

        #endregion
    }
}
