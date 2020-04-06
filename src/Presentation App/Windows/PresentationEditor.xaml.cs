using Presentation_App;
using System;
using System.Drawing;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Presentation_App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class PresentationEditor : Window
    {
        #region Public Properties

        public IPresentation Presentation { get; set; }

        public ISlideEditor CurrentPage { get; set; }
        public ISlide CurrentSlide { get; set; }

        public static Control selectedItem;
        public static Frame inspactorFrame;

        #endregion

        #region Constructers

        /// <summary>
        /// Defualt Contructer
        /// </summary>
        public PresentationEditor()
        {
            InitializeComponent();
            WireUpForm();
        }

        public PresentationEditor(IPresentation presentation)
        {
            InitializeComponent();

            this.Presentation = presentation;

            WireUpForm();

            //Add slides in reverse
            for (int i = presentation.Slides.Count -1; i >= 0; i--)
            {
                AddSlide(presentation.Slides[i], false);
            }

            UpdateDisplay();
        }

        #endregion

        #region Methods

        public static void OnSelectedItem(Control inspectorControl, Control controlSelected)
        {
            selectedItem = controlSelected;

            inspactorFrame.Content = inspectorControl;
        }

        private void WireUpForm()
        {
            inspactorFrame = InspectorPanelContent;

            foreach (var slide in Factory.SlidesOptions)
            {
                var item = new ComboBoxItem
                {
                    Content = slide
                };

                SlidePickerComboBox.Items.Add(item);
            }

            SlidePickerComboBox.SelectedIndex = 0;
        }

        private void UpdateDisplay()
        {
            MainFrame.Background = new SolidColorBrush(Presentation.Style.BackgroundColor);
            SlideCountText.Text = "Slides Count: " + Presentation.Slides.Count.ToString();

            if (Presentation.Slides.Count == 0)
                PreviewButton.Text = "\uf070";
            else
                PreviewButton.Text = "\uf06e";

            inspactorFrame.Content = null;
            inspactorFrame.Refresh();
        }

        public void CreateNewPresentation()
        {
            Presentation = Factory.CreatePresentation();
        }

        public void DisplaySlide(ISlide slide)
        {
            CurrentPage = CurrentSlide.OnEditorGUI();

            while (MainFrame.CanGoBack)
            {
                MainFrame.RemoveBackEntry();
            }

            MainFrame.Content = CurrentPage;
        }

        public void AddSlide(ISlide slide, bool addToPresentation = true)
        {
            int selectedIndex = SlideButtonsListBox.SelectedIndex;

            if (selectedIndex == -1)
            {
                selectedIndex = Presentation.Slides.Count;
            }

            if (addToPresentation == true)
            {
                if (selectedIndex >= Presentation.Slides.Count)
                {
                    Presentation.AddSlide(slide);
                }
                else
                {
                    selectedIndex++;
                    Presentation.InsertSlideAt(selectedIndex, slide);
                }
            }

            CurrentSlide = slide;

            DisplaySlide(CurrentSlide);

            CurrentPage.Initailize(Presentation, CurrentSlide);

            //Create Visual For Stack Panel
            SlideButtonControl button = new SlideButtonControl();
            button.Margin = new Thickness(0, 2, 0, 2);
            button.SetIcon(CurrentSlide.Icon);
            button.Initialize(CurrentSlide);

            ListBoxItem listBoxItem = new ListBoxItem();
            listBoxItem.Content = button;
            listBoxItem.Selected += ListBoxItem_Selected;

            SlideButtonsListBox.SelectedItem = listBoxItem;

            if (selectedIndex >= Presentation.Slides.Count)
            {
                SlideButtonsListBox.Items.Add(listBoxItem);
            }
            else
            {
                SlideButtonsListBox.Items.Insert(selectedIndex, listBoxItem);
            }

            UpdateDisplay();
        }

        public void RemoveSlide()
        {
            if (Presentation.Slides.Count == 0)
            {
                return;
            }

            //Remove From Presentation
            Presentation.RemoveSlideAt(SlideButtonsListBox.SelectedIndex);

            //Remove UI
            ListBoxItem listBoxItem = SlideButtonsListBox.SelectedItem as ListBoxItem;
            SlideButtonsListBox.Items.Remove(listBoxItem);

            if (SlideButtonsListBox.Items.Count != 0)
                SlideButtonsListBox.SelectedIndex = SlideButtonsListBox.Items.Count -1;

            SlideButtonsListBox.Focus();

            UpdateDisplay();
        }

        #endregion

        #region Events

        private void PresentationSettingsButton_Click(object sender, RoutedEventArgs e)
        {
            var window = new PresentationSettingsWindow(Presentation);
            window.Show();

            Close();
        }

        private void SaveButton_PreviewMouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (string.IsNullOrEmpty(Resource.SaveLocation) == false)
            {
                Factory.CreatePresentationWriter().Write(Presentation, Resource.SaveLocation, Resource.FileName);
            }
            else
            {
                Resource.SaveLocation = Factory.CreatePresentationWriter().WriteAt(Presentation, Resource.FileName);
            }

            StatusText.Text = "Last Save: " + DateTime.Now;
        }

        private void AddSlideButton_Click(object sender, RoutedEventArgs e)
        {
            ISlide slide = slide = Factory.CreateSlide(SlidePickerComboBox.SelectedIndex);
            AddSlide(slide);
        }

        private void ListBoxItem_Selected(object sender, RoutedEventArgs e)
        {
            ListBoxItem item = sender as ListBoxItem;
            SlideButtonControl button = item.Content as SlideButtonControl;

            CurrentSlide = button.slide;

            item.BringIntoView();

            DisplaySlide(CurrentSlide);
        }

        private void PreviewButton_PreviewMouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if(Presentation.Slides.Count == 0)
            {
                MessageBox.Show("There are no slides to show,\nplease add a slide and try again.", "Missing Slides", MessageBoxButton.OK,MessageBoxImage.Information);
                return;
            }
            var slideShowForm = new SlideShowForm(Presentation);
            slideShowForm.Show();

            slideShowForm.Focus();
            
        }

        private void RemoveSlideButton_Click(object sender, RoutedEventArgs e)
        {
            RemoveSlide();
        }

        private void MoveSlideDownButton_Click(object sender, RoutedEventArgs e)
        {
            if (SlideButtonsListBox.SelectedIndex < SlideButtonsListBox.Items.Count -1)
            {
                //UI
                ListBoxItem listBoxItem = SlideButtonsListBox.SelectedItem as ListBoxItem;

                int index = SlideButtonsListBox.SelectedIndex + 1;

                SlideButtonsListBox.Items.Remove(listBoxItem);
                SlideButtonsListBox.Items.Insert(index, listBoxItem);
                SlideButtonsListBox.SelectedIndex = index;
                SlideButtonsListBox.Focus();

                //Data
                Presentation.RemoveSlide(CurrentSlide);
                Presentation.InsertSlideAt(index, CurrentSlide);
            }
        }

        private void MoveSlideUpButton_Click(object sender, RoutedEventArgs e)
        {
            if (SlideButtonsListBox.SelectedIndex > 0)
            {
                //UI
                ListBoxItem listBoxItem = SlideButtonsListBox.SelectedItem as ListBoxItem;

                int index = SlideButtonsListBox.SelectedIndex - 1;

                SlideButtonsListBox.Items.Remove(listBoxItem);
                SlideButtonsListBox.Items.Insert(index, listBoxItem);
                SlideButtonsListBox.SelectedIndex = index;
                SlideButtonsListBox.Focus();

                //Data
                Presentation.RemoveSlide(CurrentSlide);
                Presentation.InsertSlideAt(index, CurrentSlide);
            }
        }

        #endregion
    }
}
