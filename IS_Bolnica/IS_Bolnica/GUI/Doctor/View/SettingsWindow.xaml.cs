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
        public SettingsWindow(User loggedUser)
        {
            InitializeComponent();
            this.loggedUser = loggedUser;
            DataContext = new SettingsWindowVM(loggedUser);
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

    }
}
