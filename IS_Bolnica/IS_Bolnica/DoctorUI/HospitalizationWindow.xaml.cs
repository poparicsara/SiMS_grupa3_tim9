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
    public partial class HospitalizationWindow : Window
    {
        private UserService userService = new UserService();
        private Anamnesis anamnesis;
        private RoomService roomService = new RoomService();
        private PatientService patientService = new PatientService();
        private HospitalizationService hospitalizationService = new HospitalizationService();
        private InventoryService inventoryService = new InventoryService();
        private Hospitalization hospitalization = new Hospitalization();
        public HospitalizationWindow(Anamnesis anamnesis)
        {
            InitializeComponent();
            this.anamnesis = anamnesis;
            SetDataInTextFields();
        }

        private void ConfirmButtonClick(object sender, RoutedEventArgs e)
        {
            hospitalization.Patient = patientService.findPatientById(patinetIdTxt.Text);
            hospitalization.Room = roomService.FindOrdinationById(Convert.ToInt32(roomsCB.SelectedItem));
            DateTime startDate = (DateTime)this.startDateDP.SelectedDate;
            DateTime endDate = (DateTime)this.endDateDP.SelectedDate;
            hospitalization.StartDate = new DateTime(startDate.Year, startDate.Month, startDate.Day);
            hospitalization.EndDate = new DateTime(endDate.Year, endDate.Month, endDate.Day);

            if (hospitalizationService.GetNumberOfPatientsInRoom(Convert.ToInt32(roomsCB.SelectedItem)) ==
                inventoryService.GetNumberOfBedsInRoom(hospitalization.Room))
            {
                MessageBox.Show("U sobi nema praznih kreveta!");
            }
            else
            {
                hospitalizationService.AddHospitalization(hospitalization);
            }

            this.Close();
        }

        private void BackButtonClick(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBox = MessageBox.Show("Da li ste sigurni da želite da izađete?",
                "Hospitalizacija", MessageBoxButton.YesNo);

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
            OperationsWindow operationsWindow = new OperationsWindow();
            operationsWindow.Show();
            this.Close();
        }

        private void NotificationsButtonClick(object sender, RoutedEventArgs e)
        {
            NotificationsWindow notificationsWindow = new NotificationsWindow();
            notificationsWindow.Show();
            this.Close();
        }

        private void StatisticsButtonClick(object sender, RoutedEventArgs e)
        {
            ChartWindow chartWindow = new ChartWindow();
            chartWindow.Show();
            this.Close();
        }

        private void SingOutButtonClick(object sender, RoutedEventArgs e)
        {
            userService.LogOut();
            this.Close();
        }

        private void SettingsButtonClick(object sender, RoutedEventArgs e)
        {

        }
        private void SetDataInTextFields()
        {
            patientTxt.Text = anamnesis.Patient.Name + ' ' + anamnesis.Patient.Surname;
            patinetIdTxt.Text = anamnesis.Patient.Id;
            healthCardNumTxt.Text = anamnesis.Patient.HealthCardNumber;
            diagnosisTxt.Text = anamnesis.Diagnosis;
            doctorTxt.Text = anamnesis.Doctor.Name + ' ' + anamnesis.Doctor.Surname;
            roomsCB.ItemsSource = roomService.GetAvailableRoomsForHospitalization();
        }

        private void MedicamentsButtonClick(object sender, RoutedEventArgs e)
        {
            MedicamentsWindow medicamentsWindow = new MedicamentsWindow();
            medicamentsWindow.Show();
            this.Close();
        }
    }
}
