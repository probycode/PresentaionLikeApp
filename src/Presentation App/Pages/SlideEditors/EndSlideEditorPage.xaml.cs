using Presentation_App;
using System;
using System.Windows.Controls;
using System.Windows.Media;

namespace Presentation_App
{
    /// <summary>
    /// Interaction logic for EndSlideEditorPage.xaml
    /// </summary>
    public partial class EndSlideEditorPage : Page, ISlideEditor
    {
        public event EventHandler SlideUpdated;

        IPresentation presentation;
        IEndSlide endSlide;

        public EndSlideEditorPage()
        {
            InitializeComponent();
        }

        public void Initailize(IPresentation presentation, ISlide slide)
        {
            this.presentation = presentation;
            endSlide = (IEndSlide)slide;

            UpdateEditor();
        }

        public void UpdateEditor()
        {
            SlideContent.Text = endSlide.Content;
            SlideContent.FontSize = endSlide.ContentFontSize;

            SlideContent.Foreground = new SolidColorBrush(presentation.Style.TitleColor);

            //Set Slide Image
            if (string.IsNullOrEmpty(endSlide.Image) == false)
            {
                SlideImage.Source = presentation.GetImage(endSlide.Image);
            }
        }

        private void SlideImage_PreviewMouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var command = new ReadImageToPresentationCommand();

            Action<IImageReader> action = (imageReader) => {
                endSlide.Image = imageReader.ImageName;
                SlideImage.Source = imageReader.Image;
            };

            command.Execute(presentation, action);

            SlideUpdated?.Invoke(this, EventArgs.Empty);
        }

        private void SlideContent_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (endSlide != null)
                endSlide.Content = SlideContent.Text;
        }

        private void SlideContent_GotFocus(object sender, System.Windows.RoutedEventArgs e)
        {
            var labelInspector = Factory.GetLabelInspectorContol(SlideContent, "End Title Text");
            labelInspector.OnChanged += LabelInspector_SlideContent_OnChanged;

            PresentationEditor.OnSelectedItem(labelInspector, SlideContent);

            if (SlideContent.Text == Resource.DEFAULT_INPUTFIELD_TEXT)
                SlideContent.Clear();
        }

        private void SlideContent_LostFocus(object sender, System.Windows.RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(SlideContent.Text))
            {
                SlideContent.Text = Resource.DEFAULT_INPUTFIELD_TEXT;
            }
        }

        private void LabelInspector_SlideContent_OnChanged(object sender, EventArgs e)
        {
            var s = (LabelInspectorContol)sender;
            SlideContent.FontSize = s.SelectedFontSize;
            endSlide.ContentFontSize = s.SelectedFontSize;
        }
    }
}
