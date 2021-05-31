using Model;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using IS_Bolnica.Services;

namespace IS_Bolnica.Secretary
{
    public partial class NotificationListWindow : Window
    {
        private Notification notification = new Notification();
        private NotificationService notificationService = new NotificationService();

        public NotificationListWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            
            NotificationList.ItemsSource = notificationService.getNotifications();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Secretary.ActionBarWindow abw = new Secretary.ActionBarWindow();
            abw.Show();
            this.Close();
        }

        private void addNotification(object sender, RoutedEventArgs e)
        {
            Secretary.AddNotificationWindow anw = new Secretary.AddNotificationWindow();
            anw.Show();
            this.Close();
        }

        private void editNotification(object sender, RoutedEventArgs e)
        {
            notification = (Notification)NotificationList.SelectedItem;

            Secretary.EditNotificationWindow enw = new Secretary.EditNotificationWindow(notification);

            setElementsENW(enw, notification);

            enw.Show();
            this.Close();


        }

        private void setElementsENW(EditNotificationWindow enw, Notification notification)
        {
            enw.title.Text = notification.Title;
            enw.content.Text = notification.Content;
            if (notification.notificationType == NotificationType.doctor)
            {
                enw.comboBox.SelectedIndex = 0;
            }
            else if (notification.notificationType == NotificationType.patient)
            {
                enw.comboBox.SelectedIndex = 1;
            }
            else if (notification.notificationType == NotificationType.all)
            {
                enw.comboBox.SelectedIndex = 2;
            }
            else
            {
                enw.comboBox.SelectedIndex = 3;
            }

            if (notification.PersonId.Count != 0)
            {
                foreach (string id in notification.PersonId)
                {
                    enw.idListBox.Items.Add(id);
                }
            }
        }

        private void deleteNotification(object sender, RoutedEventArgs e)
        {
            notification = (Notification)NotificationList.SelectedItem;

            int i = NotificationList.SelectedIndex;

            if (i == -1)
            {
                MessageBox.Show("You didn't choose notification which you want to delete!");
            }
            else
            {
                MessageBoxResult result = MessageBox.Show("Da li stvarno želite da obrišete pacijenta?", "Brisanje pacijenta", MessageBoxButton.YesNo);
                switch (result)
                {
                    case MessageBoxResult.Yes:
                        notificationService.DeleteNotification(notification);
                        this.Close();

                        NotificationListWindow nlw = new NotificationListWindow();
                        nlw.Show();

                        break;
                    case MessageBoxResult.No:
                        this.Close();
                        break;
                }
            }

        }

    }
}
