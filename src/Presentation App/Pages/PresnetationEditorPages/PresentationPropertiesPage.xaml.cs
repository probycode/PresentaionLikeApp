using Presentation_App;
using System;
using System.Windows.Controls;

namespace Presentation_App
{
    /// <summary>
    /// Interaction logic for PresentationPropertiesPage.xaml
    /// </summary>
    public partial class PresentationPropertiesPage : Page, IPresentationEditor
    {
        public event EventHandler OnNextPage;
        public event EventHandler OnBackPage;

        IPresentation presentation;

        public PresentationPropertiesPage(IPresentation presentation)
        {
            InitializeComponent();
            this.presentation = presentation;

            UpdateEditor();
        }

        public void UpdateEditor()
        {
            PresentationNameTextBox.Text = presentation.Name;
            QuestionPerSlideComboBox.SelectedIndex = presentation.Template.ChoiceAmount - 2;
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

        private void NextButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            OnNextPage?.Invoke(this, EventArgs.Empty);
        }

        private void BackButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {

        }
    }
}
