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
    public partial class OperationsWindow : Window
    {
        private AppointmentService appointmentService = new AppointmentService();
        private UserService userService = new UserService();
        private Appointment appointment = new Appointment();
        public OperationsWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            operationsDataGrid.ItemsSource = appointmentService.GetDoctorsOperations();
        }

        private void ExaminationsButtonClick(object sender, RoutedEventArgs e)
        {
            DoctorStartWindow doctorStartWindow = new DoctorStartWindow();
            doctorStartWindow.Show();
            this.Close();
        }

        private void OperationButtonClick(object sender, RoutedEventArgs e)
        {
            this.Show();
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

        private void DeleteButtonClick(object sender, RoutedEventArgs e)
        {
            int index = operationsDataGrid.SelectedIndex;
            appointment = (Appointment)operationsDataGrid.SelectedItem;
            if (index == -1)
            {
                MessageBox.Show("Niste izabrali operaciju koji želite da otkažete!");
            }
            else
            {
                appointmentService.DeleteAppointment(appointment);
            }

            OperationsWindow operationsWindow = new OperationsWindow();
            operationsWindow.Show();
            this.Close();
        }

        private void EditButtonClick(object sender, RoutedEventArgs e)
        {
            int selectedIndex = operationsDataGrid.SelectedIndex;
            UpdateScheduledOperationWindow updateScheduledOperation = new UpdateScheduledOperationWindow(selectedIndex, appointmentService.GetDoctorsOperations());
            updateScheduledOperation.Show();
            this.Close();

        }

        private void AddButtonClick(object sender, RoutedEventArgs e)
        {
            ScheduleOperationWindow scheduleOperationWindow = new ScheduleOperationWindow();
            scheduleOperationWindow.Show();
            this.Close();
        }

        private void HospitalizedPatientsButtonClick(object sender, RoutedEventArgs e)
        {
            HospitalizedPatientsWindow hospitalizedPatientsWindow = new HospitalizedPatientsWindow();
            hospitalizedPatientsWindow.Show();
            this.Close();
        }

        private void MedicamentsButtonClick(object sender, RoutedEventArgs e)
        {
            MedicamentsWindow medicamentsWindow = new MedicamentsWindow();
            medicamentsWindow.Show();
            this.Close();
        }
    }
}
