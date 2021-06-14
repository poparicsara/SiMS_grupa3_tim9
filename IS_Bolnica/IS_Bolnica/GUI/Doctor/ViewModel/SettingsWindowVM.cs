using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IS_Bolnica.DoctorUI;
using IS_Bolnica.GUI.Patient.Command;
using IS_Bolnica.Model;
using IS_Bolnica.Services;
using Model;

namespace IS_Bolnica.GUI.Doctor.ViewModel
{
    class SettingsWindowVM
    {
        private global::Model.Doctor doctor = new global::Model.Doctor();
        private DoctorRepository doctorRepository = new DoctorRepository();
        public string NameTxt { get; set; }
        public string UsernameTxt { get; set; }
        public string SurnameTxt { get; set; }
        public string MailTxt { get; set; }
        public string IdTxt { get; set; }
        public string PhoneTxt { get; set; }
        public SettingsWindowVM(User user)
        {
            SetCommand();
            NameTxt = user.Name;
            UsernameTxt = user.Username;
            SurnameTxt = user.Surname;
            MailTxt = user.Email;
            IdTxt = user.Id;
            PhoneTxt = user.Phone;

        }

        public RelayCommand FeedbackCommand { get; private set; }

        public void FeebackExecute(object parameter)
        {
            FeedbackWindow fw = new FeedbackWindow();
            fw.Show();
        }

        private void SetCommand()
        {
            FeedbackCommand = new RelayCommand(FeebackExecute);
        }
    }
}
