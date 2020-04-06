using Presentation_App;
using System.Windows.Controls;
using System.Windows.Media;

namespace Presentation_App
{
    /// <summary>
    /// Interaction logic for IntroSlideDisplayPage.xaml
    /// </summary>
    public partial class IntroSlideDisplayPage : Page, ISlideDisplay
    {
        IPresentation presentation;
        IIntroSlide introSlide;

        public IntroSlideDisplayPage()
        {
            InitializeComponent();
        }

        public void Initailize(IPresentation presentation, ISlide slide)
        {
            introSlide = (IIntroSlide)slide;
            this.presentation = presentation;

            UpdateDisplay();
        }

        public void DoAction(int Action)
        {
            
        }

        public void UpdateDisplay()
        {
            if (introSlide.Content != Resource.DEFAULT_INPUTFIELD_TEXT)
                SlideContent.Text = introSlide.Content;
            else
                SlideContent.Text = string.Empty;

            if (introSlide.SubTitle != Resource.DEFAULT_INPUTFIELD_TEXT)
                SubTitle.Text = introSlide.SubTitle;
            else
                SubTitle.Text = string.Empty;
            
            SlideContent.FontSize = introSlide.ContentFontSize;

            SlideContent.Foreground = new SolidColorBrush(presentation.Style.TitleColor);
            SubTitle.Foreground = new SolidColorBrush(presentation.Style.TextColor);

            //Set Slide Image
            if (string.IsNullOrEmpty(introSlide.Image) == false)
            {
                SlideImage.Source = presentation.GetImage(introSlide.Image);
            }
        }
    }
}
