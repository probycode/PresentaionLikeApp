using Presentation_App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation_App
{
    public static partial class Factory
    {
        public static IPresentationWriter CreatePresentationWriter()
        {
            return new PresentationJSONWriter();
        }

        public static IPresentationReader CreatePresentationReader()
        {
            return new PresentationJSONReader<Presentation>();
        }

        public static IImageReader CreateImageLoader()
        {
            return new ImageReader();
        }
    }
}
