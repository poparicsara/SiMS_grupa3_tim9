﻿#pragma checksum "..\..\..\Secretary\AddUrgentOperationWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "07D50F364CB9822D0D2E2663BFB4B84F02DCB49EAE7FBDC3073452C9D8A262CB"
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
    /// AddUrgentOperationWindow
    /// </summary>
    public partial class AddUrgentOperationWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 16 "..\..\..\Secretary\AddUrgentOperationWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image nasLogo;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\Secretary\AddUrgentOperationWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox specializationBox;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\Secretary\AddUrgentOperationWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox patientIdBox;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\Secretary\AddUrgentOperationWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox systemNameBox;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\Secretary\AddUrgentOperationWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton existableRButton;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\Secretary\AddUrgentOperationWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton guestRButton;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\Secretary\AddUrgentOperationWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox hourBox;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\..\Secretary\AddUrgentOperationWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox minuteBox;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\..\Secretary\AddUrgentOperationWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox operatiomRoomBox;
        
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
            System.Uri resourceLocater = new System.Uri("/IS_Bolnica;component/secretary/addurgentoperationwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Secretary\AddUrgentOperationWindow.xaml"
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
            
            #line 10 "..\..\..\Secretary\AddUrgentOperationWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.nasLogo = ((System.Windows.Controls.Image)(target));
            return;
            case 3:
            this.specializationBox = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 4:
            this.patientIdBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            
            #line 23 "..\..\..\Secretary\AddUrgentOperationWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.getOptions);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 24 "..\..\..\Secretary\AddUrgentOperationWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.addGuestAccount);
            
            #line default
            #line hidden
            return;
            case 7:
            this.systemNameBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.existableRButton = ((System.Windows.Controls.RadioButton)(target));
            
            #line 28 "..\..\..\Secretary\AddUrgentOperationWindow.xaml"
            this.existableRButton.Checked += new System.Windows.RoutedEventHandler(this.existableRButton_Checked);
            
            #line default
            #line hidden
            return;
            case 9:
            this.guestRButton = ((System.Windows.Controls.RadioButton)(target));
            
            #line 29 "..\..\..\Secretary\AddUrgentOperationWindow.xaml"
            this.guestRButton.Checked += new System.Windows.RoutedEventHandler(this.guestRButton_Checked);
            
            #line default
            #line hidden
            return;
            case 10:
            this.hourBox = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 11:
            this.minuteBox = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 12:
            this.operatiomRoomBox = ((System.Windows.Controls.ComboBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

