using System;
using System.Windows;
using System.Windows.Controls;
using System.Runtime.CompilerServices;
using System.ComponentModel;
using System.Collections.ObjectModel;
using Model;

namespace IS_Bolnica
{
    public partial class SekretarWindow : Window, INotifyPropertyChanged
    {
        private PatientRecordFileStorage storage = new PatientRecordFileStorage();
        private GuestUsersFileStorage storage1 = new GuestUsersFileStorage();
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

        private void editPatient(object sender, RoutedEventArgs e)
        {

            int i = PatientList.SelectedIndex;
            Secretary.EditPatient ep = new Secretary.EditPatient(i);

            ObservableCollection<Patient> pacijenti = new ObservableCollection<Patient>();
            PatientRecordFileStorage storage = new PatientRecordFileStorage();
            pacijenti = storage.loadFromFile("PatientRecordFileStorage.json");

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

        private void createGuestAccount(object sender, RoutedEventArgs e)
        {
            Secretary.GuestUserAccount gua = new Secretary.GuestUserAccount();
            this.Close();
            gua.Show();
        }

        private void deletePatient(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Da li stvarno želite da obrišete pacijenta?", "Brisanje pacijenta", MessageBoxButton.YesNo);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    int i = PatientList.SelectedIndex;
                    Pacijenti = storage.loadFromFile("PatientRecordFileStorage.json");
                    Pacijenti.Remove(Pacijenti[i]);
                    storage.saveToFile(Pacijenti, "PatientRecordFileStorage.json");
                    
                    break;
                case MessageBoxResult.No:
                    break;
            }
        }

        private void deleteGuestAccount(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Da li stvarno želite da obrišete nalog?", "Brisanje pacijenta", MessageBoxButton.YesNo);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    int i = GuestUsers.SelectedIndex;
                    GuestKorisnici = storage1.loadFromFile("GuestUsersFile.json");
                    GuestKorisnici.Remove(GuestKorisnici[i]);
                    storage1.saveToFile(GuestKorisnici, "GuestUsersFile.json");
                    //GuestUsers.Items.Refresh();

                    break;
                case MessageBoxResult.No:
                    break;
            }
        }
    }
}
