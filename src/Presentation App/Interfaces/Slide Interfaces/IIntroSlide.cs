using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation_App
{
    public interface IIntroSlide : ISlide
    {
        string SubTitle { get; set; }
        string Image { get; set; }
        double SubTitleFontSize { get; set; }
    }
}
