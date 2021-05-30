using System;
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
using System.Collections.ObjectModel;
using Model;
using IS_Bolnica.Model;
using System.Globalization;
using IS_Bolnica.Services;

namespace IS_Bolnica.Secretary
{
    public partial class EditPatient : Window
    {
        private Patient oldPatient = new Patient();
        private Patient patient = new Patient();
        private List<Patient> patients = new List<Patient>();
        private PatientRepository storage = new PatientRepository();
        private List<User> users = new List<User>();
        private User user = new User();
        private UserRepository storage1 = new UserRepository();

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

        private void removePatient(string id)
        {
            patients = storage.LoadFromFile();
            for (int i = 0; i < patients.Count; i++)
            {
                if (patients[i].Id.Equals(id))
                {
                    patients.RemoveAt(i);
                }
            }
        }

        private void removeUser(string id)
        {
            users = storage1.LoadFromFile("UsersFileStorage.json");
            for (int i = 0; i < users.Count; i++)
            {
                if (users[i].Id.Equals(id))
                {
                    users.RemoveAt(i);
                }
            }

        }

        private Patient setPatient()
        {
            Patient pat = new Patient();

            pat.Email = email.Text;
            pat.DateOfBirth = dateOfBirth.DisplayDate;
            pat.Name = name.Text;
            pat.Id = id.Text;
            pat.Password = iniciallyPassword.Text;
            pat.Phone = phone.Text;
            pat.Surname = surname.Text;
            pat.Username = username.Text;
            pat.UserType = UserType.patient;
            pat.Debit = Convert.ToDouble(debit.Text);
            //formiranje alergena
            pat.Allergens = new List<string>();
            String[] alergeni = (allergens.Text).Split(',');
            for (int k = 0; k < alergeni.Length; k++)
            {
                pat.Allergens.Add(alergeni[k]);
            }
            //formiranje adrese
            pat.Address = new Address();
            pat.Address.Street = "";
            String[] adresa = (adress.Text).Split(' ');
            for (int i = 0; i < adresa.Length - 1; i++)
            {
                pat.Address.Street += adresa[i] + " ";
                if (i == adresa.Length - 2)
                {
                    String pom = pat.Address.Street;
                    pat.Address.Street = pom.Remove(pom.Length - 1, 1);
                }
            }

            String[] brojSpratStan = adresa[adresa.Length - 1].Split('/');
            pat.Address.NumberOfBuilding = Convert.ToInt32(brojSpratStan[0]);
            pat.Address.Floor = Convert.ToInt32(brojSpratStan[1]);
            pat.Address.Apartment = Convert.ToInt32(brojSpratStan[2]);

            pat.Address.City = new City();
            pat.Address.City.name = "";
            String[] grad = (city.Text).Split(' ');
            for (int brojac = 0; brojac < grad.Length - 1; brojac++)
            {
                pat.Address.City.name += grad[brojac] + " ";
                if (brojac == grad.Length - 2)
                {
                    String pom = pat.Address.City.name;
                    pat.Address.City.name = pom.Remove(pom.Length - 1, 1);
                }
            }
            pat.Address.City.postalCode = grad[grad.Length - 1];
            pat.Address.City.Country = new Country();
            pat.Address.City.Country.name = country.Text;

            return pat;
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

            /*removePatient(patient.Id);
            removeUser(patient.Id);

            patient = setPatient();
            patients.Add(patient);

            user = setUser(patient);
            users.Add(user);

            storage.SaveToFile(patients, "PatientRecordFileStorage.json");
            storage1.SaveToFile(users, "UsersFileStorage.json");*/

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
