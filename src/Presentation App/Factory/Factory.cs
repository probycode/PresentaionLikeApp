using Presentation_App;
using System;
using System.Collections.Generic;

namespace Presentation_App
{
    public static partial class Factory
    {
        public static readonly List<string> SlidesOptions;

        static Factory()
        {
            SlidesOptions = new List<string>();

            //This order should be the same as the CreateSlide method order
            SlidesOptions.Add("Intro Slide");
            SlidesOptions.Add("Question Slide");
            SlidesOptions.Add("Information Slide");
            SlidesOptions.Add("End Slide");
            SlidesOptions.Add("Image Slide");
        }

        public static IPresentation CreatePresentation()
        {
            IPresentation presentation = new Presentation();

            presentation.Template = new PresentationTemplate();

            return presentation;
        }

        public static ISlide CreateSlide(int slideType)
        {
            switch (slideType)
            {
                case 0:
                    IIntroSlide introSlide = new IntroSlideModel<IntroSlideEditorPage, IntroSlideDisplayPage>();
                    introSlide.Name = "Intro Slide";
                    introSlide.Content = string.Empty;
                    introSlide.SubTitle = "Click to edit text";
                    introSlide.Icon = "\xf005";
                    return introSlide;
                case 1:
                    IQuestionSlide questionSlide = new QuestionSlideModel<QuestionEditorPage, QuestionSlideDisplayPage>();
                    questionSlide.Name = "Question Slide";
                    questionSlide.Content = "Click to edit text";
                    questionSlide.Icon = "\uf059";
                    questionSlide.SlideActions.Add(new QuestionShowAnwerAction());
                    return questionSlide;
                case 2:
                    IInformationSlide informationSlide = new InformationSlideModel<InformationSlideEditorPage, InformationSlideDisplayPage>();
                    informationSlide.Name = "Information Slide";
                    informationSlide.Content = "Click to edit text";
                    informationSlide.Icon = "\uf05a";
                    return informationSlide;
                case 3:
                    IEndSlide endSlide = new EndSlideModel<EndSlideEditorPage, EndSlideDisplayPage>();
                    endSlide.Name = "End Slide";
                    endSlide.Content = "Click to edit text";
                    endSlide.Icon = "\uf024";
                    return endSlide;
                case 4:
                    IFullImageSlide fullImageSlide = new FullImageSlideModel<FullImageSlideEditorPage, FullImageSlideDisplayPage>();
                    fullImageSlide.Name = "Image Slide";
                    fullImageSlide.Content = "Click to edit text";
                    fullImageSlide.Icon = "\uf03e";
                    return fullImageSlide;
            }

            throw new Exception("Something went wrong");
        }

        public static IChoice CreateChoice()
        {
            IChoice choice = new Choice<ChoiceEditorControl,ChoiceDisplayControl>();
            choice.ChoiceText = "Click to edit text";
            return choice;
        }
    }
}
