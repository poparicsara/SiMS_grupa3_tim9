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
            DateBox.SelectedDate = findAttributesService.returnSelectedDateByIndex(index);
            SatiBox.Text = findAttributesService.returnSelectedHourByIndex(index);
            MinutiBox.Text = findAttributesService.returnSelectedMinutesByIndex(index);
        }

        private void BackButtonClicked(object sender, RoutedEventArgs e)
        {
            PatientWindow.MyFrame.NavigationService.Navigate(new MyAppointments());
        }

        private void IzmeniButtonClicked(object sender, RoutedEventArgs e)
        {
            if (findAttributesService.checkComboBoxes(DoktorBox.Text, SatiBox.Text, MinutiBox.Text) && findAttributesService.checkDatePicker(DateBox.Text))      
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
                PatientWindow.MyFrame.NavigationService.Navigate(new MyAppointments());
            }
            else
                PatientWindow.MyFrame.NavigationService.Navigate(new InformationPage("UPOZORENJE!", "Termin kod označenog doktora je zauzet!"));
        }

        private void OdustaniButtonClicked(object sender, RoutedEventArgs e)
        {
            PatientWindow.MyFrame.NavigationService.Navigate(new MyAppointments());
        }
    }
}
