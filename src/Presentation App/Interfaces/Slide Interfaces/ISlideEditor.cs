using System;

namespace Presentation_App
{
    /// <summary>
    /// The control that will edit a slide
    /// </summary>
    public interface ISlideEditor
    {
        event EventHandler SlideUpdated;
        void Initailize(IPresentation presentation, ISlide slide);
        void UpdateEditor();
    }
}