using IS_Bolnica.Model;
using Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Shapes;

namespace IS_Bolnica.Secretary
{
    public partial class AddNotificationWindow : Window
    {
        private Notification notification = new Notification();
        private NotificationsFileStorage storage = new NotificationsFileStorage();
        private List<Notification> notifications = new List<Notification>();

        public AddNotificationWindow()
        {
            InitializeComponent();
        }

        private void cancelNotification(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void addNotification(object sender, RoutedEventArgs e)
        {
            notification.title = title.Text;
            notification.content = content.Text;
            if (comboBox.SelectedIndex == 0)
            {
                notification.notificationType = NotificationType.doctor;
            }
            else if (comboBox.SelectedIndex == 1)
            {
                notification.notificationType = NotificationType.patient;
            }
            else
            {
                notification.notificationType = NotificationType.all;
            }

            notifications = storage.LoadFromFile("NotificationsFileStorage.json");
            notifications.Add(notification);
            storage.SaveToFile(notifications, "NotificationsFileStorage.json");
            this.Close();
            Secretary.NotificationListWindow nlw = new Secretary.NotificationListWindow();
            nlw.Show();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Secretary.ActionBarWindow abw = new Secretary.ActionBarWindow();
            abw.Show();
            this.Close();
        }
    }
}
