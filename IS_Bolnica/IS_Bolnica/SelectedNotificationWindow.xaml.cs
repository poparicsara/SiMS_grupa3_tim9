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
        private NotificationRepository storage = new NotificationRepository();
        public SelectedNotificationWindow(Notification notification)
        {
            InitializeComponent();

            selectedNotification = notification;
            storage = new NotificationRepository();
            notifications = storage.LoadFromFile();

            titleBox.Text = notification.Title;
            senderBox.Text = notification.Sender.ToString();
            contentBox.Text = notification.Content;

            this.PreviewKeyDown += new KeyEventHandler(HandleEsc);
        }

        private void HandleEsc(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                this.Close();
            }
        }

        private void ClosingWindow(object sender, System.ComponentModel.CancelEventArgs e)
        {
            DirectorNotificationWindow nw = new DirectorNotificationWindow();
            nw.Show();
        }
    }
}
