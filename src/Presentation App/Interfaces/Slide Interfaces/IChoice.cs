using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation_App
{
    public interface IChoice
    {
        char ChoiceLetter { get; set; }
        string ChoiceText { get; set; }
        double ChoiceTextFontSize { get; set; }

        IChoiceDisplay OnDisplayGUI();
        IChoiceEditor OnEditorGUI();
    }
}
