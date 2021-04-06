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
        }

        private void editPatient(object sender, RoutedEventArgs e)
        {
            ObservableCollection<User> pacijenti = new ObservableCollection<User>();
            PatientRecordFileStorage storage = new PatientRecordFileStorage();
            ObservableCollection<User> korisnici = new ObservableCollection<User>();
            UsersFileStorage storage1 = new UsersFileStorage();

            pacijenti = storage.loadFromFile("PatientRecordFileStorage.json");
            korisnici = storage1.loadFromFile("UsersFileStorage.json");

            pacijenti[index].Email = email.Text;
            pacijenti[index].DateOfBirth = dateOfBirth.DisplayDate;
            pacijenti[index].Name = name.Text;
            pacijenti[index].Id = (int)Int64.Parse(id.Text);
            pacijenti[index].Password = iniciallyPassword.Text;
            pacijenti[index].Phone = (int)Int64.Parse(phone.Text);
            pacijenti[index].Surname = surname.Text;
            pacijenti[index].Username = username.Text;
            pacijenti[index].UserType = UserType.patient;

            foreach (User korisnik in korisnici)
            {
                foreach (User pacijent in pacijenti)
                {
                    if (korisnik.Id.Equals(pacijent.Id))
                    {
                        korisnik.Email = email.Text;
                        korisnik.DateOfBirth = dateOfBirth.DisplayDate;
                        korisnik.Name = name.Text;
                        korisnik.Id = (int)Int64.Parse(id.Text);
                        korisnik.Password = iniciallyPassword.Text;
                        korisnik.Phone = (int)Int64.Parse(phone.Text);
                        korisnik.Surname = surname.Text;
                        korisnik.Username = username.Text;
                        korisnik.UserType = UserType.patient;
                    }
                }
            }

            storage.saveToFile(pacijenti, "PatientRecordFileStorage.json");
            storage1.saveToFile(korisnici, "UsersFileStorage.json");

            SekretarWindow sw = new SekretarWindow();
            sw.Show();
            this.Close();


        }
    }
}
