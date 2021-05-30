using IS_Bolnica.Model;
using Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
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

namespace IS_Bolnica.DoctorsWindows
{
    public partial class AddOperationWindow : Window
    {
        public List<int> Hours { get; set; } = new List<int>();
        private DateTime dateTime;
        private Appointment appointment = new Appointment(); 
        public List<Appointment> Appointments { get; set; }
        private AppointmentService appointmentService = new AppointmentService();
        private DoctorService doctorService = new DoctorService();
        private RoomService roomService = new RoomService();
        private PatientService patientService = new PatientService();
        public AddOperationWindow()
        {
            InitializeComponent();
            roomComboBox.ItemsSource = roomService.GetOperationRoomsId();
            SetTimePicker();
            doctorsComboBox.ItemsSource = doctorService.getSpecialistsNameSurname();
        }

        private void cancelButtonClicked(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBox = MessageBox.Show("Are you sure you want to discard your changes?",
                "Scheduling", MessageBoxButton.YesNo);

            switch (messageBox)
            {
                case MessageBoxResult.Yes:
                    DoctorWindow doctorWindow = new DoctorWindow();
                    doctorWindow.Show();
                    this.Close();
                    break;
                case MessageBoxResult.No:

                    break;
            }
        }

        private void saveButtonClicked(object sender, RoutedEventArgs e)
        {
            appointment.Doctor = doctorService.findDoctorByName(doctorsComboBox.SelectedItem.ToString());
            appointment.Patient = patientService.findPatientById(jmbgTxt.Text);
            appointment.Room = new Room();
            foreach (Room room in roomService.GetRooms())
            {
                if (room.Id == Convert.ToInt32(roomComboBox.SelectedItem))
                {
                    appointment.Room = room;
                }
            }

            if (urgentRadioBtn.IsChecked == true)
            {
                appointment.IsUrgent = true;
            }
            else
            {
                appointment.IsUrgent = false;
            }

            DateTime date = new DateTime();
            date = (DateTime) datePicker.SelectedDate;
            int hour = Convert.ToInt32(hourBox.Text);
            int minute = Convert.ToInt32(minuteBox.Text);
            dateTime = new DateTime(date.Year, date.Month, date.Day, hour, minute, 0);
            appointment.AppointmentType = AppointmentType.operation;

            if (urgentRadioBtn.IsChecked == true)
            {
                foreach (Appointment a in Appointments)
                {
                    if (dateTime == a.StartTime && a.AppointmentType == AppointmentType.operation)
                    {
                        a.StartTime = a.StartTime.AddDays(1);
                        break;
                    }
                }

                appointment.StartTime = dateTime;
            }
            else
            {
                appointment.StartTime = dateTime;
            }

            appointmentService.scheduleAppointment(appointment);

            DoctorWindow doctorWindow = new DoctorWindow();
            doctorWindow.tabs.SelectedItem = doctorWindow.operationsTab;
            doctorWindow.dataGridOperations.Items.Refresh();
            doctorWindow.Show();

            this.Close();

        }

        private void jmbgTxt_LostFocus(object sender, RoutedEventArgs e)
        {
            healthCardNumberTxt.Text = patientService.findPatientById(jmbgTxt.Text).HealthCardNumber;
        }

        private void SetTimePicker()
        {
            for (int i = 7; i < 20; i++)
            {
                Hours.Add(i);
            }

            hourBox.ItemsSource = Hours;

            List<int> Minutes = new List<int>();
            Minutes.Add(00);
            Minutes.Add(30);
            minuteBox.ItemsSource = Minutes;
        }
    }
}
