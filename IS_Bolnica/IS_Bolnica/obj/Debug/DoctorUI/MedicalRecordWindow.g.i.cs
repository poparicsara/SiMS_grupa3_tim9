﻿#pragma checksum "..\..\..\DoctorUI\MedicalRecordWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "C1B488D7847CE8418EA30C91F4A65AF11E7D7640C0250721681EEA4E7B12B446"
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
    /// MedicalRecordWindow
    /// </summary>
    public partial class MedicalRecordWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 21 "..\..\..\DoctorUI\MedicalRecordWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox patientTxt;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\DoctorUI\MedicalRecordWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox patinetIdTxt;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\DoctorUI\MedicalRecordWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox healthCardNumTxt;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\DoctorUI\MedicalRecordWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox dateOfBirthTxt;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\DoctorUI\MedicalRecordWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox addressTxt;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\DoctorUI\MedicalRecordWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox allergiesLB;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\DoctorUI\MedicalRecordWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox medsLB;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\DoctorUI\MedicalRecordWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox historyLB;
        
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
            System.Uri resourceLocater = new System.Uri("/IS_Bolnica;component/doctorui/medicalrecordwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\DoctorUI\MedicalRecordWindow.xaml"
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
            
            #line 12 "..\..\..\DoctorUI\MedicalRecordWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.BackButtonClick);
            
            #line default
            #line hidden
            return;
            case 2:
            this.patientTxt = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.patinetIdTxt = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.healthCardNumTxt = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.dateOfBirthTxt = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.addressTxt = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.allergiesLB = ((System.Windows.Controls.ListBox)(target));
            return;
            case 8:
            this.medsLB = ((System.Windows.Controls.ListBox)(target));
            return;
            case 9:
            this.historyLB = ((System.Windows.Controls.ListBox)(target));
            return;
            case 10:
            
            #line 32 "..\..\..\DoctorUI\MedicalRecordWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.AnamnezaButtonClick);
            
            #line default
            #line hidden
            return;
            case 11:
            
            #line 34 "..\..\..\DoctorUI\MedicalRecordWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ExaminationsButtonClick);
            
            #line default
            #line hidden
            return;
            case 12:
            
            #line 39 "..\..\..\DoctorUI\MedicalRecordWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.OperationButtonClick);
            
            #line default
            #line hidden
            return;
            case 13:
            
            #line 44 "..\..\..\DoctorUI\MedicalRecordWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.NotificationsButtonClick);
            
            #line default
            #line hidden
            return;
            case 14:
            
            #line 49 "..\..\..\DoctorUI\MedicalRecordWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.MedicamentsButtonClick);
            
            #line default
            #line hidden
            return;
            case 15:
            
            #line 55 "..\..\..\DoctorUI\MedicalRecordWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.StatisticsButtonClick);
            
            #line default
            #line hidden
            return;
            case 16:
            
            #line 60 "..\..\..\DoctorUI\MedicalRecordWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.SingOutButtonClick);
            
            #line default
            #line hidden
            return;
            case 17:
            
            #line 65 "..\..\..\DoctorUI\MedicalRecordWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.SettingsButtonClick);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

