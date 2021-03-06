#pragma checksum "..\..\InventoryWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "5E47FDD5FEDE94DE2DD0E39ED764A9D326252AEE905F769AEC4D96F9DB892319"
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
    /// InventoryWindow
    /// </summary>
    public partial class InventoryWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 117 "..\..\InventoryWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TabControl tabs;
        
        #line default
        #line hidden
        
        
        #line 121 "..\..\InventoryWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dynamicDataGrid;
        
        #line default
        #line hidden
        
        
        #line 164 "..\..\InventoryWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox searchBox;
        
        #line default
        #line hidden
        
        
        #line 176 "..\..\InventoryWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid staticDataGrid;
        
        #line default
        #line hidden
        
        
        #line 218 "..\..\InventoryWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox statickiSearchBox;
        
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
            System.Uri resourceLocater = new System.Uri("/IS_Bolnica;component/inventorywindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\InventoryWindow.xaml"
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
            
            #line 22 "..\..\InventoryWindow.xaml"
            ((System.Windows.Input.CommandBinding)(target)).Executed += new System.Windows.Input.ExecutedRoutedEventHandler(this.MedicamentButtonClicked);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 23 "..\..\InventoryWindow.xaml"
            ((System.Windows.Input.CommandBinding)(target)).Executed += new System.Windows.Input.ExecutedRoutedEventHandler(this.RoomButtonClicked);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 24 "..\..\InventoryWindow.xaml"
            ((System.Windows.Input.CommandBinding)(target)).Executed += new System.Windows.Input.ExecutedRoutedEventHandler(this.EditDynamicButtonClicked);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 25 "..\..\InventoryWindow.xaml"
            ((System.Windows.Input.CommandBinding)(target)).Executed += new System.Windows.Input.ExecutedRoutedEventHandler(this.DeleteDynamicButtonClicked);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 26 "..\..\InventoryWindow.xaml"
            ((System.Windows.Input.CommandBinding)(target)).Executed += new System.Windows.Input.ExecutedRoutedEventHandler(this.InventoryPerRoomDynamicButton);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 27 "..\..\InventoryWindow.xaml"
            ((System.Windows.Input.CommandBinding)(target)).Executed += new System.Windows.Input.ExecutedRoutedEventHandler(this.InventoryPerRoomStaticButton);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 28 "..\..\InventoryWindow.xaml"
            ((System.Windows.Input.CommandBinding)(target)).Executed += new System.Windows.Input.ExecutedRoutedEventHandler(this.EditStaticButtonClicked);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 29 "..\..\InventoryWindow.xaml"
            ((System.Windows.Input.CommandBinding)(target)).Executed += new System.Windows.Input.ExecutedRoutedEventHandler(this.DeleteStaticButtonClicked);
            
            #line default
            #line hidden
            return;
            case 9:
            
            #line 30 "..\..\InventoryWindow.xaml"
            ((System.Windows.Input.CommandBinding)(target)).Executed += new System.Windows.Input.ExecutedRoutedEventHandler(this.ProfileButtonClicked);
            
            #line default
            #line hidden
            return;
            case 10:
            
            #line 31 "..\..\InventoryWindow.xaml"
            ((System.Windows.Input.CommandBinding)(target)).Executed += new System.Windows.Input.ExecutedRoutedEventHandler(this.NotificationButtonClicked);
            
            #line default
            #line hidden
            return;
            case 11:
            
            #line 51 "..\..\InventoryWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ProfileButtonClicked);
            
            #line default
            #line hidden
            return;
            case 12:
            
            #line 59 "..\..\InventoryWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.RoomButtonClicked);
            
            #line default
            #line hidden
            return;
            case 13:
            
            #line 75 "..\..\InventoryWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.MedicamentButtonClicked);
            
            #line default
            #line hidden
            return;
            case 14:
            
            #line 83 "..\..\InventoryWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.NotificationButtonClicked);
            
            #line default
            #line hidden
            return;
            case 15:
            
            #line 91 "..\..\InventoryWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ReportButtonClicked);
            
            #line default
            #line hidden
            return;
            case 16:
            
            #line 99 "..\..\InventoryWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.SignOutButtonClicked);
            
            #line default
            #line hidden
            return;
            case 17:
            this.tabs = ((System.Windows.Controls.TabControl)(target));
            return;
            case 18:
            this.dynamicDataGrid = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 20:
            
            #line 147 "..\..\InventoryWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.AddDynamicButtonClicked);
            
            #line default
            #line hidden
            return;
            case 21:
            
            #line 152 "..\..\InventoryWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.DeleteDynamicButtonClicked);
            
            #line default
            #line hidden
            return;
            case 22:
            
            #line 158 "..\..\InventoryWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.EditDynamicButtonClicked);
            
            #line default
            #line hidden
            return;
            case 23:
            this.searchBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 164 "..\..\InventoryWindow.xaml"
            this.searchBox.KeyUp += new System.Windows.Input.KeyEventHandler(this.DynamicKeyUp);
            
            #line default
            #line hidden
            return;
            case 24:
            this.staticDataGrid = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 26:
            
            #line 202 "..\..\InventoryWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.AddStaticButtonClicked);
            
            #line default
            #line hidden
            return;
            case 27:
            
            #line 207 "..\..\InventoryWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.DeleteStaticButtonClicked);
            
            #line default
            #line hidden
            return;
            case 28:
            
            #line 213 "..\..\InventoryWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.EditStaticButtonClicked);
            
            #line default
            #line hidden
            return;
            case 29:
            this.statickiSearchBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 218 "..\..\InventoryWindow.xaml"
            this.statickiSearchBox.KeyDown += new System.Windows.Input.KeyEventHandler(this.StaticKeyUp);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        void System.Windows.Markup.IStyleConnector.Connect(int connectionId, object target) {
            System.Windows.EventSetter eventSetter;
            switch (connectionId)
            {
            case 19:
            eventSetter = new System.Windows.EventSetter();
            eventSetter.Event = System.Windows.Controls.Control.MouseDoubleClickEvent;
            
            #line 137 "..\..\InventoryWindow.xaml"
            eventSetter.Handler = new System.Windows.Input.MouseButtonEventHandler(this.DynamicRowDoubleClick);
            
            #line default
            #line hidden
            ((System.Windows.Style)(target)).Setters.Add(eventSetter);
            break;
            case 25:
            eventSetter = new System.Windows.EventSetter();
            eventSetter.Event = System.Windows.Controls.Control.MouseDoubleClickEvent;
            
            #line 192 "..\..\InventoryWindow.xaml"
            eventSetter.Handler = new System.Windows.Input.MouseButtonEventHandler(this.StaticRowDoubleClick);
            
            #line default
            #line hidden
            ((System.Windows.Style)(target)).Setters.Add(eventSetter);
            break;
            }
        }
    }
}

