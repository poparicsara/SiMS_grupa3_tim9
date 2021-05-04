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
<<<<<<< HEAD
        private int ordination = 0;

        public DoctorWindow(int loggedUserOrdination)
        {
            InitializeComponent();
            this.DataContext = this;

            ExaminationsRecordFileStorage examinationFileStorage = new ExaminationsRecordFileStorage();
            List<Examination> examinations = examinationFileStorage.loadFromFile("examinations.json");

            dataGridExaminations.ItemsSource = examinations;

            OperationsFileStorage operationsFileStorage = new OperationsFileStorage();
            List<Operation> operations = operationsFileStorage.loadFromFile("operations.json");

            dataGridOperations.ItemsSource = operations;

            ordination = loggedUserOrdination;

=======
        private UsersFileStorage storage = new UsersFileStorage();
        private ObservableCollection<User> loggedUsers = new ObservableCollection<User>();
        private User loggedUser;
        private List<Examination> loggedDoctorExaminations = new List<Examination>();
        private List<Operation> loggedDoctorOperations = new List<Operation>();
        private Examination examination = new Examination();
        public List<Examination> Examinations { get; set; }
        private ExaminationsRecordFileStorage examinationStorage = new ExaminationsRecordFileStorage();
        private Operation operation = new Operation();
        public List<Operation> Operations { get; set; }
        private OperationsFileStorage operationStorage = new OperationsFileStorage();
        public DoctorWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            
            List<Examination> examinations = examinationStorage.loadFromFile("examinations.json");
            loggedDoctorExaminations = new List<Examination>();
            loggedDoctorOperations = new List<Operation>();
            loggedUsers = storage.loadFromFile("loggedUsers.json");

            foreach (Examination examination in examinations)
            {
                foreach (User user in loggedUsers)
                {
                    if (examination.Doctor.Username.Equals(user.Username))
                    {
                        this.loggedUser = user;
                        loggedDoctorExaminations.Add(examination);
                    }
                }
            }

            dataGridExaminations.ItemsSource = loggedDoctorExaminations;

            List<Operation> operations = operationStorage.loadFromFile("operations.json");

            foreach (Operation operation in operations)
            {
                foreach (User user in loggedUsers)
                {
                    if (operation.doctor.Username.Equals(user.Username))
                    {
                        this.loggedUser = user;
                        loggedDoctorOperations.Add(operation);
                    }
                }
            }

            dataGridOperations.ItemsSource = loggedDoctorOperations;
>>>>>>> Lekar
        }

        private void addExaminationButton(object sender, RoutedEventArgs e)
        {
            AddExaminationWindow addExaminationWindow = new AddExaminationWindow(ordination);
            addExaminationWindow.Show();
            this.Close();

        }

        private void addOperationButton(object sender, RoutedEventArgs e)
        {
            AddOperationWindow addOperationWindow = new AddOperationWindow(ordination);
            addOperationWindow.Show();
            this.Close();
        }

        private void cancelExaminationButton(object sender, RoutedEventArgs e)
        {
            int index = dataGridExaminations.SelectedIndex;
            examination = (Examination)dataGridExaminations.SelectedItem;

            if (index == -1)
            {
                MessageBox.Show("Niste izabrali pregled koji zelite da otkazete!");
            }
            else
            {
                Examinations = examinationStorage.loadFromFile("examinations.json");
                for (int i = 0; i < Examinations.Count; i++)
                {
                    if (Examinations[i].Date.Equals(examination.Date) && 
                        Examinations[i].Patient.Id.Equals(examination.Patient.Id))
                    {
                        Examinations.RemoveAt(i);
                    }
                }

                examinationStorage.saveToFile(Examinations, "examinations.json");
            }

            DoctorWindow doctorWindow = new DoctorWindow(ordination);
            doctorWindow.Show();
            this.Close();
        }

        private void cancelOperationButton(object sender, RoutedEventArgs e)
        {
            int index = dataGridOperations.SelectedIndex;
            operation = (Operation)dataGridOperations.SelectedItem;

            if (index == -1)
            {
                MessageBox.Show("Niste izabrali operaciju koju zelite da otkazete!");
            }
            else
            {
                Operations = operationStorage.loadFromFile("operations.json");

                for (int i = 0; i < Operations.Count; i++)
                {
                    if (Operations[i].Date.Equals(operation.Date) && Operations[i].Patient.Id.Equals(operation.Patient.Id))
                    {
                        Operations.RemoveAt(i);
                    }
                }

                operationStorage.saveToFile(Operations, "operations.json");
            }

<<<<<<< HEAD
            DoctorWindow doctorWindow = new DoctorWindow(ordination);
=======
            DoctorWindow doctorWindow = new DoctorWindow();
            doctorWindow.tabs.SelectedItem = doctorWindow.operationsTab;
>>>>>>> Lekar
            doctorWindow.Show();
            this.Close();
        }

        private void updateExaminationButton(object sender, RoutedEventArgs e)
        {
            int selectedIndex = dataGridExaminations.SelectedIndex;
            UpdateExaminationWindow updateExaminationWindow = new UpdateExaminationWindow(selectedIndex, loggedDoctorExaminations);
            updateExaminationWindow.Show();
            this.Close();
        }

        private void updateOperationButton(object sender, RoutedEventArgs e)
        {
           int selectedIndex = dataGridOperations.SelectedIndex;
           UpdateOperationWindow updateOperationWindow = new UpdateOperationWindow(selectedIndex, loggedDoctorOperations);
           updateOperationWindow.Show();
           this.Close();
        }

        private void startExamination(object sender, RoutedEventArgs e)
        {
            int selectedIndex = dataGridExaminations.SelectedIndex;
            ExaminationInfo examinationInfo = new ExaminationInfo(selectedIndex, loggedDoctorExaminations);
            examinationInfo.Show();
        }

        private void notificationButton(object sender, RoutedEventArgs e)
        {
            DoctorNotificationWindow dnw = new DoctorNotificationWindow();
            dnw.Show();
        }

<<<<<<< HEAD
        private void RequestButton(object sender, RoutedEventArgs e)
        {
            RequestWindow rw = new RequestWindow();
            rw.Show();
            this.Close();
=======
        private void logOutButtonClicked(object sender, RoutedEventArgs e)
        {
            ObservableCollection<User> users = new ObservableCollection<User>();
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
>>>>>>> Lekar
        }
    }
}
