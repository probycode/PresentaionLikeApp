using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation_App
{
    public class SlideShow
    {
        private readonly IPresentation presentation;

        public event EventHandler OnSlideShowFinished;

        ISlide CurrentSlide { get; set; }
        public int CurrentSlideIndex { get; set; }

        public SlideShow(IPresentation presentation)
        {
            this.presentation = presentation;
        }

        public ISlide GetNextSlide()
        {
            if (presentation.Slides.Count == 0)
            {
                return null;
            }

            if (CurrentSlide != null)
            {
                CurrentSlide.Next();

                if (CurrentSlide.IsDone == false)
                {
                    return null;
                }
                else
                {
                    CurrentSlide.OnFinished();

                    if (CurrentSlideIndex == presentation.Slides.Count - 1)
                    {
                        OnSlideShowFinished?.Invoke(this, EventArgs.Empty);
                        return null;
                    }

                    CurrentSlideIndex++;
                    CurrentSlide = presentation.Slides[CurrentSlideIndex];
                    CurrentSlide.OnStart();
                }
            }
            else
            {
                CurrentSlide = presentation.Slides[CurrentSlideIndex];
                CurrentSlide.OnStart();
            }

            return CurrentSlide;
        }

        public ISlide GetPreviousSlide()
        {
            if  (presentation.Slides.Count == 0)
            {
                return null;
            }

            if (CurrentSlideIndex == 0)
            {
                return null;
            }

            CurrentSlide.Reset();

            CurrentSlideIndex--;
            CurrentSlide = presentation.Slides[CurrentSlideIndex];
            CurrentSlide.OnFinished();

            return CurrentSlide;
        }

        public void Reset()
        {
            CurrentSlide = null;
            CurrentSlideIndex = 0;
        }
    }
}
