using System;
using System.Collections.Generic;
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
using IS_Bolnica.Model;
using IS_Bolnica.Services;

namespace IS_Bolnica.DoctorUI
{
    public partial class ScheduleOperationWindow : Window
    {
        private UserService userService = new UserService();
        private PatientService patientService = new PatientService();
        private DoctorService doctorService = new DoctorService();
        private AppointmentService appointmentService = new AppointmentService();
        private RoomService roomService = new RoomService();
        private List<int> hours = new List<int>();
        private Appointment operation = new Appointment();
        public ScheduleOperationWindow()
        {
            InitializeComponent();
            roomCB.ItemsSource = roomService.GetOperationRoomsId();
            SetTimePicker();
            doctorsCB.ItemsSource = doctorService.GetSpecialistsNameSurname();
        }
        private void PotvrdiButtonClick(object sender, RoutedEventArgs e)
        {
            operation.Doctor = doctorService.FindDoctorByName(doctorsCB.SelectedItem.ToString());
            operation.Patient = patientService.findPatientById(patinetIdTxt.Text);
            operation.Room = roomService.FindOrdinationById(Convert.ToInt32(roomCB.SelectedItem));
            if (isUrgentRB.IsChecked == true)
            {
                operation.IsUrgent = true;
            }
            else
            {
                operation.IsUrgent = false;
            }
            DateTime date = (DateTime)operationDate.SelectedDate;
            int hour = Convert.ToInt32(hoursCB.Text);
            int minute = Convert.ToInt32(minutesCB.Text);
            date = new DateTime(date.Year, date.Month, date.Day, hour, minute, 0);
            operation.AppointmentType = AppointmentType.operation;

            if (isUrgentRB.IsChecked == true)
            {
                foreach (Appointment a in appointmentService.GetAppointments())
                {
                    if (date == a.StartTime && a.AppointmentType == AppointmentType.operation)
                    {
                        a.StartTime = a.StartTime.AddDays(1);
                        break;
                    }
                }

                operation.StartTime = date;
            }
            else
            {
                operation.StartTime = date;
            }

            appointmentService.ScheduleAppointment(operation);

            OperationsWindow operationsWindow = new OperationsWindow();
            operationsWindow.Show();
            this.Close();
        }
        private void ExaminationButtonClick(object sender, RoutedEventArgs e)
        {
            DoctorStartWindow doctorStartWindow = new DoctorStartWindow();
            doctorStartWindow.Show();
            this.Close();
        }

        private void OperationButtonClick(object sender, RoutedEventArgs e)
        {
            OperationsWindow operationsWindow = new OperationsWindow();
            operationsWindow.Show();
            this.Close();
        }

        private void NotificationsButtonClick(object sender, RoutedEventArgs e)
        {
            NotificationsWindow notificationsWindow = new NotificationsWindow();
            notificationsWindow.Show();
            this.Close();
        }

        private void StatisticsButtonClick(object sender, RoutedEventArgs e)
        {
            ChartWindow chartWindow = new ChartWindow();
            chartWindow.Show();
            this.Close();
        }

        private void SingOutButtonClick(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBox = MessageBox.Show("Da li ste sigurni da želite da se odjavite?",
                "Odjavljivanje", MessageBoxButton.YesNo);

            switch (messageBox)
            {
                case MessageBoxResult.Yes:
                    userService.LogOut();
                    this.Close();
                    break;
                case MessageBoxResult.No:
                    break;
            }
        }

        private void SettingsButtonClick(object sender, RoutedEventArgs e)
        {

        }
        private void SetTimePicker()
        {
            for (int i = 7; i < 20; i++)
            {
                hours.Add(i);
            }

            hoursCB.ItemsSource = hours;

            List<int> Minutes = new List<int>();
            Minutes.Add(00);
            Minutes.Add(30);
            minutesCB.ItemsSource = Minutes;
        }

        private void BackButtonClick(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBox = MessageBox.Show("Da li ste sigurni da želite da izađete?",
                "Zakazivanje operacije", MessageBoxButton.YesNo);

            switch (messageBox)
            {
                case MessageBoxResult.Yes:
                    DoctorStartWindow doctorStartWindow = new DoctorStartWindow();
                    doctorStartWindow.Show();
                    this.Close();
                    break;
                case MessageBoxResult.No:
                    break;
            }
        }

        private void IdTextFieldLostFocus(object sender, RoutedEventArgs e)
        {
            healthCardNumTxt.Text = patientService.findPatientById(patinetIdTxt.Text).HealthCardNumber;
        }

        private void MedicamentsButtonClick(object sender, RoutedEventArgs e)
        {
            MedicamentsWindow medicamentsWindow = new MedicamentsWindow();
            medicamentsWindow.Show();
            this.Close();
        }
    }
}
