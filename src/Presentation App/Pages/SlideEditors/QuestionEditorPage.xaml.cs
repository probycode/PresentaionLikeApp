using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Presentation_App
{
    /// <summary>
    /// Interaction logic for QuestionEditorPage.xaml
    /// </summary>
    public partial class QuestionEditorPage : Page, ISlideEditor
    {
        public event EventHandler SlideUpdated;

        IPresentation Presentation { get; set; }
        IQuestionSlide quastionSlide { get; set; }

        List<IChoiceEditor> ChoiceEditors;

        private char lastChoiceLetter;
        private byte row;

        public QuestionEditorPage()
        {
            InitializeComponent();
        }

        public void Initailize(IPresentation presentation, ISlide slide)
        {
            Presentation = presentation;

            //Reset since object is not displosed
            Reset();

            quastionSlide = (IQuestionSlide)slide;

            SetUpGrid();

            UpdateEditor();

            if (quastionSlide.Choices.Count > 0)
            {
                for (int i = 0; i < quastionSlide.Choices.Count; i++)
                {
                    AddChoice(quastionSlide.Choices[i]);
                }
            }
            else
            {
                for (int i = 0; i < presentation.Template.ChoiceAmount; i++)
                {
                    AddChoice();
                }
            }
        }

        public void SetUpGrid()
        {
            var converter = new GridLengthConverter();

            //Quick visual fix
            int amount = Presentation.Template.ChoiceAmount;

            if (amount == 2)
                amount = 3;

            for (int i = 0; i < amount; i++)
            {
                var row = new RowDefinition
                {
                    Height = (GridLength)converter.ConvertFromString("*")
                };

                SlideChoiceGrid.RowDefinitions.Add(row);
            }
        }

        public void UpdateEditor()
        {
            SlideContent.Text = quastionSlide.Content;
            SlideContent.FontSize = quastionSlide.ContentFontSize;

            SlideContent.Foreground = new SolidColorBrush(Presentation.Style.TextColor);

            //Set Slide Image
            if (string.IsNullOrEmpty(quastionSlide.Image) == false)
            {
                SlideImage.Source = Presentation.GetImage(quastionSlide.Image);
            }
        }

        public void Reset()
        {
            quastionSlide = null;

            SlideChoiceGrid.Children.Clear();

            ChoiceEditors = new List<IChoiceEditor>();
            lastChoiceLetter = 'A';
            row = 0;

            SlideChoiceGrid.RowDefinitions.Clear();
        }

        private void AddChoice(IChoice choice = null)
        {
            if (choice == null)
            {
                choice = Factory.CreateChoice();
                choice.ChoiceLetter = lastChoiceLetter++;

                quastionSlide.Choices.Add(choice);
            }

            IChoiceEditor choiceEditor = choice.OnEditorGUI();
            choiceEditor.Initailize(Presentation, choice, quastionSlide.CorrectChoice);
            choiceEditor.SetChoiceStyle(Resource.GetChoiceColors()[row]);

            ChoiceEditors.Add(choiceEditor);

            choiceEditor.OnChoiceSelected += ChoiceEditor_OnChoiceSelected;

            var choiceEditorControl = (Control)choiceEditor;
            choiceEditorControl.Margin = new Thickness(0, 0, 0, 25);

            //Add To grid
            SlideChoiceGrid.Children.Add(choiceEditorControl);
            Grid.SetRow(choiceEditorControl, row);
            row++;

            SlideUpdated?.Invoke(this, EventArgs.Empty);
        }

        private void ChoiceEditor_OnChoiceSelected(object sender, IChoiceEditor e)
        {
            foreach (var editor in ChoiceEditors)
            {
                editor.UpdateSelected(e.SelectedChoice);
            }

            quastionSlide.CorrectChoice = e.SelectedChoice;
        }

        private void SlideContent_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(quastionSlide != null)
             quastionSlide.Content = SlideContent.Text;
        }

        private void SlideImage_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            var command = new ReadImageToPresentationCommand();

            Action<IImageReader> action = (imageReader) => {
                quastionSlide.Image = imageReader.ImageName;
                SlideImage.Source = imageReader.Image;
            };

            command.Execute(Presentation, action);

            SlideUpdated?.Invoke(this, EventArgs.Empty);
        }

        private void SlideContent_GotFocus(object sender, RoutedEventArgs e)
        {
            var labelInspector = Factory.GetLabelInspectorContol(SlideContent, "Question Text");
            labelInspector.OnChanged += LabelInspector_SlideContent_OnChanged;

            PresentationEditor.OnSelectedItem(labelInspector, SlideContent);

            if (SlideContent.Text == Resource.DEFAULT_INPUTFIELD_TEXT)
                SlideContent.Clear();
        }

        private void SlideContent_LostFocus(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(SlideContent.Text))
            {
                SlideContent.Text = Resource.DEFAULT_INPUTFIELD_TEXT;
            }
        }

        private void LabelInspector_SlideContent_OnChanged(object sender, EventArgs e)
        {
            var s = (LabelInspectorContol)sender;
            SlideContent.FontSize = s.SelectedFontSize;
            quastionSlide.ContentFontSize = s.SelectedFontSize;
        }
    }
}
