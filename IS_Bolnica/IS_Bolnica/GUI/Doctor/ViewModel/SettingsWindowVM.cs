using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using IS_Bolnica.DoctorUI;
using IS_Bolnica.GUI.Doctor.View;
using IS_Bolnica.GUI.Patient.Command;
using IS_Bolnica.Model;
using IS_Bolnica.Services;
using Model;

namespace IS_Bolnica.GUI.Doctor.ViewModel
{
    class SettingsWindowVM
    {
        private global::Model.Doctor doctor = new global::Model.Doctor();
        private DoctorService doctorService = new DoctorService();
        private UserService userService = new UserService();
        public string NameTxt { get; set; }
        public string UsernameTxt { get; set; }
        public string SurnameTxt { get; set; }
        public string MailTxt { get; set; }
        public string IdTxt { get; set; }
        public string PhoneTxt { get; set; }
        public string SpecTxt { get; set; }
        public SettingsWindowVM(User user)
        {
            SetCommand();
            NameTxt = user.Name;
            UsernameTxt = user.Username;
            SurnameTxt = user.Surname;
            MailTxt = user.Email;
            IdTxt = user.Id;
            PhoneTxt = user.Phone;
            SpecTxt = doctorService.GetSpecialization(user);
        }

        public RelayCommand FeedbackCommand { get; private set; }
        public RelayCommand ExaminationCommand { get; private set; }
        public RelayCommand OperationCommand { get; private set; }
        public RelayCommand NotificationCommand { get; private set; }
        public RelayCommand MedicationCommand { get; private set; }
        public RelayCommand ChartCommand { get; private set; }
        public RelayCommand LogoutCommand { get; private set; }

        public void FeebackExecute(object parameter)
        {
            FeedbackWindow fw = new FeedbackWindow();
            fw.Show();
        }

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
            MedicamentWindow mw = new MedicamentWindow();
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
                    //this.Close();
                    break;
                case MessageBoxResult.No:
                    break;
            }
        }

        private void SetCommand()
        {
            FeedbackCommand = new RelayCommand(FeebackExecute);
            ExaminationCommand = new RelayCommand(ExaminationExecute);
            OperationCommand = new RelayCommand(OperationExecute);
            NotificationCommand = new RelayCommand(NotificationExecute);
            MedicationCommand = new RelayCommand(MedicamentExecute);
            ChartCommand = new RelayCommand(ChartExecute);
            LogoutCommand = new RelayCommand(LogoutExecute);
        }
    }
}
