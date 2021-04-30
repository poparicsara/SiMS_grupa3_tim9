﻿#pragma checksum "..\..\DoctorWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "59055A4B25F5D05C8252C5B63FF54FCBA1EADBE7A70D0770CCE0C158B8290809"
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
    /// DoctorWindow
    /// </summary>
    public partial class DoctorWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 11 "..\..\DoctorWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TabControl tabs;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\DoctorWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TabItem examinationsTab;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\DoctorWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dataGridExaminations;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\DoctorWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TabItem operationsTab;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\DoctorWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dataGridOperations;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\DoctorWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGridTextColumn dateColumn;
        
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
            System.Uri resourceLocater = new System.Uri("/IS_Bolnica;component/doctorwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\DoctorWindow.xaml"
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
            this.tabs = ((System.Windows.Controls.TabControl)(target));
            return;
            case 2:
            this.examinationsTab = ((System.Windows.Controls.TabItem)(target));
            return;
            case 3:
            this.dataGridExaminations = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 4:
            
            #line 27 "..\..\DoctorWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.addExaminationButton);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 28 "..\..\DoctorWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.cancelExaminationButton);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 29 "..\..\DoctorWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.updateExaminationButton);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 30 "..\..\DoctorWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.startExamination);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 31 "..\..\DoctorWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.notificationButton);
            
            #line default
            #line hidden
            return;
            case 9:
            this.operationsTab = ((System.Windows.Controls.TabItem)(target));
            return;
            case 10:
            this.dataGridOperations = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 11:
            this.dateColumn = ((System.Windows.Controls.DataGridTextColumn)(target));
            return;
            case 12:
            
            #line 50 "..\..\DoctorWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.addOperationButton);
            
            #line default
            #line hidden
            return;
            case 13:
            
            #line 51 "..\..\DoctorWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.cancelOperationButton);
            
            #line default
            #line hidden
            return;
            case 14:
            
            #line 52 "..\..\DoctorWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.updateOperationButton);
            
            #line default
            #line hidden
            return;
            case 15:
            
            #line 53 "..\..\DoctorWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.updateOperationButton);
            
            #line default
            #line hidden
            return;
            case 16:
            
            #line 54 "..\..\DoctorWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.notificationButton);
            
            #line default
            #line hidden
            return;
            case 17:
            
            #line 59 "..\..\DoctorWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.logOutButtonClicked);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

