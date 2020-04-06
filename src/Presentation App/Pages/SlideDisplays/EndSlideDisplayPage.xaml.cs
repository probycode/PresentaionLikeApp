using Presentation_App;
using System.Windows.Controls;
using System.Windows.Media;

namespace Presentation_App
{
    /// <summary>
    /// Interaction logic for EndSlideDisplayPage.xaml
    /// </summary>
    public partial class EndSlideDisplayPage : Page, ISlideDisplay
    {
        IPresentation presentation;
        IEndSlide endSlide;

        public EndSlideDisplayPage()
        {
            InitializeComponent();
        }

        public void Initailize(IPresentation presentation, ISlide slide)
        {
            this.presentation = presentation;
            endSlide = (IEndSlide)slide;

            UpdateDisplay();

            Resource.EndAudioPlayer.PlayOnce();
        }

        public void DoAction(int Action)
        {
            
        }

        public void UpdateDisplay()
        {
            if (endSlide.Content != Resource.DEFAULT_INPUTFIELD_TEXT)
                SlideContent.Text = endSlide.Content;
            else
                SlideContent.Text = string.Empty;
            
            SlideContent.FontSize = endSlide.ContentFontSize;

            SlideContent.Foreground = new SolidColorBrush(presentation.Style.TitleColor);

            //Set Slide Image
            if (string.IsNullOrEmpty(endSlide.Image) == false)
            {
                SlideImage.Source = presentation.GetImage(endSlide.Image);
            }
        }
    }
}
