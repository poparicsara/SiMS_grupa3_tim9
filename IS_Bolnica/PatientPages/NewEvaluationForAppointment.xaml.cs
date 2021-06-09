using IS_Bolnica.Model;
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
    /// Interaction logic for NewEvaluationForAppointment.xaml
    /// </summary>
    public partial class NewEvaluationForAppointment : Page
    {
        private FindAttributesService findAttributesService = new FindAttributesService();
        private EvaluationService evaluationService = new EvaluationService();
        private AppointmentService appointmentService = new AppointmentService();
        public NewEvaluationForAppointment(Appointment appointment)
        {
            InitializeComponent();
            DoktorTextBox.Text = appointment.Doctor.Name + " " + appointment.Doctor.Surname;
        }

        private void ConfirmButtonClicked(object sender, RoutedEventArgs e)
        {
            Evaluation evaluation = new Evaluation();
            evaluation.Doctor = findAttributesService.findDoctor(DoktorTextBox.Text.Split(' ')[0], DoktorTextBox.Text.Split(' ')[1]);
            evaluation.Patient = findAttributesService.findPatientByUsername(PatientWindow.username_patient);
            evaluation.Assessment = Convert.ToInt32(EvaluationComboBox.Text);
            evaluation.Comment = CommentTextBox.Text;
            evaluation.Bolnica = "";
            evaluation.numOfMinutes = 5;
            evaluation.commentType = 0;
            evaluationService.addNote(evaluation);

            if(appointmentService.sendEvaluationOfHospital())
                PatientWindow.MyFrame.NavigationService.Navigate(new NewEvaluationForHospital());
            else
                PatientWindow.MyFrame.NavigationService.Navigate(new MyAppointments());

        }
    }
}
