using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Presentation_App;

namespace Presentation_App
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T">T is Editor</typeparam>
    /// <typeparam name="U">U is Display</typeparam>
    [System.Serializable]
    public class IntroSlideModel<T,U> : SlideBase, IIntroSlide where T : ISlideEditor, new()
                                               where U : ISlideDisplay, new()
    {
        public string SubTitle { get; set; }
        public double SubTitleFontSize { get; set; }
        public string Image { get; set; }

        public IntroSlideModel()
        {
            Name = string.Empty;

            SubTitle = string.Empty;
            ContentFontSize = 80;
            SubTitleFontSize = 20;
            Image = string.Empty;
            IsDone = true;

            SlideActions = new List<ISlideAction>();
        }

        public override void OnFinished()
        {
            
        }

        public override void Reset()
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
