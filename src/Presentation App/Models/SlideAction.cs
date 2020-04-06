using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation_App
{
    public class QuestionShowAnwerAction : ISlideAction
    {
        public void Run(ISlide slide)
        {
            slide.Display.DoAction(slide.SlideActionIndex);
        }
    }
}
