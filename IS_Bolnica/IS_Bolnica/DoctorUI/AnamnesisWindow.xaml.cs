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
    public partial class AnamnesisWindow : Window
    {
        private UserService userService = new UserService();
        private Appointment examination;
        private List<Appointment> loggedAppointments;
        private int selectedIndex;
        private Anamnesis anamnesis = new Anamnesis();
        private DoctorService doctorService = new DoctorService();
        private PatientService patientService = new PatientService();
        private AnamnesisService anamnesisService = new AnamnesisService();
        public AnamnesisWindow(Appointment examination, List<Appointment> loggedAppointments, int selectedPatient)
        {
            InitializeComponent();
            this.examination = examination;
            this.selectedIndex = selectedPatient;
            this.loggedAppointments = loggedAppointments;
            patientTxt.Text = examination.Patient.Name + ' ' + examination.Patient.Surname;
            patinetIdTxt.Text = examination.Patient.Id;
            dateOfBirthTxt.Text = examination.Patient.DateOfBirth.ToString();
            healthCardNumTxt.Text = examination.Patient.HealthCardNumber;
            examinationDate.SelectedDate = examination.StartTime;
            addressTxt.Text = examination.Patient.Address.Street + ", " + examination.Patient.Address.City.name;
            doctorTxt.Text = examination.Doctor.Name + ' ' + examination.Doctor.Surname;
        }

        private void SaveButtonClick(object sender, RoutedEventArgs e)
        {
            SetAnamnesisFields();
            anamnesisService.CreateAnamnesis(anamnesis);
        }

        private void BackButtonClick(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBox = MessageBox.Show("Da li ste sigurni da želite da izađete?",
                "Izmena operacije", MessageBoxButton.YesNo);

            switch (messageBox)
            {
                case MessageBoxResult.Yes:
                    MedicalRecordWindow medicalRecordWindow =
                        new MedicalRecordWindow(selectedIndex, loggedAppointments);
                    medicalRecordWindow.Show();
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

        private void HospitalizationButtonClick(object sender, RoutedEventArgs e)
        {
            SetAnamnesisFields();
            anamnesisService.CreateAnamnesis(anamnesis);
            HospitalizationWindow hospitalizationWindow = new HospitalizationWindow(anamnesis);
            hospitalizationWindow.Show();
            this.Close();
        }

        private void PrescriptionButtonClick(object sender, RoutedEventArgs e)
        {
            SetAnamnesisFields();
            anamnesisService.CreateAnamnesis(anamnesis);
            CreatePrescriptionWindow createPrescriptionWindow = new CreatePrescriptionWindow(anamnesis);
            createPrescriptionWindow.Show();
            this.Close();
        }

        private void SetAnamnesisFields()
        {
            anamnesis.Doctor = doctorService.FindDoctorByName(doctorTxt.Text);
            anamnesis.Patient = patientService.findPatientById(patinetIdTxt.Text);
            anamnesis.Symptoms = symptomsTxt.Text;
            anamnesis.Diagnosis = diagnosisTxt.Text;
            anamnesis.Date = (DateTime)examinationDate.SelectedDate;
        }

        private void MedicamentsButtonClick(object sender, RoutedEventArgs e)
        {
            MedicamentsWindow medicamentsWindow = new MedicamentsWindow();
            medicamentsWindow.Show();
            this.Close();
        }

        private void InvoiceButtonClick(object sender, RoutedEventArgs e)
        {
            SetAnamnesisFields();
            anamnesisService.CreateAnamnesis(anamnesis);
            AnamnesisInvoiceWindow anamnesisInvoiceWindow = new AnamnesisInvoiceWindow(anamnesis);
            anamnesisInvoiceWindow.Show();
            this.Close();
        }
    }
}
