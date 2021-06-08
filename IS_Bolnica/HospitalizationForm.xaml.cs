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

namespace IS_Bolnica
{
    public partial class HospitalizationForm : Window
    {
        private Anamnesis anamnesis;
        private RoomService roomService = new RoomService();
        private PatientService patientService = new PatientService();
        private HospitalizationService hospitalizationService = new HospitalizationService();
        private InventoryService inventoryService = new InventoryService();
        private Hospitalization hospitalization = new Hospitalization();
        public HospitalizationForm(Anamnesis anamnesis)
        {
            InitializeComponent();
            this.anamnesis = anamnesis;
            SetDataInTextFields();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            hospitalization.Patient = patientService.findPatientById(jmbgTxt.Text);
            hospitalization.Room = roomService.FindOrdinationById(Convert.ToInt32(roomsComboBox.SelectedItem));
            DateTime startDate = (DateTime) startDatePicker.SelectedDate;
            DateTime endDate = (DateTime) endDatePicker.SelectedDate;
            hospitalization.StartDate = new DateTime(startDate.Year, startDate.Month, startDate.Day);
            hospitalization.EndDate = new DateTime(endDate.Year, endDate.Month, endDate.Day);

            if (hospitalizationService.GetNumberOfPatientsInRoom(Convert.ToInt32(roomsComboBox.SelectedItem)) ==
                inventoryService.GetNumberOfBedsInRoom(hospitalization.Room))
            {
                MessageBox.Show("U sobi nema praznih kreveta!");
            }
            else
            {
                hospitalizationService.AddHospitalization(hospitalization);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void SetDataInTextFields()
        {
            patientTxt.Text = anamnesis.Patient.Name + ' ' + anamnesis.Patient.Surname;
            dateOfBirthTxt.Text = anamnesis.Patient.DateOfBirth.ToString();
            jmbgTxt.Text = anamnesis.Patient.Id;
            healthCardNumberTxt.Text = anamnesis.Patient.HealthCardNumber;
            addressTxt.Text = anamnesis.Patient.Address.Street + ", " + anamnesis.Patient.Address.City.name;
            diagnosisTxt.Text = anamnesis.Diagnosis;
            doctorTxt.Text = anamnesis.Doctor.Name + ' ' + anamnesis.Doctor.Surname;
            roomsComboBox.ItemsSource = roomService.GetAvailableRoomsForHospitalization();
        }
    }
}
