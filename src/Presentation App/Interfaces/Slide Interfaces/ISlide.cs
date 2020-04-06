using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation_App
{
    public interface ISlide
    {
        ISlideEditor Editor { get; set; }
        ISlideDisplay Display { get; set; }
        string Name { get; set; }
        string Content { get; set; }
        double ContentFontSize { get; set; }
        string Icon { get; set; }
        bool IsDone { get; set; }
        int SlideActionIndex { get; set; }
        List<ISlideAction> SlideActions { get; set; }

    void Reset();
        void Next();
        void OnFinished();
        void OnStart();
        ISlideDisplay OnDisplayGUI();
        ISlideEditor OnEditorGUI();
    }
}
