using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.TextFormatting;
using IS_Bolnica.Model;
using IS_Bolnica.Services;

namespace IS_Bolnica.Secretary
{
    public partial class EditOperation : Page
    {
        private Page prevoiusPage;
        private Appointment appointment = new Appointment();
        private Appointment oldAppointment = new Appointment();
        private RoomService roomService = new RoomService();
        private DoctorService doctorService = new DoctorService();
        private AppointmentService appointmentService = new AppointmentService();
        private FindAttributesService findAttributesService = new FindAttributesService();


        public EditOperation(Appointment oldAppointment, Page prevoiusPage)
        {
            InitializeComponent();
            this.oldAppointment = oldAppointment;
            this.prevoiusPage = prevoiusPage;
            room.ItemsSource = roomService.GetOperationRoomNums();
            doctorBox.ItemsSource = doctorService.GetDoctorNamesList();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(prevoiusPage);
        }

        private void editOperation(object sender, RoutedEventArgs e)
        {
            string[] doctorNameAndSurname = doctorBox.Text.Split(' ');
            string name = doctorNameAndSurname[0];
            string surname = doctorNameAndSurname[1];
            appointment.Doctor = findAttributesService.FindDoctor(name, surname);
            appointment.Patient = findAttributesService.FindPatient(patientId.Text);
            DateTime datumStart = new DateTime();
            datumStart = (DateTime)date.SelectedDate;
            int satStart = Convert.ToInt32(hourBoxStart.Text);
            int minutStart = Convert.ToInt32(minutesBoxStart.Text);
            appointment.StartTime = new DateTime(datumStart.Year, datumStart.Month, datumStart.Day, satStart, minutStart, 0);
            appointment.DurationInMins = Convert.ToInt32(hourBoxEnd.Text) * 60 + Convert.ToInt32(minuteBoxEnd.Text);
            appointment.EndTime = appointment.StartTime.AddMinutes(appointment.DurationInMins);
            appointment.Room = findAttributesService.FindRoomById(Convert.ToInt32(room.SelectedItem));
            appointment.AppointmentType = AppointmentType.operation;

            appointmentService.EditAppointment(oldAppointment, appointment);

            OperationList ol = new OperationList(this);
            this.NavigationService.Navigate(ol);

        }

        private void cancelEditingOperation(object sender, RoutedEventArgs e)
        {
            OperationList ol = new OperationList(this);
            this.NavigationService.Navigate(ol);
        }
    }
}
