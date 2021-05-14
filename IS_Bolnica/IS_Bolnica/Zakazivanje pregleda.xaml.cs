using IS_Bolnica.Model;
using Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace IS_Bolnica
{
    /// <summary>
    /// Interaction logic for Zakazivanje_pregleda.xaml
    /// </summary>
    public partial class Zakazivanje_pregleda : Window
    {
        public String doktor_ime = "";
        public String doktor_prezime = "";
        public String datum_predlozi = "";
        public List<String> doktori { get; set;}
        public int akcije { get; set; }
        public int ocenePacijenta { get; set; }
        public Zakazivanje_pregleda(int brojAkcija, int brojOcenjivanja)
        {
            UsersFileStorage exStorage = new UsersFileStorage();
            List<User> users = exStorage.loadFromFile("UsersFileStorage.json");

            doktori = new List<String>();
            
            foreach (User user in users) {
                if (Convert.ToInt32(user.UserType) == 1) {
                    doktori.Add(user.Name + " " + user.Surname);
                }
            }
            akcije = brojAkcija;
            ocenePacijenta = brojOcenjivanja;

            DataContext = this;

            InitializeComponent();

        }

        private void ButtonOdustaniClicked(object sender, RoutedEventArgs e) {
            PatientWindow pw = new PatientWindow(PatientWindow.username_patient, false);
            pw.Show();
            this.Close();
        }

        private void ButtonZakaziClicked(object sender, RoutedEventArgs e) {
            ExaminationsRecordFileStorage exStorage = new ExaminationsRecordFileStorage();
            List<Examination> pregledi = exStorage.loadFromFile("Pregledi.json");

            Doctor d1 = new Doctor();
            String nameAndSurname = DoctorCombo.Text;
            d1.Name = Regex.Replace(nameAndSurname.Split()[0], @"[^0-9a-zA-Z\ ]+", "");
            d1.Surname = Regex.Replace(nameAndSurname.Split()[1], @"[^0-9a-zA-Z\ ]+", "");           

            DateTime datum = (DateTime) Datum.SelectedDate;
            int dan = datum.Day;
            int mesec = datum.Month;
            int godina = datum.Year;
            int sati = Convert.ToInt32(hourBox.Text);
            int minuti = Convert.ToInt32(minutesBox.Text);
            DateTime datumPregleda = new DateTime(godina, mesec, dan, sati, minuti, 0);
            bool dodavanje = false;
            
            foreach (Examination pregled in pregledi){
                if (Convert.ToString(pregled.Date).Equals(datumPregleda.ToString()) && d1.Name.Equals(pregled.Doctor.Name) && d1.Surname.Equals(pregled.Doctor.Surname))
                {
                    MessageBox.Show("Ne mozete zakazati pregled jer je ovaj termin pregleda kod oznacenog doktora vec zauzet!");
                    dodavanje = true;
                    break;
                }
                
            }
            if (!dodavanje)
            {
                Random rnd = new Random();
                int trajanje = rnd.Next(23, 29);
                Patient pacijent = new Patient();
                pacijent.Username = PatientWindow.username_patient;
                pacijent.Akcije = akcije;
                pacijent.brojOcenjenihPregleda = ocenePacijenta;
                Examination e1 = new Examination { IsPayed = false, DurationInMinutes = trajanje, Doctor = d1, Date = datumPregleda, Patient = pacijent };
                pregledi.Add(e1);
            }
            
            exStorage.saveToFile(pregledi, "Pregledi.json");
            PatientWindow pw = new PatientWindow(PatientWindow.username_patient, false);
            pw.Show();
            this.Close();
        }

        private void ButtonPredloziClicked(object sender, RoutedEventArgs e) {

            if (DoctorCombo.Text != "")
            {
                String nameAndSurname = DoctorCombo.Text;
                doktor_ime = Regex.Replace(nameAndSurname.Split()[0], @"[^0-9a-zA-Z\ ]+", "");
                doktor_prezime = Regex.Replace(nameAndSurname.Split()[1], @"[^0-9a-zA-Z\ ]+", "");
            }
            else if (Datum.SelectedDate.ToString() != "")
            {
                datum_predlozi = Datum.SelectedDate.ToString();
            }
            
            Predlozi predlozi = new Predlozi(doktor_ime, doktor_prezime, Convert.ToDateTime(Datum.SelectedDate));
            predlozi.Show();
        }

        private void BackButtonClicked(object sender, RoutedEventArgs e)
        {
            PatientWindow pw = new PatientWindow(PatientWindow.username_patient, false);
            pw.Show();
            this.Close();
        }
    }
}
