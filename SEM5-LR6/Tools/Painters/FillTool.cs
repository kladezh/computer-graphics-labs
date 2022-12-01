using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SEM5_LR6.Tools.Painters
{
    public class FillTool : PainterTool
    {
        public override void OnClear()
        {
            return;
        }

        public override void OnSwitch()
        {
            return;
        }

        public override void OnMouseDown(MouseEventArgs e)
        {
            return;
        }

        public override void OnMouseMove(MouseEventArgs e)
        {
            return;
        }

        public override void OnMouseUp(MouseEventArgs e)
        {
            var point = e.Location;

            var color = Pen.Color;

            // fill algorithm...
        }
    }
}
