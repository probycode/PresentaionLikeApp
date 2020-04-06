using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Presentation_App
{   
    /// <summary>
    /// Interaction logic for LabelInspectorContol.xaml
    /// </summary>
    public partial class LabelInspectorContol : UserControl
    {
        TextBox textBox;
        public event EventHandler OnChanged;
        public double SelectedFontSize { get; set; }

        public LabelInspectorContol()
        {
            InitializeComponent();
        }

        public void Init(TextBox textBox, string selectedObjectTitle = "")
        {
            this.textBox = textBox;

            fontSizeInput.Text = textBox.FontSize.ToString();

            selectedobjectName.Text = selectedObjectTitle;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            double.TryParse(fontSizeInput.Text, out double size);

            if (size > 0 && size <= 1000)
            {
                SelectedFontSize = size;
                OnChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        public void Reset()
        {
            textBox = null;
            OnChanged = null;
            SelectedFontSize = 12;
        }
    }
}
