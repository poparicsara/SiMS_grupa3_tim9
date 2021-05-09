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
    /// Interaction logic for Izmena_pregleda.xaml
    /// </summary>
    public partial class Izmena_pregleda : Window
    {
        private int oznaceniIndex;

        public List<String> doktori { get; set; }
        public Izmena_pregleda(int index)
        {
            UsersFileStorage userStorage = new UsersFileStorage();
            List<User> users = userStorage.loadFromFile("UsersFileStorage.json");

            doktori = new List<String>();

            foreach (User user in users)
            {
                if (Convert.ToInt32(user.UserType) == 1)
                {
                    doktori.Add(user.Name + " " + user.Surname);
                }
            }

            oznaceniIndex = index;
            ExaminationsRecordFileStorage exStorage = new ExaminationsRecordFileStorage();
            List<Examination> pregledi = exStorage.loadFromFile("Pregledi.json");
            ObservableCollection<Examination> pacijentovi_pregledi = new ObservableCollection<Examination>();

            foreach (Examination ex in pregledi)
            {
                if (ex.Patient.Username.Equals(PatientWindow.username_patient))
                {
                    pacijentovi_pregledi.Add(ex);
                }
            }

            //2.3.2020. 09:15:00 
            DateTime oznaceniDatum = pacijentovi_pregledi.ElementAt(index).Date;
            string[] pom = oznaceniDatum.ToString().Split(' ');
            string[] datum = pom[0].Split('/');
            string[] vreme = pom[1].Split(':');

            InitializeComponent();

            DoktorBox.SelectedValue = pacijentovi_pregledi.ElementAt(index).Doctor.Name + " " + pacijentovi_pregledi.ElementAt(index).Doctor.Surname;
            DateTime dat = new DateTime(Int32.Parse(datum[2]), Int32.Parse(datum[0]), Int32.Parse(datum[1]));
            DateBox.SelectedDate = dat;
            if (pom[2].Equals("PM") && Convert.ToInt32(vreme[0]) < 12)
            {
                SatiBox.Text = (Convert.ToInt32(vreme[0]) + 12).ToString();
            }
            else {
                SatiBox.Text = vreme[0];
            }
            MinutiBox.Text = vreme[1];
            DataContext = this;

        }
        private void OdustaniButtonClicked(object sender, RoutedEventArgs e)
        {
            PatientWindow pw = new PatientWindow(PatientWindow.username_patient, false);
            pw.Show();
            this.Close();
        }

        private void IzmeniButtonClicked(object sender, RoutedEventArgs e)
        {
            ExaminationsRecordFileStorage exStorage = new ExaminationsRecordFileStorage();
            List<Examination> pregledi = exStorage.loadFromFile("Pregledi.json");
            List<Examination> pacijentovi_pregledi = new List<Examination>();

            for (int i=0; i<pregledi.Count; i++)
            {
                if (pregledi[i].Patient.Username.Equals(PatientWindow.username_patient))
                {
                    
                    pacijentovi_pregledi.Add(pregledi[i]);
                    
                }
            }

            foreach (Examination ex in pacijentovi_pregledi) {
                pregledi.Remove(ex);
            }
            

            Doctor d1 = new Doctor();
            String nameAndSurname = DoktorBox.Text;
            d1.Name = Regex.Replace(nameAndSurname.Split()[0], @"[^0-9a-zA-Z\ ]+", "");
            d1.Surname = Regex.Replace(nameAndSurname.Split()[1], @"[^0-9a-zA-Z\ ]+", "");
            DateTime datum = (DateTime)DateBox.SelectedDate;
            int dan = datum.Day;
            int mesec = datum.Month;
            int godina = datum.Year;
            int sati = Convert.ToInt32(SatiBox.Text);
            int minuti = Convert.ToInt32(MinutiBox.Text);
            DateTime datumPregledaNovi = new DateTime(godina, mesec, dan, sati, minuti, 0);
            bool dodavanje = false;

            foreach (Examination pregled in pregledi)
            {
                if (Convert.ToString(datumPregledaNovi).Equals(pregled.Date.ToString()) && d1.Name.Equals(pregled.Doctor.Name) && d1.Surname.Equals(pregled.Doctor.Surname))
                {
                    MessageBox.Show("Ne mozete zakazati pregled jer je ovaj termin pregleda kod oznacenog doktora vec zauzet!");
                    dodavanje = true;
                    break;
                }
            }

            if (!dodavanje)
            {
                pacijentovi_pregledi.ElementAt(oznaceniIndex).Date = datumPregledaNovi;
                pacijentovi_pregledi.ElementAt(oznaceniIndex).Doctor = d1;

                foreach (Examination ex in pacijentovi_pregledi) {
                    pregledi.Add(ex);
                }
                
                exStorage.saveToFile(pregledi, "Pregledi.json");
            }
            PatientWindow pw = new PatientWindow(PatientWindow.username_patient, false);
            pw.Show();
            this.Close();
        }
    }
}
