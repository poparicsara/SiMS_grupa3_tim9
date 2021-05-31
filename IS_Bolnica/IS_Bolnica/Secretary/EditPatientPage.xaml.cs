
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using IS_Bolnica.Services;
using Model;

namespace IS_Bolnica.Secretary
{
    /// <summary>
    /// Interaction logic for EditPatientPage.xaml
    /// </summary>
    public partial class EditPatientPage : Page
    {
        private Patient oldPatient = new Patient();
        private PatientService patientService = new PatientService();
        private UserService userService = new UserService();

        public EditPatientPage(Patient oldPatient)
        {
            InitializeComponent();
            this.oldPatient = oldPatient;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ActionBar ab = new ActionBar();
            this.NavigationService.Navigate(ab);
        }

        private void editPatient(object sender, RoutedEventArgs e)
        {
            patientService.EditPatient(oldPatient, setPatient());
            userService.EditUser(setUser(oldPatient), setPatient());

            PatientList pl = new PatientList();
            this.NavigationService.Navigate(pl);

        }

        private void cancelEditing(object sender, RoutedEventArgs e)
        {
            PatientList pl = new PatientList();
            this.NavigationService.Navigate(pl);
        }

        private Patient setPatient()
        {
            Patient patient = new Patient();

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
            //formiranje alergena
            patient.Allergens = new List<string>();
            String[] alergeni = (allergens.Text).Split(',');
            for (int k = 0; k < alergeni.Length; k++)
            {
                patient.Allergens.Add(alergeni[k]);
            }
            //formiranje adrese
            patient.Address = new Address();
            patient.Address.Street = "";
            String[] adresa = (adress.Text).Split(' ');
            for (int i = 0; i < adresa.Length - 1; i++)
            {
                patient.Address.Street += adresa[i] + " ";
                if (i == adresa.Length - 2)
                {
                    String pom = patient.Address.Street;
                    patient.Address.Street = pom.Remove(pom.Length - 1, 1);
                }
            }

            String[] brojSpratStan = adresa[adresa.Length - 1].Split('/');
            patient.Address.NumberOfBuilding = Convert.ToInt32(brojSpratStan[0]);
            patient.Address.Floor = Convert.ToInt32(brojSpratStan[1]);
            patient.Address.Apartment = Convert.ToInt32(brojSpratStan[2]);

            patient.Address.City = new City();
            patient.Address.City.name = "";
            String[] grad = (city.Text).Split(' ');
            for (int brojac = 0; brojac < grad.Length - 1; brojac++)
            {
                patient.Address.City.name += grad[brojac] + " ";
                if (brojac == grad.Length - 2)
                {
                    String pom = patient.Address.City.name;
                    patient.Address.City.name = pom.Remove(pom.Length - 1, 1);
                }
            }
            patient.Address.City.postalCode = grad[grad.Length - 1];
            patient.Address.City.Country = new Country();
            patient.Address.City.Country.name = country.Text;

            return patient;
        }

        private User setUser(Patient pat)
        {
            User user1 = new User
            {
                Id = pat.Id,
                Email = pat.Email,
                Address = pat.Address,
                DateOfBirth = pat.DateOfBirth,
                Name = pat.Name,
                Password = pat.Password,
                Phone = pat.Phone,
                Surname = pat.Surname,
                Username = pat.Username,
                UserType = UserType.patient
            };

            return user1;
        }
    }
}
