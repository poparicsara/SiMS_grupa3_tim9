using System;
using System.Windows;
using System.Windows.Controls;
using IS_Bolnica.Model;
using IS_Bolnica.Services;
using Model;

namespace IS_Bolnica.Secretary
{
    public partial class AddUrgentExaminationPage : Page
    {
        private Specialization specialization = new Specialization();
        private Patient patient = new Patient();
        private GuestUser guestUser = new GuestUser();
        private Appointment appointment = new Appointment();
        private FindAttributesService findAttributesService = new FindAttributesService();



        public AddUrgentExaminationPage()
        {
            InitializeComponent();
            specializationBox.ItemsSource = findAttributesService.GetSpecializationNames();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ActionBar ab = new ActionBar();
            this.NavigationService.Navigate(ab);
        }

        private void existableRButton_Checked(object sender, RoutedEventArgs e)
        {
            systemNameBox.IsEnabled = false;
            patientIdBox.IsEnabled = true;
        }

        private void guestRButton_Checked(object sender, RoutedEventArgs e)
        {
            patientIdBox.IsEnabled = false;
            systemNameBox.IsEnabled = true;
        }

        private void addGuestAccount(object sender, RoutedEventArgs e)
        {
            AddGuestUser agu = new AddGuestUser();
            this.NavigationService.Navigate(agu);
        }

        private void getOptions(object sender, RoutedEventArgs e)
        {
            if (patientIdBox.Text != "")
            {
                patient = findAttributesService.FindPatient(patientIdBox.Text);
            }
            else if (patientIdBox.Text == "" && patientIdBox.IsEnabled)
            {
                MessageBox.Show("Niste uneli id pacijenta");
                return;
            }
            else if (systemNameBox.Text != "")
            {
                guestUser = findAttributesService.FindGuest(systemNameBox.Text);
            }
            else if (systemNameBox.Text == "" && systemNameBox.IsEnabled)
            {
                MessageBox.Show("Niste uneli sistemsko ime guest korisnika");
                return;
            }

            appointment = new Appointment { GuestUser = guestUser, Patient = patient };
            specialization = findAttributesService.FindSpecialization(specializationBox.SelectedItem.ToString());

            UrgentExaminationOptions ueo = new UrgentExaminationOptions(appointment, specialization);
            this.NavigationService.Navigate(ueo);

        }
    }
}
