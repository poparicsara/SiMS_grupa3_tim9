﻿#pragma checksum "..\..\..\DoctorUI\ScheduleExaminationWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "FE340A72F64649985CAF1E17B36C7A7983FB850E3970A5D38571CEAC9E48C0E5"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using IS_Bolnica.DoctorUI;
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


namespace IS_Bolnica.DoctorUI {
    
    
    /// <summary>
    /// ScheduleExaminationWindow
    /// </summary>
    public partial class ScheduleExaminationWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 24 "..\..\..\DoctorUI\ScheduleExaminationWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox doctorsCB;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\DoctorUI\ScheduleExaminationWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox patientTxt;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\DoctorUI\ScheduleExaminationWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox patinetIdTxt;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\DoctorUI\ScheduleExaminationWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox healthCardNumTxt;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\DoctorUI\ScheduleExaminationWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox ordinationTxt;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\DoctorUI\ScheduleExaminationWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker examinationDate;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\..\DoctorUI\ScheduleExaminationWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox hoursCB;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\..\DoctorUI\ScheduleExaminationWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox minutesCB;
        
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
            System.Uri resourceLocater = new System.Uri("/IS_Bolnica;component/doctorui/scheduleexaminationwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\DoctorUI\ScheduleExaminationWindow.xaml"
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
            
            #line 12 "..\..\..\DoctorUI\ScheduleExaminationWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.BackButtonClick);
            
            #line default
            #line hidden
            return;
            case 2:
            this.doctorsCB = ((System.Windows.Controls.ComboBox)(target));
            
            #line 24 "..\..\..\DoctorUI\ScheduleExaminationWindow.xaml"
            this.doctorsCB.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.DoctorsSelectionChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.patientTxt = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.patinetIdTxt = ((System.Windows.Controls.TextBox)(target));
            
            #line 29 "..\..\..\DoctorUI\ScheduleExaminationWindow.xaml"
            this.patinetIdTxt.LostFocus += new System.Windows.RoutedEventHandler(this.IdTextFieldLostFocus);
            
            #line default
            #line hidden
            return;
            case 5:
            this.healthCardNumTxt = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.ordinationTxt = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.examinationDate = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 8:
            this.hoursCB = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 9:
            this.minutesCB = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 10:
            
            #line 42 "..\..\..\DoctorUI\ScheduleExaminationWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.PotvrdiButtonClick);
            
            #line default
            #line hidden
            return;
            case 11:
            
            #line 44 "..\..\..\DoctorUI\ScheduleExaminationWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ExaminationButtonClick);
            
            #line default
            #line hidden
            return;
            case 12:
            
            #line 49 "..\..\..\DoctorUI\ScheduleExaminationWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.OperationButtonClick);
            
            #line default
            #line hidden
            return;
            case 13:
            
            #line 54 "..\..\..\DoctorUI\ScheduleExaminationWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.NotificationsButtonClick);
            
            #line default
            #line hidden
            return;
            case 14:
            
            #line 59 "..\..\..\DoctorUI\ScheduleExaminationWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.MedicamentsButtonClick);
            
            #line default
            #line hidden
            return;
            case 15:
            
            #line 65 "..\..\..\DoctorUI\ScheduleExaminationWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.StatisticsButtonClick);
            
            #line default
            #line hidden
            return;
            case 16:
            
            #line 70 "..\..\..\DoctorUI\ScheduleExaminationWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.SingOutButtonClick);
            
            #line default
            #line hidden
            return;
            case 17:
            
            #line 75 "..\..\..\DoctorUI\ScheduleExaminationWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.SettingsButtonClick);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

