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
        public static Patient loggedPatient = new Patient();
        private AppointmentService appointmentService = new AppointmentService();
        private FindAttributesService findAttributesService = new FindAttributesService();
        private PrescriptionService prescriptionService = new PrescriptionService();
        private NotificationService notificationService = new NotificationService();
        public int akcije { get; set; }
        public int ocenePacijentove { get; set; }
        public PatientWindow(String username, Boolean pocetak)
        {
            InitializeComponent();

            loggedPatient = findAttributesService.findPatientByUsername(username);
            username_patient = username;

            lvDataBinding.ItemsSource = appointmentService.returnPatientAppointmentsAfterCheck();
            
            if (pocetak)
            {
                threadForNotificationsAboutTherapy();
            }
        }


        private void AddButtonClicked(object sender, RoutedEventArgs e)
        {
            AddAppointment zp = new AddAppointment(akcije, ocenePacijentove);
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
                EditAppointment ip = new EditAppointment(lvDataBinding.SelectedIndex);

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

        private void threadForNotificationsAboutTherapy()
        {
            Thread t = new Thread(new ThreadStart(methodForNotificationsAboutTherapy));
            t.Start();
        }
        private void methodForNotificationsAboutTherapy()
        {
            while (true)
            {
                List<Prescription> patientPrescriptions = prescriptionService.getPatientPrescriptions(username_patient);
                notificationService.sendNotifications(patientPrescriptions);

                Thread.Sleep(TimeSpan.FromSeconds(300));
            }
        }

        /*
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
        }*/

        private void OcenjivanjeButtonClicked(object sender, RoutedEventArgs e)
        {
            PatientEvaluations pacijentoveOcene = new PatientEvaluations();
            pacijentoveOcene.Show();
        }

        private void OdjavljivanjeButtonClicked(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void AnamnezeButtonClicked(object sender, RoutedEventArgs e)
        {
            ShowAnamneses patientAnamnesis = new ShowAnamneses();
            patientAnamnesis.Show();
        }
    }
}