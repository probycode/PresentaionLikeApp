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
using Presentation_App;

namespace Presentation_App
{
    /// <summary>
    /// Interaction logic for ChoiceDisplayControl.xaml
    /// </summary>
    public partial class ChoiceDisplayControl : UserControl, IChoiceDisplay
    {
        IPresentation presentation;
        IChoice choice;
        ChoiceStyle choiceStyle;

        public ChoiceDisplayControl()
        {
            InitializeComponent();
        }

        public void Highlight()
        {
            mainBorder.BorderBrush = new SolidColorBrush(presentation.Style.AnswerHighLightColor);
        }

        public void Initailize(IPresentation presentation, IChoice choice)
        {
            this.presentation = presentation;
            this.choice = choice;

            UpdateDisplay();
        }

        public void UpdateDisplay()
        {
            ChoiceTextBox.Text = choice.ChoiceText;
            ChoiceLetterText.Text = choice.ChoiceLetter.ToString();
            ChoiceTextBox.FontSize = choice.ChoiceTextFontSize;

            ChoiceTextBox.Foreground = new SolidColorBrush(presentation.Style.TextColor);
        }

        public void SetChoiceStyle(ChoiceStyle choiceStyle)
        {
            this.choiceStyle = choiceStyle;

            ChoiceSelectButton.Background = choiceStyle.SecondaryColor;
            ChoiceSelectButton.BorderBrush = choiceStyle.PrimaryColor;

            ChoiceLetterText.Foreground = choiceStyle.PrimaryColor;
        }
    }
}
