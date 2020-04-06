using System;
using System.IO;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Presentation_App
{
    /// <summary>
    /// Interaction logic for InformationSlideEditorPage.xaml
    /// </summary>
    public partial class InformationSlideEditorPage : Page, ISlideEditor
    {
        public event EventHandler SlideUpdated;
        IPresentation presentation;
        IInformationSlide informationSlide;

        public InformationSlideEditorPage()
        {
            InitializeComponent();
        }

        public void Initailize(IPresentation presentation, ISlide slide)
        {
            this.presentation = presentation;
            informationSlide = (IInformationSlide)slide;

            UpdateEditor();
        }

        public void UpdateEditor()
        {
            SlideContent.Text = informationSlide.Content;
            SlideContent.FontSize = informationSlide.ContentFontSize;

            SlideContent.Foreground = new SolidColorBrush(presentation.Style.TextColor);

            //Set Slide Image
            if (string.IsNullOrEmpty(informationSlide.Image) == false)
            {
                SlideImage.Source = presentation.GetImage(informationSlide.Image);
            }
        }

        private void SlideImage_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            var command = new ReadImageToPresentationCommand();

            Action<IImageReader> action = (imageReader) => {
                informationSlide.Image = imageReader.ImageName;
                SlideImage.Source = imageReader.Image;
            };

            command.Execute(presentation, action);

            SlideUpdated?.Invoke(this, EventArgs.Empty);
        }

        private void SlideContent_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(informationSlide != null)
                informationSlide.Content = SlideContent.Text;
        }

        private void SlideContent_GotFocus(object sender, System.Windows.RoutedEventArgs e)
        {
            var labelInspector = Factory.GetLabelInspectorContol(SlideContent, "Information Text");
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
            informationSlide.ContentFontSize = s.SelectedFontSize;
        }
    }
}
