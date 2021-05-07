﻿#pragma checksum "..\..\Diagnosis.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "23FD2AD33F5B70D639847849B93EE40F2DA968EE5CD97EBBBF4F92599B6B79FE"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using IS_Bolnica;
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


namespace IS_Bolnica {
    
    
    /// <summary>
    /// Diagnosis
    /// </summary>
    public partial class Diagnosis : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 13 "..\..\Diagnosis.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox patientTxt;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\Diagnosis.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox dateOfBirthTxt;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\Diagnosis.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox jmbgTxt;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\Diagnosis.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox addressTxt;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\Diagnosis.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox healthCardNumberTxt;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\Diagnosis.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox dateOfExaminationTxt;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\Diagnosis.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox symptomsTxt;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\Diagnosis.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox diagnosisTxt;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\Diagnosis.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox doctorTxt;
        
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
            System.Uri resourceLocater = new System.Uri("/IS_Bolnica;component/diagnosis.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Diagnosis.xaml"
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
            this.patientTxt = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.dateOfBirthTxt = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.jmbgTxt = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            
            #line 16 "..\..\Diagnosis.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.izdajRecept);
            
            #line default
            #line hidden
            return;
            case 5:
            this.addressTxt = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.healthCardNumberTxt = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.dateOfExaminationTxt = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.symptomsTxt = ((System.Windows.Controls.TextBox)(target));
            return;
            case 9:
            this.diagnosisTxt = ((System.Windows.Controls.TextBox)(target));
            return;
            case 10:
            
            #line 28 "..\..\Diagnosis.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.scheduleOperationButtonClicked);
            
            #line default
            #line hidden
            return;
            case 11:
            
            #line 29 "..\..\Diagnosis.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 12:
            this.doctorTxt = ((System.Windows.Controls.TextBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

