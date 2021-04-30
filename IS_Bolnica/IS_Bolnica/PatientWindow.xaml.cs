using IS_Bolnica.Model;
using Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
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
                if (ex.Patient.Username.Equals(username)) {
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

            nit();
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

                List<Examination> pacijentovi_pregledi = new List<Examination>();

                foreach (Examination ex in pregledi)
                {
                    if (ex.Patient.Username.Equals(username_patient))
                    {
                        pacijentovi_pregledi.Add(ex);
                    }
                }

                Examination oznacen_pregled = new Examination();

                for (int i = 0; i < pacijentovi_pregledi.Count; i++) {
                    if (i == lvDataBinding.SelectedIndex) {
                        oznacen_pregled = pacijentovi_pregledi[i];
                    }
                }
                
                DateTime now = DateTime.Now;
                string[] pom = now.AddDays(2).ToString().Split(' ');
                string[] datum = pom[0].Split('/');

                string[] pomocni = oznacen_pregled.Date.ToString().Split(' ');
                string[] pomocni_datum = pomocni[0].Split('/');

                if (Convert.ToInt32(datum[0]) == Convert.ToInt32(pomocni_datum[0]))
                {
                    if (Convert.ToInt32(datum[1]) + 2 < Convert.ToInt32(pomocni_datum[1]))
                    {
                        pregledi.Remove(oznacen_pregled);
                    }
                    else
                    {
                        MessageBox.Show("Ne mozete da otkazete pregled jer je zakazan u periodu od naredna dva dana!");
                    }
                }
                else
                {

                    pregledi.Remove(oznacen_pregled);
                }

                List<Examination> novi_pregledi = new List<Examination>();
                foreach (Examination ex in pregledi)
                {
                    if (ex.Patient.Username.Equals(username_patient))
                    {
                        novi_pregledi.Add(ex);
                    }
                }

                lvDataBinding.ItemsSource = novi_pregledi;

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
                    if (ex.Patient.Username.Equals(username_patient))
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
                
                Izmena_pregleda ip = new Izmena_pregleda(lvDataBinding.SelectedIndex);

                DateTime now = DateTime.Now;              
                string[] pom = now.AddDays(2).ToString().Split(' ');
                string[] datum = pom[0].Split('/');
                
                string[] pomocni = oznacen_pregled.Date.ToString().Split(' ');
                string[] pomocni_datum = pomocni[0].Split('/');
                
                if (Convert.ToInt32(datum[0]) == Convert.ToInt32(pomocni_datum[0]))
                {
                    if (Convert.ToInt32(datum[1]) < Convert.ToInt32(pomocni_datum[1]))
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

        static void nit()
        { 
            Thread t = new Thread(new ThreadStart(MyThreadMethod));
            t.Start();           
        }
        static void MyThreadMethod()
        {
            while (true)
            {
                
                PrescriptionFileStorage exStorage = new PrescriptionFileStorage();
                List<Prescription> recepti = exStorage.loadFromFile("prescriptions.json");

                List<Prescription> pacijentovi_recepti = new List<Prescription>();

                foreach (Prescription ter in recepti)
                {
                    if (ter.Patient.Username.Equals(username_patient))
                    {
                        pacijentovi_recepti.Add(ter);
                    }
                }

                DateTime trenutno_vreme = DateTime.Now;
                string[] pom = trenutno_vreme.ToString().Split(' ');
                string[] vreme = pom[1].Split(':');
                int sati = 0;

                if (pom[2].Equals("PM"))
                {
                    sati = Convert.ToInt32(vreme[0]) + 12;
                }
                else {
                    sati = Convert.ToInt32(vreme[0]);
                }

                foreach (Prescription recept in pacijentovi_recepti)
                {
                    if (recept.Therapy.Dose == 1)
                    {
                        if (sati == 14 && Convert.ToInt32(vreme[1]) >= 54 && Convert.ToInt32(vreme[1]) <= 59)
                        {
                            MessageBox.Show("U 15:00 treba da popijete lek: " + recept.Therapy.MedicationName, "Podsetnik");
                        }
                    }
                    else if (recept.Therapy.Dose == 2)
                    {
                        if (sati == 7 && Convert.ToInt32(vreme[1]) >= 54 && Convert.ToInt32(vreme[1]) <= 59)
                        {
                            MessageBox.Show("U 08:00 treba da popijete lek: " + recept.Therapy.MedicationName, "Podsetnik");
                        }
                        else if (sati == 14 && Convert.ToInt32(vreme[1]) >= 54 && Convert.ToInt32(vreme[1]) <= 59)
                        {
                            MessageBox.Show("U 20:00 treba da popijete lek: " + recept.Therapy.MedicationName, "Podsetnik");
                        }
                    }
                    else if (recept.Therapy.Dose == 3)
                    {
                        if (sati == 6 && Convert.ToInt32(vreme[1]) >= 54 && Convert.ToInt32(vreme[1]) <= 59)
                        {
                            MessageBox.Show("U 07:00 treba da popijete lek: " + recept.Therapy.MedicationName, "Podsetnik");
                        }
                        else if (sati == 14 && Convert.ToInt32(vreme[1]) >= 54 && Convert.ToInt32(vreme[1]) <= 59)
                        {
                            MessageBox.Show("U 15:00 treba da popijete lek: " + recept.Therapy.MedicationName, "Podsetnik");
                        }
                        else if (sati == 22 && Convert.ToInt32(vreme[1]) >= 54 && Convert.ToInt32(vreme[1]) <= 59)
                        {
                            MessageBox.Show("U 23:00 treba da popijete lek: " + recept.Therapy.MedicationName, "Podsetnik");
                        }
                    }
                    
                }

                Thread.Sleep(TimeSpan.FromSeconds(5));
            }
        }
    }
}
