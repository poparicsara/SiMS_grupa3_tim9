using IS_Bolnica.DoctorsWindows;
using IS_Bolnica.Model;
using Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public partial class Diagnosis : Window
    {
        private Appointment examination;
        private Anamnesis anamnesis = new Anamnesis();
        private DoctorService doctorService = new DoctorService();
        private PatientService patientService = new PatientService();
        private AnamnesisService anamnesisService = new AnamnesisService();
        public Diagnosis(Appointment examination, List<Appointment> loggedExaminations)
        {
            InitializeComponent();
            this.examination = examination;

            patientTxt.Text = examination.Patient.Name + ' ' + examination.Patient.Surname;
            jmbgTxt.Text = examination.Patient.Id;
            dateOfBirthTxt.Text = examination.Patient.DateOfBirth.ToString();
            healthCardNumberTxt.Text = examination.Patient.HealthCardNumber;
            dateOfExaminationTxt.Text = examination.StartTime.ToString();
            addressTxt.Text = examination.Patient.Address.Street + ", " + examination.Patient.Address.City.name;
            doctorTxt.Text = examination.Doctor.Name + ' ' + examination.Doctor.Surname;
        }

        private void izdajRecept(object sender, RoutedEventArgs e)
        {
            anamnesis.Doctor = doctorService.findDoctorByName(doctorTxt.Text);
            anamnesis.Patient = patientService.findPatientById(jmbgTxt.Text);
            anamnesis.Symptoms = symptomsTxt.Text;
            anamnesis.Diagnosis = diagnosisTxt.Text;
            anamnesis.Date = DateTime.Parse(dateOfExaminationTxt.Text);

            anamnesisService.createAnamnesis(anamnesis);

            CreatePrescription createPrescription = new CreatePrescription(anamnesis);
            createPrescription.Show();
            this.Close();
        }

        private void scheduleOperationButtonClicked(object sender, RoutedEventArgs e)
        {
            AddOperationWindow addOperationWindow = new AddOperationWindow();
            addOperationWindow.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddExaminationWindow addExaminationWindow = new AddExaminationWindow();
            addExaminationWindow.Show();
        }
    }
}
