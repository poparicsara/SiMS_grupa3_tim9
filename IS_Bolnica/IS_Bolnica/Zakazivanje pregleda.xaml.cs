using IS_Bolnica.Model;
using IS_Bolnica.Services;
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
        private DoctorService doctorService = new DoctorService();
        private FindAttributesService findAttributesService = new FindAttributesService();
        private AppointmentService appointmentService = new AppointmentService();
        public List<String> doctors { get; set; }
        public Zakazivanje_pregleda(int brojAkcija, int brojOcenjivanja)
        {
            doctors = doctorService.GetDoctorNamesList();

            DataContext = this;

            InitializeComponent();
        }

        private void ButtonOdustaniClicked(object sender, RoutedEventArgs e)
        {
            PatientWindow pw = new PatientWindow(PatientWindow.username_patient, false);
            pw.Show();
            this.Close();
        }

        private void ButtonZakaziClicked(object sender, RoutedEventArgs e)
        {
            if (!appointmentService.processActions())
            {
                String nameAndSurname = DoctorCombo.Text;
                Doctor doctor = findAttributesService.findDoctor(Regex.Replace(nameAndSurname.Split()[0], @"[^0-9a-zA-Z\ ]+", ""),
                    Regex.Replace(nameAndSurname.Split()[1], @"[^0-9a-zA-Z\ ]+", ""));
                DateTime dateOfAppointment = findAttributesService.returnSelectedDate((DateTime)Datum.SelectedDate, hourBox.Text, minutesBox.Text);

                if (!appointmentService.isSelectedDateFree(dateOfAppointment, doctor))
                {
                    Random rnd = new Random();
                    int duration = rnd.Next(23, 29);
                    Patient patient = findAttributesService.findPatientByUsername(PatientWindow.username_patient);
                    Room room = findAttributesService.findRoomByDoctor(doctor);
                    Appointment appointment = new Appointment { DurationInMins = duration, Doctor = doctor, StartTime = dateOfAppointment, EndTime = dateOfAppointment.AddMinutes(30), Patient = patient, Room = room };
                    appointmentService.AddAppointment(appointment);
                }

                PatientWindow pw = new PatientWindow(PatientWindow.username_patient, false);
                pw.Show();
                this.Close();
            }
        }

        private void ButtonPredloziClicked(object sender, RoutedEventArgs e)
        {

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