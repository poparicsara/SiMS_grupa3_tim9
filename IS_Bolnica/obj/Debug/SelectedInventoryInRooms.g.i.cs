﻿#pragma checksum "..\..\SelectedInventoryInRooms.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "9833CAC16E7BF619B2546EED01BF7A13A9DF9DFD2645532E6F38C78C39653E11"
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
    /// SelectedInventoryInRooms
    /// </summary>
    public partial class SelectedInventoryInRooms : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 15 "..\..\SelectedInventoryInRooms.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid selectedInventoryOrdinacija;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\SelectedInventoryInRooms.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox ordinacijaSearchBox;
        
        #line default
        #line hidden
        
        
        #line 50 "..\..\SelectedInventoryInRooms.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid selectedInventoryOperacionaSala;
        
        #line default
        #line hidden
        
        
        #line 72 "..\..\SelectedInventoryInRooms.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox operacionaSearchBox;
        
        #line default
        #line hidden
        
        
        #line 84 "..\..\SelectedInventoryInRooms.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid selectedInventorySoba;
        
        #line default
        #line hidden
        
        
        #line 106 "..\..\SelectedInventoryInRooms.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox sobaSearchBox;
        
        #line default
        #line hidden
        
        
        #line 121 "..\..\SelectedInventoryInRooms.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label currentAmount;
        
        #line default
        #line hidden
        
        
        #line 122 "..\..\SelectedInventoryInRooms.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label minAmount;
        
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
            System.Uri resourceLocater = new System.Uri("/IS_Bolnica;component/selectedinventoryinrooms.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\SelectedInventoryInRooms.xaml"
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
            this.selectedInventoryOrdinacija = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 2:
            this.ordinacijaSearchBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 37 "..\..\SelectedInventoryInRooms.xaml"
            this.ordinacijaSearchBox.KeyUp += new System.Windows.Input.KeyEventHandler(this.ordinacijaKeyUp);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 40 "..\..\SelectedInventoryInRooms.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ChangeButton);
            
            #line default
            #line hidden
            return;
            case 4:
            this.selectedInventoryOperacionaSala = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 5:
            this.operacionaSearchBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 72 "..\..\SelectedInventoryInRooms.xaml"
            this.operacionaSearchBox.KeyDown += new System.Windows.Input.KeyEventHandler(this.operacionaKeyUp);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 75 "..\..\SelectedInventoryInRooms.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ChangeButton);
            
            #line default
            #line hidden
            return;
            case 7:
            this.selectedInventorySoba = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 8:
            this.sobaSearchBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 106 "..\..\SelectedInventoryInRooms.xaml"
            this.sobaSearchBox.KeyDown += new System.Windows.Input.KeyEventHandler(this.sobaKeyUp);
            
            #line default
            #line hidden
            return;
            case 9:
            
            #line 109 "..\..\SelectedInventoryInRooms.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ChangeButton);
            
            #line default
            #line hidden
            return;
            case 10:
            this.currentAmount = ((System.Windows.Controls.Label)(target));
            return;
            case 11:
            this.minAmount = ((System.Windows.Controls.Label)(target));
            return;
            case 12:
            
            #line 126 "..\..\SelectedInventoryInRooms.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ChangeButton);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
