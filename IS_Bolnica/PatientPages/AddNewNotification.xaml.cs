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
using IS_Bolnica.GUI.Patient.View;
using IS_Bolnica.Services;
using Model;

namespace IS_Bolnica.PatientPages
{
    /// <summary>
    /// Interaction logic for AddNewNotification.xaml
    /// </summary>
    public partial class AddNewNotification : Page
    {
        private NotificationService notificationService = new NotificationService();
        public AddNewNotification()
        {
            InitializeComponent();
        }

        private void ButtonAddClicked(object sender, RoutedEventArgs e)
        {
            if (notificationService.checkNotificationText(FeedbackText.Text))
            {
                Notification notification = new Notification
                {
                    Title = "Feedback od pacijenta",
                    Content = FeedbackText.Text,
                    Sender = UserType.patient,
                    notificationType = NotificationType.all
                };
                notificationService.AddNotification(notification);
                PatientWindow.MyFrame.NavigationService.Navigate(new PatientNotificationsPage());
            }
            else
            {
                PatientWindow.MyFrame.NavigationService.Navigate(new InformationPage("UPOZORENJE!", "Niste uneli tekst!"));
            }
        }

        private void DeclineButtonClicked(object sender, RoutedEventArgs e)
        {
            PatientWindow.MyFrame.NavigationService.Navigate(new PatientNotificationsPage());
        }

        private void BackButtonClicked(object sender, RoutedEventArgs e)
        {
            PatientWindow.MyFrame.NavigationService.Navigate(new PatientNotificationsPage());
        }
    }
}
