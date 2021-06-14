using IS_Bolnica.Model;
using IS_Bolnica.Services;
using Model;
using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using IS_Bolnica.GUI.Patient.View;

namespace IS_Bolnica.PatientPages
{
    /// <summary>
    /// Interaction logic for AddNewAppointment.xaml
    /// </summary>
    public partial class AddNewAppointment : Page
    {
        private DoctorService doctorService = new DoctorService();
        private FindAttributesService findAttributesService = new FindAttributesService();
        private AppointmentService appointmentService = new AppointmentService();
        public List<String> doctors { get; set; }
        public static Doctor selectedDoctor = new Doctor();
        public static DateTime selectedDate = new DateTime();
        public AddNewAppointment()
        {
            doctors = doctorService.GetDoctorNamesWithSpecialization();

            DataContext = this;

            InitializeComponent();
        }

        private void BackButtonClicked(object sender, RoutedEventArgs e)
        {
            PatientWindow.MyFrame.NavigationService.Navigate(new MyAppointments());
        }

        private void AddButtonClicked(object sender, RoutedEventArgs e)
        {
            if (findAttributesService.checkComboBoxes(DoctorCombo.Text, HourBox.Text, MinutesBox.Text) && findAttributesService.checkDatePicker(AddDatePicker.Text))
            {
                if (!appointmentService.processActions())
                    AddAppointment();
                else
                    PatientWindow.MyFrame.NavigationService.Navigate(new InformationPage("UPOZORENJE!", "Najvise 6 akcija nad pregledima mozete izvrsiti prilikom logovanja!"));
            } 
            else
                PatientWindow.MyFrame.NavigationService.Navigate(new InformationPage("UPOZORENJE!", "Nisu popunjena sva neophodna polja!"));
        }

        private void AddAppointment() {
            Doctor doctor = findAttributesService.FindDoctor(Regex.Replace(DoctorCombo.Text.Split('(')[0].Split()[0], @"[^0-9a-zA-Z\ ]+", ""),
                Regex.Replace(DoctorCombo.Text.Split('(')[0].Split()[1], @"[^0-9a-zA-Z\ ]+", ""));
            DateTime dateOfAppointment = findAttributesService.returnSelectedDate((DateTime)AddDatePicker.SelectedDate, HourBox.Text, MinutesBox.Text);

            if (!appointmentService.isSelectedDateFree(dateOfAppointment, doctor))
            {
                Random rnd = new Random();
                int duration = rnd.Next(23, 29);
                Patient patient = findAttributesService.findPatientByUsername(PatientWindow.loggedPatient.Username);
                Room room = findAttributesService.findRoomByDoctor(doctor);
                Appointment appointment = new Appointment { DurationInMins = duration, Doctor = doctor, StartTime = dateOfAppointment, EndTime = dateOfAppointment.AddMinutes(30), Patient = patient, Room = room, AppointmentType = AppointmentType.examination };
                if (isAppointmentInDoctorsShift(appointment))
                {
                    appointmentService.AddAppointment(appointment);
                    PatientWindow.MyFrame.NavigationService.Navigate(new MyAppointments());
                }
                else
                    PatientWindow.MyFrame.NavigationService.Navigate(new InformationPage("UPOZORENJE!", "Termin nije u doktorovoj smeni!"));

            }
            else
                PatientWindow.MyFrame.NavigationService.Navigate(new InformationPage("UPOZORENJE!", "Termin kod označenog doktora je zauzet!"));
        }

        private bool isAppointmentInDoctorsShift(Appointment appointment)
        {
            if (appointmentService.isDoctorsShift(appointment))
                return true;

            return false;
        }

        private void DeclineButtonClicked(object sender, RoutedEventArgs e)
        { 
            PatientWindow.MyFrame.NavigationService.Navigate(new MyAppointments());
        }

        private void SuggestionButtonClicked(object sender, RoutedEventArgs e)
        {
            if (!DoctorCombo.Text.Equals("") && AddDatePicker.Text.Equals(""))
            {
                selectedDoctor = doctorService.FindDoctorByName(DoctorCombo.Text.Split('(')[0]);
                PatientWindow.MyFrame.NavigationService.Navigate(new Suggestions(new SuggestionServiceBySelectedDoctor()));
            }
            else if (!AddDatePicker.Text.Equals("") && DoctorCombo.Text.Equals(""))
            {
                selectedDate = findAttributesService.returnDateBySelectionInDatePicker(AddDatePicker.Text);
                PatientWindow.MyFrame.NavigationService.Navigate(new Suggestions(new SuggestionServiceBySelectedDate()));
            }
            else if (!AddDatePicker.Text.Equals("") && !DoctorCombo.Text.Equals(""))
            {
                selectedDoctor = doctorService.FindDoctorByName(DoctorCombo.Text.Split('(')[0]);
                selectedDate = findAttributesService.returnDateBySelectionInDatePicker(AddDatePicker.Text);
                PatientWindow.MyFrame.NavigationService.Navigate(new Suggestions(new SuggestionServiceBySelectedDateAndDoctor()));
            }
            else
                PatientWindow.MyFrame.NavigationService.Navigate(new Suggestions(new SuggestionServiceWithoutSelection()));
        }

    }
}
