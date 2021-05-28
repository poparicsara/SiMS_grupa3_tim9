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

namespace IS_Bolnica
{
    public partial class Diagnosis : Window
    {
        private Examination examination;
        private Anamnesis anamnesis = new Anamnesis();
        private AnamnesisRepository anamnesisStorage = new AnamnesisRepository();
        public List<Anamnesis> Anamneses { get; set; } = new List<Anamnesis>();
        private PatientRepository patientStorage = new PatientRepository();
        public List<Patient> Patients { get; set; } = new List<Patient>();
        public List<Doctor> Doctors { get; set; }
        private DoctorRepository doctorStorage = new DoctorRepository();
        public Diagnosis(Examination examination, List<Examination> loggedExaminations)
        {
            InitializeComponent();
            this.examination = examination;

            patientTxt.Text = examination.Patient.Name + ' ' + examination.Patient.Surname;
            jmbgTxt.Text = examination.Patient.Id;
            dateOfBirthTxt.Text = examination.Patient.DateOfBirth.ToString();
            healthCardNumberTxt.Text = examination.Patient.HealthCardNumber;
            dateOfExaminationTxt.Text = examination.Date.ToString();
            addressTxt.Text = examination.Patient.Address.Street + ", " + examination.Patient.Address.City.name;
            doctorTxt.Text = examination.Doctor.Name + ' ' + examination.Doctor.Surname;
        }

        private void izdajRecept(object sender, RoutedEventArgs e)
        {
            Anamneses = anamnesisStorage.loadFromFile("anamneses.json");
            Patients = patientStorage.LoadFromFile("PatientRecordFileStorage.json");
            Doctors = doctorStorage.loadFromFile("Doctors.json");

            foreach (Doctor doctor in Doctors)
            {

                string drNameSurname = doctor.Name + ' ' + doctor.Surname;

                if (drNameSurname.Equals(doctorTxt.Text))
                {
                    anamnesis.Doctor = doctor;
                }
            }

            foreach (Patient patient in Patients)
            {
                if (patient.Id.Equals(jmbgTxt.Text))
                {
                    anamnesis.Patient = patient;
                }
            }

            anamnesis.Symptoms = symptomsTxt.Text;
            anamnesis.Diagnosis = diagnosisTxt.Text;
            anamnesis.Date = DateTime.Parse(dateOfExaminationTxt.Text);

            Anamneses.Add(anamnesis);
            anamnesisStorage.saveToFile(Anamneses, "anamneses.json");

            ExaminationsRecordFileStorage examinationsRecordFileStorage = new ExaminationsRecordFileStorage();
            List<Examination> examinations = examinationsRecordFileStorage.loadFromFile("examinations.json");

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
