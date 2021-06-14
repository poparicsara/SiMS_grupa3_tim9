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
    /// Interaction logic for EditAppointment.xaml
    /// </summary>
    public partial class EditAppointment : Page
    { 
        private int selectedIndex { get; set; }
        private DoctorService doctorService = new DoctorService();
        private AppointmentService appointmentService = new AppointmentService();
        private FindAttributesService findAttributesService = new FindAttributesService();
        public List<String> doctors { get; set; }
        public EditAppointment(int index)
        {
            doctors = doctorService.GetDoctorNamesWithSpecialization();
            DataContext = this;
            selectedIndex = index;

            InitializeComponent();

            DoktorBox.SelectedValue = findAttributesService.returnDoctorsNameAndSurnameByIndex(index);
            EditDatePicker.SelectedDate = findAttributesService.returnSelectedDateByIndex(index);
            HourBox.Text = findAttributesService.returnSelectedHourByIndex(index);
            MinutesBox.Text = findAttributesService.returnSelectedMinutesByIndex(index);
        }

        private void BackButtonClicked(object sender, RoutedEventArgs e)
        {
            PatientWindow.MyFrame.NavigationService.Navigate(new MyAppointments());
        }

        private void EditButtonClicked(object sender, RoutedEventArgs e)
        {
            if (findAttributesService.checkComboBoxes(DoktorBox.Text, HourBox.Text, MinutesBox.Text) && findAttributesService.checkDatePicker(EditDatePicker.Text))      
            {
                if (!appointmentService.processActions())
                    EditSelectedAppointment();
                else
                    PatientWindow.MyFrame.NavigationService.Navigate(new InformationPage("UPOZORENJE!", "Najvise 6 akcija nad pregledima mozete izvrsiti prilikom logovanja!"));
            }
            else
                PatientWindow.MyFrame.NavigationService.Navigate(new InformationPage("UPOZORENJE!", "Nisu popunjena sva neophodna polja!"));
        }

        private void EditSelectedAppointment() {
            Appointment oldAppointment = appointmentService.findSelectedPatientAppointment(selectedIndex);

            String nameAndSurname = DoktorBox.Text.Split('(')[0];
            Doctor doctor = findAttributesService.FindDoctor(Regex.Replace(nameAndSurname.Split()[0], @"[^0-9a-zA-Z\ ]+", ""),
                Regex.Replace(nameAndSurname.Split()[1], @"[^0-9a-zA-Z\ ]+", ""));
            DateTime dateOfAppointment = findAttributesService.returnSelectedDate((DateTime)EditDatePicker.SelectedDate, HourBox.Text, MinutesBox.Text);

            if (!appointmentService.isSelectedDateFree(dateOfAppointment, doctor))
            {
                Random rnd = new Random();
                int duration = rnd.Next(23, 29);
                Patient patient = findAttributesService.findPatientByUsername(PatientWindow.loggedPatient.Username);
                Room room = findAttributesService.findRoomByDoctor(doctor);
                Appointment newAppointment = new Appointment { DurationInMins = duration, Doctor = doctor, StartTime = dateOfAppointment, EndTime = dateOfAppointment.AddMinutes(30), Patient = patient, Room = room };
                if (isAppointmentInDoctorsShift(newAppointment))
                {
                    appointmentService.EditAppointment(oldAppointment, newAppointment);
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
    }
}
