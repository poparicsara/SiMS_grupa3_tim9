#pragma checksum "..\..\..\DemoMode\DemoMedicamentWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "78364BBC8C58AC6CCB64DEC0BA78F989B682E9C7FF676DD6CE68A78CAF2471CD"
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
    /// DemoMedicamentWindow
    /// </summary>
    public partial class DemoMedicamentWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 106 "..\..\..\DemoMode\DemoMedicamentWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid medicamentDataGrid;
        
        #line default
        #line hidden
        
        
        #line 146 "..\..\..\DemoMode\DemoMedicamentWindow.xaml"
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
            System.Uri resourceLocater = new System.Uri("/IS_Bolnica;component/demomode/demomedicamentwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\DemoMode\DemoMedicamentWindow.xaml"
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
            
            #line 20 "..\..\..\DemoMode\DemoMedicamentWindow.xaml"
            ((System.Windows.Input.CommandBinding)(target)).Executed += new System.Windows.Input.ExecutedRoutedEventHandler(this.RoomButtonClicked);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 21 "..\..\..\DemoMode\DemoMedicamentWindow.xaml"
            ((System.Windows.Input.CommandBinding)(target)).Executed += new System.Windows.Input.ExecutedRoutedEventHandler(this.InventoryButtonClicked);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 22 "..\..\..\DemoMode\DemoMedicamentWindow.xaml"
            ((System.Windows.Input.CommandBinding)(target)).Executed += new System.Windows.Input.ExecutedRoutedEventHandler(this.AddButtonClicked);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 23 "..\..\..\DemoMode\DemoMedicamentWindow.xaml"
            ((System.Windows.Input.CommandBinding)(target)).Executed += new System.Windows.Input.ExecutedRoutedEventHandler(this.EditButtonClicked);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 24 "..\..\..\DemoMode\DemoMedicamentWindow.xaml"
            ((System.Windows.Input.CommandBinding)(target)).Executed += new System.Windows.Input.ExecutedRoutedEventHandler(this.DeleteButtonClicked);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 48 "..\..\..\DemoMode\DemoMedicamentWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.RoomButtonClicked);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 56 "..\..\..\DemoMode\DemoMedicamentWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.InventoryButtonClicked);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 88 "..\..\..\DemoMode\DemoMedicamentWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.SingOutButtonClicked);
            
            #line default
            #line hidden
            return;
            case 9:
            this.medicamentDataGrid = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 10:
            
            #line 130 "..\..\..\DemoMode\DemoMedicamentWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.AddButtonClicked);
            
            #line default
            #line hidden
            return;
            case 11:
            
            #line 135 "..\..\..\DemoMode\DemoMedicamentWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.DeleteButtonClicked);
            
            #line default
            #line hidden
            return;
            case 12:
            
            #line 140 "..\..\..\DemoMode\DemoMedicamentWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.EditButtonClicked);
            
            #line default
            #line hidden
            return;
            case 13:
            this.searchBox = ((System.Windows.Controls.TextBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

