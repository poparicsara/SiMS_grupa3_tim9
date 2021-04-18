using Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace IS_Bolnica
{
    /// <summary>
    /// Interaction logic for PatientWindow.xaml
    /// </summary>
    public partial class PatientWindow : Window
    {
        public static String username_patient { get; set; }
        public PatientWindow(String username)
        {
            InitializeComponent();

            ExaminationsRecordFileStorage exStorage = new ExaminationsRecordFileStorage();
            List<Examination> pregledi = exStorage.loadFromFile("Pregledi.json");
            List<Examination> pacijentovi_pregledi = new List<Examination>();
            username_patient = username;

            foreach (Examination ex in pregledi) {
                if (ex.username.Equals(username)) {
                    pacijentovi_pregledi.Add(ex);
                }
            }

            lvDataBinding.ItemsSource = pacijentovi_pregledi;

            /*
            Specialization s1 = new Specialization { name = "RADIOLOG" };
            Specialization s2 = new Specialization { name = "KARDIOLOG" };
            Specialization s3 = new Specialization { name = "PULMOLOG" };
            Doctor d1 = new Doctor { specialization = s1 };
            Doctor d2 = new Doctor { specialization = s2 };
            Doctor d3 = new Doctor { specialization = s3 };
            d1.name = "Pera";
            d1.surname = "Peric";
            d2.name = "Mika";
            d2.surname = "Mikic";
            d3.name = "Zika";
            d3.surname = "Zikic";

            Examination e1 = new Examination
            {
                isPayed = false,
                evaluation = Evaluation.poor,
                durationInMinutes = 56,
                doctor = d1,
                date = new DateTime(2021,02,23,15,30,00)
            };
        Examination e2 = new Examination
        {
            isPayed = true,
            evaluation = Evaluation.good,
            durationInMinutes = 26,
            doctor = d2,
            date = new DateTime(2021,03,02,09,00,00)
            };
    Examination e3 = new Examination
    {
        isPayed = false,
        evaluation = Evaluation.veryGood,
        durationInMinutes = 30,
        doctor = d3,
        date = new DateTime(2021,04,11,11,30,30)
            };

            pregledi.Add(e1);
            pregledi.Add(e2);
            pregledi.Add(e3);
            
            exStorage.saveToFile(pregledi, "Pregledi.json");*/
        }

        private void AddButtonClicked(object sender, RoutedEventArgs e)
        {
            Zakazivanje_pregleda zp = new Zakazivanje_pregleda();
            zp.Show();
            this.Close();
        }

        private void OtkaziButtonClicked(object sender, RoutedEventArgs e) {

            if (lvDataBinding.SelectedIndex == -1)
            {
                MessageBox.Show("Oznacite pregled koji zelite da otkazete!");
            }
            else
            {
                ExaminationsRecordFileStorage exStorage = new ExaminationsRecordFileStorage();
                List<Examination> pregledi = exStorage.loadFromFile("Pregledi.json");

                
                Examination oznacen_pregled = new Examination();

                for (int i = 0; i < pregledi.Count; i++) {
                    if (i == lvDataBinding.SelectedIndex) {
                        oznacen_pregled = pregledi[i];
                    }
                }
                DateTime now = DateTime.Now;
                string[] pom = now.ToString().Split(' ');
                string[] datum = pom[0].Split('/');

                string[] pomocni = oznacen_pregled.date.ToString().Split(' ');
                string[] pomocni_datum = pomocni[0].Split('/');

                if (Convert.ToInt32(datum[1]) + 2 < Convert.ToInt32(pomocni_datum[1]))
                {
                    pregledi.Remove(oznacen_pregled);
                }
                else
                {
                    MessageBox.Show("Ne mozete da otkazete pregled jer je zakazan u periodu od naredna dva dana!");
                }

                List<Examination> pacijentovi_pregledi = new List<Examination>();

                foreach (Examination ex in pregledi)
                {
                    if (ex.username.Equals(username_patient))
                    {
                        pacijentovi_pregledi.Add(ex);
                    }
                }

                lvDataBinding.ItemsSource = pacijentovi_pregledi;

                exStorage.saveToFile(pregledi, "Pregledi.json");
            }
        }

        private void IzmeniButtonClicked(object sender, RoutedEventArgs e) {
            if (lvDataBinding.SelectedIndex == -1)
            {
                MessageBox.Show("Oznacite pregled koji zelite da izmenite!");
            }
            else
            {
                ExaminationsRecordFileStorage exStorage = new ExaminationsRecordFileStorage();
                List<Examination> pregledi = exStorage.loadFromFile("Pregledi.json");

                Examination oznacen_pregled = new Examination();

                List<Examination> pacijentovi_pregledi = new List<Examination>();

                foreach (Examination ex in pregledi)
                {
                    if (ex.username.Equals(username_patient))
                    {
                        pacijentovi_pregledi.Add(ex);
                    }
                }

                for (int i = 0; i < pacijentovi_pregledi.Count; i++)
                {
                    if (i == lvDataBinding.SelectedIndex)
                    {
                        oznacen_pregled = pacijentovi_pregledi[i];
                    }
                }
                
                Izmena_pregleda ip = new Izmena_pregleda(lvDataBinding.SelectedIndex + 1);
               
                DateTime now = DateTime.Now;
                string[] pom = now.ToString().Split(' ');
                string[] datum = pom[0].Split('/');
                
                //DateTime datum_iz_pregleda = oznacen_pregled.date;
                string[] pomocni = oznacen_pregled.date.ToString().Split(' ');
                string[] pomocni_datum = pomocni[0].Split('/');

                if (Convert.ToInt32(datum[0]) == Convert.ToInt32(pomocni_datum[0]))
                {
                    if (Convert.ToInt32(datum[1]) + 2 < Convert.ToInt32(pomocni_datum[1]))
                    {
                        ip.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Ne mozete da izmenite pregled jer je zakazan u periodu od naredna dva dana!");
                    }
                }
                else {
                    ip.Show();
                    this.Close();
                }
            }
        }

        private void ObavestenjaButtonClicked(object sender, RoutedEventArgs e)
        {
            PatientNotificationWindow pnw = new PatientNotificationWindow();
            pnw.Show();
        }


    }
}
