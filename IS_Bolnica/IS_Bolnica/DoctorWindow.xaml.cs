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

namespace IS_Bolnica
{
    public partial class DoctorWindow : Window
    {
        private UsersFileStorage storage = new UsersFileStorage();
        private List<User> loggedUsers = new List<User>();
        private User loggedUser;
        private List<Appointment> loggedExaminations = new List<Appointment>();
        private List<Appointment> loggedOperations = new List<Appointment>();
        private AppointmentRepository appointmentRepository = new AppointmentRepository();
        private Appointment appointment = new Appointment();
        public List<Appointment> Appointments { get; set; }

        public DoctorWindow()
        {
            InitializeComponent();
            this.DataContext = this;

            loggedUsers = storage.loadFromFile("loggedUsers.json");
            List<Appointment> appointments = appointmentRepository.LoadFromFile("Appointments.json");
            loggedExaminations = new List<Appointment>();

            foreach (Appointment appointment in appointments)
            {
                foreach (User user in loggedUsers) 
                {
                    if (appointment.Doctor.Username.Equals(user.Username) &&
                        appointment.AppointmentType == AppointmentType.examination)
                    {
                        loggedExaminations.Add(appointment);
                    }

                    this.loggedUser = user;
                }
            }

            dataGridExaminations.ItemsSource = loggedExaminations;

            loggedOperations = new List<Appointment>();

            foreach (Appointment appointment in appointments)
            {
                foreach (User user in loggedUsers)
                {
                    if (appointment.Doctor.Username.Equals(user.Username) &&
                        appointment.AppointmentType == AppointmentType.operation)
                    {
                        loggedOperations.Add(appointment);
                    }

                    this.loggedUser = user;
                }
            }

            dataGridOperations.ItemsSource = loggedOperations;
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
                Appointments = appointmentRepository.LoadFromFile("Appointments.json");
                for (int i = 0; i < Appointments.Count; i++)
                {
                    if (Appointments[i].StartTime.Equals(appointment.StartTime) && Appointments[i].Patient.Id.Equals(appointment.Patient.Id) &&
                        Appointments[i].AppointmentType == AppointmentType.examination)
                    {
                        Appointments.RemoveAt(i);
                    }
                }

                appointmentRepository.SaveToFile(Appointments, "Appointments.json");
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
                Appointments = appointmentRepository.LoadFromFile("Appointments.json");
                for (int i = 0; i < Appointments.Count; i++)
                {
                    if (Appointments[i].StartTime.Equals(appointment.StartTime) &&
                        Appointments[i].Patient.Id.Equals(appointment.Patient.Id) &&
                        Appointments[i].AppointmentType == AppointmentType.operation)
                    {
                        Appointments.RemoveAt(i);
                    }
                }

                appointmentRepository.SaveToFile(Appointments, "Appointments.json");
            }

            DoctorWindow doctorWindow = new DoctorWindow();
            doctorWindow.tabs.SelectedItem = doctorWindow.operationsTab;
            doctorWindow.Show();
            this.Close();
        }

        private void updateExaminationButton(object sender, RoutedEventArgs e)
        {
            int selectedIndex = dataGridExaminations.SelectedIndex;
            UpdateExaminationWindow updateExaminationWindow = new UpdateExaminationWindow(selectedIndex, loggedExaminations);
            updateExaminationWindow.Show();
            this.Close();
        }

        private void updateOperationButton(object sender, RoutedEventArgs e)
        {
            int selectedIndex = dataGridOperations.SelectedIndex;
            UpdateOperationWindow updateOperationWindow = new UpdateOperationWindow(selectedIndex, loggedOperations);
            updateOperationWindow.Show();
            this.Close();
        }

        private void startExamination(object sender, RoutedEventArgs e)
        {
            int selectedIndex = dataGridExaminations.SelectedIndex;
            ExaminationInfo examinationInfo = new ExaminationInfo(selectedIndex, loggedExaminations);
            examinationInfo.Show();
        }

        private void notificationButtonClicked(object sender, RoutedEventArgs e)
        {
            DoctorNotificationWindow dnw = new DoctorNotificationWindow(this.loggedUser);
            dnw.Show();
        }

        private void logOutButtonClicked(object sender, RoutedEventArgs e)
        {
            List<User> users = new List<User>();
            users = storage.loadFromFile("loggedUsers.json");

            for (int i = 0; i < users.Count; i++)
            {
                if (users[i].Username == loggedUser.Username)
                {
                    users.RemoveAt(i);
                }
            }
            storage.saveToFile(users, "loggedUsers.json");

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