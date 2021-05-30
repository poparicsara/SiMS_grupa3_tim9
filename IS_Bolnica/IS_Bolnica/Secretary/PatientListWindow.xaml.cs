using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using IS_Bolnica.Services;

namespace IS_Bolnica.Secretary
{
    public partial class PatientListWindow : Window
    {
        private List<Patient> patients { get; set; } = new List<Patient>();
        private PatientService patientService = new PatientService();
        private UserService userService = new UserService();
        private AppointmentService appointmentService = new AppointmentService();

        public PatientListWindow()
        {
            InitializeComponent();
            this.DataContext = this;

            patients = patientService.GetPatients();
            PatientList.ItemsSource = patients;
        }

        private void addPatient(object sender, RoutedEventArgs e)
        {
            Secretary.AddPatient ap = new Secretary.AddPatient();
            ap.Show();
            this.Close();
        }

        private void editPatient(object sender, RoutedEventArgs e)
        {
            int i = PatientList.SelectedIndex;
            Patient patient = (Patient)PatientList.SelectedItem;

            if (i == -1)
            {
                MessageBox.Show("You didn't choose patient which you want to edit!");
            }
            else
            {
                Secretary.EditPatient ep = new Secretary.EditPatient(patient);
                setElementsEPW(ep, patient);
                ep.Show();
                this.Close();
            }

        }

        private void setElementsEPW(EditPatient ep, Patient patient)
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
            ep.debit.Text = Convert.ToString(patient.Debit);
            List<string> alergeni = patient.Allergens;
            foreach (var alergen in alergeni)
            {
                ep.allergens.Text += alergen + ",";

            }
            String pom = ep.allergens.Text;
            ep.allergens.Text = pom.Remove(pom.Length - 1, 1);
        }

        private void deletePatient(object sender, RoutedEventArgs e)
        {
            
            int i = PatientList.SelectedIndex;

            Patient patient = (Patient)PatientList.SelectedItem;

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
                            Id = patient.Id, Email = patient.Email,
                            Name = patient.Name,
                            Password = patient.Password,
                            Phone = patient.Phone,
                            Surname = patient.Surname,
                            UserType = UserType.patient,
                            Username = patient.Username
                        };
                        userService.DeleteUser(user);
                        appointmentService.RemovePatientsAppointments(patient);

                        PatientListWindow plw = new PatientListWindow();

                        plw.Show();
                        this.Close();

                        break;
                    case MessageBoxResult.No:
                        break;
                }
            }
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Secretary.ActionBarWindow abw = new Secretary.ActionBarWindow();
            abw.Show();
            this.Close();
        }

        private void pretraziBox_KeyUp(object sender, KeyEventArgs e)
        {
            var filtered = patients.Where(patient => patient.Id.StartsWith(pretraziBox.Text));

            PatientList.ItemsSource = filtered;
        }
    }
}