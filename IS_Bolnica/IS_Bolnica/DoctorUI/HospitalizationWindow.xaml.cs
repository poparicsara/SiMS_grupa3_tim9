using System;
using System.Windows;
using System.Windows.Controls;
using IS_Bolnica.GUI.Doctor.View;
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
            confirmBTN.IsEnabled = false;
        }

        private void ConfirmButtonClick(object sender, RoutedEventArgs e)
        {
            hospitalization.Patient = patientService.FindById(patinetIdTxt.Text);
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
            MessageBoxResult messageBox = MessageBox.Show("Da li ste sigurni da želite da se odjavite?",
                "Odjavljivanje", MessageBoxButton.YesNo);

            switch (messageBox)
            {
                case MessageBoxResult.Yes:
                    userService.LogOut();
                    this.Close();
                    break;
                case MessageBoxResult.No:
                    break;
            }
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

        private void SetButtonVisibility()
        {
            if (roomsCB.SelectedItem != null && diagnosisTxt.Text != String.Empty)
            {
                confirmBTN.IsEnabled = true;
            }
            else
            {
                confirmBTN.IsEnabled = false;
            }
        }

        private void DiagnosisTextChanged(object sender, TextChangedEventArgs e)
        {
            SetButtonVisibility();
        }

        private void RoomSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SetButtonVisibility();
        }
    }
}
