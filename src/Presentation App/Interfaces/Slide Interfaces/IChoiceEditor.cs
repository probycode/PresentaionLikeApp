using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation_App
{
    /// <summary>
    /// The control that will edit the choice
    /// </summary>
    public interface IChoiceEditor
    {
        event EventHandler<IChoiceEditor> OnChoiceSelected;
        char SelectedChoice { get; set; }
        void Initailize(IPresentation presentation, IChoice choice, char CorrectLetter);
        void UpdateSelected(char letter);
        void UpdateEditor(char CorrectLetter);
        void SetChoiceStyle(ChoiceStyle choiceStyle);
        void Reset();
    }
}
