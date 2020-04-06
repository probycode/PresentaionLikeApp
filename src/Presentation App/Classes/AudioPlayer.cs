using Presentation_App;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Presentation_App
{
    public class AudioPlayer
    {
        private MediaPlayer mediaPlayer;

        public AudioPlayer ()
        {
            mediaPlayer = new MediaPlayer();
        }

        private void MediaPlayer_MediaEnded(object sender, EventArgs e)
        {
            mediaPlayer.Position = TimeSpan.Zero;
            mediaPlayer.Play();
        }

        public void Load(string audioPath)
        {
            mediaPlayer.Open(new Uri(audioPath));
        }

        public void PlayOnce()
        {
            if (mediaPlayer.HasAudio == false) { return; }

            mediaPlayer.Play();
        }

        public void PlayLoop()
        {
            //if (mediaPlayer.HasAudio == false) { return; }

            mediaPlayer.MediaEnded += MediaPlayer_MediaEnded;
            mediaPlayer.Play();
        }

        public void SetVolume(double volume)
        {
            mediaPlayer.Volume = volume;
        }

        public double GetVolume()
        {
            return mediaPlayer.Volume;
        }

        public void Stop()
        {
            mediaPlayer.Stop();
            mediaPlayer.MediaEnded -= MediaPlayer_MediaEnded;
        }

        public void Close()
        {
            mediaPlayer.Close();
            mediaPlayer.MediaEnded -= MediaPlayer_MediaEnded;
        }

        public void Pause()
        {
            mediaPlayer.Pause();
        }
    }
}
