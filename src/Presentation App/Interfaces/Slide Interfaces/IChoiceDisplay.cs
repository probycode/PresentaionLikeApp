using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation_App
{
    public interface IChoiceDisplay
    {
        void Initailize(IPresentation presentation, IChoice choice);
        void UpdateDisplay();
        void Highlight();
        void SetChoiceStyle(ChoiceStyle choiceStyle);
    }
}
