using System;
using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace Presentation_App
{
    public class PresentationJSONWriter : IPresentationWriter
    {
        public bool Canceled { get; set; }

        public void Write(IPresentation presentation, string path, string FileName)
        {
            string CurrentPresentationFolder = Path.Combine(path, FileName);
            string ImageFolder = Path.Combine(CurrentPresentationFolder, Resource.IMAGE_FOLDER_NAME);
            string AudioFolder = Path.Combine(CurrentPresentationFolder, Resource.AUDIO_FOLDER_NAME);

            //Create Folders
            if (File.Exists(CurrentPresentationFolder) == false)
            {
                Directory.CreateDirectory(CurrentPresentationFolder);
            }
            if (File.Exists(ImageFolder) == false)
            {
                Directory.CreateDirectory(ImageFolder);
            }
            if (File.Exists(AudioFolder) == false)
            {
                Directory.CreateDirectory(AudioFolder);
            }

            string pathString = Path.Combine(CurrentPresentationFolder, FileName);

            WriteJSON(presentation, CurrentPresentationFolder, FileName);

            //WriteImages(CurrentPresentationFolder, presentation);
        }

        public string WriteAt(IPresentation presentation, string FileName)
        {
            FolderBrowserDialog folderBrowser = new FolderBrowserDialog();

            folderBrowser.ShowNewFolderButton = false;
            folderBrowser.Description = "Presenetation Save Location";

            if (folderBrowser.ShowDialog() == DialogResult.OK)
            {
                Write(presentation, folderBrowser.SelectedPath, FileName);
                return folderBrowser.SelectedPath;
            }
            else
            {
                Canceled = true;
                return null;
            }
        }

        /*private void WriteImages (string presentaionFolder, IPresentation presentation)
        {
            string path = Path.Combine(presentaionFolder, Resource.IMAGE_FOLDER_NAME);

            foreach (var i in presentation.GetImages())
            {
                path = Path.Combine(presentaionFolder, Resource.IMAGE_FOLDER_NAME, i.Key);

                if (File.Exists(path) == false)
                {
                    BitmapEncoder encoder = new PngBitmapEncoder();
                    encoder.Frames.Add(BitmapFrame.Create(i.Value));

                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        encoder.Save(fileStream);
                    }
                }
            }
        }*/

        private static void WriteJSON(IPresentation objectToJson, string folderPath, string fileName)
        {
            string fullPath = folderPath + @"\" + fileName + ".json";

            using (StreamWriter file = File.CreateText(fullPath))
            {
                JsonSerializerSettings settings = new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.All
                };

                string jsonString = JsonConvert.SerializeObject(objectToJson, settings);
                file.Write(jsonString);
            }

            Console.WriteLine("Saved Successeful");
        }
    }
}
