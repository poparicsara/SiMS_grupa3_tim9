﻿#pragma checksum "..\..\..\DemoMode\EditRoomDemo.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "B541745DB8BD591865A7F00476BDA96C0CC63C1A0D6E2D6EA745AF1586D0640B"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using IS_Bolnica.DemoMode;
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


namespace IS_Bolnica.DemoMode {
    
    
    /// <summary>
    /// EditRoomDemo
    /// </summary>
    public partial class EditRoomDemo : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 13 "..\..\..\DemoMode\EditRoomDemo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox idBox;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\..\DemoMode\EditRoomDemo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox wardBox;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\DemoMode\EditRoomDemo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox purposeBox;
        
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
            System.Uri resourceLocater = new System.Uri("/IS_Bolnica;component/demomode/editroomdemo.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\DemoMode\EditRoomDemo.xaml"
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
            
            #line 8 "..\..\..\DemoMode\EditRoomDemo.xaml"
            ((IS_Bolnica.DemoMode.EditRoomDemo)(target)).Closing += new System.ComponentModel.CancelEventHandler(this.ClosingWindow);
            
            #line default
            #line hidden
            return;
            case 2:
            this.idBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.wardBox = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 4:
            this.purposeBox = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 5:
            
            #line 17 "..\..\..\DemoMode\EditRoomDemo.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.DoneButtonClicked);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 18 "..\..\..\DemoMode\EditRoomDemo.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.CancelButtonClicked);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
