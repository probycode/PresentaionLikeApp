using Presentation_App;
using System;
using System.IO;
using System.Windows.Forms;

namespace Presentation_App
{
    public class ReadAudioToPresentationCommand
    {
        public void Execute(IPresentation presentation, Action<OpenFileDialog> OnSeccessfullFinished, string Title = null)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();

            fileDialog.Multiselect = false;
            fileDialog.Title = Title;

            fileDialog.Filter = Resource.AUDIO_FILTER;

            if (fileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string savePath = Path.Combine(Resource.GetAudioFolderPath(), fileDialog.SafeFileName);

                File.Copy(fileDialog.FileName, savePath, true);

                OnSeccessfullFinished(fileDialog);
            }
            else
            {
                return;
            }
        }
    }
}
