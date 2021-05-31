using System;
using System.Collections.Generic;
using System.Windows;
using Model;
using IS_Bolnica.Model;
using IS_Bolnica.Services;

namespace IS_Bolnica.Secretary
{
    public partial class EditPatient : Window
    {
        private Patient oldPatient = new Patient();
        private PatientService patientService = new PatientService();
        private UserService userService = new UserService();

        public EditPatient(Patient oldPatient)
        {
            InitializeComponent();
            this.oldPatient = oldPatient;
        }

        private void cancelEditing(object sender, RoutedEventArgs e)
        {
            this.Close();
            Secretary.PatientListWindow plw = new Secretary.PatientListWindow();
            plw.Show();
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

        private void editPatient(object sender, RoutedEventArgs e)
        {
            patientService.EditPatient(oldPatient, setPatient());
            userService.EditUser(setUser(oldPatient), setPatient());

            Secretary.PatientListWindow plw = new Secretary.PatientListWindow();
            plw.Show();
            this.Close();


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Secretary.ActionBarWindow abw = new Secretary.ActionBarWindow();
            abw.Show();
            this.Close();
        }
    }
}
