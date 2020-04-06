using Newtonsoft.Json;
using System;
using System.Windows.Forms;
using Presentation_App;
using System.Collections.Generic;

namespace Presentation_App
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T">T is Editor </typeparam>
    /// <typeparam name="U">U is Display</typeparam>
    [System.Serializable]
    public class InformationSlideModel<T, U> : SlideBase, IInformationSlide where T : ISlideEditor, new()
                                                                 where U : ISlideDisplay, new()
    {
        public string Image { get; set; }

        public InformationSlideModel()
        {
            Name = string.Empty;
            IsDone = true;
            ContentFontSize = 24;

            Image = string.Empty;
            SlideActions = new List<ISlideAction>();
        }

        public override void Reset()
        {

        }

        public override void OnFinished()
        {
            
        }

        public override ISlideDisplay OnDisplayGUI()
        {
            if (Display == null) Display = new U();

            return Display;
        }

        public override ISlideEditor OnEditorGUI()
        {
            if (Editor == null) Editor = new T();

            return Editor;
        }
    }
}
