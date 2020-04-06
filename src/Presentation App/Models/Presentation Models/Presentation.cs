using System.Collections.Generic;
using System.Windows.Media.Imaging;
using Newtonsoft.Json;

namespace Presentation_App
{
    [System.Serializable]
    public class Presentation : IPresentation
    {
        public string Name { get; set; }
        int CurrentSlideIndex { get; set; }
        public List<ISlide> Slides { get; private set; }
        public PresentationStyle Style { get; private set; }
        public PresentationAudio Audio { get; private set; }
        public PresentationTemplate Template { get; set; }
        [JsonIgnore] public SlideShow SlideShow { get; set; }
        [JsonIgnore] private Dictionary<string, BitmapImage> Images { get; set; }
        
        public Presentation()
        {
            Name = string.Empty;

            Slides = new List<ISlide>();
            Style = new PresentationStyle();
            Audio = new PresentationAudio();
            Images = new Dictionary<string, BitmapImage>();
            SlideShow = new SlideShow(this);
        }

        public void SetImages(Dictionary<string, BitmapImage> images)
        {
            this.Images = images;
        }

        public void AddImage(string imageName, BitmapImage image)
        {
            if(imageName == null)
            {
                return;
            }

            if (Images.ContainsKey(imageName) == false)
                Images.Add(imageName, image);
        }

        public Dictionary<string, BitmapImage> GetImages()
        {
            return new Dictionary<string, BitmapImage>(Images);
        }

        public void AddSlide(ISlide slideData)
        {
            Slides.Add(slideData);
        }

        public void InsertSlideAt(int index, ISlide slideData)
        {
            Slides.Insert(index, slideData);
        }

        public void RemoveSlide(ISlide slideData)
        {
            Slides.Remove(slideData);
        }

        public void RemoveSlideAt(int index)
        {
            Slides.RemoveAt(index);
        }

        public BitmapImage GetImage(string imageName)
        {
            if (Images.ContainsKey(imageName))
            {
                return Images[imageName];
            }

            return null;
        }

        public void UseTemplate()
        {
            Template.Use(this);
        }
    }
}
