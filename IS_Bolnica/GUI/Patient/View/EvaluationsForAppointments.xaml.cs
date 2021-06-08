using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using IS_Bolnica.GUI.Patient.ViewModel;
using IS_Bolnica.PatientPages;
using IS_Bolnica.Services;
using Model;

namespace IS_Bolnica.GUI.Patient.View
{
    /// <summary>
    /// Interaction logic for EvaluationsForAppointments.xaml
    /// </summary>
    public partial class EvaluationsForAppointments : Page
    {
        private EvaluationService evaluationService = new EvaluationService();
        public EvaluationsForAppointments()
        {
            InitializeComponent();
            DataContext = new EvaulationsForAppointmentsVM();
            OceneDataBinding.ItemsSource = evaluationService.getPatientEvaluationsOfAppointment();
        }

        private void BackButtonClicked(object sender, RoutedEventArgs e)
        {
            PatientWindow.MyFrame.NavigationService.Navigate(new PatientEvaluations());
        }

        private void SearchKeyUp(object sender, KeyEventArgs e)
        {
            List<Evaluation> patientEvaluations = evaluationService.getPatientEvaluationsOfAppointment();
            var filtered = patientEvaluations.Where(evaluation => evaluation.Doctor.Name.ToLower().Contains(SearchBox.Text.ToLower()));
            OceneDataBinding.ItemsSource = filtered;
        }
    }
}
