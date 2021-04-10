using Model;
using System;
using System.Windows;
using System.Collections.ObjectModel;
using IS_Bolnica.Model;
using System.Collections.Generic;
using System.ComponentModel;

namespace IS_Bolnica.Secretary
{
    public partial class AddPatient : Window, INotifyPropertyChanged
    {
        private Patient patient = new Patient();
        private User user = new User();
        private PatientRecordFileStorage storage = new PatientRecordFileStorage();
        private UsersFileStorage storage1 = new UsersFileStorage();

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

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
            patient.Email = email.Text;
            patient.DateOfBirth = dateOfBirth.DisplayDate;
            patient.Name = name.Text;
            patient.Id = id.Text;
            patient.Password = iniciallyPassword.Text;
            patient.Phone = phone.Text;
            patient.Surname = surname.Text;
            patient.Username = username.Text;
            patient.UserType = UserType.patient;
            patient.Debit = Convert.ToDouble( debit.Text);
            String[] alergeni = (allergens.Text).Split(',');
            patient.Allergens = new List<string>();
            for(int i = 0; i < alergeni.Length; i++)
            {
                patient.Allergens.Add(alergeni[i]);
            }
            //formiranje adrese
            patient.Address = new Address();
            String[] adresa = (adress.Text).Split(' ');
            int brojac;
            for(brojac = 0; brojac < adresa.Length-1; brojac++)
            {
                patient.Address.Street += adresa[brojac] + " ";
            }
            String[] brojSpratStan = adresa[adresa.Length-1].Split('/');
            patient.Address.NumberOfBuilding = Convert.ToInt32(brojSpratStan[0]);
            patient.Address.Floor = Convert.ToInt32(brojSpratStan[1]);
            patient.Address.Apartment = Convert.ToInt32(brojSpratStan[2]);

            patient.Address.City = new City();
            String[] grad = (city.Text).Split(' ');
            int k;
            for(k = 0; k < grad.Length - 1; k++)
            {
                patient.Address.City.name += grad[k] + " ";
            }
            patient.Address.City.postalCode = grad[grad.Length-1];

            patient.Address.City.Country = new Country();
            patient.Address.City.Country.name = county.Text;

            ObservableCollection<Patient> pacijenti = new ObservableCollection<Patient>();
            pacijenti = storage.loadFromFile("PatientRecordFileStorage.json");
            pacijenti.Add(patient);
            storage.saveToFile(pacijenti, "PatientRecordFileStorage.json");


            user.Email = email.Text;
            user.DateOfBirth = dateOfBirth.DisplayDate;
            user.Name = name.Text;
            user.Id = id.Text;
            user.Password = iniciallyPassword.Text;
            user.Phone = phone.Text;
            user.Surname = surname.Text;
            user.Username = username.Text;
            user.UserType = UserType.patient;
            user.Address = patient.Address;
            /*user.Address.NumberOfBuilding = patient.Address.NumberOfBuilding;
            user.Address.Floor = patient.Address.Floor;
            user.Address.Apartment = patient.Address.Apartment;
            user.Address.City.name = patient.Address.City.name;
            user.Address.City.postalCode = patient.Address.City.postalCode;
            user.Address.City.Country.name = patient.Address.City.Country.name;*/

            ObservableCollection<User> korisnici = new ObservableCollection<User>();
            korisnici = storage1.loadFromFile("UsersFileStorage.json");
            korisnici.Add(user);
            storage1.saveToFile(korisnici, "UsersFileStorage.json");

            Secretary.PatientListWindow plw = new Secretary.PatientListWindow();
            plw.Show();
            this.Close();


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Secretary.ActionBarWindow abw = new Secretary.ActionBarWindow();
            abw.Show();
        }
    }
}
