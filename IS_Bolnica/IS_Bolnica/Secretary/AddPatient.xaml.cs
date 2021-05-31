using Model;
using System;
using System.Windows;
using System.Collections.Generic;
using IS_Bolnica.Services;

namespace IS_Bolnica.Secretary
{
    public partial class AddPatient : Window
    {
        private Patient patient = new Patient();
        private User user = new User();

        private PatientService patientService = new PatientService();
        private UserService userService = new UserService();

        public AddPatient()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        private void cancelAdding(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void addPatient(object sender, RoutedEventArgs e)
        {

            patient = setPatientAtributes();

            patientService.AddPatient(patient);

            user = setUserAtributes(patient);

            userService.AddUser(user);

            Secretary.PatientListWindow plw = new Secretary.PatientListWindow();
            plw.Show();
            this.Close();


        }

        private Patient setPatientAtributes()
        {
            /*patient.isBlocked = false;
            patient.Email = email.Text;
            patient.DateOfBirth = dateOfBirth.DisplayDate;
            patient.Name = name.Text;
            patient.Id = id.Text;
            patient.Password = iniciallyPassword.Text;
            patient.Phone = phone.Text;
            patient.Surname = surname.Text;
            patient.Username = username.Text;
            patient.UserType = UserType.patient;
            patient.Debit = Convert.ToDouble(debit.Text);
            String[] alergeni = (allergens.Text).Split(',');
            patient.Allergens = new List<string>();
            for (int i = 0; i < alergeni.Length; i++)
            {
                patient.Allergens.Add(alergeni[i]);
            }
            //formiranje adrese
            patient.Address = new Address();
            String[] adresa = (adress.Text).Split(' ');
            int brojac;
            for (brojac = 0; brojac < adresa.Length - 1; brojac++)
            {
                patient.Address.Street += adresa[brojac] + " ";
            }
            String[] brojSpratStan = adresa[adresa.Length - 1].Split('/');
            patient.Address.NumberOfBuilding = Convert.ToInt32(brojSpratStan[0]);
            patient.Address.Floor = Convert.ToInt32(brojSpratStan[1]);
            patient.Address.Apartment = Convert.ToInt32(brojSpratStan[2]);

            patient.Address.City = new City();
            String[] grad = (city.Text).Split(' ');
            int k;
            for (k = 0; k < grad.Length - 1; k++)
            {
                patient.Address.City.name += grad[k] + " ";
            }
            patient.Address.City.postalCode = grad[grad.Length - 1];

            patient.Address.City.Country = new Country();
            patient.Address.City.Country.name = county.Text;
            */
            return patient;
        }

        private User setUserAtributes(Patient patient)
        {
            user.Email = patient.Email;
            user.DateOfBirth = patient.DateOfBirth;
            user.Name = patient.Name;
            user.Id = patient.Id;
            user.Password = patient.Password;
            user.Phone = patient.Phone;
            user.Surname = patient.Surname;
            user.Username = patient.Username;
            user.UserType = UserType.patient;
            user.Address = patient.Address;

            return user;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Secretary.ActionBarWindow abw = new Secretary.ActionBarWindow();
            abw.Show();
            this.Close();
        }
    }
}