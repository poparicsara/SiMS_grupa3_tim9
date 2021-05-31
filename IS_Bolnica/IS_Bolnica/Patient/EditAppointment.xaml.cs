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
    /// Interaction logic for Izmena_pregleda.xaml
    /// </summary>
    public partial class EditAppointment : Window
    {
        private int selectedIndex { get; set; }
        private DoctorService doctorService = new DoctorService();
        private AppointmentService appointmentService = new AppointmentService();
        private FindAttributesService findAttributesService = new FindAttributesService();
        public List<String> doctors { get; set; }
        public EditAppointment(int index)
        {
            doctors = doctorService.GetDoctorNamesList();
            DataContext = this;
            selectedIndex = index;

            InitializeComponent();

            DoktorBox.SelectedValue = findAttributesService.returnDoctorsNameAndSurnameByIndex(index);
            DateBox.SelectedDate = findAttributesService.returnSelectedDateByIndex(index);
            SatiBox.Text = findAttributesService.returnSelectedHourByIndex(index);
            MinutiBox.Text = findAttributesService.returnSelectedMinutesByIndex(index);
            
        }

        private void OdustaniButtonClicked(object sender, RoutedEventArgs e)
        {
            PatientWindow pw = new PatientWindow(PatientWindow.username_patient, false);
            pw.Show();
            this.Close();
        }

        private void IzmeniButtonClicked(object sender, RoutedEventArgs e)
        {
            if (!appointmentService.processActions())
            {
                Appointment oldAppointment = appointmentService.findSelectedPatientAppointment(selectedIndex);

                String nameAndSurname = DoktorBox.Text;
                Doctor doctor = findAttributesService.findDoctor(Regex.Replace(nameAndSurname.Split()[0], @"[^0-9a-zA-Z\ ]+", ""),
                    Regex.Replace(nameAndSurname.Split()[1], @"[^0-9a-zA-Z\ ]+", ""));
                DateTime dateOfAppointment = findAttributesService.returnSelectedDate((DateTime)DateBox.SelectedDate, SatiBox.Text, MinutiBox.Text);

                if (!appointmentService.isSelectedDateFree(dateOfAppointment, doctor))
                {
                    Random rnd = new Random();
                    int duration = rnd.Next(23, 29);
                    Patient patient = findAttributesService.findPatientByUsername(PatientWindow.username_patient);
                    Room room = findAttributesService.findRoomByDoctor(doctor);
                    Appointment newAppointment = new Appointment { DurationInMins = duration, Doctor = doctor, StartTime = dateOfAppointment, EndTime = dateOfAppointment.AddMinutes(30), Patient = patient, Room = room };
                    appointmentService.EditAppointment(oldAppointment, newAppointment);
                }

                PatientWindow pw = new PatientWindow(PatientWindow.username_patient, false);
                pw.Show();
                this.Close();
            }
        }

        private void BackButtonClicked(object sender, RoutedEventArgs e)
        {
            PatientWindow pw = new PatientWindow(PatientWindow.username_patient, false);
            pw.Show();
            this.Close();
        }
    }
}