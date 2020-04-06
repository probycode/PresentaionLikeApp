using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation_App
{
    public static partial class Resource
    {
        public const string PRESENTATION_FOLDER_NAME = "Presentation";
        public const string IMAGE_FOLDER_NAME = "Images";
        public const string AUDIO_FOLDER_NAME = "Audio";

        public const string IMAGE_FILTER = "Image Files(*.BMP;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG|All files (*.*)|*.*";
        public const string AUDIO_FILTER = "Files|*.mp3;*.wav;*.wmp;*.ogg;*.mp4;*.wma";

        public const int CHOICE_MARGIN_LEFT = 50;
        public const int CHOICE_MARGIN_TOP = 10;
        public const int CHOICE_MARGIN_RIGHT = 50;
        public const int CHOICE_MARGIN_BOTTOM = 10;

        public const string DEFAULT_AUDIO_FOLDER_NAME = "Default_Audio";

        public const string DEFAULT_ANSWER_SOUND = "Defualt_Answer_Sound.wav";
        public const string DEFAULT_QUESTION_SOUND = "Defualt_Question_Sound.wav";
        public const string DEFAULT_END_SOUND = "Defualt_End_Sound.wav";

        public const string DEFAULT_INPUTFIELD_TEXT = "Click to edit text";
    }
}