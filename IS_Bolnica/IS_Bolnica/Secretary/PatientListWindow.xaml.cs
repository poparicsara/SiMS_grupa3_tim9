using IS_Bolnica.Model;
using Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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

namespace IS_Bolnica.Secretary
{
    public partial class PatientListWindow : Window, INotifyPropertyChanged
    {
        private PatientRecordFileStorage storage = new PatientRecordFileStorage();
        private Patient pacijent;
        private UsersFileStorage usersStorage = new UsersFileStorage();
        public ObservableCollection<Patient> Pacijenti
        {
            get; set;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public PatientListWindow()
        {
            InitializeComponent();
            this.DataContext = this;

            Pacijenti = new ObservableCollection<Patient>();
            Pacijenti = storage.loadFromFile("PatientRecordFileStorage.json");
            PatientList.ItemsSource = Pacijenti;
        }

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
            int i = -1;
            i = PatientList.SelectedIndex;
            Patient patient = (Patient)PatientList.SelectedItem;

            if (i == -1)
            {
                MessageBox.Show("You didn't choose patient which you want to edit!");
            }
            else
            {
                ObservableCollection<User> korisnici = new ObservableCollection<User>();
                UsersFileStorage storage1 = new UsersFileStorage();
                korisnici = storage1.loadFromFile("UsersFileStorage.json");

                ObservableCollection<Patient> pacijenti = new ObservableCollection<Patient>();
                PatientRecordFileStorage storage = new PatientRecordFileStorage();

                pacijenti = storage.loadFromFile("PatientRecordFileStorage.json");


                Secretary.EditPatient ep = new Secretary.EditPatient(patient);
                /*

                ep.name.Text = pacijenti[i].Name;
                ep.surname.Text = pacijenti[i].Surname;
                ep.username.Text = pacijenti[i].Username;
                ep.dateOfBirth.DisplayDate = pacijenti[i].DateOfBirth.Date;
                ep.iniciallyPassword.Text = pacijenti[i].Password;
                ep.id.Text = pacijenti[i].Id.ToString();
                ep.phone.Text = pacijenti[i].Phone.ToString();
                ep.email.Text = pacijenti[i].Email;
                ep.adress.Text = pacijenti[i].Address.Street + " "
                    + pacijenti[i].Address.NumberOfBuilding + "/"
                    + pacijenti[i].Address.Floor + "/"
                    + pacijenti[i].Address.Apartment;
                ep.city.Text = pacijenti[i].Address.City.name + " "
                    + Convert.ToString(pacijenti[i].Address.City.postalCode);
                ep.country.Text = pacijenti[i].Address.City.Country.name;
                ep.debit.Text = Convert.ToString(pacijenti[i].Debit);
                List<string> alergeni = pacijenti[i].Allergens;
                foreach(var alergen in alergeni)
                {
                    ep.allergens.Text += alergen + ",";

                }
                String pom = ep.allergens.Text;
                ep.allergens.Text = pom.Remove(pom.Length-1,1);*/

                ep.name.Text = patient.Name;
                ep.surname.Text = patient.Surname;
                ep.username.Text = patient.Username;
                ep.dateOfBirth.DisplayDate = patient.DateOfBirth.Date;
                ep.iniciallyPassword.Text = patient.Password;
                ep.id.Text = patient.Id.ToString();
                ep.phone.Text = patient.Phone.ToString();
                ep.email.Text = patient.Email;
                ep.adress.Text = patient.Address.Street + " "
                    + patient.Address.NumberOfBuilding + "/"
                    + patient.Address.Floor + "/"
                    + patient.Address.Apartment;
                ep.city.Text = patient.Address.City.name + " "
                    + Convert.ToString(patient.Address.City.postalCode);
                ep.country.Text = patient.Address.City.Country.name;
                ep.debit.Text = Convert.ToString(patient.Debit);
                List<string> alergeni = patient.Allergens;
                foreach (var alergen in alergeni)
                {
                    ep.allergens.Text += alergen + ",";

                }
                String pom = ep.allergens.Text;
                ep.allergens.Text = pom.Remove(pom.Length - 1, 1);

                ep.Show();
                this.Close();
            }

        }

        private void deletePatient(object sender, RoutedEventArgs e)
        {
            int i = -1;
            i = PatientList.SelectedIndex;
            ObservableCollection<User> users = new ObservableCollection<User>();

            Patient patient = (Patient)PatientList.SelectedItem;

            

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
                        for (int k = 0; k < Pacijenti.Count; k++)
                        {
                            if (Pacijenti[k].Id.Equals(patient.Id))
                            {
                                Pacijenti.RemoveAt(k);
                            }
                        }
                        storage.saveToFile(Pacijenti, "PatientRecordFileStorage.json");
                        
                        users = usersStorage.loadFromFile("UsersFileStorage.json");
                        for(int k = 0; k < users.Count; k++)
                        {
                            if (users[k].Id.Equals(patient.Id))
                            {
                                users.RemoveAt(k);
                            }
                        }
                        usersStorage.saveToFile(users, "UsersFileStorage.json");

                        /*pacijenti = storage.loadFromFile("PatientRecordFileStorage.json");
                        for (int i = 0; i < pacijenti.Count; i++)
                        {
                            if (pacijenti[i].Id.Equals(patient.Id))
                            {
                                pacijenti.RemoveAt(i);
                            }
                        }

                        korisnici = storage1.loadFromFile("UsersFileStorage.json");
                        for (int i = 0; i < korisnici.Count; i++)
                        {
                            if (korisnici[i].Id.Equals(patient.Id))
                            {
                                korisnici.RemoveAt(i);
                            }
                        }
                        */
                        SekretarWindow sw = new SekretarWindow();

                        sw.Show();
                        this.Close();

                        break;
                    case MessageBoxResult.No:
                        break;
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Secretary.ActionBarWindow abw = new Secretary.ActionBarWindow();
            abw.Show();
        }

        private void pretraziBox_KeyUp(object sender, KeyEventArgs e)
        {
            var filtered = Pacijenti.Where(patient => patient.Id.StartsWith(pretraziBox.Text));

            PatientList.ItemsSource = filtered;
        }
    }
}
