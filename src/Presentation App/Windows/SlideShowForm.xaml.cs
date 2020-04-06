using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace Presentation_App
{
    /// <summary>
    /// Interaction logic for SlideShowForm.xaml
    /// </summary>
    public partial class SlideShowForm : Window
    {
        IPresentation presentation;
        ISlideDisplay SlideDisplay { get; set; }

        public SlideShowForm(IPresentation presentation = null)
        {
            InitializeComponent();

            if (presentation != null)
            {
                this.presentation = presentation;
            }
            else
            {
                IPresentationReader reader = Factory.CreatePresentationReader();

                this.presentation = reader.Read();
            }

            if (this.presentation != null)
                ShowNextSlide();

            presentation.SlideShow.OnSlideShowFinished += SlideShow_OnSlideShowFinished;

            UpdateDisplay();

            //TODO: Optimize
            Resource.LoadAudioPlayers();

            Resource.MusicAudioPlayer.PlayLoop();           
        }

        public void UpdateDisplay()
        {
            Background = new SolidColorBrush(presentation.Style.BackgroundColor);
        }

        public void DisplaySlide(ISlide slide)
        {
            SlideDisplay = slide.OnDisplayGUI();
            SlideDisplay.Initailize(presentation, slide);

            MainFrame.Content = SlideDisplay;

            slideIndicator.Content = $"{presentation.SlideShow.CurrentSlideIndex + 1}/{presentation.Slides.Count}";
        }

        public void ShowNextSlide()
        {
            if (presentation.Slides.Count == 0)
            {
                MessageBox.Show("There are no slides to show.");
                return;
            }

            if (presentation.SlideShow.CurrentSlideIndex >= presentation.Slides.Count)
            {
                EndSlideShow();
                return;
            }

            ISlide slide = presentation.SlideShow.GetNextSlide();

            if(slide != null)
                DisplaySlide(slide);
        }

        public void ShowPrevSlide()
        {
            if (presentation.Slides.Count == 0)
            {
                MessageBox.Show("There are no slides to show.");
                return;
            }

            if (presentation.SlideShow.CurrentSlideIndex < 0)
            {
                //We are at the first Slide
                return;
            }

            ISlide slide = presentation.SlideShow.GetPreviousSlide();

            if (slide != null)
                DisplaySlide(slide);
        }

        public void EndSlideShow()
        {
            presentation.SlideShow.Reset();
            Resource.CloseAudioPlayers();
            Close();
        }

        private void SlideShow_OnSlideShowFinished(object sender, System.EventArgs e)
        {
            EndSlideShow();
        }

        #region Keys

        protected override void OnMouseDown(MouseButtonEventArgs e)
        {
            base.OnMouseDown(e);

            ShowNextSlide();
        }

        protected override void OnMouseWheel(MouseWheelEventArgs e)
        {
            base.OnMouseWheel(e);

            if(e.Delta < 0)
            {
                ShowNextSlide();
            }
            else
            {
                ShowPrevSlide();
            }
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);

            if (e.Key == Key.Escape)
            {
                OnEscapeKeyDown();
            }
            else if (e.Key == Key.Right || e.Key == Key.Down || e.Key == Key.Space)
            {
                OnRightArrowKeyDown();
            }
            else if (e.Key == Key.Left || e.Key == Key.Up)
            {
                OnLeftArrowKeyDown();
            }
            else if (e.Key == Key.Enter)
            {
                OnEnterKeyDown();
            }
        }

        public void OnEnterKeyDown()
        {
            ShowNextSlide();
        }

        public void OnEscapeKeyDown()
        {
            EndSlideShow();
        }

        public void OnRightArrowKeyDown()
        {
            ShowNextSlide();
        }

        public void OnLeftArrowKeyDown()
        {
            ShowPrevSlide();
        }

        #endregion
    }
}