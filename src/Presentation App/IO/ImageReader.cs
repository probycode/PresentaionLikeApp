using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Windows.Media.Imaging;

namespace Presentation_App
{
    public class ImageReader : IImageReader
    {
        public string ImageName { get; set; }
        public string ImagePath { get; set; }
        public BitmapImage Image { get; set; }

        public BitmapImage Read()
        {
            OpenFileDialog op = new OpenFileDialog
            {
                Title = "Select a picture",
                Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
                        "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
                        "Portable Network Graphic (*.png)|*.png"
            };

            op.ShowDialog();

            if(string.IsNullOrEmpty(op.FileName) == false)
            {
                Image = new BitmapImage(new Uri(op.FileName));
                ImageName = op.SafeFileName;
                ImagePath = op.FileName;

                return Image;
            }

            return null;
        }

        public Dictionary<string, BitmapImage> ReadAll(string imageFolder)
        {
            Dictionary<string, BitmapImage> output = new Dictionary<string, BitmapImage>(); 

            foreach (var imageFile in Resource.GetFilesAtFolder(imageFolder, Resource.GetImageExtensons()))
            {
                string fileName = Path.GetFileName(imageFile);
                BitmapImage image = new BitmapImage(new Uri(imageFile));

                if (output.ContainsKey(fileName) == false)
                {
                    output.Add(fileName, image);
                }
                else
                {
                    Console.WriteLine("Already contains an image with name: " + fileName + " in dictionary");
                }
            }

            return output;
        }
    }
}