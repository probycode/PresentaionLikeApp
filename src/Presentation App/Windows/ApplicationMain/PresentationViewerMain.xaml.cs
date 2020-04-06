using Presentation_App;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Threading;

namespace Presentation_App
{
    /// <summary>
    /// Interaction logic for PresentationViewerMain.xaml
    /// </summary>
    public partial class PresentationViewerMain : Window
    {
        public PresentationViewerMain()
        {
            InitializeComponent();

            Resource.Presentation = LoadPresentation();

            if (Resource.Presentation != null)
            {
                var window = new SlideShowForm(Resource.Presentation);
                window.Show();

                Close();
            }
            else
            {
                MessageBox.Show("Couldent open presentation");
                Close();
            }
        }

        public IPresentation LoadPresentation()
        {
            IPresentation presentation = null;

            string currentDirectory = Directory.GetCurrentDirectory();

            List<string> found = Directory.GetFiles(currentDirectory, "*.json", SearchOption.AllDirectories).ToList();

            if (found.Count > 0)
            {
                string presentationFolder = Path.GetFullPath(Path.Combine(found[0], @"..\"));

                Resource.FileName = presentationFolder;

                presentation = Factory.CreatePresentationReader().ReadAt(presentationFolder);
            }

            Resource.SaveLocation = currentDirectory;

            return presentation;
        }
    }
}
