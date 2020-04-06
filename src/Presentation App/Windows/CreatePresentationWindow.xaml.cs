using Presentation_App;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Media;

namespace Presentation_App
{
    /// <summary>
    /// Interaction logic for CreatePresentationWindow.xaml
    /// </summary>
    public partial class CreatePresentationWindow : Window
    {
        IPresentation presentation;

        public CreatePresentationWindow(IPresentation presentation)
        {
            InitializeComponent();

            this.presentation = presentation;

            UpdateDisplay();
        }

        void UpdateDisplay()
        {
            PresentationNameTextBox.Text = presentation.Name;

            PreivewTitleColor.Foreground = new SolidColorBrush(presentation.Style.TitleColor);
            PreivewTextColor.Foreground = new SolidColorBrush(presentation.Style.TextColor);
            PreivewBackgroundColor.Background = new SolidColorBrush(presentation.Style.BackgroundColor);
        }

        #region Helper Functions

        Color PickColor()
        {
            var colorDialog = new ColorDialog();
            colorDialog.ShowDialog();

            Color color = Color.FromArgb(colorDialog.Color.A, colorDialog.Color.R, colorDialog.Color.G, colorDialog.Color.B);

            return color;
        }

        #endregion

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            var dashBoardWindow = new DashboardWindow();
            dashBoardWindow.Show();

            Close();
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            var presentationEditor = new PresentationEditor(presentation);
            presentationEditor.Show();

            Close();
        }

        private void TextColorPickerButton_Click(object sender, RoutedEventArgs e)
        {
            Color colorPicked = PickColor();

            presentation.Style.TextColor = colorPicked;

            PreivewTextColor.Foreground = new SolidColorBrush(colorPicked);

            TextColorPickerButton.Foreground = new SolidColorBrush(colorPicked);
        }

        private void TilteColorPickerButton_Click(object sender, RoutedEventArgs e)
        {
            Color colorPicked = PickColor();

            presentation.Style.TitleColor = colorPicked;

            PreivewTitleColor.Foreground = new SolidColorBrush(colorPicked);

            TitleColorPickerButton.Foreground = new SolidColorBrush(colorPicked);
        }

        private void BackgroundColorPickerButton_Click(object sender, RoutedEventArgs e)
        {
            Color colorPicked = PickColor();

            presentation.Style.BackgroundColor = colorPicked;

            PreivewBackgroundColor.Background = new SolidColorBrush(colorPicked);

            BackgroundColorPickerButton.Foreground = new SolidColorBrush(colorPicked);
        }

        private void PresentationNameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (presentation != null)
                presentation.Name = PresentationNameTextBox.Text;
        }

        private void QuestionPerSlideComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (presentation != null)
            {
                int selected = QuestionPerSlideComboBox.SelectedIndex;
                if (selected == 0)
                    presentation.Template.ChoiceAmount = 2;
                if (selected == 1)
                    presentation.Template.ChoiceAmount = 3;
                if (selected == 2)
                    presentation.Template.ChoiceAmount = 4;
            }
        }

        private void MusicPickerButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();

            fileDialog.Multiselect = false;
            fileDialog.Title = "Select Music";

            fileDialog.Filter = Resource.AUDIO_FILTER;

            if (fileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                presentation.Audio.Music.Name = fileDialog.SafeFileName;

                string savePath = Path.Combine(Resource.GetAudioFolderPath(), fileDialog.SafeFileName);

                File.Copy(fileDialog.FileName, savePath, true);

                MusicPickerButton.Content = fileDialog.SafeFileName;
            }
            else
            {
                return;
            }
        }

        private void CorrectSFXPickerButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();

            fileDialog.Multiselect = false;
            fileDialog.Title = "Select Correct SFX";

            fileDialog.Filter = Resource.AUDIO_FILTER;

            if (fileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                presentation.Audio.Answer.Name = fileDialog.SafeFileName;

                string savePath = Path.Combine(Resource.GetAudioFolderPath(), fileDialog.SafeFileName);

                File.Copy(fileDialog.FileName, savePath, true);

                CorrectSFXPickerButton.Content = fileDialog.SafeFileName;
            }
            else
            {
                return;
            }
        }
    }
}