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
    public partial class Diagnosis : Window
    {
        public Diagnosis()
        {
            InitializeComponent();
        }

        private void izdajRecept(object sender, RoutedEventArgs e)
        {
            CreatePrescription createPrescription = new CreatePrescription();
            createPrescription.patientNameTxt.Text = patientNameTxt.Text;
            createPrescription.patientSurnameTxt.Text = patientSurnameTxt.Text;
            createPrescription.prescriptionDateTxt.Text = dateOfExaminationTxt.Text;
            createPrescription.doctorTxt.Text = "Petar Petrović";
            createPrescription.dateOfBirthTxt.Text = dateOfBirthTxt.Text;
            createPrescription.jmbgTxt.Text = jmbgTxt.Text;
            createPrescription.healthCardIdTxt.Text = healthCardNumberTxt.Text;

            Patient patient = new Patient();
            patient.Name = patientNameTxt.Text;
            patient.Surname = patientSurnameTxt.Text;
            patient.DateOfBirth = DateTime.Parse(dateOfBirthTxt.Text);
            patient.Id = jmbgTxt.Text;
            patient.HealthCardNumber = healthCardNumberTxt.Text;

            ExaminationsRecordFileStorage storage = new ExaminationsRecordFileStorage();
            List<Examination> examinations = storage.loadFromFile("examinations.json");

            Anamnesis anamnesis = new Anamnesis();
            anamnesis.Symptoms = symptomsTxt.Text;
            anamnesis.Diagnosis = diagnosisTxt.Text;
            anamnesis.Date = DateTime.Parse(dateOfExaminationTxt.Text);
            //anamnesis.Patient = patient;

            foreach (Examination examination in examinations)
            {
                if (examination.Patient.Id.Equals(jmbgTxt.Text))
                {
                    anamnesis.Patient = examination.Patient;
                }
            }

            AnamnesisFileStorage anamnesisFileStorage = new AnamnesisFileStorage();
            List<Anamnesis> anamneses = anamnesisFileStorage.loadFromFile("anamneses.json");
            anamneses.Add(anamnesis);
            anamnesisFileStorage.saveToFile(anamneses, "anamneses.json");

            createPrescription.diagnosisTxt.Text = diagnosisTxt.Text;

            PrescriptionFileStorage prescriptionFileStorage = new PrescriptionFileStorage();
            List<Prescription> prescriptions = prescriptionFileStorage.loadFromFile("prescriptions.json");

            foreach (Prescription prescription in prescriptions)
            {
                if (prescription.Patient.Id.Equals(jmbgTxt.Text))
                {
                    prescription.Anamnesis = anamnesis;
                }
            }

            createPrescription.Show();

            this.Close();
        }
    }
}
