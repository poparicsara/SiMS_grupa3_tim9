﻿#pragma checksum "..\..\..\PatientPages\MyAppointments.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "9641E8456570D02D9E20F595011AEA73E303E35E1F4813F6A6056C9597D51BE5"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using IS_Bolnica.PatientPages;
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


namespace IS_Bolnica.PatientPages {
    
    
    /// <summary>
    /// MyAppointments
    /// </summary>
    public partial class MyAppointments : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 18 "..\..\..\PatientPages\MyAppointments.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Frame StartFrame;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\PatientPages\MyAppointments.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid AppointmentsDataBinding;
        
        #line default
        #line hidden
        
        
        #line 70 "..\..\..\PatientPages\MyAppointments.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button DeleteButton;
        
        #line default
        #line hidden
        
        
        #line 96 "..\..\..\PatientPages\MyAppointments.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox SearchBox;
        
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
            System.Uri resourceLocater = new System.Uri("/IS_Bolnica;component/patientpages/myappointments.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\PatientPages\MyAppointments.xaml"
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
            this.StartFrame = ((System.Windows.Controls.Frame)(target));
            return;
            case 2:
            this.AppointmentsDataBinding = ((System.Windows.Controls.DataGrid)(target));
            
            #line 25 "..\..\..\PatientPages\MyAppointments.xaml"
            this.AppointmentsDataBinding.MouseMove += new System.Windows.Input.MouseEventHandler(this.DataGridMouseMove);
            
            #line default
            #line hidden
            
            #line 26 "..\..\..\PatientPages\MyAppointments.xaml"
            this.AppointmentsDataBinding.PreviewMouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.DataGridPreviewMouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 52 "..\..\..\PatientPages\MyAppointments.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.EvaluationsButtonClicked);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 58 "..\..\..\PatientPages\MyAppointments.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ReportButtonClicked);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 64 "..\..\..\PatientPages\MyAppointments.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.EditButtonClicked);
            
            #line default
            #line hidden
            return;
            case 6:
            this.DeleteButton = ((System.Windows.Controls.Button)(target));
            
            #line 70 "..\..\..\PatientPages\MyAppointments.xaml"
            this.DeleteButton.Click += new System.Windows.RoutedEventHandler(this.RemoveButtonClicked);
            
            #line default
            #line hidden
            
            #line 70 "..\..\..\PatientPages\MyAppointments.xaml"
            this.DeleteButton.Drop += new System.Windows.DragEventHandler(this.DeleteAppoinmentDrop);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 76 "..\..\..\PatientPages\MyAppointments.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.AddButtonClicked);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 82 "..\..\..\PatientPages\MyAppointments.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.NotificationsButtonClicked);
            
            #line default
            #line hidden
            return;
            case 9:
            
            #line 88 "..\..\..\PatientPages\MyAppointments.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.HealthButtonClicked);
            
            #line default
            #line hidden
            return;
            case 10:
            this.SearchBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 96 "..\..\..\PatientPages\MyAppointments.xaml"
            this.SearchBox.KeyUp += new System.Windows.Input.KeyEventHandler(this.SearchKeyUp);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

