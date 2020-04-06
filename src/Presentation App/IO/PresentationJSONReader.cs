using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace Presentation_App
{
    public class PresentationJSONReader<T> : IPresentationReader where T : IPresentation, new()
    {
        public IPresentation Read()
        {
            Console.WriteLine("Loading Presentations");

            IPresentation presentation;

            string path = Path.Combine(Directory.GetCurrentDirectory(), Resource.PRESENTATION_FOLDER_NAME);

            if (Directory.Exists(path))
            {
                foreach (var dir in Resource.GetDirectories(path))
                {

                    List<string> extensions = new List<string>()
                    {
                        "json"
                    };

                    presentation = LoadJSON<T>(Resource.GetFilesAtFolder(dir, extensions)[0]);

                    path = Path.Combine(dir, Resource.IMAGE_FOLDER_NAME);

                    IImageReader imageLoader = new ImageReader();

                    presentation.SetImages(imageLoader.ReadAll(path));

                    Console.WriteLine("Finished Loading Presentation: " + presentation.Name);

                    return presentation;
                }
            }

            return null;
        }

        public IPresentation ReadAt(string path)
        {
            Console.WriteLine("Loading Presentations");
            IPresentation presentation;

            List<string> extensions = new List<string>()
                {
                    "json"
                };

            presentation = LoadJSON<T>(Resource.GetFilesAtFolder(path, extensions)[0]);

            path = Path.Combine(path, Resource.IMAGE_FOLDER_NAME);

            IImageReader imageLoader = new ImageReader();

            presentation.SetImages(imageLoader.ReadAll(path));

            Console.WriteLine("Finished Loading Presentation: " + presentation.Name);

            return presentation;
        }

        public List<IPresentation> ReadAll()
        {
            Console.WriteLine("Loading Presentations");

            List<IPresentation> presentations = new List<IPresentation>();

            string root = Directory.GetCurrentDirectory();

            string AllPresentationFolder = Path.Combine(root, Resource.PRESENTATION_FOLDER_NAME);

            if (Directory.Exists(AllPresentationFolder))
            {
                foreach (var presentationFolder in Resource.GetDirectories(AllPresentationFolder))
                {
                    IPresentation presentation = new T();

                    List<string> extensions = new List<string>()
                    {
                        "json"
                    };

                    foreach (var file in Resource.GetFilesAtFolder(presentationFolder, extensions))
                    {
                        presentation = LoadJSON<T>(file);
                        presentations.Add(presentation);
                    }

                    if (presentation != null)
                    {
                        IImageReader imageReader = Factory.CreateImageLoader();

                        string imageFolder = Path.Combine(presentationFolder, Resource.IMAGE_FOLDER_NAME);

                        presentation.SetImages(imageReader.ReadAll(imageFolder));
                    }
                }

                Console.WriteLine("Finished Loading Presentations: " + presentations.Count);

                return presentations;
            }

            return null;
        }

        public static U LoadJSON<U>(string folderPath) where U : new()
        {
            U objectRead = new U();

            using (StreamReader stream = new StreamReader(folderPath))
            {
                JsonSerializerSettings settings = new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.All
                };

                string jsonString = stream.ReadToEnd();
                objectRead = JsonConvert.DeserializeObject<U>(jsonString, settings);
            }

            Console.WriteLine("Load Successeful");

            return objectRead;
        }
    }
}
