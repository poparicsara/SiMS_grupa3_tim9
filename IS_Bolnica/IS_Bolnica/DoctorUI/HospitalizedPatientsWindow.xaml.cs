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
using IS_Bolnica.Services;

namespace IS_Bolnica.DoctorUI
{
    public partial class HospitalizedPatientsWindow : Window
    {
        private HospitalizationService hospitalizationService = new HospitalizationService();
        private UserService userService = new UserService();
        public HospitalizedPatientsWindow()
        {
            InitializeComponent();
            hospitalizedPatientsDataGrid.ItemsSource = hospitalizationService.GetAllHospitalizedPatients();
            prolongBTN.IsEnabled = false;
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

        private void ProlongButtonClick(object sender, RoutedEventArgs e)
        {
            int selectedIndex = hospitalizedPatientsDataGrid.SelectedIndex;
            ProlongTreatmentWindow prolongTreatmentWindow = new ProlongTreatmentWindow(selectedIndex, hospitalizationService.GetAllHospitalizedPatients());
            prolongTreatmentWindow.Show();
        }

        private void MedicamentsButtonClick(object sender, RoutedEventArgs e)
        {
            MedicamentsWindow medicamentsWindow = new MedicamentsWindow();
            medicamentsWindow.Show();
            this.Close();
        }

        private void SetButtonVisibility()
        {
            if (hospitalizedPatientsDataGrid.SelectedItem != null)
            {
                prolongBTN.IsEnabled = true;
            }
            else
            {
                prolongBTN.IsEnabled = false;
            }
        }

        private void PatientSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SetButtonVisibility();
        }
    }
}
