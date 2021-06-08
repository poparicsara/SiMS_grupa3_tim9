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
    /// Interaction logic for CalendarForAppointments.xaml
    /// </summary>
    public partial class CalendarForAppointments : Page
    {
        private AppointmentService appointmentService = new AppointmentService();
        public CalendarForAppointments()
        {
            InitializeComponent();

            Scheduler.ItemsSource = appointmentService.FindPatientAppointments(PatientWindow.loggedPatient);
        }

        private void BackButtonClicked(object sender, RoutedEventArgs e)
        {
            PatientWindow.MyFrame.NavigationService.Navigate(new MyAppointments());
        }

        private void ReportButtonClicked(object sender, RoutedEventArgs e)
        {
            PatientWindow.MyFrame.NavigationService.Navigate(new ChoosePeriodForReportPage());
        }
    }
}
