using Model;
using System;
using System.Collections.Generic;
using System.Windows;
using IS_Bolnica.Model;
using IS_Bolnica.Services;

namespace IS_Bolnica.Secretary
{
    public partial class AddUrgentOperationWindow : Window
    {
        private Specialization specialization = new Specialization();
        private Patient patient = new Patient();
        private GuestUser guestUser = new GuestUser();
        private Appointment appointment = new Appointment();
        private FindAttributesService findAttributesService = new FindAttributesService();

        public AddUrgentOperationWindow()
        {
            InitializeComponent();

            specializationBox.ItemsSource = findAttributesService.GetSpecializationNames();

            operatiomRoomBox.ItemsSource = findAttributesService.GetRoomIds();

        }

        private void addGuestAccount(object sender, RoutedEventArgs e)
        {
            GuestUserAccount gua = new GuestUserAccount(sender);
            gua.Show();
            this.Close();
        }

        private void getOptions(object sender, RoutedEventArgs e)
        {
            if(patientIdBox.Text != "")
            {
                patient = findAttributesService.FindPatient(patientIdBox.Text);
            }
            else if(patientIdBox.Text == "" && patientIdBox.IsEnabled)
            {
                MessageBox.Show("Niste uneli id pacijenta");
                return;
            } 
            else if(systemNameBox.Text != "")
            {
                guestUser = findAttributesService.FindGuest(systemNameBox.Text);
            } 
            else if(systemNameBox.Text == "" && systemNameBox.IsEnabled)
            {
                MessageBox.Show("Niste uneli sistemsko ime guest korisnika");
                return;
            }

            appointment = new Appointment { DurationInMins = findAttributesService.GetDurationInMinutes(Convert.ToInt32(hourBox.Text), Convert.ToInt32(minuteBox.Text)),
                                            GuestUser = guestUser, Patient = patient,
                                            Room = findAttributesService.FindRoomById(Convert.ToInt32(operatiomRoomBox.SelectedItem.ToString())) }; 
            specialization = findAttributesService.FindSpecialization(specializationBox.SelectedItem.ToString());

            UrgentOperationOptionsWindow uoow = new UrgentOperationOptionsWindow(appointment, specialization);
            uoow.Show();
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ActionBarWindow abw = new ActionBarWindow();
            abw.Show();
            this.Close();
        }

        private void existableRButton_Checked(object sender, RoutedEventArgs e)
        {
            patientIdBox.IsEnabled = true;
            systemNameBox.IsEnabled = false;
        }

        private void guestRButton_Checked(object sender, RoutedEventArgs e)
        {
            patientIdBox.IsEnabled = false;
            systemNameBox.IsEnabled = true;
        }
    }
}
