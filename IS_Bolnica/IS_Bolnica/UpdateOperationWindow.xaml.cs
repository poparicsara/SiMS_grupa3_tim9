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

namespace IS_Bolnica.DoctorsWindows
{
    public partial class UpdateOperationWindow : Window
    {
        private Appointment operation;
        public List<int> Hours { get; set; } = new List<int>();
        private RoomService roomService = new RoomService();
        private AppointmentService appointmentService = new AppointmentService();
        private DoctorService doctorService = new DoctorService();
        private PatientService patientService = new PatientService();
        public UpdateOperationWindow(int selectedIndex, List<Appointment> loggedDoctorOperations)

        {
            InitializeComponent();

            List<Appointment> operations = loggedDoctorOperations;

            this.operation = operations.ElementAt(selectedIndex);

            datePicker.SelectedDate = operation.StartTime;
            hourBox.SelectedItem = operation.StartTime.Hour;
            minuteBox.SelectedItem = operation.StartTime.Minute;
            patientTxt.Text = operation.Patient.Name + ' ' + operation.Patient.Surname;
            jmbgTxt.Text = operation.Patient.Id;
            healthCardNumberTxt.Text = operation.Patient.HealthCardNumber;
            doctorsComboBox.SelectedItem = operation.Doctor.Name + ' ' + operation.Doctor.Surname;

            roomsComboBox.ItemsSource = roomService.getOperationRoomsId();
            roomsComboBox.SelectedItem = operation.RoomRecord.Id;

            for (int i = 7; i < 20; i++)
            {
                Hours.Add(i);
            }

            hourBox.ItemsSource = Hours;

            List<int> Minutes = new List<int>();
            Minutes.Add(00);
            Minutes.Add(30);
            minuteBox.ItemsSource = Minutes;

            doctorsComboBox.ItemsSource = doctorService.getSpecialistsNameSurname();
        }

        private void saveButtonClicked(object sender, RoutedEventArgs e)
        {
            appointmentService.DeleteAppointment(operation);

            operation.Doctor = doctorService.findDoctorByName(doctorsComboBox.SelectedItem.ToString());
            operation.Patient = patientService.findPatientById(jmbgTxt.Text);
            DateTime date = new DateTime();
            date = (DateTime) datePicker.SelectedDate;
            int hour = Convert.ToInt32(hourBox.Text);
            int minute = Convert.ToInt32(minuteBox.Text);
            operation.StartTime = new DateTime(date.Year, date.Month, date.Day, hour, minute, 0);
            operation.RoomRecord = new RoomRecord();

            foreach (RoomRecord room in roomService.GetRooms())
            {
                if (room.Id == Convert.ToInt32(roomsComboBox.SelectedItem))
                {
                    operation.RoomRecord = room;
                }
            }

            appointmentService.scheduleAppointment(operation);

            DoctorWindow doctorWindow = new DoctorWindow();
            doctorWindow.tabs.SelectedItem = doctorWindow.operationsTab;
            doctorWindow.dataGridOperations.Items.Refresh();
            doctorWindow.Show();
            this.Close();
        }

        private void cancelButtonClicked(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBox = MessageBox.Show("Are you sure you want to discard your changes?",
                                                "Update operation", MessageBoxButton.YesNo);

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
    }
}