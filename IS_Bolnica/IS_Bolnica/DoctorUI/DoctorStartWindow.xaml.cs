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
using IS_Bolnica.DoctorUI;
using IS_Bolnica.Model;
using IS_Bolnica.Services;

namespace IS_Bolnica
{
    public partial class DoctorStartWindow : Window
    {
        private AppointmentService appointmentService = new AppointmentService();
        private UserService userService = new UserService();
        private Appointment appointment = new Appointment();
        public DoctorStartWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            examinationsDataGrid.ItemsSource = appointmentService.GetDoctorsExaminations();
        }

        private void ExaminationButtonClick(object sender, RoutedEventArgs e)
        {
            this.Show();
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

        private void DeleteButtonClick(object sender, RoutedEventArgs e)
        {
            int index = examinationsDataGrid.SelectedIndex;
            appointment = (Appointment) examinationsDataGrid.SelectedItem;
            if (index == -1)
            {
                MessageBox.Show("Niste izabrali pregled koji želite da otkažete!");
            }
            else
            {
                appointmentService.DeleteAppointment(appointment);
            }

            DoctorStartWindow doctorStartWindow = new DoctorStartWindow();
            doctorStartWindow.Show();
            this.Close();
        }

        private void EditButtonClick(object sender, RoutedEventArgs e)
        {
            int selectedIndex = examinationsDataGrid.SelectedIndex;
            UpdateScheduledExaminationWindow updateScheduledExamination =
                new UpdateScheduledExaminationWindow(selectedIndex, appointmentService.GetDoctorsExaminations());
            updateScheduledExamination.Show();
            this.Close();
        }

        private void AddButtonClick(object sender, RoutedEventArgs e)
        {
            ScheduleExaminationWindow scheduleExaminationWindow = new ScheduleExaminationWindow();
            scheduleExaminationWindow.Show();
            this.Close();
        }

        private void ZapocniPregledButtonClick(object sender, RoutedEventArgs e)
        {
            int selectedIndex = examinationsDataGrid.SelectedIndex;
            MedicalRecordWindow medicalRecordWindow = new MedicalRecordWindow(selectedIndex, appointmentService.GetDoctorsExaminations());
            medicalRecordWindow.Show();
            this.Close();
        }
    }
}
