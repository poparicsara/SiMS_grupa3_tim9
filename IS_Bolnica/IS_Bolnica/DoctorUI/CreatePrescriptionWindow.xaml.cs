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
    public partial class CreatePrescriptionWindow : Window
    {
        private UserService userService = new UserService();
        private Anamnesis anamnesis;
        private Prescription prescription = new Prescription();
        private Therapy therapy = new Therapy();
        private PatientService patientService = new PatientService();
        private PrescriptionService prescriptionService = new PrescriptionService();
        public CreatePrescriptionWindow(Anamnesis anamnesis)
        {
            InitializeComponent();
            this.anamnesis = anamnesis;
            SetDataInTextFields();
        }

        private void ConfirmButtonClick(object sender, RoutedEventArgs e)
        {
            SetPrescriptionData();

            if (patientService.IsPatientAllergic(prescription.Patient.Id, medTxt.Text))
            {
                MessageBox.Show("Pacijent je alergičan na unesen lek/sastojak!");
            }
            else
            {
                prescriptionService.CreatePrescription(prescription);
                this.Close();
            }
        }

        private void BackButtonClick(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBox = MessageBox.Show("Da li ste sigurni da želite da izađete?",
                "Izmena operacije", MessageBoxButton.YesNo);

            switch (messageBox)
            {
                case MessageBoxResult.Yes:

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

        private void SetPrescriptionData()
        {
            therapy.MedicationName = medTxt.Text;
            therapy.Dose = int.Parse(doseTxt.Text);
            prescription.Therapy = therapy;
            prescription.Date = (DateTime)prescriptionDate.SelectedDate;
            prescription.Patient = anamnesis.Patient;
            prescription.Doctor = anamnesis.Doctor;
            prescription.Anamnesis = anamnesis;
        }

        private void SetDataInTextFields()
        {
            patientTxt.Text = anamnesis.Patient.Name + ' ' + anamnesis.Patient.Surname;
            patinetIdTxt.Text = anamnesis.Patient.Id;
            healthCardNumTxt.Text = anamnesis.Patient.HealthCardNumber;
            prescriptionDate.SelectedDate = (DateTime)anamnesis.Date;
            diagnosisTxt.Text = anamnesis.Diagnosis;
            doctorTxt.Text = anamnesis.Doctor.Name + ' ' + anamnesis.Doctor.Surname;
        }

        private void MedicationTextChange(object sender, TextChangedEventArgs e)
        {
            if (patientService.IsPatientAllergic(patinetIdTxt.Text, medTxt.Text))
            {
                allergyWarningTxt.Text = "Pacijent je alergican na unesen lek/sastojak!";
                confirmBTN.IsEnabled = false;
            }
            else
            {
                allergyWarningTxt.Text = " ";
                confirmBTN.IsEnabled = true;
            }
        }

        private void MedicamentsButtonClick(object sender, RoutedEventArgs e)
        {
            MedicamentsWindow medicamentsWindow = new MedicamentsWindow();
            medicamentsWindow.Show();
            this.Close();
        }

        private void InvoiceButtonClick(object sender, RoutedEventArgs e)
        {
            SetPrescriptionData();
            prescriptionService.CreatePrescription(prescription);
            InvoiceWindow invoiceWindow = new InvoiceWindow(prescription);
            invoiceWindow.Show();
            this.Close();
        }
    }
}
