using Presentation_App;
using System.IO;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Media;

namespace Presentation_App
{
    /// <summary>
    /// Interaction logic for DashboardWindow.xaml
    /// </summary>
    public partial class DashboardWindow : Window
    {
        public DashboardWindow()
        {
            InitializeComponent();

            Resource.CreateApplicationFolders();
        }

        private void NewButton_PreviewMouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            IPresentation presentation = Factory.CreatePresentation();
            presentation.UseTemplate();

            presentation.Name = PresentationNameTextBox.Text;
            Resource.FileName = PresentationNameTextBox.Text;

            if (string.IsNullOrEmpty(Resource.SaveLocation) == false)
            {
                Factory.CreatePresentationWriter().Write(presentation, Resource.SaveLocation, Resource.FileName);
            }
            else
            {
                IPresentationWriter writer = Factory.CreatePresentationWriter();
                Resource.SaveLocation = writer.WriteAt(presentation, Resource.FileName);

                if (writer.Canceled)
                {
                    return;
                }
            }

            Resource.Presentation = presentation;

            var window = new PresentationSettingsWindow(presentation);
            window.Show();

            Close();
        }

        private void OpenButton_PreviewMouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            FolderBrowserDialog folderBrowser = new FolderBrowserDialog();

            folderBrowser.ShowDialog();

            if (string.IsNullOrEmpty(folderBrowser.SelectedPath) == false)
            {
                IPresentation presentation = Factory.CreatePresentationReader().ReadAt(folderBrowser.SelectedPath);

                if (presentation != null)
                {
                    Resource.FileName = Path.GetFileName(folderBrowser.SelectedPath);
                    Resource.SaveLocation = folderBrowser.SelectedPath.Replace(Resource.FileName, "");

                    Resource.Presentation = presentation;

                    var window = new PresentationEditor(presentation);
                    window.Show();

                    Close();
                }
                else
                {
                    System.Windows.MessageBox.Show("Failed to read presentation");
                }
            }
        }

        private void NewButtonHover_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            NewButton.Background = new SolidColorBrush(Color.FromArgb(255, 39, 206, 42));
        }

        private void NewButtonHover_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            NewButton.Background = new SolidColorBrush(Color.FromArgb(255, 2, 142, 5));
        }

        private void OpenButton_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            OpenButton.Background = new SolidColorBrush(Color.FromArgb(255, 39, 206, 42));
        }

        private void OpenButton_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            OpenButton.Background = new SolidColorBrush(Color.FromArgb(255, 2, 142, 5));
        }
    }
}
