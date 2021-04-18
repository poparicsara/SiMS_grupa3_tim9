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

namespace IS_Bolnica
{
    public partial class CreatePrescription : Window
    {
        public CreatePrescription()
        {
            InitializeComponent();
        }

        private void potvrdiClicked(object sender, RoutedEventArgs e)
        {
            Prescription prescription = new Prescription();
            Doctor doctor = new Doctor();
            Patient patient = new Patient();
            Therapy therapy = new Therapy();

           // patient.Name = patientNameTxt.Text;
           // patient.Surname = patientSurnameTxt.Text;
           // patient.DateOfBirth = DateTime.Parse(dateOfBirthTxt.Text);
           // patient.Id = jmbgTxt.Text;
           // patient.HealthCardNumber = healthCardIdTxt.Text;
            //prescription.Diagnosis = diagnosisTxt.Text;
           // prescription.Doctor.Name = doctorTxt.Text;
            therapy.MedicationName = medTxt.Text;
            therapy.Dose = int.Parse(doseTxt.Text);
            prescription.Therapy = therapy;
            prescription.Date = DateTime.Parse(prescriptionDateTxt.Text);
           // prescription.Patient = patient;

            ExaminationsRecordFileStorage storage = new ExaminationsRecordFileStorage();
            List<Examination> examinations = storage.loadFromFile("examinations.json");
            
            foreach (Examination examination in examinations)
            {
                if (examination.Patient.Id.Equals(jmbgTxt.Text))
                {
                    prescription.Patient = examination.Patient;
                }
            }

            PrescriptionFileStorage prescriptionFileStorage = new PrescriptionFileStorage();
            List<Prescription> prescriptions = prescriptionFileStorage.loadFromFile("prescriptions.json");
            prescriptions.Add(prescription);
            prescriptionFileStorage.saveToFile(prescriptions, "prescriptions.json");

            this.Close();
        }
    }
}
