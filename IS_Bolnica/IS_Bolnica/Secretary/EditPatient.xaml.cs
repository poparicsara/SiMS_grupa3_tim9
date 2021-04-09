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
        int index;
        public EditPatient(int index)
        {
            InitializeComponent();
            this.index = index;
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
            korisnici = storage1.loadFromFile("UsersFileStorage.json");

            pacijenti[index].Email = email.Text;
            pacijenti[index].DateOfBirth = dateOfBirth.DisplayDate;
            pacijenti[index].Name = name.Text;
            pacijenti[index].Id = id.Text;
            pacijenti[index].Password = iniciallyPassword.Text;
            pacijenti[index].Phone = phone.Text;
            pacijenti[index].Surname = surname.Text;
            pacijenti[index].Username = username.Text;
            pacijenti[index].UserType = UserType.patient;
            pacijenti[index].Debit = Convert.ToDouble(debit.Text);
            //formiranje alergena
            pacijenti[index].Allergens = new List<string>();
            String[] alergeni = (allergens.Text).Split(',');
            for (int k = 0; k < alergeni.Length; k++)
            {
                pacijenti[index].Allergens.Add(alergeni[k]);
            }
            //formiranje adrese
            pacijenti[index].Address.Street = "";
            String[] adresa = (adress.Text).Split(' ');
            for (int i = 0; i < adresa.Length-1; i++)
            {
                pacijenti[index].Address.Street += adresa[i] + " ";
                if (i == adresa.Length-2)
                {
                    String pom = pacijenti[index].Address.Street;
                    pacijenti[index].Address.Street = pom.Remove(pom.Length-1, 1);
                }
            }


            String[] brojSpratStan = adresa[adresa.Length-1].Split('/');
            pacijenti[index].Address.NumberOfBuilding = Convert.ToInt32( brojSpratStan[0]);
            pacijenti[index].Address.Floor = Convert.ToInt32( brojSpratStan[1]);
            pacijenti[index].Address.Apartment = Convert.ToInt32(brojSpratStan[2]);

            pacijenti[index].Address.City.name = "";
            String[] grad = (city.Text).Split(' ');
            for (int brojac = 0; brojac < grad.Length - 1; brojac++)
            {
                pacijenti[index].Address.City.name += grad[brojac] + " ";
                if(brojac == grad.Length-2)
                    {
                        String pom = pacijenti[index].Address.City.name;
                        pacijenti[index].Address.City.name = pom.Remove(pom.Length-1, 1);
                    }
            }
            pacijenti[index].Address.City.postalCode = grad[grad.Length-1];
            pacijenti[index].Address.City.Country.name = country.Text;

            

            foreach (User korisnik in korisnici)
            {
                if (korisnik.Id.Equals(pacijenti[index].Id))
                {
                    korisnik.Email = pacijenti[index].Email;
                    korisnik.DateOfBirth = pacijenti[index].DateOfBirth;
                    korisnik.Name = pacijenti[index].Name;
                    korisnik.Id = pacijenti[index].Id;
                    korisnik.Password = pacijenti[index].Password;
                    korisnik.Phone = pacijenti[index].Phone;
                    korisnik.Surname = pacijenti[index].Surname;
                    korisnik.Username = pacijenti[index].Username;
                    korisnik.UserType = UserType.patient;
                    korisnik.Address = pacijenti[index].Address;
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
