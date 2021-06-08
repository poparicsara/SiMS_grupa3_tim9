using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using IS_Bolnica.GUI.Patient.Command;
using IS_Bolnica.PatientPages;
using IS_Bolnica.Services;
using Model;

namespace IS_Bolnica.GUI.Patient.ViewModel
{
    public class EvaulationsForAppointmentsVM
    {
        private EvaluationService evaluationService = new EvaluationService();
        #region Properties

        public string SearchText { get; set; }
        public List<Evaluation> PatientEvaluations { get; set; }

        #endregion

        #region Constructor

        public EvaulationsForAppointmentsVM()
        {
            SetCommands();
            PatientEvaluations = evaluationService.getPatientEvaluationsOfAppointment();
        }

        #endregion

        #region Commands

        public RelayCommand BackButtonCommand { get; private set; }

        public RelayCommand SearchCommand { get; private set; }

        #endregion

        #region CommandActions

        private void BackExecute(object parameter)
        {
            PatientWindow.MyFrame.NavigationService.Navigate(new PatientEvaluations());
        }

        private void SearchExecute(object parameter)
        {
            DataGrid OceneDataBinding = (DataGrid) parameter;
            EvaluationService evaluationService = new EvaluationService();
            List<Evaluation> patientEvaluations = evaluationService.getPatientEvaluationsOfAppointment();
            var filtered = patientEvaluations.Where(evaluation => evaluation.Doctor.Name.ToLower().Contains(SearchText.ToLower()));
            OceneDataBinding.ItemsSource = filtered;
        }


        #endregion

        #region Methods

        private void SetCommands()
        {
            BackButtonCommand = new RelayCommand(BackExecute);
            SearchCommand = new RelayCommand(SearchExecute);
        }

        #endregion
    }
}
