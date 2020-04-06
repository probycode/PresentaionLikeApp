using Presentation_App;
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
    /// Interaction logic for DummyEditor.xaml
    /// </summary>
    public partial class DummyEditor : Page, ISlideEditor
    {
        public DummyEditor()
        {
            InitializeComponent();
        }

        public event EventHandler SlideUpdated;

        public void Initailize(IPresentation presentation, ISlide slide)
        {
            UpdateEditor();
        }

        public void UpdateEditor()
        {
            
        }
    }
}
