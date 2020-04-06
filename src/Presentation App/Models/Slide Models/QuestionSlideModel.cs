using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Presentation_App;

namespace Presentation_App
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T">T is Editor </typeparam>
    /// <typeparam name="U">U is Display</typeparam>
    [System.Serializable]
    public class QuestionSlideModel<T, U> : SlideBase, IQuestionSlide where T : ISlideEditor, new()
                                                      where U : ISlideDisplay, new()
    {
        public string Image { get; set; }
        public char CorrectChoice { get; set; }
        public List<IChoice> Choices { get; set; }

        public QuestionSlideModel()
        {
            Name = string.Empty;
            CorrectChoice = 'A';
            ContentFontSize = 24;

            Image = string.Empty;
            Choices = new List<IChoice>();

            SlideActions = new List<ISlideAction>();
        }

        public override void OnFinished()
        {
            base.OnFinished();
            IsDone = false;
        }

        public override ISlideDisplay OnDisplayGUI()
        {
            if (Display == null)
                Display = new U();

            return Display;
        }

        public override ISlideEditor OnEditorGUI()
        {
            if (Editor == null)
                Editor = new T();

            return Editor;
        }
    }
}
