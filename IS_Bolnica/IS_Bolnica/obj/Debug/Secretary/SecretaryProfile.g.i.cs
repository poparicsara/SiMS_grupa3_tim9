// Updated by XamlIntelliSenseFileGenerator 6/13/2021 09:00:48 PM
#pragma checksum "..\..\..\Secretary\SecretaryProfile.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "D6E914D6EF95F3ED97FF54F7575866A1AEC48B4906805994A74EE78983427803"
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


namespace IS_Bolnica.GUI.Secretary.View
{


    /// <summary>
    /// SecretaryProfile
    /// </summary>
    public partial class SecretaryProfile : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector
    {


#line 20 "..\..\..\Secretary\SecretaryProfile.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Frame Frame;

#line default
#line hidden


#line 32 "..\..\..\Secretary\SecretaryProfile.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image nasLogo;

#line default
#line hidden


#line 43 "..\..\..\Secretary\SecretaryProfile.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label imeLabel;

#line default
#line hidden


#line 44 "..\..\..\Secretary\SecretaryProfile.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label prezimeimeLabel;

#line default
#line hidden


#line 45 "..\..\..\Secretary\SecretaryProfile.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label usernameLabel;

#line default
#line hidden


#line 46 "..\..\..\Secretary\SecretaryProfile.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label JMBGLabel;

#line default
#line hidden


#line 47 "..\..\..\Secretary\SecretaryProfile.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label dateLabel;

#line default
#line hidden


#line 48 "..\..\..\Secretary\SecretaryProfile.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label emailLabel;

#line default
#line hidden


#line 49 "..\..\..\Secretary\SecretaryProfile.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label telephoneLabel;

#line default
#line hidden


#line 50 "..\..\..\Secretary\SecretaryProfile.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label adressLabel;

#line default
#line hidden


#line 51 "..\..\..\Secretary\SecretaryProfile.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label cityLabel;

#line default
#line hidden


#line 52 "..\..\..\Secretary\SecretaryProfile.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label countryLabel;

#line default
#line hidden

        private bool _contentLoaded;

        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent()
        {
            if (_contentLoaded)
            {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/IS_Bolnica;component/secretary/secretaryprofile.xaml", System.UriKind.Relative);

#line 1 "..\..\..\Secretary\SecretaryProfile.xaml"
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
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target)
        {
            switch (connectionId)
            {
                case 1:
                    this.Frame = ((System.Windows.Controls.Frame)(target));
                    return;
                case 2:

#line 21 "..\..\..\Secretary\SecretaryProfile.xaml"
                    ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);

#line default
#line hidden
                    return;
                case 3:

#line 26 "..\..\..\Secretary\SecretaryProfile.xaml"
                    ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Logout_Clicked);

#line default
#line hidden
                    return;
                case 4:
                    this.nasLogo = ((System.Windows.Controls.Image)(target));
                    return;
                case 5:
                    this.imeLabel = ((System.Windows.Controls.Label)(target));
                    return;
                case 6:
                    this.prezimeimeLabel = ((System.Windows.Controls.Label)(target));
                    return;
                case 7:
                    this.usernameLabel = ((System.Windows.Controls.Label)(target));
                    return;
                case 8:
                    this.JMBGLabel = ((System.Windows.Controls.Label)(target));
                    return;
                case 9:
                    this.dateLabel = ((System.Windows.Controls.Label)(target));
                    return;
                case 10:
                    this.emailLabel = ((System.Windows.Controls.Label)(target));
                    return;
                case 11:
                    this.telephoneLabel = ((System.Windows.Controls.Label)(target));
                    return;
                case 12:
                    this.adressLabel = ((System.Windows.Controls.Label)(target));
                    return;
                case 13:
                    this.cityLabel = ((System.Windows.Controls.Label)(target));
                    return;
                case 14:
                    this.countryLabel = ((System.Windows.Controls.Label)(target));
                    return;
            }
            this._contentLoaded = true;
        }
    }
}

