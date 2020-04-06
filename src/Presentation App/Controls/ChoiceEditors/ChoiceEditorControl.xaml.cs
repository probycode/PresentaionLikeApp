using Presentation_App;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Presentation_App
{
    /// <summary>
    /// Interaction logic for ChoiceEditorControl.xaml
    /// </summary>
    public partial class ChoiceEditorControl : UserControl , IChoiceEditor
    {
        public char SelectedChoice { get; set; }
        IPresentation presentation;
        IChoice Choice;
        ChoiceStyle choiceStyle;

        public event EventHandler<IChoiceEditor> OnChoiceSelected;

        public ChoiceEditorControl()
        {
            InitializeComponent();
        }

        public void Initailize(IPresentation presentation, IChoice choice, char CorrectLetter)
        {
            this.presentation = presentation;
            Choice = choice;

            UpdateEditor(CorrectLetter);
        }

        public void UpdateEditor(char CorrectLetter)
        {
            ChoiceTextBox.Text = Choice.ChoiceText;
            ChoiceLetterText.Text = Choice.ChoiceLetter.ToString();
            ChoiceTextBox.FontSize = Choice.ChoiceTextFontSize;

            ChoiceTextBox.Foreground = new SolidColorBrush(presentation.Style.TextColor);

            UpdateSelected(CorrectLetter);
        }

        public void UpdateSelected(char letter)
        {
            if (Choice.ChoiceLetter == letter)
            {
                mainBorder.BorderBrush = new SolidColorBrush(presentation.Style.AnswerHighLightColor);
            }
            else
            {
                mainBorder.BorderBrush = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0));
            }
        }

        public void Reset()
        {
            mainBorder.BorderBrush = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0));
        }

        private void ChoiceSelectButton_Click(object sender, RoutedEventArgs e)
        {
            SelectedChoice = Choice.ChoiceLetter;
            OnChoiceSelected?.Invoke(this, this);

            UpdateEditor(SelectedChoice);
        }

        private void ChoiceTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Choice != null)
            {
                Choice.ChoiceText = ChoiceTextBox.Text;
            }
        }

        public void SetChoiceStyle(ChoiceStyle choiceStyle)
        {
            this.choiceStyle = choiceStyle;

            ChoiceSelectButton.Background = choiceStyle.SecondaryColor;
            ChoiceSelectButton.BorderBrush = choiceStyle.PrimaryColor;

            ChoiceLetterText.Foreground = choiceStyle.PrimaryColor;
        }

        private void ChoiceTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            var labelInspector = Factory.GetLabelInspectorContol(ChoiceTextBox, $"Choice {Choice.ChoiceLetter}");
            labelInspector.OnChanged += LabelInspector_ChoiceText_OnChanged;

            PresentationEditor.OnSelectedItem(labelInspector, ChoiceTextBox);

            if (ChoiceTextBox.Text == Resource.DEFAULT_INPUTFIELD_TEXT)
                ChoiceTextBox.Clear();
        }

        private void ChoiceTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(ChoiceTextBox.Text))
            {
                ChoiceTextBox.Text = Resource.DEFAULT_INPUTFIELD_TEXT;
            }
        }

        private void LabelInspector_ChoiceText_OnChanged(object sender, EventArgs e)
        {
            var s = (LabelInspectorContol)sender;
            ChoiceTextBox.FontSize = s.SelectedFontSize;
            Choice.ChoiceTextFontSize = s.SelectedFontSize;
        }

    }
}