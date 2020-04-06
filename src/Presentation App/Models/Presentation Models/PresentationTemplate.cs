using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Resources;

namespace Presentation_App
{
    public class PresentationTemplate
    {
        public int ChoiceAmount { get; set; } = 2;

        public void Use(IPresentation presentation)
        {
            presentation.Name = "New Presentation";

            LoadDefualtColors(presentation);
            LoadDefualtSFX(presentation);
        }

        public void LoadDefualtColors(IPresentation presentation)
        {
            presentation.Style.BackgroundColor = Color.FromArgb(255, 255, 239, 186);
            presentation.Style.TitleColor = Color.FromArgb(255, 0, 0, 0);
            presentation.Style.TextColor = Color.FromArgb(255, 0, 0, 0);
            presentation.Style.AnswerHighLightColor = Color.FromArgb(255, 38, 109, 0);
        }

        public void LoadDefualtSFX(IPresentation presentation)
        {
            //presentation.Audio.Answer = "Defualt_Answer_Sound.mp3";
            //presentation.Audio.Question = "Defualt_Question_Sound.mp3";
        }
    }
}
