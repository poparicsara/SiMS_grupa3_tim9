﻿#pragma checksum "..\..\RoomWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "095C87BCE8817252AE4031378C0C5C129356F0B178A87F5F66ED6C75C0878C62"
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
    /// RoomWindow
    /// </summary>
    public partial class RoomWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 11 "..\..\RoomWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.WrapPanel Wrap1;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\RoomWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button pacijent;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\RoomWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button lekar;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\RoomWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button sekretar;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\RoomWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button upravnik;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\RoomWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid roomDataGrid;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\RoomWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox searchBox;
        
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
            System.Uri resourceLocater = new System.Uri("/IS_Bolnica;component/roomwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\RoomWindow.xaml"
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
            this.Wrap1 = ((System.Windows.Controls.WrapPanel)(target));
            return;
            case 2:
            this.pacijent = ((System.Windows.Controls.Button)(target));
            
            #line 12 "..\..\RoomWindow.xaml"
            this.pacijent.Click += new System.Windows.RoutedEventHandler(this.ProfileButtonClicked);
            
            #line default
            #line hidden
            return;
            case 3:
            this.lekar = ((System.Windows.Controls.Button)(target));
            return;
            case 4:
            this.sekretar = ((System.Windows.Controls.Button)(target));
            
            #line 18 "..\..\RoomWindow.xaml"
            this.sekretar.Click += new System.Windows.RoutedEventHandler(this.InventoryButtonClicked);
            
            #line default
            #line hidden
            return;
            case 5:
            this.upravnik = ((System.Windows.Controls.Button)(target));
            
            #line 21 "..\..\RoomWindow.xaml"
            this.upravnik.Click += new System.Windows.RoutedEventHandler(this.MedicamentButtonClicked);
            
            #line default
            #line hidden
            return;
            case 6:
            this.roomDataGrid = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 7:
            
            #line 46 "..\..\RoomWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.AddButtonClicked);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 47 "..\..\RoomWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.DeleteButtonClicked);
            
            #line default
            #line hidden
            return;
            case 9:
            
            #line 48 "..\..\RoomWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.EditButtonClicked);
            
            #line default
            #line hidden
            return;
            case 10:
            this.searchBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 49 "..\..\RoomWindow.xaml"
            this.searchBox.KeyUp += new System.Windows.Input.KeyEventHandler(this.searchKeyUp);
            
            #line default
            #line hidden
            return;
            case 11:
            
            #line 50 "..\..\RoomWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.NotificationButtonClicked);
            
            #line default
            #line hidden
            return;
            case 12:
            
            #line 51 "..\..\RoomWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.RenovationButton);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

