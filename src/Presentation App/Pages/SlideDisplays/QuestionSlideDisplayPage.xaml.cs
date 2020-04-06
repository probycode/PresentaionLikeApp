using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Presentation_App;

namespace Presentation_App
{
    /// <summary>
    /// Interaction logic for QuestionSlideDisplayPage.xaml
    /// </summary>
    public partial class QuestionSlideDisplayPage : Page, ISlideDisplay
    {
        IPresentation presentation;
        IQuestionSlide questionSlide;

        IChoiceDisplay correctChoiceDisplay;

        private byte row = 0;

        public QuestionSlideDisplayPage()
        {
            InitializeComponent();
        }

        public void Initailize(IPresentation presentation, ISlide slide)
        {
            this.presentation = presentation;
            this.questionSlide = (IQuestionSlide)slide;

            // B/c this slide is not desposed
            Reset();

            SetUpGrid();

            UpdateDisplay();

            foreach (var choice in questionSlide.Choices)
            {
                AddChoice(choice);
            }
        }

        public void UpdateDisplay()
        {
            if (questionSlide.Content != Resource.DEFAULT_INPUTFIELD_TEXT)
                SlideContent.Text = questionSlide.Content;
            else
                SlideContent.Text = string.Empty;

            SlideContent.FontSize = questionSlide.ContentFontSize;

            SlideContent.Foreground = new SolidColorBrush(presentation.Style.TextColor);

            //Set Slide Image
            if (string.IsNullOrEmpty(questionSlide.Image) == false)
            {
                SlideImage.Source = presentation.GetImage(questionSlide.Image);
            }

            Resource.QuestionAudioPlayer.PlayOnce();
        }

        private void AddChoice(IChoice choice)
        {
            IChoiceDisplay choiceDisplay = choice.OnDisplayGUI();
            choiceDisplay.Initailize(presentation, choice);
            choiceDisplay.SetChoiceStyle(Resource.GetChoiceColors()[row]);

            var choiceDisplayControl = (Control)choiceDisplay;
            choiceDisplayControl.Margin = new Thickness(0, 10, 0, 10);

            //Add To grid
            SlideChoiceGrid.Children.Add(choiceDisplayControl);
            Grid.SetRow(choiceDisplayControl, row);
            row++;

            if (choice.ChoiceLetter == questionSlide.CorrectChoice)
            {
                correctChoiceDisplay = choiceDisplay;
            }
        }

        public void SetUpGrid()
        {
            var converter = new GridLengthConverter();

            for (int i = 0; i < 4; i++)
            {
                var row = new RowDefinition
                {
                    Height = (GridLength)converter.ConvertFromString("*")
                };

                SlideChoiceGrid.RowDefinitions.Add(row);
            }
        }

        public void DoAction(int action)
        {
            if(action == 0)
            {
                ShowAnswer();
            }
        }

        public void ShowAnswer()
        {
            if (correctChoiceDisplay != null)
            {
                correctChoiceDisplay.Highlight();
            }

            Resource.AnswerAudioPlayer.PlayOnce();
        }

        public void Reset()
        {
            SlideChoiceGrid.Children.Clear();
            SlideChoiceGrid.RowDefinitions.Clear();
            SlideChoiceGrid.ColumnDefinitions.Clear();

            row = 0;

            Resource.AnswerAudioPlayer.Stop();
            Resource.QuestionAudioPlayer.Stop();
        }
    }
}
