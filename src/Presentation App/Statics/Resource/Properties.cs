using Presentation_App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation_App
{
    public static partial class Resource
    {
        public static IPresentation Presentation { get; set; }

        public static string FileName { get; set; }
        public static string SaveLocation { get; set; }

        public static List<AudioPlayer> AudioPlayers { get; set; } = new List<AudioPlayer>();

        public static AudioPlayer MusicAudioPlayer { get; set; } = new AudioPlayer();
        public static AudioPlayer AnswerAudioPlayer { get; set; } = new AudioPlayer();
        public static AudioPlayer QuestionAudioPlayer { get; set; } = new AudioPlayer();
        public static AudioPlayer EndAudioPlayer { get; set; } = new AudioPlayer();
    }
}