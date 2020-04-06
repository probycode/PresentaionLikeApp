using Presentation_App;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Presentation_App
{
    /// <summary>
    /// Interaction logic for SlideButtonControl.xaml
    /// </summary>
    public partial class SlideButtonControl : UserControl
    {
        public ISlide slide;

        public SlideButtonControl()
        {
            InitializeComponent();
        }

        public void Initialize(ISlide slide)
        {
            this.slide = slide;

            SlideText.Text = slide.Name;
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
        }

        public void SetIcon (string icon)
        {
            Icon.Text = icon;
        }

        private void SlideText_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(slide != null)
                slide.Name = SlideText.Text;
        }
    }
}
