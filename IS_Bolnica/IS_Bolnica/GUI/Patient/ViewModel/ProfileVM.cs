using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IS_Bolnica.GUI.Patient.Command;
using IS_Bolnica.PatientPages;

namespace IS_Bolnica.GUI.Patient.ViewModel
{
    class ProfileVM
    {
        #region Properties

        public string UserLabel { get; set; }
        public string IDLabel { get; set; }
        public string NameLabel { get; set; }
        public string SurnameLabel { get; set; }
        public string PhoneLabel { get; set; }
        public string AddressLabel { get; set; }
        public string HealthCardLabel { get; set; }

        #endregion

        #region Constructor

        public ProfileVM()
        {
            SetCommands();

            UserLabel = PatientWindow.loggedPatient.Username;
            NameLabel = PatientWindow.loggedPatient.Name;
            SurnameLabel = PatientWindow.loggedPatient.Surname;
            IDLabel = PatientWindow.loggedPatient.Id;
            PhoneLabel = PatientWindow.loggedPatient.Phone;
            AddressLabel = PatientWindow.loggedPatient.Address.Street + " " + PatientWindow.loggedPatient.Address.NumberOfBuilding + ", " + PatientWindow.loggedPatient.Address.City.name;
            HealthCardLabel = PatientWindow.loggedPatient.HealthCardNumber;
        }

        #endregion

        #region Commands

        public RelayCommand BackButtonCommand { get; private set; }

        #endregion

        #region CommandActions

        private void BackExecute(object parameter)
        {
            PatientWindow.MyFrame.NavigationService.Navigate(new StartPage());
        }

        #endregion

        #region Methods

        private void SetCommands()
        {
            BackButtonCommand = new RelayCommand(BackExecute);
        }

        #endregion
    }
}
