﻿#pragma checksum "..\..\..\Secretary\AllergenManipulation.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "4933B78FDE9BC907E47DD3D09E0ECD6E57F939854E981A5C34863EA034B99AD9"
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
    /// AllergenManipulation
    /// </summary>
    public partial class AllergenManipulation : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 18 "..\..\..\Secretary\AllergenManipulation.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image nasLogo;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\Secretary\AllergenManipulation.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView AllAllergens;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\Secretary\AllergenManipulation.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView PatientsAllergens;
        
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
            System.Uri resourceLocater = new System.Uri("/IS_Bolnica;component/secretary/allergenmanipulation.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Secretary\AllergenManipulation.xaml"
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
            
            #line 12 "..\..\..\Secretary\AllergenManipulation.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.nasLogo = ((System.Windows.Controls.Image)(target));
            return;
            case 3:
            this.AllAllergens = ((System.Windows.Controls.ListView)(target));
            
            #line 20 "..\..\..\Secretary\AllergenManipulation.xaml"
            this.AllAllergens.DragOver += new System.Windows.DragEventHandler(this.AllAllergens_OnDragOver);
            
            #line default
            #line hidden
            
            #line 20 "..\..\..\Secretary\AllergenManipulation.xaml"
            this.AllAllergens.Drop += new System.Windows.DragEventHandler(this.AllAllergens_OnDrop);
            
            #line default
            #line hidden
            
            #line 20 "..\..\..\Secretary\AllergenManipulation.xaml"
            this.AllAllergens.PreviewMouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.AllAllergens_OnPreviewMouseLeftButtonDown);
            
            #line default
            #line hidden
            
            #line 20 "..\..\..\Secretary\AllergenManipulation.xaml"
            this.AllAllergens.MouseMove += new System.Windows.Input.MouseEventHandler(this.AllAllergens_OnMouseMove);
            
            #line default
            #line hidden
            return;
            case 4:
            this.PatientsAllergens = ((System.Windows.Controls.ListView)(target));
            
            #line 30 "..\..\..\Secretary\AllergenManipulation.xaml"
            this.PatientsAllergens.DragOver += new System.Windows.DragEventHandler(this.PatientsAllergens_OnDragOver);
            
            #line default
            #line hidden
            
            #line 30 "..\..\..\Secretary\AllergenManipulation.xaml"
            this.PatientsAllergens.Drop += new System.Windows.DragEventHandler(this.PatientsAllergens_OnDrop);
            
            #line default
            #line hidden
            
            #line 30 "..\..\..\Secretary\AllergenManipulation.xaml"
            this.PatientsAllergens.PreviewMouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.PatientsAllergens_OnPreviewMouseLeftButtonDown);
            
            #line default
            #line hidden
            
            #line 30 "..\..\..\Secretary\AllergenManipulation.xaml"
            this.PatientsAllergens.MouseMove += new System.Windows.Input.MouseEventHandler(this.PatientsAllergens_OnMouseMove);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 39 "..\..\..\Secretary\AllergenManipulation.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.EditAllergens);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 40 "..\..\..\Secretary\AllergenManipulation.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.CancelEditingAllergens);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

