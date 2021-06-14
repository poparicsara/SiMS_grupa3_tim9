using System;
using System.Windows;
using IS_Bolnica.DoctorUI;
using IS_Bolnica.GUI.Doctor.ViewModel;
using IS_Bolnica.Services;
using Model;

namespace IS_Bolnica.GUI.Doctor.View
{
    public partial class SettingsWindow : Window
    {
        private User loggedUser;
        private UserService userService = new UserService();
        private DoctorService doctorService = new DoctorService();
        public SettingsWindow(User loggedUser)
        {
            InitializeComponent();
            this.loggedUser = loggedUser;
            DataContext = new SettingsWindowVM(loggedUser);

            if (loggedUser.UserType == UserType.doctor)
            {
                foreach (global::Model.Doctor doctor in doctorService.GetAllDoctors())
                {
                    if (loggedUser.Username.Equals(doctor.Username))
                    {
                        specTxt.Text = doctor.Specialization.Name;
                    }
                }
            }
        }

        private void ExaminationsButtonClick(object sender, RoutedEventArgs e)
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
            this.Show();
        }

        private void MedicamentsButtonClick(object sender, RoutedEventArgs e)
        {
            MedicamentsWindow medicamentsWindow = new MedicamentsWindow();
            medicamentsWindow.Show();
            this.Close();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void FeedbackButtonClick(object sender, RoutedEventArgs e)
        {
            FeedbackWindow feedbackWindow = new FeedbackWindow();
            feedbackWindow.Show();
            this.Close();
        }
    }
}
