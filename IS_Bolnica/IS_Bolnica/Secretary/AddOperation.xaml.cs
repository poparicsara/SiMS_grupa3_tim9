using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using IS_Bolnica.Model;
using IS_Bolnica.Patterns;
using IS_Bolnica.Services;
using Model;

namespace IS_Bolnica.Secretary
{
    public partial class AddOperation : Page
    {
        private Page previousPage;
        private Appointment appointment = new Appointment();
        private FindAttributesService findAttributesService = new FindAttributesService();
        private DoctorService doctorService = new DoctorService();
        private AppointmentService appointmentService = new AppointmentService();
        private PatientService patientService = new PatientService();

        public AddOperation(Page previousPage)
        {
            InitializeComponent();
            this.previousPage = previousPage;
            roomBox.ItemsSource = findAttributesService.GetRoomIds();
            doctorBox.ItemsSource = doctorService.GetDoctorNamesList();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(previousPage);
        }

        private bool isAllFilled()
        {
            if (doctorBox.SelectedIndex == -1 || dateBox.SelectedDate == null || idPatientBox.Text == ""
                || roomBox.SelectedIndex == -1 || hourBoxStart.SelectedIndex == -1 || hourBoxEnd.SelectedIndex == -1 
                || minuteBoxStart.SelectedIndex == -1 || minuteBoxEnd.SelectedIndex == -1)
            {
                return false;
            }

            return true;

        }

        private void setAppointmentAttributes()
        {
            string[] doctorNameAndSurname = doctorBox.Text.Split(' ');
            string name = doctorNameAndSurname[0];
            string surname = doctorNameAndSurname[1];
            appointment.Doctor = findAttributesService.FindDoctor(name, surname);
            appointment.Patient = findAttributesService.FindPatient(idPatientBox.Text);
            DateTime datumStart = new DateTime();
            datumStart = (DateTime)dateBox.SelectedDate;
            int satStart = Convert.ToInt32(hourBoxStart.Text);
            int minutStart = Convert.ToInt32(minuteBoxStart.Text);
            appointment.StartTime = new DateTime(datumStart.Year, datumStart.Month, datumStart.Day, satStart, minutStart, 0);
            appointment.Room = findAttributesService.FindRoomById(Convert.ToInt32(roomBox.Text));
            int hours = Convert.ToInt32(hourBoxEnd.Text);
            int minutes = Convert.ToInt32(minuteBoxEnd.Text);
            appointment.DurationInMins = hours * 60 + minutes;
            appointment.EndTime = appointment.StartTime.AddMinutes(appointment.DurationInMins);
            appointment.GuestUser = new GuestUser();
            appointment.IsUrgent = false;
            appointment.PostponedDate = new DateTime();
        }

        private void addOperation(object sender, RoutedEventArgs e)
        {
            if (!isAllFilled()) return;

            if (!patientService.PatientIdExists(idPatientBox.Text)) return;
            
            setAppointmentAttributes();
            
            AddAppointmentTemplate template = new Patterns.AddOperation(appointment);
            template.AddAppointment();
            

            OperationList ol = new OperationList(this);
            this.NavigationService.Navigate(ol);
        }

        private void cancelAddingOperation(object sender, RoutedEventArgs e)
        {
            OperationList ol = new OperationList(this);
            this.NavigationService.Navigate(ol);
        }
    }
}
