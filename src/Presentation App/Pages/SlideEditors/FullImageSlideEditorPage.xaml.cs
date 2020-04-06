using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Presentation_App
{
    /// <summary>
    /// Interaction logic for FullImageSlideEditorPage.xaml
    /// </summary>
    public partial class FullImageSlideEditorPage : Page, ISlideEditor
    {
        public event EventHandler SlideUpdated;

        IPresentation presentation;
        IFullImageSlide slide;

        public FullImageSlideEditorPage()
        {
            InitializeComponent();
        }

        public void Initailize(IPresentation presentation, ISlide slide)
        {
            this.presentation = presentation;
            this.slide = slide as IFullImageSlide;

            UpdateEditor();
        }

        public void UpdateEditor()
        {
            //Set Slide Image
            if (string.IsNullOrEmpty(slide.Image) == false)
            {
                SlideImage.Source = presentation.GetImage(slide.Image);
            }
        }

        private void SlideImage_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            var command = new ReadImageToPresentationCommand();

            void action(IImageReader imageReader)
            {
                slide.Image = imageReader.ImageName;
                SlideImage.Source = imageReader.Image;
            }

            command.Execute(presentation, action);

            SlideUpdated?.Invoke(this, EventArgs.Empty);
        }
    }
}
