using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using IS_Bolnica.DoctorUI;
using IS_Bolnica.GUI.Doctor.View;
using IS_Bolnica.Model;
using IS_Bolnica.Services;
using IS_Bolnica.GUI.Patient.Command;

namespace IS_Bolnica.GUI.Doctor.ViewModel
{
    class NotificationsWindowVM
    {
        private RequestRepository requestRepository = new RequestRepository();
        private UserService userService = new UserService();
        public List<Request> Requests { get; set; }

        public NotificationsWindowVM()
        {
            SetCommand();
            Requests = requestRepository.GetAll();
        }

        public RelayCommand ExaminationCommand { get; private set; }
        public RelayCommand OperationCommand { get; private set; }
        public RelayCommand NotificationCommand { get; private set; }
        public RelayCommand MedicationCommand { get; private set; }
        public RelayCommand ChartCommand { get; private set; }
        public RelayCommand LogoutCommand { get; private set; }

        public void ExaminationExecute(object parameter)
        {
            DoctorStartWindow dsw = new DoctorStartWindow();
            dsw.Show();
        }

        public void OperationExecute(object parameter)
        {
            OperationsWindow ow = new OperationsWindow();
            ow.Show();
        }

        public void NotificationExecute(object parameter)
        {
            NotificationsWindow nw = new NotificationsWindow();
            nw.Show();
        }

        public void MedicamentExecute(object parameter)
        {
            MedicamentsWindow mw = new MedicamentsWindow();
            mw.Show();
        }

        public void ChartExecute(object parameter)
        {
            ChartWindow cw = new ChartWindow();
            cw.Show();
        }

        public void LogoutExecute(object parameter)
        {
            MessageBoxResult messageBox = MessageBox.Show("Da li ste sigurni da želite da se odjavite?",
                "Odjavljivanje", MessageBoxButton.YesNo);

            switch (messageBox)
            {
                case MessageBoxResult.Yes:
                    userService.LogOut();
                    break;
                case MessageBoxResult.No:
                    break;
            }
        }

        private void SetCommand()
        {
            ExaminationCommand = new RelayCommand(ExaminationExecute);
            OperationCommand = new RelayCommand(OperationExecute);
            NotificationCommand = new RelayCommand(NotificationExecute);
            MedicationCommand = new RelayCommand(MedicamentExecute);
            ChartCommand = new RelayCommand(ChartExecute);
            LogoutCommand = new RelayCommand(LogoutExecute);
        }
    }
}
