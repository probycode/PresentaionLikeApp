using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation_App
{
    public interface ISlideDisplay
    {
        void Initailize(IPresentation presentation, ISlide slide);
        void UpdateDisplay();
        void DoAction(int action);
    }
}
