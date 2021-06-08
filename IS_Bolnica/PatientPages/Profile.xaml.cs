using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace IS_Bolnica.PatientPages
{
    /// <summary>
    /// Interaction logic for Profile.xaml
    /// </summary>
    public partial class Profile : Page
    {
        public Profile()
        {
            InitializeComponent();

            UsernameLabel.Content = PatientWindow.loggedPatient.Username;
            NameLabel.Content = PatientWindow.loggedPatient.Name;
            SurnameLabel.Content = PatientWindow.loggedPatient.Surname;
            JMBGLabel.Content = PatientWindow.loggedPatient.Id;
            PhoneLabel.Content = PatientWindow.loggedPatient.Phone;
            AddressLabel.Content = PatientWindow.loggedPatient.Address.Street + " " + PatientWindow.loggedPatient.Address.NumberOfBuilding + ", " + PatientWindow.loggedPatient.Address.City.name;
            HealthCardLabel.Content = PatientWindow.loggedPatient.HealthCardNumber;
        }

        private void BackButtonClicked(object sender, RoutedEventArgs e)
        {
            PatientWindow.MyFrame.NavigationService.Navigate(new StartPage());
        }
    }
}
