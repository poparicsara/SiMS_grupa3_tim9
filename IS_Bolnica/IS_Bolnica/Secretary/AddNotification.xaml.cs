using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using IS_Bolnica.Services;
using Model;

namespace IS_Bolnica.Secretary
{
    public partial class AddNotification : Page
    {
        private Page previousPage;
        private Notification notification = new Notification();
        private List<string> userList = new List<string>();
        private NotificationService notificationService = new NotificationService();
        private UserService userService = new UserService();

        public AddNotification(Page previousPage)
        {
            InitializeComponent();
            this.previousPage = previousPage;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(previousPage);
        }

        private void Button_Add_Clicked(object sender, RoutedEventArgs e)
        {
            string userId = idBox.Text;

            if (!notificationService.IsBoxEmpty(userId) && userService.UserExists(userId) && !notificationService.ExistsInList(userList, userId))
            {
                userList.Add(userId);
                refreshListBox(userList);
            }
            else
            {
                return;
            }
        }

        private void refreshListBox(List<string> idList)
        {
            idListBox.Items.Clear();
            foreach (string id in idList)
            {
                idListBox.Items.Add(id);
            }
        }

        private void Button_Remove_Clicked(object sender, RoutedEventArgs e)
        {
            if (isSelected())
            {
                string id = (string)idListBox.SelectedItem;
                idListBox.Items.Remove(idListBox.SelectedItem);
                for (int i = 0; i < userList.Count; i++)
                {
                    if (id.Equals(userList[i]))
                    {
                        userList.RemoveAt(i);
                    }
                }
            }
            else
            {
                MessageBox.Show("Niste označili id koji želite da uklonite!");
                return;
            }
        }

        private bool isSelected()
        {
            int i = idListBox.SelectedIndex;
            if (i == -1)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void cancelNotification(object sender, RoutedEventArgs e)
        {

        }

        private void addNotification(object sender, RoutedEventArgs e)
        {
            notification.Title = title.Text;
            notification.Content = content.Text;
            if (comboBox.SelectedIndex == 0)
            {
                notification.notificationType = NotificationType.doctor;
            }
            else if (comboBox.SelectedIndex == 1)
            {
                notification.notificationType = NotificationType.patient;
            }
            else if (comboBox.SelectedIndex == 2)
            {
                notification.notificationType = NotificationType.all;
            }
            else
            {
                notification.PersonId = idListBox.Items.Cast<String>().ToList();
                notification.notificationType = NotificationType.specific;

            }

            notification.Sender = UserType.patient;

            notificationService.AddNotification(notification);

            NotificationList nl = new NotificationList(this);
            this.NavigationService.Navigate(nl);
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
            else if (comboBox.SelectedIndex == -1)
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
