using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Presentation_App
{
    public static partial class Factory
    {
        private static LabelInspectorContol LabelInspectorControl;

        public static LabelInspectorContol GetLabelInspectorContol(TextBox control, string controlName)
        {
            //Lazy Load
            if (LabelInspectorControl == null)
                LabelInspectorControl = new LabelInspectorContol();

            LabelInspectorControl.Reset();
            LabelInspectorControl.Init(control, controlName);

            return LabelInspectorControl;
        }
    }
}
