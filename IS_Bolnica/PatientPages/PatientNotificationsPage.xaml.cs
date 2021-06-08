using IS_Bolnica.Model;
using IS_Bolnica.Services;
using Model;
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
    /// Interaction logic for PatientNotificationsPage.xaml
    /// </summary>
    public partial class PatientNotificationsPage : Page
    {
        public List<Notification> Notifications { get; set; }
        private Model.NotificationRepository notificationRepository = new NotificationRepository();
        private NotificationService notificationService = new NotificationService();
        public PatientNotificationsPage()
        {
            InitializeComponent();

            patientNotificationsGrid.ItemsSource = notificationService.getPatientNotifications();
        }

        private void BackButtonClicked(object sender, RoutedEventArgs e)
        {
            PatientWindow.MyFrame.NavigationService.Navigate(new MyAppointments());
        }

        private void SearchKeyUp(object sender, KeyEventArgs e)
        {
            List<Notification> patientNotifications = notificationService.getPatientNotifications();
            var filtered = patientNotifications.Where(notification => notification.Title.ToLower().Contains(SearchBox.Text.ToLower()));
            patientNotificationsGrid.ItemsSource = filtered;
        }
    }
}
