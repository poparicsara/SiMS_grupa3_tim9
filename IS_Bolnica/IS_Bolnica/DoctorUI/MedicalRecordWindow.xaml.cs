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
using IS_Bolnica.Model;
using IS_Bolnica.Services;

namespace IS_Bolnica.DoctorUI
{
    public partial class MedicalRecordWindow : Window
    {
        private Appointment examination;
        private int selectedPatient;
        private List<Appointment> loggedExaminations;
        private PrescriptionService prescriptionService = new PrescriptionService();
        private PatientService patientService = new PatientService();
        private AnamnesisService anamnesisService = new AnamnesisService();
        private UserService userService = new UserService();
        public MedicalRecordWindow(int selectedIndex, List<Appointment> loggedDoctorExaminations)
        {
            InitializeComponent();
            loggedExaminations = loggedDoctorExaminations;
            this.examination = loggedExaminations.ElementAt(selectedIndex);
            patientTxt.Text = examination.Patient.Name + ' ' + examination.Patient.Surname;
            dateOfBirthTxt.Text = examination.Patient.DateOfBirth.ToString("MM/dd/yyyy");
            patinetIdTxt.Text = examination.Patient.Id;
            healthCardNumTxt.Text = examination.Patient.HealthCardNumber;
            addressTxt.Text = examination.Patient.Address.Street + ", " + examination.Patient.Address.City.name;

            medsLB.ItemsSource = prescriptionService.GetMedicationFromPrescription(patinetIdTxt.Text);
            historyLB.ItemsSource = anamnesisService.GetPatientsDiagnosesFromAnamneses(patinetIdTxt.Text);
            allergiesLB.ItemsSource = patientService.GetPatientsAllergies(patinetIdTxt.Text);

            selectedPatient = selectedIndex;
        }

        private void AnamnezaButtonClick(object sender, RoutedEventArgs e)
        {
            this.examination = loggedExaminations.ElementAt(selectedPatient);
            AnamnesisWindow anamnesisWindow = new AnamnesisWindow(examination, loggedExaminations, selectedPatient);
            anamnesisWindow.Show();
            this.Close();
        }

        private void BackButtonClick(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBox = MessageBox.Show("Da li ste sigurni da želite da izađete?",
                "Izmena operacije", MessageBoxButton.YesNo);

            switch (messageBox)
            {
                case MessageBoxResult.Yes:
                    DoctorStartWindow doctorStartWindow = new DoctorStartWindow();
                    doctorStartWindow.Show();
                    this.Close();
                    break;
                case MessageBoxResult.No:
                    break;
            }
        }

        private void ExaminationsButtonClick(object sender, RoutedEventArgs e)
        {
            DoctorStartWindow doctorStartWindow = new DoctorStartWindow();
            doctorStartWindow.Show();
            this.Close();
        }

        private void OperationButtonClick(object sender, RoutedEventArgs e)
        {
            this.Show();
        }

        private void NotificationsButtonClick(object sender, RoutedEventArgs e)
        {

        }

        private void StatisticsButtonClick(object sender, RoutedEventArgs e)
        {

        }

        private void SingOutButtonClick(object sender, RoutedEventArgs e)
        {
            userService.LogOut();
            this.Close();
        }

        private void SettingsButtonClick(object sender, RoutedEventArgs e)
        {

        }

        private void MedicamentsButtonClick(object sender, RoutedEventArgs e)
        {
            MedicamentsWindow medicamentsWindow = new MedicamentsWindow();
            medicamentsWindow.Show();
            this.Close();
        }
    }
}
