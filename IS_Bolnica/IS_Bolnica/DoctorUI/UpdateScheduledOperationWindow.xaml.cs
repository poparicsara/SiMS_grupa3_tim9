﻿using System;
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
using IS_Bolnica.GUI.Doctor.View;
using IS_Bolnica.Model;
using IS_Bolnica.Services;

namespace IS_Bolnica.DoctorUI
{
    public partial class UpdateScheduledOperationWindow : Window
    {
        private List<int> hours = new List<int>();
        private Appointment operation;
        private AppointmentService appointmentService = new AppointmentService();
        private UserService userService = new UserService();
        private DoctorService doctorService = new DoctorService();
        private PatientService patientService = new PatientService();
        private RoomService roomService = new RoomService();
        public UpdateScheduledOperationWindow(int selectedIndex, List<Appointment> loggedDoctorOperations)
        {
            InitializeComponent();
            List<Appointment> operations = loggedDoctorOperations;
            this.operation = operations.ElementAt(selectedIndex);

            operationDate.SelectedDate = operation.StartTime;
            hoursCB.SelectedItem = operation.StartTime.Hour;
            minutesCB.SelectedItem = operation.StartTime.Minute;
            patientTxt.Text = operation.Patient.Name + ' ' + operation.Patient.Surname;
            patinetIdTxt.Text = operation.Patient.Id;
            healthCardNumTxt.Text = operation.Patient.HealthCardNumber;
            doctorsCB.SelectedItem = operation.Doctor.Name + ' ' + operation.Doctor.Surname;
            
            roomCB.ItemsSource = roomService.GetOperationRoomsId();
            roomCB.SelectedItem = operation.Room.Id;

            SetTimePicker();
            doctorsCB.ItemsSource = doctorService.GetSpecialistsNameSurname();

            if (operation.IsUrgent)
            {
                isUrgentRB.IsChecked = true;
            }
            else
            {
                isUrgentRB.IsChecked = false;
            }
        }
        private void PotvrdiButtonClick(object sender, RoutedEventArgs e)
        {
            appointmentService.DeleteAppointment(operation);

            operation.Doctor = doctorService.FindDoctorByName(doctorsCB.SelectedItem.ToString());
            operation.Patient = patientService.FindById(patinetIdTxt.Text);
            DateTime date = new DateTime();
            date = (DateTime)operationDate.SelectedDate;
            int hour = Convert.ToInt32(hoursCB.Text);
            int minute = Convert.ToInt32(minutesCB.Text);
            operation.StartTime = new DateTime(date.Year, date.Month, date.Day, hour, minute, 0);
            operation.Room = roomService.FindOrdinationById(Convert.ToInt32(roomCB.SelectedItem));
            if (isUrgentRB.IsChecked == true)
            {
                operation.IsUrgent = true;
            }
            else
            {
                operation.IsUrgent = false;
            }

            appointmentService.ScheduleAppointment(operation);

            OperationsWindow operationsWindow = new OperationsWindow();
            operationsWindow.Show();
            this.Close();
        }

        private void ExaminationButtonClick(object sender, RoutedEventArgs e)
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
        private void SetTimePicker()
        {
            for (int i = 7; i < 20; i++)
            {
                hours.Add(i);
            }

            hoursCB.ItemsSource = hours;

            List<int> Minutes = new List<int>();
            Minutes.Add(00);
            Minutes.Add(30);
            minutesCB.ItemsSource = Minutes;
        }

        private void BackButtonClick(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBox = MessageBox.Show("Da li ste sigurni da želite da izađete? Vaše promene neće biti sačuvane.",
                "Izmena operacije", MessageBoxButton.YesNo);

            switch (messageBox)
            {
                case MessageBoxResult.Yes:
                    DoctorStartWindow doctorStartWindow = new DoctorStartWindow();
                    doctorStartWindow.Show();
                    this.Close();
                    break;
                case MessageBoxResult.No:
                    break;
            }
        }

        private void IdTextFieldLostFocus(object sender, RoutedEventArgs e)
        {
            healthCardNumTxt.Text = patientService.FindById(patinetIdTxt.Text).HealthCardNumber;
        }

        private void MedicamentsButtonClick(object sender, RoutedEventArgs e)
        {
            MedicamentsWindow medicamentsWindow = new MedicamentsWindow();
            medicamentsWindow.Show();
            this.Close();
        }

        private void SetButtonVisibility()
        {
            if (patientTxt.Text != String.Empty && patinetIdTxt.Text != String.Empty && healthCardNumTxt.Text != String.Empty
                && doctorsCB.SelectedItem != null && minutesCB.SelectedItem != null && hoursCB.SelectedItem != null && roomCB.SelectedItem != null)
            {
                confirmButton.IsEnabled = true;
            }
            else
            {
                confirmButton.IsEnabled = false;
            }
        }

        private void PatientTextChanged(object sender, TextChangedEventArgs e)
        {
            SetButtonVisibility();
        }

        private void IdTextChanged(object sender, TextChangedEventArgs e)
        {
            SetButtonVisibility();
        }

        private void HealthCardTextChanged(object sender, TextChangedEventArgs e)
        {
            SetButtonVisibility();
        }

        private void DoctorsSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SetButtonVisibility();
        }
    }
}
