﻿#pragma checksum "..\..\..\DoctorUI\ScheduleOperationWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "EC74A73FA4CDC535DFC3AAAB3F9F5EA16B60E63739F9056C69121A12423BCE2F"
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
    /// ScheduleOperationWindow
    /// </summary>
    public partial class ScheduleOperationWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 56 "..\..\..\DoctorUI\ScheduleOperationWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox doctorsCB;
        
        #line default
        #line hidden
        
        
        #line 59 "..\..\..\DoctorUI\ScheduleOperationWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox patientTxt;
        
        #line default
        #line hidden
        
        
        #line 60 "..\..\..\DoctorUI\ScheduleOperationWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox patinetIdTxt;
        
        #line default
        #line hidden
        
        
        #line 61 "..\..\..\DoctorUI\ScheduleOperationWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox healthCardNumTxt;
        
        #line default
        #line hidden
        
        
        #line 62 "..\..\..\DoctorUI\ScheduleOperationWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker operationDate;
        
        #line default
        #line hidden
        
        
        #line 63 "..\..\..\DoctorUI\ScheduleOperationWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox hoursCB;
        
        #line default
        #line hidden
        
        
        #line 64 "..\..\..\DoctorUI\ScheduleOperationWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox minutesCB;
        
        #line default
        #line hidden
        
        
        #line 66 "..\..\..\DoctorUI\ScheduleOperationWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton isUrgentRB;
        
        #line default
        #line hidden
        
        
        #line 67 "..\..\..\DoctorUI\ScheduleOperationWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox roomCB;
        
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
            System.Uri resourceLocater = new System.Uri("/IS_Bolnica;component/doctorui/scheduleoperationwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\DoctorUI\ScheduleOperationWindow.xaml"
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
            
            #line 12 "..\..\..\DoctorUI\ScheduleOperationWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ExaminationButtonClick);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 17 "..\..\..\DoctorUI\ScheduleOperationWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.OperationButtonClick);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 22 "..\..\..\DoctorUI\ScheduleOperationWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.NotificationsButtonClick);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 28 "..\..\..\DoctorUI\ScheduleOperationWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.StatisticsButtonClick);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 33 "..\..\..\DoctorUI\ScheduleOperationWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.SingOutButtonClick);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 38 "..\..\..\DoctorUI\ScheduleOperationWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.SettingsButtonClick);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 44 "..\..\..\DoctorUI\ScheduleOperationWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.BackButtonClick);
            
            #line default
            #line hidden
            return;
            case 8:
            this.doctorsCB = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 9:
            this.patientTxt = ((System.Windows.Controls.TextBox)(target));
            return;
            case 10:
            this.patinetIdTxt = ((System.Windows.Controls.TextBox)(target));
            
            #line 60 "..\..\..\DoctorUI\ScheduleOperationWindow.xaml"
            this.patinetIdTxt.LostFocus += new System.Windows.RoutedEventHandler(this.IdTextFieldLostFocus);
            
            #line default
            #line hidden
            return;
            case 11:
            this.healthCardNumTxt = ((System.Windows.Controls.TextBox)(target));
            return;
            case 12:
            this.operationDate = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 13:
            this.hoursCB = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 14:
            this.minutesCB = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 15:
            this.isUrgentRB = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 16:
            this.roomCB = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 17:
            
            #line 69 "..\..\..\DoctorUI\ScheduleOperationWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.PotvrdiButtonClick);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

