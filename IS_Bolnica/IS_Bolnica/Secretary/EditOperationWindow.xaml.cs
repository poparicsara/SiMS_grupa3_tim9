using IS_Bolnica.Model;
using Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using IS_Bolnica.Services;

namespace IS_Bolnica.Secretary
{
    public partial class EditOperationWindow : Window
    {
        private Appointment appointment = new Appointment();
        private Appointment oldAppointment = new Appointment();
        private RoomService roomService = new RoomService();
        private DoctorService doctorService = new DoctorService();
        private AppointmentService appointmentService = new AppointmentService();
        private FindAttributesService findAttributesService = new FindAttributesService();

        public EditOperationWindow(Appointment oldAppointment)
        {
            InitializeComponent();

            this.oldAppointment = oldAppointment;

            room.ItemsSource = roomService.GetOperationRoomNums();

            doctorBox.ItemsSource = doctorService.GetDoctorNamesList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Secretary.ActionBarWindow abw = new Secretary.ActionBarWindow();
            abw.Show();
            this.Close();
        }

        private void editOperation(object sender, RoutedEventArgs e)
        {
            string[] doctorNameAndSurname = doctorBox.Text.Split(' ');
            string name = doctorNameAndSurname[0];
            string surname = doctorNameAndSurname[1];
            appointment.Doctor = findAttributesService.findDoctor(name, surname);
            appointment.Patient = findAttributesService.findPatient(patientId.Text);
            DateTime datumStart = new DateTime();
            datumStart = (DateTime)date.SelectedDate;
            int satStart = Convert.ToInt32(hourBoxStart.Text);
            int minutStart = Convert.ToInt32(minutesBoxStart.Text);
            appointment.StartTime = new DateTime(datumStart.Year, datumStart.Month, datumStart.Day, satStart, minutStart, 0);
            appointment.DurationInMins = Convert.ToInt32(hourBoxEnd.Text) * 60 + Convert.ToInt32(minuteBoxEnd.Text);
            appointment.EndTime = appointment.StartTime.AddMinutes(appointment.DurationInMins);
            appointment.RoomRecord = findAttributesService.findRoomById(Convert.ToInt32(room.SelectedItem));
            appointment.AppointmentType = AppointmentType.operation;

            appointmentService.EditAppointment(oldAppointment, appointment);
           

            Secretary.OperationListWindow olw = new Secretary.OperationListWindow();
            olw.Show();
            this.Close();
        }

        private void cancelEditingOperation(object sender, RoutedEventArgs e)
        {
            Secretary.OperationListWindow olw = new Secretary.OperationListWindow();
            olw.Show();
            this.Close();
        }
    }
}
