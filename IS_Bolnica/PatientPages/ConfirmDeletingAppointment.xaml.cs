using IS_Bolnica.Model;
using IS_Bolnica.Services;
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
    /// Interaction logic for ConfirmDeletingAppointment.xaml
    /// </summary>
    public partial class ConfirmDeletingAppointment : Page
    {
        private AppointmentService appointmentService = new AppointmentService();
        private int selectedIndex;
        public ConfirmDeletingAppointment(int index)
        {
            InitializeComponent();
            selectedIndex = index;
        }

        private void ButtonConfirmClicked(object sender, RoutedEventArgs e)
        {
            if (!appointmentService.processActions())
            {
                Appointment selectedAppointment = appointmentService.findSelectedPatientAppointment(selectedIndex);
                appointmentService.DeleteAppointment(selectedAppointment);
                PatientWindow.MyFrame.NavigationService.Navigate(new MyAppointments());
                
            } else
                PatientWindow.MyFrame.NavigationService.Navigate(new InformationPage("UPOZORENJE!", "Najvise 6 akcija nad pregledima mozete izvrsiti prilikom logovanja!"));
        }

        private void ButtonDeclineClicked(object sender, RoutedEventArgs e)
        {
            PatientWindow.MyFrame.NavigationService.Navigate(new MyAppointments());
        }

        private void BackButtonClicked(object sender, RoutedEventArgs e)
        {
            PatientWindow.MyFrame.NavigationService.Navigate(new MyAppointments());
        }
    }
}
