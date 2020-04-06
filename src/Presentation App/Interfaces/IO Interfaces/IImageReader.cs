using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Presentation_App
{
    public interface IImageReader
    {
        string ImagePath { get; set; }
        string ImageName { get; set; }
        BitmapImage Image { get; set; }

        Dictionary<string, BitmapImage> ReadAll(string imageFolder);
        BitmapImage Read();
    }
}
