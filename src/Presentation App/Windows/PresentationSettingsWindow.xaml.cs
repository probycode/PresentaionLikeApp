using Presentation_App;
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
using System.Windows.Shapes;

namespace Presentation_App
{
    /// <summary>
    /// Interaction logic for PresentationSettingsWindow.xaml
    /// </summary>
    public partial class PresentationSettingsWindow : Window
    {
        IPresentation presentation;
        int selectedIndex;

        public PresentationSettingsWindow(IPresentation presentaion)
        {
            InitializeComponent();

            this.presentation = presentaion;

            SelectMenuItem(-1);
        }

        public void SelectMenuItem(int index)
        {
            if(index < -1 || index > 1)
            {
                return;
            }
            gridCursor.Margin = new Thickness((300 * index), 0, 0, 0);

            selectedIndex = index;

            IPresentationEditor page;

            switch (index)
            {
                case -1:
                    page = new PresentationPropertiesPage(presentation);
                    page.OnNextPage += Page_OnNextPage;
                    page.OnBackPage += Page_OnBackPage;
                    PageContent.Content = page;
                    break;
                case 0:
                    page = new PresentationSoundsPage(presentation);
                    page.OnNextPage += Page_OnNextPage;
                    page.OnBackPage += Page_OnBackPage;
                    PageContent.Content = page;
                    break;
                case 1:
                    page = new PresentationStylesPage(presentation);
                    page.OnNextPage += Page_OnNextPage;
                    page.OnBackPage += Page_OnBackPage;
                    PageContent.Content = page;
                    break;
            }
        }

        private void Page_OnBackPage(object sender, EventArgs e)
        {
            selectedIndex--;

            SelectMenuItem(selectedIndex);
        }

        private void Page_OnNextPage(object sender, EventArgs e)
        {
            selectedIndex++;

            SelectMenuItem(selectedIndex);
        }

        private void MenuButton_Click(object sender, RoutedEventArgs e)
        {
            int index = int.Parse(((Button)e.Source).Uid);

            SelectMenuItem(index);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var presentationEditor = new PresentationEditor(presentation);
            presentationEditor.Show();

            Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var dashBoardWindow = new DashboardWindow();
            dashBoardWindow.Show();

            Close();
        }
    }
}
