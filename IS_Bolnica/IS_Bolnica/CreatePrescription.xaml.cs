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
        private Anamnesis anamnesis;
        private Prescription prescription = new Prescription();
        private Therapy therapy = new Therapy();
        private Doctor doctor = new Doctor();
        private PrescriptionFileStorage prescriptionStorage = new PrescriptionFileStorage();
        private List<Prescription> Prescriptions { get; set; } = new List<Prescription>();
        public List<Anamnesis> Anamneses { get; set; } = new List<Anamnesis>();
        public CreatePrescription(Anamnesis anamnesis)
        {
            InitializeComponent();

            this.anamnesis = anamnesis;

            patientTxt.Text = anamnesis.Patient.Name + ' ' + anamnesis.Patient.Surname;
            dateOfBirthTxt.Text = anamnesis.Patient.DateOfBirth.ToString();
            jmbgTxt.Text = anamnesis.Patient.Id;
            healthCardIdTxt.Text = anamnesis.Patient.HealthCardNumber;
            prescriptionDateTxt.Text = anamnesis.Date.ToString();
            diagnosisTxt.Text = anamnesis.Diagnosis;

        }

        private void potvrdiClicked(object sender, RoutedEventArgs e)
        {
            Prescriptions = prescriptionStorage.loadFromFile("prescriptions.json");

            therapy.MedicationName = medTxt.Text;
            therapy.Dose = int.Parse(doseTxt.Text);
            prescription.Therapy = therapy;
            prescription.Date = DateTime.Parse(prescriptionDateTxt.Text);
            prescription.Patient = anamnesis.Patient;

            Prescriptions.Add(prescription);
            prescriptionStorage.saveToFile(Prescriptions, "prescriptions.json");

            this.Close();
        }
    }
}
