﻿#pragma checksum "..\..\NewRoomWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "13D5E875BB987D1E1780E2744DC6736E13DF84B4D068B187D1C720690A147472"
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
    /// NewRoomWindow
    /// </summary>
    public partial class NewRoomWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 18 "..\..\NewRoomWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox roomBox;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\NewRoomWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox purposeBox;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\NewRoomWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox wardBox;
        
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
            System.Uri resourceLocater = new System.Uri("/IS_Bolnica;component/newroomwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\NewRoomWindow.xaml"
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
            
            #line 9 "..\..\NewRoomWindow.xaml"
            ((IS_Bolnica.NewRoomWindow)(target)).Closing += new System.ComponentModel.CancelEventHandler(this.ClosingWindow);
            
            #line default
            #line hidden
            return;
            case 2:
            this.roomBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 18 "..\..\NewRoomWindow.xaml"
            this.roomBox.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.NumberValidation);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 20 "..\..\NewRoomWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.DoneAddingButton);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 21 "..\..\NewRoomWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.CancelButton);
            
            #line default
            #line hidden
            return;
            case 5:
            this.purposeBox = ((System.Windows.Controls.ComboBox)(target));
            
            #line 22 "..\..\NewRoomWindow.xaml"
            this.purposeBox.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.PurposeSelectionChanged);
            
            #line default
            #line hidden
            return;
            case 6:
            this.wardBox = ((System.Windows.Controls.ComboBox)(target));
            
            #line 23 "..\..\NewRoomWindow.xaml"
            this.wardBox.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.SelectionChanged);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

