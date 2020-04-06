using System.Collections.Generic;
using System.Drawing;
using System.Windows.Media.Imaging;

namespace Presentation_App
{
    public interface IPresentation
    {
        string Name { get; set; }
        List<ISlide> Slides { get; }
        PresentationStyle Style { get; }
        PresentationAudio Audio { get; }
        PresentationTemplate Template { get; set; }
        SlideShow SlideShow { get; set; }

        void AddImage(string imageName, BitmapImage image);
        void AddSlide(ISlide slideData);
        void InsertSlideAt(int index, ISlide slideData);
        void RemoveSlide(ISlide slideData);
        void RemoveSlideAt(int index);
        void SetImages(Dictionary<string, BitmapImage> images);
        void UseTemplate();

        BitmapImage GetImage(string imageName);
        Dictionary<string, BitmapImage> GetImages();
    }
}