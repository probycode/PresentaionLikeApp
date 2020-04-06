using Presentation_App;
using System.Windows.Controls;


namespace Presentation_App
{
    /// <summary>
    /// Interaction logic for DummyDisplay.xaml
    /// </summary>
    public partial class DummyDisplay : Page , ISlideDisplay
    {
        public DummyDisplay()
        {
            InitializeComponent();
        }

        public void Initailize(IPresentation presentation, ISlide slide)
        {
            UpdateDisplay();
        }

        public void DoAction(int Action)
        {
            
        }

        public void UpdateDisplay()
        {
            
        }
    }
}
