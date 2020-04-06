using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation_App
{
    [System.Serializable]
    class FullImageSlideModel<T, U> : SlideBase, IFullImageSlide where T : ISlideEditor, new()
                                            where U : ISlideDisplay, new()
    {
        public string Image { get; set; }

        public FullImageSlideModel()
        {
            Name = string.Empty;
            IsDone = true;

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
