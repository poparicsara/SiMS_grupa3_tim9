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
    /// <summary>
    /// Interaction logic for EditNotificationWindow.xaml
    /// </summary>
    public partial class EditNotificationWindow : Window
    {
        private Notification notification1 = new Notification();
        private NotificationsFileStorage storage = new NotificationsFileStorage();
        public List<Notification> Notifications { get; set; } = new List<Notification>();

        public EditNotificationWindow(Notification notification)
        {
            InitializeComponent();
            notification1 = notification;
        }

        private void cancelEditing(object sender, RoutedEventArgs e)
        {
            this.Close();

            Secretary.NotificationListWindow nlw = new Secretary.NotificationListWindow();
            nlw.Show();
        }

        private void editNotification(object sender, RoutedEventArgs e)
        {

            Notifications = storage.LoadFromFile("NotificationsFileStorage.json");
            for (int i = 0; i < Notifications.Count; i++)
            {
                if (notification1.Content.Equals(Notifications[i].Content)
                    && notification1.Title.Equals(Notifications[i].Title)
                    && notification1.notificationType.Equals(Notifications[i].notificationType))
                {
                    Notifications[i].Content = content.Text;
                    Notifications[i].Title = title.Text;
                    if (comboBox.SelectedIndex == 0)
                    {
                        Notifications[i].notificationType = NotificationType.doctor;
                    }
                    else if (comboBox.SelectedIndex == 1)
                    {
                        Notifications[i].notificationType = NotificationType.patient;
                    }
                    else if (comboBox.SelectedIndex == 2)
                    {
                        Notifications[i].notificationType = NotificationType.all;
                    }
                    else
                    {
                        Notifications[i].notificationType = NotificationType.specific;
                        foreach(string id in Notifications[i].PersonId)
                        {
                            
                        }
                        //Notifications[i].PersonId = 
                    }
                }
            }
            storage.SaveToFile(Notifications, "NotificationsFileStorage.json");
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

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comboBox.SelectedIndex == 0)
            {
                idBox.IsEnabled = false;
            }
            else if (comboBox.SelectedIndex == 1)
            {
                idBox.IsEnabled = false;
            }
            else if (comboBox.SelectedIndex == 2)
            {
                idBox.IsEnabled = false;
            }
            else
            {
                idBox.IsEnabled = true;

            }
        }
    }
}
