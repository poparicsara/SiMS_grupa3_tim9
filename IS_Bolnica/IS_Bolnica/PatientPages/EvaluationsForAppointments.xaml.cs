using IS_Bolnica.Services;
using Model;
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

namespace IS_Bolnica.PatientPages
{
    public partial class EvaluationsForAppointments : Page
    {
        private EvaluationService evaluationService = new EvaluationService();
        public EvaluationsForAppointments()
        {
            InitializeComponent();
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
