using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using IS_Bolnica.GUI.Patient.View;

namespace IS_Bolnica.PatientPages
{
    /// <summary>
    /// Interaction logic for PatientEvaluations.xaml
    /// </summary>
    public partial class PatientEvaluations : Page
    {
        public PatientEvaluations()
        {
            InitializeComponent();
        }

        private void AppointmentEvaluationsButtonClicked(object sender, RoutedEventArgs e)
        {
            PatientWindow.MyFrame.NavigationService.Navigate(new EvaluationsForAppointments());
        }

        private void HospitalEvaluationsButtonClicked(object sender, RoutedEventArgs e)
        {
            PatientWindow.MyFrame.NavigationService.Navigate(new EvaluationsForHospital());
        }

        private void BackButtonClicked(object sender, RoutedEventArgs e)
        {
            PatientWindow.MyFrame.NavigationService.Navigate(new MyAppointments());
        }
    }
}
