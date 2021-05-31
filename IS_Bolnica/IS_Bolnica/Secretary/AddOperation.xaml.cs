using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using IS_Bolnica.Model;
using IS_Bolnica.Services;

namespace IS_Bolnica.Secretary
{
    public partial class AddOperation : Page
    {
        private Appointment appointment = new Appointment();
        private FindAttributesService findAttributesService = new FindAttributesService();
        private DoctorService doctorService = new DoctorService();
        private AppointmentService appointmentService = new AppointmentService();
        private PatientService patientService = new PatientService();

        public AddOperation()
        {
            InitializeComponent();
            roomBox.ItemsSource = findAttributesService.GetRoomIds();
            doctorBox.ItemsSource = doctorService.GetDoctorNamesList();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ActionBar ab = new ActionBar();
            this.NavigationService.Navigate(ab);
        }

        private void addOperation(object sender, RoutedEventArgs e)
        {
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

            OperationList ol = new OperationList();
            this.NavigationService.Navigate(ol);
        }

        private void cancelAddingOperation(object sender, RoutedEventArgs e)
        {
            OperationList ol = new OperationList();
            this.NavigationService.Navigate(ol);
        }
    }
}
