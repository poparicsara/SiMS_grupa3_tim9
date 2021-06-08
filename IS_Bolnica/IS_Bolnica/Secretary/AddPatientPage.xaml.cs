using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using IS_Bolnica.Model;
using IS_Bolnica.Services;
using Model;

namespace IS_Bolnica.Secretary
{
    public partial class AddPatientPage : Page
    {
        private Page previousPage;
        private Patient patient = new Patient();
        private User user = new User();
        private PatientService patientService = new PatientService();
        private UserService userService = new UserService();
        public ObservableCollection<Ingredient> Ingredients { get; set; }
        private IngredientService ingredientService = new IngredientService();

        public string JMBG { get; set; }

        public AddPatientPage(Page previousPage)
        {
            InitializeComponent();
            this.previousPage = previousPage;
            this.DataContext = this;
            Ingredients = new ObservableCollection<Ingredient>(ingredientService.GetIngredients());

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(previousPage);
        }

        private void addPatient(object sender, RoutedEventArgs e)
        {
            patient = setPatientAtributes();

            patientService.AddPatient(patient);

            user = setUserAtributes(patient);

            userService.AddUser(user);

            PatientList pl = new PatientList(this);
            this.NavigationService.Navigate(pl);
        }

        private Patient setPatientAtributes()
        {
            patient.isBlocked = false;
            patient.Email = email.Text;
            patient.DateOfBirth = dateOfBirth.DisplayDate;
            patient.Name = name.Text;
            patient.Id = id.Text;
            patient.Password = iniciallyPassword.Password;
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

            setAllergens();
            
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
            patient.examinations = new List<Examination>();
            patient.Anamneses = new List<Anamnesis>();
            patient.HealthCardNumber = "";

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
            PatientList pl = new PatientList(this);
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

        private void setAllergens()
        {
            int i = Allergens.SelectedIndex;
            if (i == -1)
            {
                patient.Ingredients = new List<Ingredient>();
            }
            else
            {
                List<Ingredient> ingredients = new List<Ingredient>();
                ingredients = Allergens.SelectedItems.Cast<Ingredient>().ToList();
                patient.Ingredients = ingredients;
            }
        }
    }
}
