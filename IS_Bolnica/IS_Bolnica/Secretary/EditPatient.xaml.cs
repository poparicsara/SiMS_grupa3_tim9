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

namespace IS_Bolnica.Secretary
{
    /// <summary>
    /// Interaction logic for EditPatient.xaml
    /// </summary>
    public partial class EditPatient : Window
    {
        private Patient patient;
        public EditPatient(Patient patient)
        {
            InitializeComponent();
            this.patient = patient;
        }

        private void cancelEditing(object sender, RoutedEventArgs e)
        {
            this.Close();
            Secretary.PatientListWindow plw = new Secretary.PatientListWindow();
            plw.Show();
        }

        private void editPatient(object sender, RoutedEventArgs e)
        {
            ObservableCollection<Patient> pacijenti = new ObservableCollection<Patient>();
            PatientRecordFileStorage storage = new PatientRecordFileStorage();
            ObservableCollection<User> korisnici = new ObservableCollection<User>();
            UsersFileStorage storage1 = new UsersFileStorage();

            pacijenti = storage.loadFromFile("PatientRecordFileStorage.json");
            for(int i = 0; i < pacijenti.Count; i++)
            {
                if(pacijenti[i].Id.Equals(patient.Id))
                {
                    pacijenti.RemoveAt(i);
                }
            }

            korisnici = storage1.loadFromFile("UsersFileStorage.json");
            for(int i = 0; i < korisnici.Count; i++)
            {
                if(korisnici[i].Id.Equals(patient.Id))
                {
                    korisnici.RemoveAt(i);
                }
            }

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
            patient.Address.Street = "";
            String[] adresa = (adress.Text).Split(' ');
            for (int i = 0; i < adresa.Length-1; i++)
            {
                patient.Address.Street += adresa[i] + " ";
                if (i == adresa.Length-2)
                {
                    String pom = patient.Address.Street;
                    patient.Address.Street = pom.Remove(pom.Length-1, 1);
                }
            }


            String[] brojSpratStan = adresa[adresa.Length-1].Split('/');
            patient.Address.NumberOfBuilding = Convert.ToInt32( brojSpratStan[0]);
            patient.Address.Floor = Convert.ToInt32( brojSpratStan[1]);
            patient.Address.Apartment = Convert.ToInt32(brojSpratStan[2]);

            patient.Address.City.name = "";
            String[] grad = (city.Text).Split(' ');
            for (int brojac = 0; brojac < grad.Length - 1; brojac++)
            {
                patient.Address.City.name += grad[brojac] + " ";
                if(brojac == grad.Length-2)
                    {
                        String pom = patient.Address.City.name;
                        patient.Address.City.name = pom.Remove(pom.Length-1, 1);
                    }
            }
            patient.Address.City.postalCode = grad[grad.Length-1];
            patient.Address.City.Country.name = country.Text;

            pacijenti.Add(patient);

            foreach (User korisnik in korisnici)
            {
                if (korisnik.Id.Equals(patient.Id))
                {
                    korisnik.Email = patient.Email;
                    korisnik.DateOfBirth = patient.DateOfBirth;
                    korisnik.Name = patient.Name;
                    korisnik.Id = patient.Id;
                    korisnik.Password = patient.Password;
                    korisnik.Phone = patient.Phone;
                    korisnik.Surname = patient.Surname;
                    korisnik.Username = patient.Username;
                    korisnik.UserType = UserType.patient;
                    korisnik.Address = patient.Address;
                    korisnici.Add(korisnik);
                }
            }
            
            storage.saveToFile(pacijenti, "PatientRecordFileStorage.json");
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
