﻿#pragma checksum "..\..\..\..\Pages\PresnetationPages\PresentationPropertiesPage.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2F0146685FD61C3FC22E71223B24313A104E3DB2"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Presentation_App;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace Presentation_App {
    
    
    /// <summary>
    /// PresentationPropertiesPage
    /// </summary>
    public partial class PresentationPropertiesPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 31 "..\..\..\..\Pages\PresnetationPages\PresentationPropertiesPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox PresentationNameTextBox;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\..\..\Pages\PresnetationPages\PresentationPropertiesPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox QuestionPerSlideComboBox;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Presentation App;component/pages/presnetationpages/presentationpropertiespage.xa" +
                    "ml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Pages\PresnetationPages\PresentationPropertiesPage.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.PresentationNameTextBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 31 "..\..\..\..\Pages\PresnetationPages\PresentationPropertiesPage.xaml"
            this.PresentationNameTextBox.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.PresentationNameTextBox_TextChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.QuestionPerSlideComboBox = ((System.Windows.Controls.ComboBox)(target));
            
            #line 37 "..\..\..\..\Pages\PresnetationPages\PresentationPropertiesPage.xaml"
            this.QuestionPerSlideComboBox.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.QuestionPerSlideComboBox_SelectionChanged);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
