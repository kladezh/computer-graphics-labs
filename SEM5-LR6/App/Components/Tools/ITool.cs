using System;
using System.Windows.Forms;

using SEM5_LR6.App.Services;

namespace SEM5_LR6.App.Components.Tools
{
    public interface ITool
    {
        Painter Painter { get; set; }

        void OnClear();
        void OnSwitch();

        void OnMouseDown(MouseEventArgs e);
        void OnMouseMove(MouseEventArgs e);
        void OnMouseUp(MouseEventArgs e);
    }
}
