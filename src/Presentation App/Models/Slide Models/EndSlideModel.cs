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
    public class EndSlideModel<T, U> : SlideBase, IEndSlide where T : ISlideEditor, new()
                                            where U : ISlideDisplay, new()
    {
        public string Image { get; set; }

        public EndSlideModel()
        {
            Name = string.Empty;
            IsDone = true;
            ContentFontSize = 80;

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
