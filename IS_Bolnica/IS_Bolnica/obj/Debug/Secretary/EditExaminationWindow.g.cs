﻿#pragma checksum "..\..\..\Secretary\EditExaminationWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "037F63444997ED02F18533318E4D4F35EBDC130547A6A8CE33D2CBD2EE8C05F5"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using IS_Bolnica.Secretary;
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


namespace IS_Bolnica.Secretary {
    
    
    /// <summary>
    /// EditExaminationWindow
    /// </summary>
    public partial class EditExaminationWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 16 "..\..\..\Secretary\EditExaminationWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image nasLogo;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\Secretary\EditExaminationWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox idPatientBox;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\Secretary\EditExaminationWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox doctor;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\Secretary\EditExaminationWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox hourBox;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\..\Secretary\EditExaminationWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox minutesBox;
        
        #line default
        #line hidden
        
        
        #line 51 "..\..\..\Secretary\EditExaminationWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker dateBox;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\..\Secretary\EditExaminationWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox durationInMinutesBox;
        
        #line default
        #line hidden
        
        
        #line 57 "..\..\..\Secretary\EditExaminationWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox room;
        
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
            System.Uri resourceLocater = new System.Uri("/IS_Bolnica;component/secretary/editexaminationwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Secretary\EditExaminationWindow.xaml"
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
            
            #line 10 "..\..\..\Secretary\EditExaminationWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.nasLogo = ((System.Windows.Controls.Image)(target));
            return;
            case 3:
            this.idPatientBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.doctor = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 5:
            this.hourBox = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 6:
            this.minutesBox = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 7:
            
            #line 49 "..\..\..\Secretary\EditExaminationWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.editExamination);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 50 "..\..\..\Secretary\EditExaminationWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.cancelEditingExamination);
            
            #line default
            #line hidden
            return;
            case 9:
            this.dateBox = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 10:
            this.durationInMinutesBox = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 11:
            this.room = ((System.Windows.Controls.ComboBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

