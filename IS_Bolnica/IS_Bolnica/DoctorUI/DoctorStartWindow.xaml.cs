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
using IS_Bolnica.DoctorUI;
using IS_Bolnica.GUI.Doctor.View;
using IS_Bolnica.Model;
using IS_Bolnica.Services;
using Model;

namespace IS_Bolnica
{
    public partial class DoctorStartWindow : Window
    {
        private AppointmentService appointmentService = new AppointmentService();
        private UserService userService = new UserService();
        private Appointment appointment = new Appointment();
        private User loggedUser;
        public DoctorStartWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            this.loggedUser = userService.GetLoggedUser();
            examinationsDataGrid.ItemsSource = appointmentService.GetDoctorsExaminations();
            startExaminationButton.IsEnabled = false;
        }

        private void ExaminationButtonClick(object sender, RoutedEventArgs e)
        {
            this.Show();
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
            SettingsWindow settingsWindow = new SettingsWindow(loggedUser);
            settingsWindow.Show();
            this.Close();
        }

        private void DeleteButtonClick(object sender, RoutedEventArgs e)
        {
            int index = examinationsDataGrid.SelectedIndex;
            appointment = (Appointment)examinationsDataGrid.SelectedItem;
            MessageBoxResult messageBox = MessageBox.Show("Da li ste sigurni da želite da otkažete pregled?",
                "Otkazivanje pregleda", MessageBoxButton.YesNo);

            switch (messageBox)
            {
                case MessageBoxResult.Yes:

                    if (index == -1)
                    {
                        MessageBox.Show("Niste izabrali pregled koji želite da otkažete!");
                    }
                    else
                    {
                        appointmentService.DeleteAppointment(appointment);
                    }

                    DoctorStartWindow doctorStartWindow = new DoctorStartWindow();
                    doctorStartWindow.Show();
                    this.Close();
                    break;
                case MessageBoxResult.No:
                    break;
            }
        }

        private void EditButtonClick(object sender, RoutedEventArgs e)
        {
            int selectedIndex = examinationsDataGrid.SelectedIndex;
            UpdateScheduledExaminationWindow updateScheduledExamination =
                new UpdateScheduledExaminationWindow(selectedIndex, appointmentService.GetDoctorsExaminations());
            updateScheduledExamination.Show();
            this.Close();
        }

        private void AddButtonClick(object sender, RoutedEventArgs e)
        {
            ScheduleExaminationWindow scheduleExaminationWindow = new ScheduleExaminationWindow();
            scheduleExaminationWindow.Show();
            this.Close();
        }

        private void StartExaminationButtonClick(object sender, RoutedEventArgs e)
        {
            int selectedIndex = examinationsDataGrid.SelectedIndex;
            MedicalRecordWindow medicalRecordWindow = new MedicalRecordWindow(selectedIndex, appointmentService.GetDoctorsExaminations());
            medicalRecordWindow.Show();
            this.Close();
        }

        private void MedicamentsButtonClick(object sender, RoutedEventArgs e)
        {
            MedicamentsWindow medicamentsWindow = new MedicamentsWindow();
            medicamentsWindow.Show();
            this.Close();
        }

        private void SetButtonVisibility()
        {
            if (examinationsDataGrid.SelectedItem != null)
            {
                startExaminationButton.IsEnabled = true;
            }
            else
            {
                startExaminationButton.IsEnabled = false;
            }
        }

        private void ExaminationSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SetButtonVisibility();
        }
    }
}
