using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation_App
{
    public abstract class SlideBase : ISlide
    {
        [JsonIgnore] public ISlideEditor Editor { get; set; }
        [JsonIgnore] public ISlideDisplay Display { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
        public double ContentFontSize { get; set; } = 12;
        public string Icon { get; set; }
        [JsonIgnore] public bool IsDone { get; set; }
        [JsonIgnore] public int SlideActionIndex { get; set; }
        public List<ISlideAction> SlideActions { get; set; }

        public virtual void Next()
        {
            if (SlideActions.Count == 0)
            {
                return;
            }

            if (SlideActionIndex >= SlideActions.Count)
            {
                IsDone = true;
                return;
            }

            SlideActions[SlideActionIndex].Run(this);

            SlideActionIndex++;
        }

        public abstract ISlideDisplay OnDisplayGUI();

        public abstract ISlideEditor OnEditorGUI();

        public virtual void OnFinished()
        {
            Reset();
        }

        public virtual void OnStart()
        {
            
        }

        public virtual void Reset()
        {
            SlideActionIndex = 0;
        }
    }
}
