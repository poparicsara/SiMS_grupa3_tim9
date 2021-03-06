#pragma checksum "..\..\..\DoctorUI\UpdateScheduledExaminationWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "2CE6D95E270CBB0D2F1300B7F79FC12581D4C80F2E2F77A50856C063DBC7BB6B"
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
    /// UpdateScheduledExaminationWindow
    /// </summary>
    public partial class UpdateScheduledExaminationWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 23 "..\..\..\DoctorUI\UpdateScheduledExaminationWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox doctorsCB;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\DoctorUI\UpdateScheduledExaminationWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox patientTxt;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\DoctorUI\UpdateScheduledExaminationWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox patinetIdTxt;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\DoctorUI\UpdateScheduledExaminationWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox healthCardNumTxt;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\DoctorUI\UpdateScheduledExaminationWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox ordinationTxt;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\DoctorUI\UpdateScheduledExaminationWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker examinationDate;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\DoctorUI\UpdateScheduledExaminationWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox hoursCB;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\DoctorUI\UpdateScheduledExaminationWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox minutesCB;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\DoctorUI\UpdateScheduledExaminationWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button confirmButton;
        
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
            System.Uri resourceLocater = new System.Uri("/IS_Bolnica;component/doctorui/updatescheduledexaminationwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\DoctorUI\UpdateScheduledExaminationWindow.xaml"
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
            
            #line 10 "..\..\..\DoctorUI\UpdateScheduledExaminationWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.BackButtonClick);
            
            #line default
            #line hidden
            return;
            case 2:
            this.doctorsCB = ((System.Windows.Controls.ComboBox)(target));
            
            #line 23 "..\..\..\DoctorUI\UpdateScheduledExaminationWindow.xaml"
            this.doctorsCB.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.DoctorsSelectionChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.patientTxt = ((System.Windows.Controls.TextBox)(target));
            
            #line 25 "..\..\..\DoctorUI\UpdateScheduledExaminationWindow.xaml"
            this.patientTxt.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.PatientTextChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.patinetIdTxt = ((System.Windows.Controls.TextBox)(target));
            
            #line 26 "..\..\..\DoctorUI\UpdateScheduledExaminationWindow.xaml"
            this.patinetIdTxt.LostFocus += new System.Windows.RoutedEventHandler(this.IdTextFieldLostFocus);
            
            #line default
            #line hidden
            
            #line 26 "..\..\..\DoctorUI\UpdateScheduledExaminationWindow.xaml"
            this.patinetIdTxt.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.IdTextChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.healthCardNumTxt = ((System.Windows.Controls.TextBox)(target));
            
            #line 27 "..\..\..\DoctorUI\UpdateScheduledExaminationWindow.xaml"
            this.healthCardNumTxt.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.HealthCardTextChanged);
            
            #line default
            #line hidden
            return;
            case 6:
            this.ordinationTxt = ((System.Windows.Controls.TextBox)(target));
            
            #line 28 "..\..\..\DoctorUI\UpdateScheduledExaminationWindow.xaml"
            this.ordinationTxt.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.OrdinationTextChanged);
            
            #line default
            #line hidden
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
            this.confirmButton = ((System.Windows.Controls.Button)(target));
            
            #line 32 "..\..\..\DoctorUI\UpdateScheduledExaminationWindow.xaml"
            this.confirmButton.Click += new System.Windows.RoutedEventHandler(this.PotvrdiButtonClick);
            
            #line default
            #line hidden
            return;
            case 11:
            
            #line 35 "..\..\..\DoctorUI\UpdateScheduledExaminationWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ExaminationButtonClick);
            
            #line default
            #line hidden
            return;
            case 12:
            
            #line 40 "..\..\..\DoctorUI\UpdateScheduledExaminationWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.OperationButtonClick);
            
            #line default
            #line hidden
            return;
            case 13:
            
            #line 45 "..\..\..\DoctorUI\UpdateScheduledExaminationWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.NotificationsButtonClick);
            
            #line default
            #line hidden
            return;
            case 14:
            
            #line 50 "..\..\..\DoctorUI\UpdateScheduledExaminationWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.MedicamentsButtonClick);
            
            #line default
            #line hidden
            return;
            case 15:
            
            #line 56 "..\..\..\DoctorUI\UpdateScheduledExaminationWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.StatisticsButtonClick);
            
            #line default
            #line hidden
            return;
            case 16:
            
            #line 61 "..\..\..\DoctorUI\UpdateScheduledExaminationWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.SingOutButtonClick);
            
            #line default
            #line hidden
            return;
            case 17:
            
            #line 66 "..\..\..\DoctorUI\UpdateScheduledExaminationWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.SettingsButtonClick);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

