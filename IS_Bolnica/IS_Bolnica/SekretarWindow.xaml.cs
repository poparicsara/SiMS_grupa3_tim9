using System;
using System.Windows;
using System.Windows.Controls;
using System.Runtime.CompilerServices;
using System.ComponentModel;
using System.Collections.ObjectModel;
using Model;
using IS_Bolnica.Model;

namespace IS_Bolnica
{
    public partial class SekretarWindow : Window, INotifyPropertyChanged
    {
        private PatientRecordFileStorage storage = new PatientRecordFileStorage();
        private GuestUsersFileStorage storage1 = new GuestUsersFileStorage();
        private UsersFileStorage usersStorage = new UsersFileStorage();
        private Patient pacijent;
        private GuestUser guestKorisnik;

        public ObservableCollection<Patient> Pacijenti {
            get; set;
        }

        public ObservableCollection<GuestUser> GuestKorisnici
        {
            get; set;
        }

        private int colNum = 0;

        public SekretarWindow()
        {
            InitializeComponent();
            this.DataContext = this;

            Pacijenti = new ObservableCollection<Patient>();
            Pacijenti = storage.loadFromFile("PatientRecordFileStorage.json");

            guestKorisnik = new GuestUser
            {
                SystemName = "xxx123",
                InjuryDescription = "Razbijane glava"
            };

            GuestKorisnici = new ObservableCollection<GuestUser>();
            GuestKorisnici = storage1.loadFromFile("GuestUsersFile.json");
        }

        private void generateColumns(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            colNum++;
            if(colNum == 3)
            {
                e.Column.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void addPatient(object sender, RoutedEventArgs e)
        {
            Secretary.AddPatient ap = new Secretary.AddPatient();
            ap.Show();
            this.Close();
        }

        /*private void editPatient(object sender, RoutedEventArgs e)
        {
            int i = -1;
            i = PatientList.SelectedIndex;

            if (i == -1)
            {
                MessageBox.Show("You didn't choose patient which you want to edit!");
            }
            else
            {
                ObservableCollection<User> korisnici = new ObservableCollection<User>();
                UsersFileStorage storage1 = new UsersFileStorage();
                korisnici = storage1.loadFromFile("UsersFileStorage.json");

                ObservableCollection<User> pacijenti = new ObservableCollection<User>();
                PatientRecordFileStorage storage = new PatientRecordFileStorage();

                pacijenti = storage.loadFromFile("PatientRecordFileStorage.json");


                Secretary.EditPatient ep = new Secretary.EditPatient(i);


                ep.name.Text = pacijenti[i].Name;
                ep.surname.Text = pacijenti[i].Surname;
                ep.username.Text = pacijenti[i].Username;
                ep.dateOfBirth.DisplayDate = pacijenti[i].DateOfBirth;
                ep.iniciallyPassword.Text = pacijenti[i].Password;
                ep.id.Text = pacijenti[i].Id.ToString();
                ep.phone.Text = pacijenti[i].Phone.ToString();
                ep.email.Text = pacijenti[i].Email;

                ep.Show();
                this.Close();
            }
        }*/

        private void createGuestAccount(object sender, RoutedEventArgs e)
        {
            Secretary.GuestUserAccount gua = new Secretary.GuestUserAccount();
            this.Close();
            gua.Show();
        }

        /*private void deletePatient(object sender, RoutedEventArgs e)
        {
            int i = -1;
            i = PatientList.SelectedIndex;
            ObservableCollection<User> users = new ObservableCollection<User>();

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
                        Pacijenti = storage.loadFromFile("PatientRecordFileStorage.json");
                        Pacijenti.Remove(Pacijenti[i]);
                        storage.saveToFile(Pacijenti, "PatientRecordFileStorage.json");

                        users = usersStorage.loadFromFile("UsersFileStorage.json");
                        users.Remove(users[i]);
                        usersStorage.saveToFile(users, "UsersFileStorage.json");

                        SekretarWindow sw = new SekretarWindow();

                        sw.Show();
                        this.Close();

                        break;
                    case MessageBoxResult.No:
                        break;
                }
            }
        }*/

        /*private void deleteGuestAccount(object sender, RoutedEventArgs e)
        {

            int i = -1;
            i = GuestUsers.SelectedIndex;

            if (i == -1)
            {
                MessageBox.Show("You didn't choose account which you want to delete!");
            }
            else
            {
                MessageBoxResult result = MessageBox.Show("Da li stvarno želite da obrišete nalog?", "Brisanje pacijenta", MessageBoxButton.YesNo);
                switch (result)
                {
                    case MessageBoxResult.Yes:
                        GuestKorisnici = storage1.loadFromFile("GuestUsersFile.json");
                        GuestKorisnici.Remove(GuestKorisnici[i]);
                        storage1.saveToFile(GuestKorisnici, "GuestUsersFile.json");

                        SekretarWindow sw = new SekretarWindow();

                        sw.Show();
                        this.Close();


                        break;
                    case MessageBoxResult.No:
                        break;
                }
            }
        }*/

        private void ActionBarOpen(object sender, RoutedEventArgs e)
        {
            Secretary.ActionBarWindow abw = new Secretary.ActionBarWindow();
            abw.Show();
        }
    }
}
