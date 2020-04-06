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
    /// Interaction logic for FullImageSlideDisplayPage.xaml
    /// </summary>
    public partial class FullImageSlideDisplayPage : Page, ISlideDisplay
    {
        IPresentation presentation;
        IFullImageSlide slide;

        public FullImageSlideDisplayPage()
        {
            InitializeComponent();
        }

        public void DoAction(int action)
        {
             
        }

        public void Initailize(IPresentation presentation, ISlide slide)
        {
            this.presentation = presentation;
            this.slide = slide as IFullImageSlide;

            UpdateDisplay();
        }

        public void UpdateDisplay()
        {
            //Set Slide Image
            if (string.IsNullOrEmpty(slide.Image) == false)
            {
                SlideImage.Source = presentation.GetImage(slide.Image);
            }
        }
    }
}
