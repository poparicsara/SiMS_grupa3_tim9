using System;
using System.Windows;
using System.Windows.Controls;
using System.Runtime.CompilerServices;
using System.ComponentModel;
using System.Collections.ObjectModel;
using Model;
using IS_Bolnica.Model;
using System.Collections.Generic;

namespace IS_Bolnica
{
    public partial class SekretarWindow : Window, INotifyPropertyChanged
    {
        private PatientRecordFileStorage storage = new PatientRecordFileStorage();
        private GuestUsersFileStorage storage1 = new GuestUsersFileStorage();
        private UsersFileStorage usersStorage = new UsersFileStorage();
        private Patient pacijent;
        private GuestUser guestKorisnik;

        public List<Patient> Pacijenti
        {
            get; set;
        }

        public List<GuestUser> GuestKorisnici
        {
            get; set;
        }

        private int colNum = 0;

        public SekretarWindow()
        {
            InitializeComponent();
            this.DataContext = this;

            Pacijenti = new List<Patient>();
            Pacijenti = storage.loadFromFile("PatientRecordFileStorage.json");

            guestKorisnik = new GuestUser
            {
                SystemName = "xxx123",
                InjuryDescription = "Razbijane glava"
            };

            GuestKorisnici = new List<GuestUser>();
            GuestKorisnici = storage1.loadFromFile("GuestUsersFile.json");
        }

        private void generateColumns(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            colNum++;
            if (colNum == 3)
            {
                e.Column.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ActionBarOpen(object sender, RoutedEventArgs e)
        {
            Secretary.ActionBarWindow abw = new Secretary.ActionBarWindow();
            abw.Show();
            this.Close();
        }

        public void setProfileInfo(User user)
        {
            name.Text = user.Name;
            surname.Text = user.Surname;
            username.Text = user.Username;
            dateOfBirth.Text = Convert.ToString( user.DateOfBirth.Date);
            iniciallyPassword.Text = user.Password;
            id.Text = user.Id.ToString();
            phone.Text = user.Phone.ToString();
            email.Text = user.Email;
            adress.Text = user.Address.Street + " "
                + user.Address.NumberOfBuilding + "/"
                + user.Address.Floor + "/"
                + user.Address.Apartment;
            city.Text = user.Address.City.name + " "
                + Convert.ToString(user.Address.City.postalCode);
            country.Text = user.Address.City.Country.name;
        }
    }
}
