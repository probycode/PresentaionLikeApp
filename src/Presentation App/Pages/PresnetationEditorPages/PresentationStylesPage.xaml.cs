using Presentation_App;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Media;

namespace Presentation_App
{
    /// <summary>
    /// Interaction logic for PresentationColorsPage.xaml
    /// </summary>
    public partial class PresentationStylesPage : Page, IPresentationEditor
    {
        public event EventHandler OnNextPage;
        public event EventHandler OnBackPage;

        IPresentation presentation;

        public PresentationStylesPage(IPresentation presentation)
        {
            InitializeComponent();
            this.presentation = presentation;

            UpdateEditor();
        }

        public void UpdateEditor()
        {
            var TextColor = new SolidColorBrush(presentation.Style.TextColor);
            var TitleColor = new SolidColorBrush(presentation.Style.TitleColor);
            var BackgroundColor = new SolidColorBrush(presentation.Style.BackgroundColor);
            var AnswerHighLightColor = new SolidColorBrush(presentation.Style.AnswerHighLightColor);

            //Buttons
            TextColorPickerButton.Background = TextColor;
            TitleColorPickerButton.Background = TitleColor;
            BackgroundColorPickerButton.Background = BackgroundColor;
            AnswerColorPickerButton.Background = AnswerHighLightColor;

            //Preivew
            PreivewTextColor.Foreground = TextColor;
            PreivewTitleColor.Foreground = TitleColor;
            PreivewBackgroundColor.Background = BackgroundColor;
            ChoiceBorder.BorderBrush = AnswerHighLightColor;
        }

        private void TextColorPickerButton_Click(object sender, RoutedEventArgs e)
        {
            var command = new ReadColorCommand();

            Action<Color> action = c =>
            {
                presentation.Style.TextColor = c;

                TextColorPickerButton.Background = new SolidColorBrush(c);
                PreivewTextColor.Foreground = new SolidColorBrush(c);
            };

            command.Execute(action);
        }

        private void TilteColorPickerButton_Click(object sender, RoutedEventArgs e)
        {
            var command = new ReadColorCommand();

            Action<Color> action = c =>
            {
                presentation.Style.TitleColor = c;

                TitleColorPickerButton.Background = new SolidColorBrush(c);
                PreivewTitleColor.Foreground = new SolidColorBrush(c);
            };

            command.Execute(action);
        }

        private void BackgroundColorPickerButton_Click(object sender, RoutedEventArgs e)
        {
            var command = new ReadColorCommand();

            Action<Color> action = c =>
            {
                presentation.Style.BackgroundColor = c;

                BackgroundColorPickerButton.Background = new SolidColorBrush(c);
                PreivewBackgroundColor.Background = new SolidColorBrush(c);
            };

            command.Execute(action);
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            var presentationEditor = new PresentationEditor(presentation);
            presentationEditor.Show();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            OnBackPage?.Invoke(this, EventArgs.Empty);
        }

        private void AnswerColorPickerButton_Click(object sender, RoutedEventArgs e)
        {
            var command = new ReadColorCommand();

            Action<Color> action = c =>
            {
                presentation.Style.AnswerHighLightColor = c;

                AnswerColorPickerButton.Background = new SolidColorBrush(c);
                ChoiceBorder.BorderBrush = new SolidColorBrush(c);
            };

            command.Execute(action);
        }
    }
}
