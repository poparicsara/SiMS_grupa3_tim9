using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IS_Bolnica.GUI.Patient.Command;
using IS_Bolnica.GUI.Secretary.View;
using IS_Bolnica.Model;
using IS_Bolnica.Secretary;

namespace IS_Bolnica.GUI.Secretary.ViewModel
{
    class DoctorListVM
    {
        public List<global::Model.Doctor> DoctorListGrid { get; set; }
        private DoctorRepository doctorRepository = new DoctorRepository();
        public DoctorListVM()
        {
            SetCommands();
            DoctorListGrid = doctorRepository.GetAll();
        }

        public RelayCommand BackCommand { get; private set; }
        public RelayCommand AddShiftCommand { get; private set; }
        public RelayCommand AddVacationCommand { get; private set; }

        private void BackExecute(object parameter)
        {
            SekretarWindow.MyFrame.NavigationService.Navigate(new ActionBar());
        }

        private void AddShiftExecute(object parameter)
        {
            SekretarWindow.MyFrame.NavigationService.Navigate(new EditShift(new DoctorList(new ActionBar())));
        }

        private void AddVacationExecute(object parameter)
        {
            SekretarWindow.MyFrame.NavigationService.Navigate(new AddVacation(new DoctorList(new ActionBar())));

        }

        private void SetCommands()
        {
            BackCommand = new RelayCommand(BackExecute);
            AddShiftCommand = new RelayCommand(AddShiftExecute);
            AddVacationCommand = new RelayCommand(AddVacationExecute);
        }
    }
}
