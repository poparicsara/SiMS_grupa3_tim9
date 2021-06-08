using System;
using System.Windows;
using System.Windows.Controls;
using IS_Bolnica.GUI.Patient.ViewModel;
using IS_Bolnica.PatientPages;

namespace IS_Bolnica.GUI.Patient.View
{
    /// <summary>
    /// Interaction logic for InformationPage.xaml
    /// </summary>
    public partial class InformationPage : Page
    {
        public InformationPage(String title, String text)
        {
            InitializeComponent();

            DataContext = new InformationPageVM(title, text);
        }
    }
}
