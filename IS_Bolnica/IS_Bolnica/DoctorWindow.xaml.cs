using IS_Bolnica.DoctorsWindows;
using IS_Bolnica.Model;
using Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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

namespace IS_Bolnica
{
    public partial class DoctorWindow : Window
    {
        private User loggedUser;
        private Appointment appointment = new Appointment();
        private AppointmentService appointmentService = new AppointmentService();
        private UserService userService = new UserService();
        public DoctorWindow()
        {
            InitializeComponent();
            this.DataContext = this;

            dataGridExaminations.ItemsSource = appointmentService.getDoctorsExaminations();
            dataGridOperations.ItemsSource = appointmentService.getDoctorsOperations();
        }

        private void addExaminationButton(object sender, RoutedEventArgs e)
        {
            AddExaminationWindow addExaminationWindow = new AddExaminationWindow();
            addExaminationWindow.Show();
            this.Close();

        }

        private void addOperationButton(object sender, RoutedEventArgs e)
        {
            AddOperationWindow addOperationWindow = new AddOperationWindow();
            addOperationWindow.Show();
            this.Close();
        }

        private void cancelExaminationButton(object sender, RoutedEventArgs e)
        {
            int index = dataGridExaminations.SelectedIndex;
            appointment = (Appointment) dataGridExaminations.SelectedItem;

            if (index == -1)
            {
                MessageBox.Show("Niste izabrali pregled koji zelite da otkazete!");
            }
            else
            {
                appointmentService.DeleteAppointment(appointment);
            }

            DoctorWindow doctorWindow = new DoctorWindow();
            doctorWindow.Show();
            this.Close();
        }

        private void cancelOperationButton(object sender, RoutedEventArgs e)
        {
            int index = dataGridOperations.SelectedIndex;
            appointment = (Appointment)dataGridOperations.SelectedItem;

            if (index == -1)
            {
                MessageBox.Show("Niste izabrali operaciju koju zelite da otkazete!");
            }
            else
            {
                appointmentService.DeleteAppointment(appointment);
            }

            DoctorWindow doctorWindow = new DoctorWindow();
            doctorWindow.tabs.SelectedItem = doctorWindow.operationsTab;
            doctorWindow.Show();
            this.Close();
        }

        private void updateExaminationButton(object sender, RoutedEventArgs e)
        {
            int selectedIndex = dataGridExaminations.SelectedIndex;
            UpdateExaminationWindow updateExaminationWindow = new UpdateExaminationWindow(selectedIndex, appointmentService.getDoctorsExaminations());
            updateExaminationWindow.Show();
            this.Close();
        }

        private void updateOperationButton(object sender, RoutedEventArgs e)
        {
            int selectedIndex = dataGridOperations.SelectedIndex;
            UpdateOperationWindow updateOperationWindow = new UpdateOperationWindow(selectedIndex, appointmentService.getDoctorsOperations());
            updateOperationWindow.Show();
            this.Close();
        }

        private void startExamination(object sender, RoutedEventArgs e)
        {
            int selectedIndex = dataGridExaminations.SelectedIndex;
            ExaminationInfo examinationInfo = new ExaminationInfo(selectedIndex, appointmentService.getDoctorsExaminations());
            examinationInfo.Show();
        }

        private void notificationButtonClicked(object sender, RoutedEventArgs e)
        {
            DoctorNotificationWindow dnw = new DoctorNotificationWindow(this.loggedUser);
            dnw.Show();
        }

        private void logOutButtonClicked(object sender, RoutedEventArgs e)
        {
            userService.logOut();
            MainWindow mainWindow = new MainWindow();
            this.Close();
            mainWindow.Show();
        }

        private void requestButtonClicked(object sender, RoutedEventArgs e)
        {
            RequestWindow rw = new RequestWindow();
            rw.Show();
        }

        private void medicationButtonClicked(object sender, RoutedEventArgs e)
        {
            ListOfMedications listOfMedications = new ListOfMedications();
            listOfMedications.Show();
        }
    }
}