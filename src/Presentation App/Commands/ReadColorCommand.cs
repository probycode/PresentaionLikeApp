using System;
using System.Windows.Forms;
using System.Windows.Media;
using Presentation_App;

namespace Presentation_App
{
    public class ReadColorCommand
    {
        public void Execute(Action<Color> OnSeccessfull)
        {
            var colorDialog = new ColorDialog();
            colorDialog.ShowDialog();

            Color color = Color.FromArgb(colorDialog.Color.A, colorDialog.Color.R, colorDialog.Color.G, colorDialog.Color.B);

            OnSeccessfull(color);
        }
    }
}
