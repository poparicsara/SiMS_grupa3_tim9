﻿#pragma checksum "..\..\..\DoctorUI\ReviewMedRequestWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "D1BD806F082509E5989E989C64B6220B3489D6C360576E823B25667DF39B3ED7"
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
    /// ReviewMedRequestWindow
    /// </summary>
    public partial class ReviewMedRequestWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 24 "..\..\..\DoctorUI\ReviewMedRequestWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox idTxt;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\DoctorUI\ReviewMedRequestWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox nameTxt;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\DoctorUI\ReviewMedRequestWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox producerTxt;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\DoctorUI\ReviewMedRequestWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox replacementTxt;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\DoctorUI\ReviewMedRequestWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox ingredientsTxt;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\DoctorUI\ReviewMedRequestWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox responseTxt;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\DoctorUI\ReviewMedRequestWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button approveDeleting;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\DoctorUI\ReviewMedRequestWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button approveMed;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\DoctorUI\ReviewMedRequestWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button sendOnUpdate;
        
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
            System.Uri resourceLocater = new System.Uri("/IS_Bolnica;component/doctorui/reviewmedrequestwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\DoctorUI\ReviewMedRequestWindow.xaml"
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
            
            #line 13 "..\..\..\DoctorUI\ReviewMedRequestWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.BackButtonClick);
            
            #line default
            #line hidden
            return;
            case 2:
            this.idTxt = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.nameTxt = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.producerTxt = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.replacementTxt = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.ingredientsTxt = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.responseTxt = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.approveDeleting = ((System.Windows.Controls.Button)(target));
            
            #line 31 "..\..\..\DoctorUI\ReviewMedRequestWindow.xaml"
            this.approveDeleting.Click += new System.Windows.RoutedEventHandler(this.ApproveDeletingButtonClick);
            
            #line default
            #line hidden
            return;
            case 9:
            this.approveMed = ((System.Windows.Controls.Button)(target));
            
            #line 32 "..\..\..\DoctorUI\ReviewMedRequestWindow.xaml"
            this.approveMed.Click += new System.Windows.RoutedEventHandler(this.ApproveMedButtonClick);
            
            #line default
            #line hidden
            return;
            case 10:
            this.sendOnUpdate = ((System.Windows.Controls.Button)(target));
            
            #line 33 "..\..\..\DoctorUI\ReviewMedRequestWindow.xaml"
            this.sendOnUpdate.Click += new System.Windows.RoutedEventHandler(this.SendOnUpdateButtonClick);
            
            #line default
            #line hidden
            return;
            case 11:
            
            #line 36 "..\..\..\DoctorUI\ReviewMedRequestWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ExaminationsButtonClick);
            
            #line default
            #line hidden
            return;
            case 12:
            
            #line 41 "..\..\..\DoctorUI\ReviewMedRequestWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.OperationButtonClick);
            
            #line default
            #line hidden
            return;
            case 13:
            
            #line 46 "..\..\..\DoctorUI\ReviewMedRequestWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.NotificationsButtonClick);
            
            #line default
            #line hidden
            return;
            case 14:
            
            #line 51 "..\..\..\DoctorUI\ReviewMedRequestWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.MedicamentsButtonClick);
            
            #line default
            #line hidden
            return;
            case 15:
            
            #line 57 "..\..\..\DoctorUI\ReviewMedRequestWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.StatisticsButtonClick);
            
            #line default
            #line hidden
            return;
            case 16:
            
            #line 62 "..\..\..\DoctorUI\ReviewMedRequestWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.SingOutButtonClick);
            
            #line default
            #line hidden
            return;
            case 17:
            
            #line 67 "..\..\..\DoctorUI\ReviewMedRequestWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.SettingsButtonClick);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
