﻿#pragma checksum "..\..\SelectedRequest.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "A2199A9EFF42FDA0CBEB8AC59B726AE0DFA2DEA683171E14D5C8B0FD234EC73C"
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
    /// SelectedRequest
    /// </summary>
    public partial class SelectedRequest : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 11 "..\..\SelectedRequest.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox idBox;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\SelectedRequest.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox nameBox;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\SelectedRequest.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox replacementBox;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\SelectedRequest.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox producerBox;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\SelectedRequest.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button sentToEditButton;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\SelectedRequest.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button acceptMedButton;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\SelectedRequest.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox responceBox;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\SelectedRequest.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button deleteButton;
        
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
            System.Uri resourceLocater = new System.Uri("/IS_Bolnica;component/selectedrequest.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\SelectedRequest.xaml"
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
            this.idBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.nameBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.replacementBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.producerBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.sentToEditButton = ((System.Windows.Controls.Button)(target));
            
            #line 21 "..\..\SelectedRequest.xaml"
            this.sentToEditButton.Click += new System.Windows.RoutedEventHandler(this.SentToEditButton);
            
            #line default
            #line hidden
            return;
            case 6:
            this.acceptMedButton = ((System.Windows.Controls.Button)(target));
            
            #line 24 "..\..\SelectedRequest.xaml"
            this.acceptMedButton.Click += new System.Windows.RoutedEventHandler(this.AcceptMedicamentButton);
            
            #line default
            #line hidden
            return;
            case 7:
            this.responceBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.deleteButton = ((System.Windows.Controls.Button)(target));
            
            #line 29 "..\..\SelectedRequest.xaml"
            this.deleteButton.Click += new System.Windows.RoutedEventHandler(this.ConfirmDeletingButton);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

