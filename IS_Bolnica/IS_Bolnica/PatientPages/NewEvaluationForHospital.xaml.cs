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
    /// Interaction logic for NewEvaluationForHospital.xaml
    /// </summary>
    public partial class NewEvaluationForHospital : Page
    {
        private FindAttributesService findAttributesService = new FindAttributesService();
        private EvaluationService evaluationService = new EvaluationService();
        public NewEvaluationForHospital()
        {
            InitializeComponent();
            HospitalTextBox.Text = "Zdravo bolnica, Novi Sad";
        }

        private void ConfirmButtonClicked(object sender, RoutedEventArgs e)
        {
            Evaluation evaluation = new Evaluation();
            evaluation.Bolnica = "Zdravo bolnica, Novi Sad";
            evaluation.Patient = findAttributesService.findPatientByUsername(PatientWindow.loggedPatient.Username);
            evaluation.Assessment = Convert.ToInt32(EvaluationComboBox.Text);
            evaluation.Comment = CommentTextBox.Text;
            evaluation.numOfMinutes = 5;
            evaluation.commentType = 1;
            evaluationService.addNote(evaluation);
            PatientWindow.MyFrame.NavigationService.Navigate(new MyAppointments());
        }
    }
}
