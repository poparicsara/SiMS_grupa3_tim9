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
        public int akcije { get; set; }
        public int ocenePacijentove { get; set; }
        public PatientWindow(String username, Boolean pocetak)
        {
            InitializeComponent();
            
            ExaminationsRecordFileStorage exStorage = new ExaminationsRecordFileStorage();
            List<Examination> pregledi = exStorage.loadFromFile("Pregledi.json");
            ObservableCollection<Examination> pacijentovi_pregledi = new ObservableCollection<Examination>();
            username_patient = username;

            foreach (Examination ex in pregledi) {
                if (ex.Patient.Username.Equals(username)) {
                    DateTime now = DateTime.Now;
                    string[] pom = now.ToString().Split(' ');
                    string[] datum = pom[0].Split('/');

                    string[] pomocni = ex.Date.ToString().Split(' ');
                    string[] pomocni_datum = pomocni[0].Split('/');

                    if (Convert.ToInt32(datum[0]) > Convert.ToInt32(pomocni_datum[0])) {
                        ex.Patient.brojOcenjenihPregleda++;
                        ocenePacijentove = ex.Patient.brojOcenjenihPregleda;
                        pregledi.Remove(ex);
                        OcenjivanjePregleda op = new OcenjivanjePregleda(ex);
                        op.Show();
                        if(ex.Patient.brojOcenjenihPregleda % 7 == 0)
                        {
                            OcenjivanjeBolnice ob = new OcenjivanjeBolnice();
                            ob.Show();
                        }
                        break;
                    } else if (Convert.ToInt32(datum[0]) == Convert.ToInt32(pomocni_datum[0]) && Convert.ToInt32(datum[1]) > Convert.ToInt32(pomocni_datum[1])) {
                        ex.Patient.brojOcenjenihPregleda++;
                        ocenePacijentove = ex.Patient.brojOcenjenihPregleda;
                        pregledi.Remove(ex);
                        OcenjivanjePregleda op = new OcenjivanjePregleda(ex);
                        op.Show();
                        {
                            OcenjivanjeBolnice ob = new OcenjivanjeBolnice();
                            ob.Show();
                        }
                        break;
                    }   
                    pacijentovi_pregledi.Add(ex);
                }
            }

            lvDataBinding.ItemsSource = pacijentovi_pregledi;

            exStorage.saveToFile(pregledi, "Pregledi.json");

            if (pocetak)
            {
                nitZaObavestenjaOTerapiji();
                nitZaInicijalizovanjeAkcije();
            }
        }
        

        private void AddButtonClicked(object sender, RoutedEventArgs e)
        {
            if(!povecajAkcije())
            {
                Zakazivanje_pregleda zp = new Zakazivanje_pregleda(akcije, ocenePacijentove);
                zp.Show();
                this.Close();
            }
        }

        private Boolean povecajAkcije() {
            ExaminationsRecordFileStorage exStorage = new ExaminationsRecordFileStorage();
            List<Examination> pregledi = exStorage.loadFromFile("Pregledi.json");
            
            foreach (Examination ex in pregledi) {
                if (ex.Patient.Username.Equals(username_patient))
                {
                    ex.Patient.Akcije++;
                    akcije = ex.Patient.Akcije;
                }
            }

            exStorage.saveToFile(pregledi, "Pregledi.json");
            
            if (akcije >= 6)
            {
                MessageBox.Show("Najvise 6 akcija nad pregledima mozete izvrsiti prilikom logovanja!");
                return true;
            }

            return false;
        }

        private void OtkaziButtonClicked(object sender, RoutedEventArgs e) {

            if (lvDataBinding.SelectedIndex == -1)
            {
                MessageBox.Show("Oznacite pregled koji zelite da otkazete!");
            }
            else
            {
                if (!povecajAkcije())
                {
                    ExaminationsRecordFileStorage exStorage = new ExaminationsRecordFileStorage();
                    List<Examination> pregledi = exStorage.loadFromFile("Pregledi.json");
                    ObservableCollection<Examination> pacijentovi_pregledi = new ObservableCollection<Examination>();

                    foreach (Examination ex in pregledi) {
                        if (ex.Patient.Username.Equals(username_patient))
                            pacijentovi_pregledi.Add(ex);
                    }

                    Examination oznacen_pregled = new Examination();

                    for (int i = 0; i < pacijentovi_pregledi.Count; i++)
                    {
                        if (i == lvDataBinding.SelectedIndex)
                            oznacen_pregled = pacijentovi_pregledi[i];
                    }
                    
                    DateTime now = DateTime.Now;
                    string[] pom = now.AddDays(2).ToString().Split(' ');
                    string[] datum = pom[0].Split('/');
                    
                    string[] pomocni = oznacen_pregled.Date.ToString().Split(' ');
                    string[] pomocni_datum = pomocni[0].Split('/');

                    if (Convert.ToInt32(datum[0]) == Convert.ToInt32(pomocni_datum[0]))
                    {
                        if (Convert.ToInt32(datum[1]) + 2 < Convert.ToInt32(pomocni_datum[1]))
                            pregledi.Remove(oznacen_pregled);
                        else
                            MessageBox.Show("Ne mozete da otkazete pregled jer je zakazan u periodu od naredna dva dana!");
                    }
                    else
                        pregledi.Remove(oznacen_pregled);

                    exStorage.saveToFile(pregledi, "Pregledi.json");
                    refreshView();
                }
            }
        }

        private void refreshView() {
            ExaminationsRecordFileStorage exStorage = new ExaminationsRecordFileStorage();
            List<Examination> pregledi = exStorage.loadFromFile("Pregledi.json");

            ObservableCollection<Examination> novi_pregledi = new ObservableCollection<Examination>();
            foreach (Examination ex in pregledi)
            {
                if (ex.Patient.Username.Equals(username_patient))
                {
                    novi_pregledi.Add(ex);
                }
            }

            lvDataBinding.ItemsSource = novi_pregledi;
        }
        private Examination pronadjiOznaceniPregled() {
            ExaminationsRecordFileStorage exStorage = new ExaminationsRecordFileStorage();
            List<Examination> pregledi = exStorage.loadFromFile("Pregledi.json");

            ObservableCollection<Examination> pacijentovi_pregledi = new ObservableCollection<Examination>();
            Examination oznacen_pregled = new Examination();
            
            foreach (Examination ex in pregledi)
            {
                if (ex.Patient.Username.Equals(username_patient))
                    pacijentovi_pregledi.Add(ex);
            }

            for (int i = 0; i < pacijentovi_pregledi.Count; i++)
            {
                if (i == lvDataBinding.SelectedIndex)
                    oznacen_pregled = pacijentovi_pregledi[i];
            }

            return oznacen_pregled;
        }

        private void IzmeniButtonClicked(object sender, RoutedEventArgs e) {
            if (lvDataBinding.SelectedIndex == -1)
            {
                MessageBox.Show("Oznacite pregled koji zelite da izmenite!");
            }
            else
            {
                if (!povecajAkcije())
                {
                    Examination oznacen_pregled = pronadjiOznaceniPregled();
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
                    else
                    {
                        ip.Show();
                        this.Close();
                    }
                }
            }
        }

        private void ObavestenjaButtonClicked(object sender, RoutedEventArgs e)
        {
            PatientNotificationWindow pnw = new PatientNotificationWindow();
            pnw.Show();
        }

        static void nitZaObavestenjaOTerapiji()
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

                Thread.Sleep(TimeSpan.FromSeconds(300));
            }
        }

        static void nitZaInicijalizovanjeAkcije() {
            Thread refreshingThread = new Thread(new ThreadStart(inicijalizovanjeAkcija));
            refreshingThread.Start();
        }

        static void inicijalizovanjeAkcija() {
            while (true)
            {
                ExaminationsRecordFileStorage exStorage = new ExaminationsRecordFileStorage();
                List<Examination> pregledi = exStorage.loadFromFile("Pregledi.json");
                
                foreach (Examination ex in pregledi)
                    ex.Patient.Akcije = 0;

                exStorage.saveToFile(pregledi, "Pregledi.json");
                Thread.Sleep(TimeSpan.FromMinutes(10));
            }
        }

        private void OcenjivanjeButtonClicked(object sender, RoutedEventArgs e)
        {
            OcenePacijenta pacijentoveOcene = new OcenePacijenta();
            pacijentoveOcene.Show();
        }
    }
}
