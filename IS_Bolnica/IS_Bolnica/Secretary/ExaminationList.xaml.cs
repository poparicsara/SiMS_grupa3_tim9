﻿using System;
using System.Windows;
using System.Windows.Controls;
using IS_Bolnica.Model;
using IS_Bolnica.Services;

namespace IS_Bolnica.Secretary
{
    public partial class ExaminationList : Page
    {
        private Appointment appointment = new Appointment();
        private AppointmentService appointmentService = new AppointmentService();

        public ExaminationList()
        {
            InitializeComponent();
            this.DataContext = this;

            ExaminationListGrid.ItemsSource = appointmentService.getExaminations();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ActionBar ab = new ActionBar();
            this.NavigationService.Navigate(ab);
        }

        private void addExamination(object sender, RoutedEventArgs e)
        {
            AddExamination ae = new AddExamination();
            this.NavigationService.Navigate(ae);
        }

        private void editExamination(object sender, RoutedEventArgs e)
        {
            int i = ExaminationListGrid.SelectedIndex;

            Appointment appointment = (Appointment)ExaminationListGrid.SelectedItem;

            if (!isSelected(i))
            {
                MessageBox.Show("Niste izabrali pregled koji želite da izmenite!");
            }
            else
            {
                EditExamination ee = new EditExamination(appointment);
                setElementsEE(ee, appointment);
                

            }
        }

        private bool isSelected(int i)
        {
            if (i == -1)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void setElementsEE(EditExamination eew, Appointment appointment)
        {
            eew.idPatientBox.Text = appointment.Patient.Id;
            eew.hourBox.Text = appointment.StartTime.Hour.ToString();
            eew.minutesBox.Text = appointment.StartTime.Minute.ToString();
            eew.doctorBox.Text = appointment.Doctor.Name + " " + appointment.Doctor.Surname;
            eew.dateBox.SelectedDate = new DateTime(appointment.StartTime.Year, appointment.StartTime.Month, appointment.StartTime.Day);
            eew.durationInMinutesBox.Text = "30";
        }

        private void deleteExamination(object sender, RoutedEventArgs e)
        {
            int i = ExaminationListGrid.SelectedIndex;
            appointment = (Appointment)ExaminationListGrid.SelectedItem;


            if (!isSelected(i))
            {
                MessageBox.Show("Niste izabrali pregled koji želite da obrišete!");
            }
            else
            {
                MessageBoxResult result = MessageBox.Show("Da li stvarno želite da izbrišete", "Brisanje pregleda", MessageBoxButton.YesNo);
                switch (result)
                {
                    case MessageBoxResult.Yes:
                        appointmentService.DeleteAppointment(appointment);
                        ExaminationList el = new ExaminationList();
                        this.NavigationService.Navigate(el);
                        break;

                    case MessageBoxResult.No:
                        break;
                }
            }
        }
    }
}
