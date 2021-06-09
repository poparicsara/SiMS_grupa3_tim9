using System;
using System.Windows;
using System.Windows.Controls;
using IS_Bolnica.Model;
using IS_Bolnica.Services;
using Model;

namespace IS_Bolnica.Secretary
{
    public partial class AddUrgentOperation : Page
    {
        private Page previousPage;
        private Specialization specialization = new Specialization();
        private Patient patient = new Patient();
        private GuestUser guestUser = new GuestUser();
        private Appointment appointment = new Appointment();
        private FindAttributesService findAttributesService = new FindAttributesService();
        private PatientService patientService = new PatientService();

        public AddUrgentOperation(Page previousPage)
        {
            InitializeComponent();
            this.previousPage = previousPage;
            specializationBox.ItemsSource = findAttributesService.GetSpecializationNames();
            operatiomRoomBox.ItemsSource = findAttributesService.GetRoomIds();

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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(previousPage);
        }

        private void addGuestAccount(object sender, RoutedEventArgs e)
        {
            AddGuestUser agu = new AddGuestUser(this);
            this.NavigationService.Navigate(agu);
        }

        private bool isAllFilled()
        {
            if (patientIdBox.Text == "" && systemNameBox.Text == "") return false;
            if (specializationBox.SelectedIndex == -1 || hourBox.SelectedIndex == -1 || minuteBox.SelectedIndex == -1 ||
                operatiomRoomBox.SelectedIndex == -1) return false;
            return true;
        }

        private void getOptions(object sender, RoutedEventArgs e)
        {
            if (!isAllFilled())
            {
                MessageBox.Show("Morate da popunite sva dozvoljena polja!");
                return;
            }

            if (patientIdBox.Text != "")
            {
                if (!patientService.PatientIdExists(patientIdBox.Text))
                {
                    MessageBox.Show("Pacijent sa ovim JMBG-om ne postoji!");
                    return;
                }
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

            appointment = new Appointment
            {
                DurationInMins = findAttributesService.GetDurationInMinutes(Convert.ToInt32(hourBox.Text), Convert.ToInt32(minuteBox.Text)),
                GuestUser = guestUser,
                Patient = patient,
                Room = findAttributesService.FindRoomById(Convert.ToInt32(operatiomRoomBox.SelectedItem.ToString()))
            };
            specialization = findAttributesService.FindSpecialization(specializationBox.SelectedItem.ToString());

            UrgentOperationOptions uoo = new UrgentOperationOptions(appointment, specialization, this);
            this.NavigationService.Navigate(uoo);
        }
    }
}
