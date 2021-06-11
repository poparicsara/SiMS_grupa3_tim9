﻿#pragma checksum "..\..\SeparateRoomWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "A98775EF7DB0F1F5B8ADB75FAFBC7FA0577592C7C87195FA9AF768F322D99DD6"
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
    /// SeparateRoomWindow
    /// </summary>
    public partial class SeparateRoomWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 14 "..\..\SeparateRoomWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker startDate;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\SeparateRoomWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker endDate;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\SeparateRoomWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox room1Box;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\SeparateRoomWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox roomNumberBox;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\SeparateRoomWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox hourBox;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\SeparateRoomWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox minuteBox;
        
        #line default
        #line hidden
        
        
        #line 78 "..\..\SeparateRoomWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock roomBlock;
        
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
            System.Uri resourceLocater = new System.Uri("/IS_Bolnica;component/separateroomwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\SeparateRoomWindow.xaml"
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
            
            #line 9 "..\..\SeparateRoomWindow.xaml"
            ((IS_Bolnica.SeparateRoomWindow)(target)).Closing += new System.ComponentModel.CancelEventHandler(this.ClosingWindow);
            
            #line default
            #line hidden
            return;
            case 2:
            this.startDate = ((System.Windows.Controls.DatePicker)(target));
            
            #line 14 "..\..\SeparateRoomWindow.xaml"
            this.startDate.SelectedDateChanged += new System.EventHandler<System.Windows.Controls.SelectionChangedEventArgs>(this.SetStartDate);
            
            #line default
            #line hidden
            return;
            case 3:
            this.endDate = ((System.Windows.Controls.DatePicker)(target));
            
            #line 15 "..\..\SeparateRoomWindow.xaml"
            this.endDate.SelectedDateChanged += new System.EventHandler<System.Windows.Controls.SelectionChangedEventArgs>(this.SetEndDate);
            
            #line default
            #line hidden
            return;
            case 4:
            this.room1Box = ((System.Windows.Controls.ComboBox)(target));
            
            #line 18 "..\..\SeparateRoomWindow.xaml"
            this.room1Box.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.RoomSelectionChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.roomNumberBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 19 "..\..\SeparateRoomWindow.xaml"
            this.roomNumberBox.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.NumberValidation);
            
            #line default
            #line hidden
            return;
            case 6:
            this.hourBox = ((System.Windows.Controls.ComboBox)(target));
            
            #line 21 "..\..\SeparateRoomWindow.xaml"
            this.hourBox.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.SetHour);
            
            #line default
            #line hidden
            return;
            case 7:
            this.minuteBox = ((System.Windows.Controls.ComboBox)(target));
            
            #line 47 "..\..\SeparateRoomWindow.xaml"
            this.minuteBox.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.SetMinute);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 75 "..\..\SeparateRoomWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.DoneButtonClicked);
            
            #line default
            #line hidden
            return;
            case 9:
            
            #line 77 "..\..\SeparateRoomWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.CancelButtonClicked);
            
            #line default
            #line hidden
            return;
            case 10:
            this.roomBlock = ((System.Windows.Controls.TextBlock)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
