using IS_Bolnica.Model;
using IS_Bolnica.Services;
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
        Patient loggedPatient = new Patient();
        private AppointmentService appointmentService = new AppointmentService();
        private FindAttributesService findAttributesService = new FindAttributesService();
        public int akcije { get; set; }
        public int ocenePacijentove { get; set; }
        public PatientWindow(String username, Boolean pocetak)
        {
            InitializeComponent();

            loggedPatient = findAttributesService.findPatientByUsername(username);
            username_patient = username;

            lvDataBinding.ItemsSource = appointmentService.FindPatientAppointments(loggedPatient);
            
            if (pocetak)
            {
                nitZaObavestenjaOTerapiji();
            }
        }


        private void AddButtonClicked(object sender, RoutedEventArgs e)
        {
            Zakazivanje_pregleda zp = new Zakazivanje_pregleda(akcije, ocenePacijentove);
            zp.Show();
            this.Close();
        }

        private void OtkaziButtonClicked(object sender, RoutedEventArgs e)
        {
            if (!findAttributesService.checkSelectedIndex(lvDataBinding.SelectedIndex, false))
            {
                if (!appointmentService.processActions())
                {
                    Appointment selectedAppointment = appointmentService.findSelectedPatientAppointment(lvDataBinding.SelectedIndex);

                    appointmentService.DeleteAppointment(selectedAppointment);

                    if (!appointmentService.checkDateOfAppointment(selectedAppointment))
                        appointmentService.DeleteAppointment(selectedAppointment);
                    else
                        MessageBox.Show("Ne mozete da otkazete pregled jer je zakazan u periodu od naredna dva dana!");


                    lvDataBinding.ItemsSource = appointmentService.FindPatientAppointments(loggedPatient);
                }
            }
        }

        private void IzmeniButtonClicked(object sender, RoutedEventArgs e)
        {
            if (!findAttributesService.checkSelectedIndex(lvDataBinding.SelectedIndex, true))
            {
                Appointment selectedAppointment = appointmentService.findSelectedPatientAppointment(lvDataBinding.SelectedIndex);
                Izmena_pregleda ip = new Izmena_pregleda(lvDataBinding.SelectedIndex);

                if (!appointmentService.checkDateOfAppointment(selectedAppointment))
                {
                    ip.Show();
                    this.Close();
                }
                else
                    MessageBox.Show("Ne mozete da izmenite pregled jer je zakazan u periodu od naredna dva dana!");
            }
        }

        private void ObavestenjaButtonClicked(object sender, RoutedEventArgs e)
        {
            //PatientNotificationWindow pnw = new PatientNotificationWindow();
            //pnw.Show();
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
                else
                {
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

        static void nitZaInicijalizovanjeAkcije()
        {
            Thread refreshingThread = new Thread(new ThreadStart(inicijalizovanjeAkcija));
            refreshingThread.Start();
        }

        static void inicijalizovanjeAkcija()
        {
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

        private void OdjavljivanjeButtonClicked(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}