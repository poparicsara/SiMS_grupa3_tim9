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
    public partial class InvoiceWindow : Window
    {
        private Prescription prescription;
        public InvoiceWindow(Prescription prescription)
        {
            InitializeComponent();
            this.prescription = prescription;

            this.patientTxt.Text = prescription.Patient.Name + ' ' + prescription.Patient.Surname;
            this.dateOfBirthTxt.Text = prescription.Patient.DateOfBirth.ToString("dd/MM/yyyy");
            this.addressTxt.Text = prescription.Patient.Address.Street + ' ' +
                                   prescription.Patient.Address.NumberOfBuilding.ToString() + ", " +
                                   prescription.Patient.Address.City.name;
            this.idTxt.Text = prescription.Patient.Id;
            this.healthCardTxt.Text = prescription.Patient.HealthCardNumber;
            this.examinationDateTxt.Text = prescription.Date.ToString("dd/MM/yyyy");
            this.precriptionDateTxt.Text = prescription.Date.ToString("dd/MM/yyyy");
            this.diagnosisTxt.Text = prescription.Anamnesis.Diagnosis;
            this.medTxt.Text = prescription.Therapy.MedicationName;
        }
    }
}
