using IS_Bolnica.Services;
using Model;
using System;
using System.Windows;
using System.Windows.Controls;

namespace IS_Bolnica.Secretary
{
    public partial class NotificationList : Page
    {
        private Page prevoiusPage;
        private Notification notification = new Notification();
        private NotificationService notificationService = new NotificationService();

        public NotificationList(Page prevoiusPage)
        {
            InitializeComponent();
            this.DataContext = this;
            this.prevoiusPage = prevoiusPage;

            NotificationListGrid.ItemsSource = notificationService.getNotifications();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(prevoiusPage);
        }

        private void addNotification(object sender, RoutedEventArgs e)
        {
            AddNotification an = new AddNotification(this);
            this.NavigationService.Navigate(an);
        }

        private void editNotification(object sender, RoutedEventArgs e)
        {
            notification = (Notification)NotificationListGrid.SelectedItem;
            EditNotification en = new EditNotification(notification, this);
            setElementsEN(en, notification);
            this.NavigationService.Navigate(en);

        }

        private void setElementsEN(EditNotification enw, Notification notification)
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
            notification = (Notification)NotificationListGrid.SelectedItem;

            int i = NotificationListGrid.SelectedIndex;

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
                        NotificationList nl = new NotificationList(this);
                        this.NavigationService.Navigate(nl);


                        break;
                    case MessageBoxResult.No:
                        break;
                }
            }
        }
    }
}
