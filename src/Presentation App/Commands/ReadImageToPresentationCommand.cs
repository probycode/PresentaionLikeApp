using System;
using System.IO;

namespace Presentation_App
{
    public class ReadImageToPresentationCommand
    {
        public void Execute(IPresentation presentation, Action<IImageReader> OnReadSeccessfull)
        {
            IImageReader imageReader = Factory.CreateImageLoader();
            var image = imageReader.Read();

            if (image != null)
            {
                presentation.AddImage(imageReader.ImageName, image);

                string savePath = Path.Combine(Resource.GetImageFolderPath(), imageReader.ImageName);

                File.Copy(imageReader.ImagePath, savePath, true);

                OnReadSeccessfull(imageReader);
            }
        }
    }
}
