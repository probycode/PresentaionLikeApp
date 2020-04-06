using System;
using System.Windows.Controls;
using System.Windows.Media;

namespace Presentation_App
{
    /// <summary>
    /// Interaction logic for IntroSlideEditorPage.xaml
    /// </summary>
    public partial class IntroSlideEditorPage : Page, ISlideEditor
    {
        public event EventHandler SlideUpdated;
        IPresentation presentation;
        IIntroSlide introSlide;

        public IntroSlideEditorPage()
        {
            InitializeComponent();
        }

        public void Initailize(IPresentation presentation, ISlide slide)
        {
            introSlide = (IIntroSlide)slide;
            this.presentation = presentation;
            
            if(String.IsNullOrEmpty(introSlide.Content))
                introSlide.Content = presentation.Name;

            UpdateEditor();
        }

        public void UpdateEditor()
        {
            SlideContent.Text = introSlide.Content;
            SubTitle.Text = introSlide.SubTitle;

            SlideContent.FontSize = introSlide.ContentFontSize;
            SubTitle.FontSize = introSlide.SubTitleFontSize;


            SlideContent.Foreground = new SolidColorBrush(presentation.Style.TitleColor);
            SubTitle.Foreground = new SolidColorBrush(presentation.Style.TextColor);

            //Set Slide Image
            if (string.IsNullOrEmpty(introSlide.Image) == false)
            {
                SlideImage.Source = presentation.GetImage(introSlide.Image);
            }
        }

        private void SlideImage_PreviewMouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var command = new ReadImageToPresentationCommand();

            Action<IImageReader> action = (imageReader) => {
                introSlide.Image = imageReader.ImageName;
                SlideImage.Source = imageReader.Image;
            };

            command.Execute(presentation, action);

            SlideUpdated?.Invoke(this, EventArgs.Empty);
        }

        private void SlideContent_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (introSlide != null)
                introSlide.Content = SlideContent.Text;
        }

        private void SubTitle_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (introSlide != null)
                introSlide.SubTitle = SubTitle.Text;
        }

        private void SlideContent_GotFocus(object sender, System.Windows.RoutedEventArgs e)
        {
            var labelInspector = Factory.GetLabelInspectorContol(SlideContent, "Title");
            labelInspector.OnChanged += LabelInspector_SlideContent_OnChanged;

            PresentationEditor.OnSelectedItem(labelInspector, SlideContent);

            if (SlideContent.Text == presentation.Name)
            SlideContent.Clear();
        }

        private void SlideContent_LostFocus(object sender, System.Windows.RoutedEventArgs e)
        {
            if(String.IsNullOrEmpty(SlideContent.Text))
            {
                SlideContent.Text = presentation.Name;
            }
        }

        private void SubTitle_GotFocus(object sender, System.Windows.RoutedEventArgs e)
        {
            var labelInspector = Factory.GetLabelInspectorContol(SubTitle, "Sub-Title");
            labelInspector.OnChanged += LabelInspector_SubTitle_OnChanged;

            PresentationEditor.OnSelectedItem(labelInspector, SlideContent);

            if (SubTitle.Text == Resource.DEFAULT_INPUTFIELD_TEXT)
                SubTitle.Clear();
        }

        private void LabelInspector_SlideContent_OnChanged(object sender, EventArgs e)
        {
            var s = (LabelInspectorContol)sender;
            SlideContent.FontSize = s.SelectedFontSize;
            introSlide.ContentFontSize = s.SelectedFontSize;
        }

        private void LabelInspector_SubTitle_OnChanged(object sender, EventArgs e)
        {
            var s = (LabelInspectorContol)sender;
            SubTitle.FontSize = s.SelectedFontSize;
            introSlide.SubTitleFontSize = s.SelectedFontSize;
        }

        private void SubTitle_LostFocus(object sender, System.Windows.RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(SubTitle.Text))
            {
                SubTitle.Text = Resource.DEFAULT_INPUTFIELD_TEXT;
            }
        }
    }
}
