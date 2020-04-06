using Presentation_App;
using System.Windows.Controls;
using System.Windows.Media;

namespace Presentation_App
{
    /// <summary>
    /// Interaction logic for InformationSlideDisplayPage.xaml
    /// </summary>
    public partial class InformationSlideDisplayPage : Page, ISlideDisplay
    {
        IPresentation presentation;
        IInformationSlide informationSlide;

        public InformationSlideDisplayPage()
        {
            InitializeComponent();
        }

        public void Initailize(IPresentation presentation, ISlide slide)
        {
            this.presentation = presentation;
            informationSlide = (IInformationSlide)slide;

            UpdateDisplay();
        }

        public void DoAction(int Action)
        {
            
        }

        public void UpdateDisplay()
        {
            if (informationSlide.Content != Resource.DEFAULT_INPUTFIELD_TEXT)
                SlideContent.Text = informationSlide.Content;
            else
                SlideContent.Text = string.Empty;

            SlideContent.FontSize = informationSlide.ContentFontSize;

            SlideContent.Foreground = new SolidColorBrush(presentation.Style.TextColor);

            //Set Slide Image
            if (string.IsNullOrEmpty(informationSlide.Image) == false)
            {
                SlideImage.Source = presentation.GetImage(informationSlide.Image);
            }
        }
    }
}
