﻿#pragma checksum "..\..\..\Secretary\ActionBar.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "E75E3BE57C80EA29A864CACBDAD06510EDC7B81D228F91FEDBF5EAF47FD2BD61"
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
    /// ActionBar
    /// </summary>
    public partial class ActionBar : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 18 "..\..\..\Secretary\ActionBar.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image nasLogo;
        
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
            System.Uri resourceLocater = new System.Uri("/IS_Bolnica;component/secretary/actionbar.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Secretary\ActionBar.xaml"
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
            this.nasLogo = ((System.Windows.Controls.Image)(target));
            return;
            case 2:
            
            #line 20 "..\..\..\Secretary\ActionBar.xaml"
            ((System.Windows.Controls.ListBoxItem)(target)).Selected += new System.Windows.RoutedEventHandler(this.Profil_Selected);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 34 "..\..\..\Secretary\ActionBar.xaml"
            ((System.Windows.Controls.ListBoxItem)(target)).Selected += new System.Windows.RoutedEventHandler(this.SpisakPacijenata_Selected);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 41 "..\..\..\Secretary\ActionBar.xaml"
            ((System.Windows.Controls.ListBoxItem)(target)).Selected += new System.Windows.RoutedEventHandler(this.BlokiraniPacijenti_Selected);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 48 "..\..\..\Secretary\ActionBar.xaml"
            ((System.Windows.Controls.ListBoxItem)(target)).Selected += new System.Windows.RoutedEventHandler(this.SpisakGuestNaloga_Selected);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 55 "..\..\..\Secretary\ActionBar.xaml"
            ((System.Windows.Controls.ListBoxItem)(target)).Selected += new System.Windows.RoutedEventHandler(this.SpisakObavestenja_Selected);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 62 "..\..\..\Secretary\ActionBar.xaml"
            ((System.Windows.Controls.ListBoxItem)(target)).Selected += new System.Windows.RoutedEventHandler(this.SpisakLekara_Selected);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 69 "..\..\..\Secretary\ActionBar.xaml"
            ((System.Windows.Controls.ListBoxItem)(target)).Selected += new System.Windows.RoutedEventHandler(this.SpisakPregleda_Selected);
            
            #line default
            #line hidden
            return;
            case 9:
            
            #line 76 "..\..\..\Secretary\ActionBar.xaml"
            ((System.Windows.Controls.ListBoxItem)(target)).Selected += new System.Windows.RoutedEventHandler(this.SpisakOperacija_Selected);
            
            #line default
            #line hidden
            return;
            case 10:
            
            #line 83 "..\..\..\Secretary\ActionBar.xaml"
            ((System.Windows.Controls.ListBoxItem)(target)).Selected += new System.Windows.RoutedEventHandler(this.ZakaziHitanPregled_Selected);
            
            #line default
            #line hidden
            return;
            case 11:
            
            #line 90 "..\..\..\Secretary\ActionBar.xaml"
            ((System.Windows.Controls.ListBoxItem)(target)).Selected += new System.Windows.RoutedEventHandler(this.ZakaziHitnuOperaciju_Selected);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

