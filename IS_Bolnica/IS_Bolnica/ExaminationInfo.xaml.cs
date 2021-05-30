using IS_Bolnica.Model;
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
using System.Windows.Shapes;
using IS_Bolnica.Services;

namespace IS_Bolnica
{
    public partial class ExaminationInfo : Window
    {
        private int selectedPatient;
        private Appointment examination;
        private List<Appointment> loggedExaminations;
        private PrescriptionService prescriptionService = new PrescriptionService();
        private AnamnesisService anamnesisService = new AnamnesisService();
        private PatientService patientService = new PatientService();
        public ExaminationInfo(int selectedIndex, List<Appointment> loggedDoctorExaminations)
        {
            InitializeComponent();

            ExaminationsRecordFileStorage examinationsRecordFileStorage = new ExaminationsRecordFileStorage();

            this.loggedExaminations = loggedDoctorExaminations;
            this.examination = loggedExaminations.ElementAt(selectedIndex);

            patientTxt.Text = examination.Patient.Name + ' ' + examination.Patient.Surname;
            dateOfBirthTxt.Text = examination.Patient.DateOfBirth.ToString();
            jmbgTxt.Text = examination.Patient.Id;
            healthCardNumberTxt.Text = examination.Patient.HealthCardNumber;
            addressTxt.Text = examination.Patient.Address.Street + ", " + examination.Patient.Address.City.name;

            medicationsList.ItemsSource = prescriptionService.GetMedicationFromPrescription(jmbgTxt.Text);
            historyList.ItemsSource = anamnesisService.GetPatientsDiagnosesFromAnamneses(jmbgTxt.Text);
            allergiesList.ItemsSource = patientService.GetPatientsAllergies(jmbgTxt.Text);

            selectedPatient = selectedIndex;
        }

        private void anamnezaClicked(object sender, RoutedEventArgs e)
        {
            this.examination = loggedExaminations.ElementAt(selectedPatient);

            Diagnosis diagnosis = new Diagnosis(examination, loggedExaminations);

            diagnosis.Show();
            this.Close();

        }
    }
}
