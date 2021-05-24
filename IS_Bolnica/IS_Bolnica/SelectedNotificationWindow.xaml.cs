using IS_Bolnica.Model;
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
using System.Windows.Shapes;

namespace IS_Bolnica
{

    public partial class SelectedNotificationWindow : Window
    {
        private Notification selectedNotification = new Notification();
        private List<Notification> notifications = new List<Notification>();
        private NotificationsFileStorage storage = new NotificationsFileStorage();
        public SelectedNotificationWindow(Notification notification)
        {
            InitializeComponent();

            selectedNotification = notification;
            storage = new NotificationsFileStorage();
            notifications = storage.LoadFromFile("NotificationsFileStorage.json");

            contentBox.Text = notification.Content;
        }

        private void ClosingWindow(object sender, System.ComponentModel.CancelEventArgs e)
        {
            DeleteNotification();
            DirectorNotificationWindow nw = new DirectorNotificationWindow();
            nw.Show();
        }

        private void DeleteNotification()
        {
            int index = GetNotificationIndex();
            notifications.RemoveAt(index);
            storage.SaveToFile(notifications, "NotificationsFileStorage.json");
        }

        private int GetNotificationIndex()
        {
            int index = 0;
            foreach (Notification n in notifications)
            {
                if (n.Title.Equals(selectedNotification.Title) && n.Content.Equals(selectedNotification.Content))
                {
                    break;
                }
                index++;
            }
            return index;
        }
    }
}
