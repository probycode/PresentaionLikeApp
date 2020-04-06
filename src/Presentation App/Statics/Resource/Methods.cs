using Presentation_App;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;

namespace Presentation_App
{
    public static partial class Resource
    {
        public static string GetImageFolderPath()
        {
            string path = Path.Combine(SaveLocation, FileName, IMAGE_FOLDER_NAME);

            return path;
        }

        public static string GetAudioFolderPath()
        {
            string path = Path.Combine(SaveLocation, FileName, AUDIO_FOLDER_NAME);

            return path;
        }

        public static string GetDefaultAudioFolderPath()
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), DEFAULT_AUDIO_FOLDER_NAME);

            return path;
        }

        public static void CreateApplicationFolders()
        {
            string dir = Directory.GetCurrentDirectory();
            string DefaultAudioFolder = Path.Combine(dir, DEFAULT_AUDIO_FOLDER_NAME);

            if (Directory.Exists(DefaultAudioFolder) == false)
            {
                Directory.CreateDirectory(DefaultAudioFolder);
            }
        }

        public static void LoadAudioPlayers()
        {
            AudioPlayers.Add(MusicAudioPlayer);
            AudioPlayers.Add(QuestionAudioPlayer);
            AudioPlayers.Add(AnswerAudioPlayer);
            AudioPlayers.Add(EndAudioPlayer);

            //Load Music 
            if (String.IsNullOrEmpty(Presentation.Audio.Music.Name) == false)
            {
                string audio = Path.Combine(GetAudioFolderPath(), Presentation.Audio.Music.Name);
                MusicAudioPlayer.Load(audio);
            }

            //Load Question SFX
            if (String.IsNullOrEmpty(Presentation.Audio.Question.Name))
            {
                string audio = Path.Combine(GetDefaultAudioFolderPath(), DEFAULT_QUESTION_SOUND);

                QuestionAudioPlayer.Load(audio);
            }
            else
                QuestionAudioPlayer.Load(Path.Combine(GetAudioFolderPath(), Presentation.Audio.Question.Name));

            //Load Answer SFX
            if (String.IsNullOrEmpty(Presentation.Audio.Answer.Name))
            {
                string audio = Path.Combine(GetDefaultAudioFolderPath(), DEFAULT_ANSWER_SOUND);

                AnswerAudioPlayer.Load(audio);
            }
            else
                AnswerAudioPlayer.Load(Path.Combine(GetAudioFolderPath(), Presentation.Audio.Answer.Name));

            //Load End SFX
            if (String.IsNullOrEmpty(Presentation.Audio.End.Name))
            {
                string audio = Path.Combine(GetDefaultAudioFolderPath(), DEFAULT_END_SOUND);

                EndAudioPlayer.Load(audio);
            }
            else
                EndAudioPlayer.Load(Path.Combine(GetAudioFolderPath(), Presentation.Audio.End.Name));
        }

        public static void CloseAudioPlayers()
        {
            foreach (var player in AudioPlayers)
            {
                player.Close();
            }
        }

        public static List<ChoiceStyle> GetChoiceColors()
        {
            List<ChoiceStyle> choiceStyles = new List<ChoiceStyle>();

            //Color1
            ChoiceStyle color1 = new ChoiceStyle();

            color1.PrimaryColor = new SolidColorBrush(Color.FromRgb(106, 206, 92));
            color1.SecondaryColor = new SolidColorBrush(Color.FromRgb(196, 255, 188));

            choiceStyles.Add(color1);

            //Color2
            ChoiceStyle color2 = new ChoiceStyle();

            color2.PrimaryColor = new SolidColorBrush(Color.FromRgb(255, 0, 0));
            color2.SecondaryColor = new SolidColorBrush(Color.FromRgb(224, 176, 161));

            choiceStyles.Add(color2);

            //Color3
            ChoiceStyle color3 = new ChoiceStyle();

            color3.PrimaryColor = new SolidColorBrush(Color.FromRgb(0, 47, 158));
            color3.SecondaryColor = new SolidColorBrush(Color.FromRgb(175, 199, 255));

            choiceStyles.Add(color3);

            //Color2
            ChoiceStyle color4 = new ChoiceStyle();

            color4.PrimaryColor = new SolidColorBrush(Color.FromRgb(255, 0, 223));
            color4.SecondaryColor = new SolidColorBrush(Color.FromRgb(255, 181, 246));

            choiceStyles.Add(color4);

            return choiceStyles;
        }

        public static List<string> GetDirectories(string path, string searchPattern = "*", SearchOption searchOption = SearchOption.TopDirectoryOnly)
        {
            if (searchOption == SearchOption.TopDirectoryOnly)
                return Directory.GetDirectories(path, searchPattern).ToList();

            var directories = new List<string>(GetDirectories(path, searchPattern));

            for (var i = 0; i < directories.Count; i++)
                directories.AddRange(GetDirectories(directories[i], searchPattern));

            return directories;
        }

        public static List<string> GetFilesAtFolder(string path, List<string> extensions)
        {
            List<string> paths = new List<string>();

            IEnumerable<string> info = Directory.EnumerateFiles(path, "*.*", SearchOption.AllDirectories)
                .Where((s) =>
                {
                    foreach (var extension in extensions)
                    {
                        if (s.EndsWith(extension))
                        {
                            return s.EndsWith(extension);
                        }
                    }
                    return false;
                });

            foreach (var f in info)
            {
                paths.Add(f);
            }

            return paths;
        }

        public static string GetRootPath()
        {
            string root = string.Empty;

            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();

            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                root = folderBrowserDialog.SelectedPath;
                return root;
            }

            return null;
        }

        public static List<string> GetImageExtensons()
        {
            List<string> output = new List<string>
            {
                "png",
                "PNG",
                "bmp",
                "BMP",
                "jpg",
                "JPG",
                "jpeg",
                "JPEG",
                "gif",
                "GIF"
            };

            return output;
        }
    }
}