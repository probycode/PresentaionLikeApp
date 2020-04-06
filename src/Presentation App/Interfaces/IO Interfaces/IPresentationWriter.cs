using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation_App
{
    public interface IPresentationWriter
    {
        bool Canceled { get; set; }

        void Write(IPresentation presentation, string path, string FileName);

        /// <summary>
        /// Returns the path saved to
        /// </summary>
        /// <param name="presentation"></param>
        /// <returns></returns>
        string WriteAt(IPresentation presentation, string FileName);
    }
}
