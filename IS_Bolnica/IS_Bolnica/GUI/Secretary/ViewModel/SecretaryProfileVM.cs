using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IS_Bolnica.GUI.Patient.Command;
using IS_Bolnica.Secretary;
using IS_Bolnica.Services;
using Model;

namespace IS_Bolnica.GUI.Secretary.ViewModel
{
    class SecretaryProfileVM
    {
        private UserService userService = new UserService();
        private User user;
        private SekretarWindow window;
        public string NameLabel { get; set; }
        public string SurnameLabel { get; set; }
        public string UsernameLabel { get; set; }
        public string DateLabel { get; set; }
        public string JMBGLabel { get; set; }
        public string EmailLabel { get; set; }
        public string PhoneLabel { get; set; }
        public string AddressLabel { get; set; }
        public string CityLabel { get; set; }
        public string CountryLabel { get; set; }

        public SecretaryProfileVM(string username, SekretarWindow window)
        {
            SetCommands();
            this.window = window;
            if (username == "")
            {
                set();
                return;
                
            }
            user = userService.FindUserByUsername(username);
            NameLabel = user.Name;
            SurnameLabel = user.Surname;
            UsernameLabel = username;
            DateLabel = user.DateOfBirth.Day + "." + user.DateOfBirth.Month + "." +
                        user.DateOfBirth.Year;
            JMBGLabel = user.Id;
            EmailLabel = user.Email;
            PhoneLabel = user.Phone;
            AddressLabel = user.Address.Street + " "
                                                  + Convert.ToString(user.Address.NumberOfBuilding) + "/"
                                                  + Convert.ToString(user.Address.Floor) + "/"
                                                  + Convert.ToString(user.Address.Apartment);
            CityLabel = user.Address.City.name + " "
                                                  + Convert.ToString(user.Address.City.postalCode);
            CountryLabel = user.Address.City.Country.name;
            
        }

        private void set()
        {
            NameLabel = "";
            SurnameLabel = "";
            UsernameLabel = "";
            DateLabel = "";
            JMBGLabel = "";
            EmailLabel = "";
            PhoneLabel = "";
            AddressLabel = "";
            CityLabel = "";
            CountryLabel = "";
        }

        public RelayCommand ActionBarCommand { get; private set; }
        public RelayCommand LogOutCommand { get; private set; }

        private void ActionBarExecute(object parameter)
        {
            SekretarWindow.MyFrame.NavigationService.Navigate(new ActionBar());
        }

        private void LogOutExecute(object parameter)
        {
            window.Close();
        }

        private void SetCommands()
        {
            ActionBarCommand = new RelayCommand(ActionBarExecute);
            LogOutCommand = new RelayCommand(LogOutExecute);
        }
    }
}
