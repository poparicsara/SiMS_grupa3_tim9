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

namespace IS_Bolnica.DoctorUI
{
    public partial class AnamnesisInvoiceWindow : Window
    {
        private Anamnesis anamnesis;
        private Appointment examination;
        private List<Appointment> loggedAppointments;
        private int selectedIndex;
        public AnamnesisInvoiceWindow(Anamnesis anamnesis, Appointment examination, List<Appointment> loggedAppointments, int selectedPatient)
        {
            InitializeComponent();
            this.anamnesis = anamnesis;
            this.loggedAppointments = loggedAppointments;
            this.selectedIndex = selectedPatient;
            this.examination = examination;

            this.patientTxt.Text = anamnesis.Patient.Name + ' ' + anamnesis.Patient.Surname;
            this.dateOfBirthTxt.Text = anamnesis.Patient.DateOfBirth.ToString("dd/MM/yyyy");
            this.idTxt.Text = anamnesis.Patient.Id;
            this.addressTxt.Text = anamnesis.Patient.Address.Street + ' ' +
                                   anamnesis.Patient.Address.NumberOfBuilding.ToString() + ' '
                                   + anamnesis.Patient.Address.City.name;
            this.healthCardTxt.Text = anamnesis.Patient.HealthCardNumber;
            this.sympthomsTxt.Text = anamnesis.Symptoms;
            this.diagnosisTxt.Text = anamnesis.Diagnosis;
            this.examinationDateTxt.Text = anamnesis.Date.ToString("dd/MM/yyyy");
        }

        private void PrintButtonClick(object sender, RoutedEventArgs e)
        {
            try
            {
                this.IsEnabled = false;
                PrintDialog printDialog = new PrintDialog();
                if (printDialog.ShowDialog() == true)
                {
                    printDialog.PrintVisual(this, "Invoice");
                }
            }
            finally
            {
                this.IsEnabled = true;
            }
        }

        private void BackButtonClick(object sender, RoutedEventArgs e)
        {
            AnamnesisWindow anamnesisWindow = new AnamnesisWindow(examination, loggedAppointments, selectedIndex);
            anamnesisWindow.symptomsTxt.Text = anamnesis.Symptoms;
            anamnesisWindow.diagnosisTxt.Text = anamnesis.Diagnosis;
            anamnesisWindow.Show();
            this.Close();
        }
    }
}
