using System;
using System.Windows;
using System.Windows.Controls;
using IS_Bolnica.Model;
using IS_Bolnica.Services;
using Model;

namespace IS_Bolnica.Secretary
{
    public partial class AddPatientPage : Page
    {
        private Patient patient = new Patient();
        private User user = new User();
        private PatientService patientService = new PatientService();
        private UserService userService = new UserService();

        public AddPatientPage()
        {
            InitializeComponent();
            this.DataContext = this;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ActionBar ab = new ActionBar();
            this.NavigationService.Navigate(ab);
        }

        private void addPatient(object sender, RoutedEventArgs e)
        {
            patient = setPatientAtributes();

            patientService.AddPatient(patient);

            user = setUserAtributes(patient);

            userService.AddUser(user);

            PatientList pl = new PatientList();
            this.NavigationService.Navigate(pl);
        }

        private Patient setPatientAtributes()
        {
            patient.isBlocked = false;
            patient.Email = email.Text;
            patient.DateOfBirth = dateOfBirth.DisplayDate;
            patient.Name = name.Text;
            patient.Id = id.Text;
            patient.Password = iniciallyPassword.Text;
            patient.Phone = phone.Text;
            patient.Surname = surname.Text;
            patient.Username = username.Text;
            patient.UserType = UserType.patient;
            if (GenderBox.SelectedIndex == 0)
            {
                patient.Gender = Gender.male;
            }
            else
            {
                patient.Gender = Gender.female;
            }
            /*String[] alergeni = (allergens.Text).Split(',');
            patient.Allergens = new List<string>();
            for (int i = 0; i < alergeni.Length; i++)
            {
                patient.Allergens.Add(alergeni[i]);
            }*/
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

        private void cancelAdding(object sender, RoutedEventArgs e)
        {
            PatientList pl = new PatientList();
            this.NavigationService.Navigate(pl);
        }

        private void Edit_Button_Clicked(object sender, RoutedEventArgs e)
        {
            if (id.Text.Equals(""))
            {
                MessageBox.Show("Niste uneli id pacijenta!");
                return;
            }
            AllergenManipulation am = new AllergenManipulation(this, id.Text);
            this.NavigationService.Navigate(am);
        }
    }
}
