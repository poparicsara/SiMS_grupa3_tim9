using IS_Bolnica.Model;
using System;
using System.Collections.Generic;
using System.Windows;
using IS_Bolnica.Services;

namespace IS_Bolnica.Secretary
{
    public partial class AddOperationWindow : Window
    {
        private Appointment appointment = new Appointment();
        private List<Appointment> appointments = new List<Appointment>();
        private AppointmentRepository appointmentRepository = new AppointmentRepository();
        private FindAttributesService findAttributesService = new FindAttributesService();
        private DoctorService doctorService = new DoctorService();
        private AppointmentService appointmentService = new AppointmentService();
        private PatientService patientService = new PatientService();

        public AddOperationWindow()
        {
            InitializeComponent();

            roomBox.ItemsSource = findAttributesService.GetRoomIds();
            doctorBox.ItemsSource = doctorService.GetDoctorNamesList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Secretary.ActionBarWindow abw = new Secretary.ActionBarWindow();
            abw.Show();
            this.Close();
        }

        private void addOperation(object sender, RoutedEventArgs e)
        {
            appointments = appointmentRepository.LoadFromFile();

            if (patientService.PatientIdExists(idPatientBox.Text))
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
                appointment.AppointmentType = AppointmentType.operation;
                
                if (appointmentService.IsAvailable(appointment))
                {
                    appointmentService.AddAppointment(appointment);
                }
                else
                {
                    return;
                }
            } 
            else
            {
                return;
            }

            Secretary.OperationListWindow olw = new Secretary.OperationListWindow();
            olw.Show();
            this.Close();
        }

        private void cancelAddingOperation(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}
