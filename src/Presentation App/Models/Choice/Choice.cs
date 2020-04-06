using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Presentation_App;

namespace Presentation_App
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T">T is Editor</typeparam>
    /// <typeparam name="U">U is Display</typeparam>
    [System.Serializable]
    public class Choice<T, U> : IChoice where T : IChoiceEditor, new()
                                        where U : IChoiceDisplay, new()
    {
        public char ChoiceLetter { get; set; }
        public string ChoiceText { get; set; }
        public double ChoiceTextFontSize { get; set; }

        public Choice()
        {
            ChoiceText = string.Empty;
            ChoiceTextFontSize = 18;
            ChoiceLetter = 'A';
        }

        public IChoiceDisplay OnDisplayGUI()
        {
            return new U();
        }

        public IChoiceEditor OnEditorGUI()
        {
            return new T();
        }
    }
}
