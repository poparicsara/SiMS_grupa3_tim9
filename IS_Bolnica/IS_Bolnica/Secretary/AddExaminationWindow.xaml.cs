using IS_Bolnica.Model;
using Model;
using System;
using System.Collections.Generic;
using System.Windows;
using IS_Bolnica.Services;

namespace IS_Bolnica.Secretary
{
    public partial class AddExaminationWindow : Window
    {
        private Appointment appointment = new Appointment();
        private List<Appointment> appointments = new List<Appointment>();
        private AppointmentRepository appointmentRepository = new AppointmentRepository();
        private DoctorService doctorService = new DoctorService();
        private AppointmentService appointmentService = new AppointmentService();
        private FindAttributesService findAttributesService = new FindAttributesService();

        public AddExaminationWindow()
        {
            InitializeComponent();

            doctorBox.ItemsSource = doctorService.GetDoctorNamesList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Secretary.ActionBarWindow abw = new Secretary.ActionBarWindow();
            abw.Show();
            this.Close();
        }

        private void cancelAddingExamination(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void addExamination(object sender, RoutedEventArgs e)
        {
            appointment.DurationInMins = 30;
            appointment.Patient = findAttributesService.findPatient(idPatientBox.Text);
            string[] doctorNameAndSurname = doctorBox.Text.Split(' ');
            string name = doctorNameAndSurname[0];
            string surname = doctorNameAndSurname[1];
            appointment.Doctor = findAttributesService.findDoctor(name, surname);
            DateTime datum = new DateTime();
            datum = (DateTime)dateBox.SelectedDate;
            int sat = Convert.ToInt32(hourBox.Text);
            int minut = Convert.ToInt32(minutesBox.Text);
            appointment.StartTime = new DateTime(datum.Year, datum.Month, datum.Day, sat, minut, 0);
            appointment.EndTime = appointment.StartTime.AddMinutes(appointment.DurationInMins);
            appointment.Room = findAttributesService.findRoomByDoctor(appointment.Doctor);
            appointment.AppointmentType = AppointmentType.examination;

            appointmentService.AddAppointment(appointment);

            Secretary.ExaminationListWindow elw = new Secretary.ExaminationListWindow();
            elw.Show();
            this.Close();
        }

    }

}
