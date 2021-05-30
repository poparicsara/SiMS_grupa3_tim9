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
    public partial class ScheduleExaminationWindow : Window
    {
        private AppointmentService appointmentService = new AppointmentService();
        private UserService userService = new UserService();
        private RoomService roomService = new RoomService();
        private PatientService patientService = new PatientService();
        private DoctorService doctorService = new DoctorService();
        private List<int> hours = new List<int>();
        private Appointment examination = new Appointment();
        public ScheduleExaminationWindow()
        {
            InitializeComponent();
            SetTimePicker();
            doctorsCB.ItemsSource = doctorService.GetDoctorNamesList();
        }
        private void PotvrdiButtonClick(object sender, RoutedEventArgs e)
        {
            SetDataInTextBoxes();
            appointmentService.ScheduleAppointment(examination);

            DoctorStartWindow doctorStartWindow = new DoctorStartWindow();
            doctorStartWindow.Show();
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

        }

        private void StatisticsButtonClick(object sender, RoutedEventArgs e)
        {

        }

        private void SingOutButtonClick(object sender, RoutedEventArgs e)
        {
            userService.LogOut();
            this.Close();
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
                "Zakazivanje pregleda", MessageBoxButton.YesNo);

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

        private void SetDataInTextBoxes()
        {
            examination.Patient = patientService.findPatientById(patinetIdTxt.Text);
            examination.Doctor = doctorService.FindDoctorByName(doctorsCB.SelectedItem.ToString());
            DateTime examinationDate = (DateTime) this.examinationDate.SelectedDate;
            int hour = Convert.ToInt32(hoursCB.Text);
            int minute = Convert.ToInt32(minutesCB.Text);
            examination.StartTime = new DateTime(examinationDate.Year, examinationDate.Month, examinationDate.Day, hour, minute, 0);
            examination.Room = roomService.FindOrdinationById(examination.Doctor.Ordination);
            examination.AppointmentType = AppointmentType.examination;
        }

        private void IdTextFieldLostFocus(object sender, RoutedEventArgs e)
        {
            healthCardNumTxt.Text = patientService.findPatientById(patinetIdTxt.Text).HealthCardNumber;
        }

        private void ShowDoctorsOrdination()
        {
            ordinationTxt.Text = doctorService.ShowDoctorsOrdination(doctorsCB.SelectedItem.ToString()).ToString();
        }
        
        private void DoctorsSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (doctorsCB.SelectedItem != null)
            {
                ShowDoctorsOrdination();
            }
            else if (doctorsCB.SelectedItem == null)
            {
                ordinationTxt.Text = " ";
            }
        }
    }
}
