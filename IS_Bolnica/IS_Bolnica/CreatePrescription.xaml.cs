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
    public partial class CreatePrescription : Window
    {
        private Anamnesis anamnesis;
        private Prescription prescription = new Prescription();
        private Therapy therapy = new Therapy();
        private PatientService patientService = new PatientService();
        private PrescriptionService prescriptionService = new PrescriptionService();
        public CreatePrescription(Anamnesis anamnesis)
        {
            InitializeComponent();
            this.anamnesis = anamnesis;
            SetDataInTextFields();
        }

        private void potvrdiClicked(object sender, RoutedEventArgs e)
        {
            therapy.MedicationName = medTxt.Text;
            therapy.Dose = int.Parse(doseTxt.Text);
            prescription.Therapy = therapy;
            prescription.Date = DateTime.Parse(prescriptionDateTxt.Text);
            prescription.Patient = anamnesis.Patient;
            prescription.Doctor = anamnesis.Doctor;

            if (patientService.IsPatientAllergic(prescription.Patient.Id, medTxt.Text))
            {
                MessageBox.Show("Pacijent je alergican na unesen lek/sastojak!");
            }
            else
            {
                prescriptionService.CreatePrescription(prescription);
                this.Close();
            }

            //this.Close();
        }

        private void medTxt_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (patientService.IsPatientAllergic(jmbgTxt.Text, medTxt.Text))
            {
                allergyWarning.Content = "Pacijent je alergičan na unesen lek/sastojak!";
                potvrdiBtn.IsEnabled = false;
            }
            else
            {
                allergyWarning.Content = ' ';
                potvrdiBtn.IsEnabled = true;
            }
        }

        private void SetDataInTextFields()
        {
            patientTxt.Text = anamnesis.Patient.Name + ' ' + anamnesis.Patient.Surname;
            dateOfBirthTxt.Text = anamnesis.Patient.DateOfBirth.ToString();
            jmbgTxt.Text = anamnesis.Patient.Id;
            healthCardIdTxt.Text = anamnesis.Patient.HealthCardNumber;
            prescriptionDateTxt.Text = anamnesis.Date.ToString();
            diagnosisTxt.Text = anamnesis.Diagnosis;
            doctorTxt.Text = anamnesis.Doctor.Name + ' ' + anamnesis.Doctor.Surname;
        }
    }
}
