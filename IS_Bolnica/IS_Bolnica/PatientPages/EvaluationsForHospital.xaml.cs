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
    /// <summary>
    /// Interaction logic for EvaluationsForHospital.xaml
    /// </summary>
    public partial class EvaluationsForHospital : Page
    {
        private EvaluationService evaluationService = new EvaluationService();
        public EvaluationsForHospital()
        {
            InitializeComponent();
            EvaluationsOfHospitalDataBinding.ItemsSource = evaluationService.getPatientEvaluationsOfHospital();
        }

        private void BackButtonClicked(object sender, RoutedEventArgs e)
        {
            PatientWindow.MyFrame.NavigationService.Navigate(new PatientEvaluations());
        }

        private void SearchKeyUp(object sender, KeyEventArgs e)
        {
            List<Evaluation> patientEvaluations = evaluationService.getPatientEvaluationsOfHospital();
            var filtered = patientEvaluations.Where(evaluation => evaluation.Assessment.ToString().Contains(SearchBox.Text.ToLower()));
            EvaluationsOfHospitalDataBinding.ItemsSource = filtered;
        }
    }
}
