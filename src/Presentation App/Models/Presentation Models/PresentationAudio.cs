using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation_App
{
    [Serializable]
    public class Audio
    {
        public string Name { get; set; } = string.Empty;
        public double Volume { get; set; } = 0.5;
    }

    public class PresentationAudio
    {
        public Audio Music { get; set; } = new Audio();
        public Audio Question { get; set; } = new Audio();
        public Audio Answer { get; set; } = new Audio();
        public Audio End { get; set; } = new Audio();
    }
}
