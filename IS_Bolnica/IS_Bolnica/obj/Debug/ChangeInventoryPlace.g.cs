﻿#pragma checksum "..\..\ChangeInventoryPlace.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "75D2CCF25C076B33FB0E4F6898E6BA273B13AF9E27EC6832437CD193F5804F30"
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
    /// ChangeInventoryPlace
    /// </summary>
    public partial class ChangeInventoryPlace : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 14 "..\..\ChangeInventoryPlace.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox wardFromBox;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\ChangeInventoryPlace.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox numberFromBox;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\ChangeInventoryPlace.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox wardToBox;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\ChangeInventoryPlace.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox numberToBox;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\ChangeInventoryPlace.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox amountBox;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\ChangeInventoryPlace.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox purposeFromBox;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\ChangeInventoryPlace.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox purposeToBox;
        
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
            System.Uri resourceLocater = new System.Uri("/IS_Bolnica;component/changeinventoryplace.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\ChangeInventoryPlace.xaml"
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
            this.wardFromBox = ((System.Windows.Controls.ComboBox)(target));
            
            #line 14 "..\..\ChangeInventoryPlace.xaml"
            this.wardFromBox.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.wardFromChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.numberFromBox = ((System.Windows.Controls.ComboBox)(target));
            
            #line 15 "..\..\ChangeInventoryPlace.xaml"
            this.numberFromBox.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.numberFromChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.wardToBox = ((System.Windows.Controls.ComboBox)(target));
            
            #line 16 "..\..\ChangeInventoryPlace.xaml"
            this.wardToBox.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.wardToChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.numberToBox = ((System.Windows.Controls.ComboBox)(target));
            
            #line 17 "..\..\ChangeInventoryPlace.xaml"
            this.numberToBox.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.numberToChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 20 "..\..\ChangeInventoryPlace.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.DoneButton);
            
            #line default
            #line hidden
            return;
            case 6:
            this.amountBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 22 "..\..\ChangeInventoryPlace.xaml"
            this.amountBox.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.NumberValidation);
            
            #line default
            #line hidden
            return;
            case 7:
            this.purposeFromBox = ((System.Windows.Controls.ComboBox)(target));
            
            #line 24 "..\..\ChangeInventoryPlace.xaml"
            this.purposeFromBox.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.purposeFromChanged);
            
            #line default
            #line hidden
            return;
            case 8:
            this.purposeToBox = ((System.Windows.Controls.ComboBox)(target));
            
            #line 26 "..\..\ChangeInventoryPlace.xaml"
            this.purposeToBox.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.purposeToChanged);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

