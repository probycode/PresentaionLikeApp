using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation_App
{
    public interface IPresentationReader
    {
        List<IPresentation> ReadAll();
        IPresentation ReadAt(string path);
        IPresentation Read();
    }
}
