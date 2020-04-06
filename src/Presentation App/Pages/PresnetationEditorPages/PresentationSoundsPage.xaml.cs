using Presentation_App;
using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;

namespace Presentation_App
{
    /// <summary>
    /// Interaction logic for PresentationSoundsPage.xaml
    /// </summary>
    public partial class PresentationSoundsPage : Page, IPresentationEditor
    {
        public event EventHandler OnNextPage;
        public event EventHandler OnBackPage;

        IPresentation presentation;

        public PresentationSoundsPage(IPresentation presentation)
        {
            InitializeComponent();
            this.presentation = presentation;

            UpdateEditor();
        }

        public void UpdateEditor()
        {
            //Audio Pickers
            if (String.IsNullOrEmpty(presentation.Audio.Music.Name))
                MusicPickerButton.Content = "Defualt";
            else
                MusicPickerButton.Content = presentation.Audio.Music;

            if (String.IsNullOrEmpty(presentation.Audio.Answer.Name))
                AnswerPickerButton.Content = "Defualt";
            else
                AnswerPickerButton.Content = presentation.Audio.Answer;

            if (String.IsNullOrEmpty(presentation.Audio.Question.Name))
                QuestionPickerButton.Content = "Defualt";
            else
                QuestionPickerButton.Content = presentation.Audio.Question;

            if (String.IsNullOrEmpty(presentation.Audio.End.Name))
                EndPickerButton.Content = "Defualt";
            else
                EndPickerButton.Content = presentation.Audio.End;

            //Audio Volume
            MusicVolume.Value = presentation.Audio.Music.Volume;
            MusicVolumeText.Text = Format(presentation.Audio.Music.Volume);

            QuestionVolume.Value = presentation.Audio.Question.Volume;
            QuestionVolumeText.Text = Format(presentation.Audio.Question.Volume);

            AnwserVolume.Value = presentation.Audio.Answer.Volume;
            AnwserVolumeText.Text = Format(presentation.Audio.Answer.Volume);

            EndVolume.Value = presentation.Audio.End.Volume;
            EndVolumeText.Text = Format(presentation.Audio.End.Volume);
        }

        private string Format(double num)
        {
            string output = num.ToString(".0");
            output = output.Replace(".", "");
            return output;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            OnBackPage?.Invoke(this, EventArgs.Empty);
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            OnNextPage?.Invoke(this, EventArgs.Empty);
        }

        #region SFX Pickers

        private void MusicPickerButton_Click(object sender, RoutedEventArgs e)
        {
            var command = new ReadAudioToPresentationCommand();

            Action<OpenFileDialog> action = ofd => {
                MusicPickerButton.Content = ofd.SafeFileName;
                presentation.Audio.Music.Name = ofd.SafeFileName;
            };

            command.Execute(presentation, action, "Selected Music");
        }

        private void AnswerPickerButton_Click(object sender, RoutedEventArgs e)
        {
            var command = new ReadAudioToPresentationCommand();

            Action<OpenFileDialog> action = ofd => {
                AnswerPickerButton.Content = ofd.SafeFileName;
                presentation.Audio.Answer.Name = ofd.SafeFileName;
            };

            command.Execute(presentation, action, "Selected Answer SFX");
        }

        private void QuestionPickerButton_Click(object sender, RoutedEventArgs e)
        {
            var command = new ReadAudioToPresentationCommand();

            Action<OpenFileDialog> action = ofd => {
                QuestionPickerButton.Content = ofd.SafeFileName;
                presentation.Audio.Question.Name = ofd.SafeFileName;
            };

            command.Execute(presentation, action, "Selected Question SFX");
        }

        private void EndPickerButton_Click(object sender, RoutedEventArgs e)
        {
            var command = new ReadAudioToPresentationCommand();

            Action<OpenFileDialog> action = ofd => {
                EndPickerButton.Content = ofd.SafeFileName;
                presentation.Audio.End.Name = ofd.SafeFileName;
            };

            command.Execute(presentation, action, "Selected End SFX");
        }

        #endregion

        #region Clear

        private void ClearEndPickerButton_Click(object sender, RoutedEventArgs e)
        {
            presentation.Audio.Music.Name = string.Empty;
            EndPickerButton.Content = "Non Selected";
        }

        private void ClearMusicPickerButton_Click(object sender, RoutedEventArgs e)
        {
            presentation.Audio.Music.Name = string.Empty;
            MusicPickerButton.Content = "Non Selected";
        }

        private void ClearAnswerPickerButton_Click(object sender, RoutedEventArgs e)
        {
            presentation.Audio.Answer.Name = string.Empty;
            AnswerPickerButton.Content = "Non Selected";
        }

        private void ClearQuestionPickerButton_Click(object sender, RoutedEventArgs e)
        {
            presentation.Audio.Question.Name = string.Empty;
            QuestionPickerButton.Content = "Non Selected";
        }

        #endregion

        #region Vomlume Changed

        private void MusicVolume_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Resource.MusicAudioPlayer.SetVolume(e.NewValue);
            MusicVolumeText.Text = Format(e.NewValue);
            presentation.Audio.Music.Volume = e.NewValue;
        }

        private void QuestionVolume_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Resource.QuestionAudioPlayer.SetVolume(e.NewValue);
            QuestionVolumeText.Text = Format(e.NewValue);
            presentation.Audio.Question.Volume = e.NewValue;
        }

        private void AnwserVolume_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Resource.AnswerAudioPlayer.SetVolume(e.NewValue);
            AnwserVolumeText.Text = Format(e.NewValue);
            presentation.Audio.Answer.Volume = e.NewValue;
        }

        private void EndVolume_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Resource.EndAudioPlayer.SetVolume(e.NewValue);
            EndVolumeText.Text = Format(e.NewValue);
            presentation.Audio.End.Volume = e.NewValue;
        }

        #endregion
    }
}
