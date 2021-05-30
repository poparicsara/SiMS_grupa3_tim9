using IS_Bolnica.Model;
using Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
    public partial class DirectorNotificationWindow : Window
    {
        public List<Notification> notifications = new List<Notification>();
        private Model.NotificationRepository storage = new NotificationRepository();

        public DirectorNotificationWindow()
        {
            InitializeComponent();
            this.DataContext = this;

            notifications = storage.LoadFromFile();

            NotificationList.ItemsSource = GetDirectorNotifications();
        }

        private List<Notification> GetDirectorNotifications()
        {
            List<Notification> directorNotifications = new List<Notification>();
            foreach (Notification n in notifications)
            {
                if (IsDirectorNotification(n))
                {
                    directorNotifications.Add(n);
                }
            }
            return directorNotifications;
        }

        private bool IsDirectorNotification(Notification n)
        {
            return n.notificationType == NotificationType.all || n.notificationType == NotificationType.director;
        }

        private void Row_DoubleClik(object sender, MouseButtonEventArgs e)
        {
            Notification selectedNotification = (Notification)NotificationList.SelectedItem;
            SelectedNotificationWindow selected = new SelectedNotificationWindow(selectedNotification);
            selected.Show();
            this.Close();
        }
    }
}
