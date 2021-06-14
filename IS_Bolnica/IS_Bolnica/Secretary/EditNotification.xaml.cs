using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using IS_Bolnica.Services;
using Model;

namespace IS_Bolnica.Secretary
{
    public partial class EditNotification : Page
    {
        private Page previousPage;
        private Notification notification = new Notification();
        private Notification oldNotification = new Notification();
        private List<string> userList = new List<string>();
        private UserService userService = new UserService();
        private NotificationService notificationService = new NotificationService();

        public EditNotification(Notification oldNotification, Page previousPage)
        {
            InitializeComponent();
            this.oldNotification = oldNotification;
            this.previousPage = previousPage;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(previousPage);
        }

        private void Button_Add_Clicked(object sender, RoutedEventArgs e)
        {
            addExistingIdsInList();
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

        private void addExistingIdsInList()
        {
            userList = idListBox.Items.Cast<string>().ToList();
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

        private void cancelEditing(object sender, RoutedEventArgs e)
        {
            NotificationList nl = new NotificationList(this);
            this.NavigationService.Navigate(nl);
        }

        private bool isAllFilled()
        {
            if (comboBox.SelectedIndex == -1 || title.Text == "" || content.Text == "")
            {
                MessageBox.Show("Morate popuniti sva polja!");
                return false;
            }

            return true;
        }

        private void editNotification(object sender, RoutedEventArgs e)
        {
            if (!isAllFilled()) return;

                notification.Content = content.Text;
            notification.Title = title.Text;
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
                notification.PersonId = idListBox.Items.Cast<string>().ToList();
                notification.notificationType = NotificationType.specific;

            }

            notificationService.EditNotification(oldNotification, notification);

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
            else
            {
                idBox.IsEnabled = true;

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
    }
}
