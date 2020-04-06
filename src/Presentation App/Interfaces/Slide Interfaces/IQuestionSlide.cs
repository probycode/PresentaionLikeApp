using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation_App
{
    public interface IQuestionSlide : ISlide
    {
        string Image { get; set; }
        char CorrectChoice { get; set; }
        List<IChoice> Choices { get; set; }
    }
}
