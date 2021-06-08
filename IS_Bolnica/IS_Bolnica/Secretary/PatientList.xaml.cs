using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using IS_Bolnica.Model;
using IS_Bolnica.Services;
using Model;

namespace IS_Bolnica.Secretary
{
    public partial class PatientList : Page
    {
        private Page prevoiusPage;
        private List<Patient> patients { get; set; } = new List<Patient>();
        private PatientService patientService = new PatientService();
        private UserService userService = new UserService();
        private AppointmentService appointmentService = new AppointmentService();

        public PatientList(Page prevoiusPage)
        {
            InitializeComponent();
            this.DataContext = this;
            this.prevoiusPage = prevoiusPage;
            patients = patientService.GetPatients();
            PatientListGrid.ItemsSource = patients;
        }

        private void addPatient(object sender, RoutedEventArgs e)
        {
            AddPatientPage app = new AddPatientPage(this);
            this.NavigationService.Navigate(app);
        }

        private void editPatient(object sender, RoutedEventArgs e)
        {
            int i = PatientListGrid.SelectedIndex;
            Patient patient = (Patient)PatientListGrid.SelectedItem;

            if (i == -1)
            {
                MessageBox.Show("You didn't choose patient which you want to edit!");
            }
            else
            {
                EditPatientPage epp = new EditPatientPage(patient, this);
                setElementsEP(epp, patient);
                this.NavigationService.Navigate(epp);
            }
        }

        private void setElementsEP(EditPatientPage ep, Patient patient)
        {
            ep.name.Text = patient.Name;
            ep.surname.Text = patient.Surname;
            ep.username.Text = patient.Username;
            ep.dateOfBirth.SelectedDate = new DateTime(patient.DateOfBirth.Year, patient.DateOfBirth.Month, patient.DateOfBirth.Day);
            ep.iniciallyPassword.Text = patient.Password;
            ep.id.Text = patient.Id.ToString();
            ep.phone.Text = patient.Phone.ToString();
            ep.email.Text = patient.Email;
            ep.adress.Text = patient.Address.Street + " "
                                                    + patient.Address.NumberOfBuilding + "/"
                                                    + patient.Address.Floor + "/"
                                                    + patient.Address.Apartment;
            ep.city.Text = patient.Address.City.name + " "
                                                     + Convert.ToString(patient.Address.City.postalCode);
            ep.country.Text = patient.Address.City.Country.name;
            if (patient.Gender == Gender.male)
            {
                ep.GenderBox.SelectedIndex = 0;
            }
            else
            {
                ep.GenderBox.SelectedIndex = 1;
            }
        }

        private void deletePatient(object sender, RoutedEventArgs e)
        {
            int i = PatientListGrid.SelectedIndex;

            Patient patient = (Patient)PatientListGrid.SelectedItem;

            if (i == -1)
            {
                MessageBox.Show("You didn't choose patient which you want to delete!");
            }
            else
            {

                MessageBoxResult result = MessageBox.Show("Da li stvarno želite da obrišete pacijenta?", "Brisanje pacijenta", MessageBoxButton.YesNo);
                switch (result)
                {
                    case MessageBoxResult.Yes:

                        patientService.DeletePatient(patient);

                        User user = new User
                        {
                            Address = patient.Address,
                            DateOfBirth = patient.DateOfBirth,
                            Id = patient.Id,
                            Email = patient.Email,
                            Name = patient.Name,
                            Password = patient.Password,
                            Phone = patient.Phone,
                            Surname = patient.Surname,
                            UserType = UserType.patient,
                            Username = patient.Username
                        };
                        userService.DeleteUser(user);
                        appointmentService.RemovePatientsAppointments(patient);

                        PatientList pl = new PatientList(this);
                        this.NavigationService.Navigate(pl);

                        break;
                    case MessageBoxResult.No:
                        break;
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(prevoiusPage);
        }

        private void pretraziBox_KeyUp(object sender, KeyEventArgs e)
        {

            var filtered = patientService.GetSearchedPatients(pretraziBox.Text.ToLower());
            PatientListGrid.ItemsSource = filtered;
        }
    }
}
