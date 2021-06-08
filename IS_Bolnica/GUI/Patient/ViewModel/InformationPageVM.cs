using IS_Bolnica.GUI.Patient.Command;
using IS_Bolnica.PatientPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IS_Bolnica.GUI.Patient.ViewModel
{
    class InformationPageVM
    {
        #region Properties

        public string TitleText { get; set; }
        public string InformationText { get; set; }

        #endregion

        #region Constructor

        public InformationPageVM(String title, String text)
        {
            SetCommands();
            TitleText = title;
            InformationText = text;
        }

        #endregion

        #region Commands

        public RelayCommand BackButtonCommand { get; private set; }

        #endregion

        #region CommandActions

        private void BackExecute(object parameter)
        {
            PatientWindow.MyFrame.NavigationService.Navigate(new MyAppointments());
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
