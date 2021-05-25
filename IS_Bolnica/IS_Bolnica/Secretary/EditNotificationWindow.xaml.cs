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
using IS_Bolnica.Services;

namespace IS_Bolnica.Secretary
{
    public partial class EditNotificationWindow : Window
    {
        private Notification notification = new Notification();
        private Notification oldNotification = new Notification();
        private NotificationRepository storage = new NotificationRepository();
        public List<Notification> Notifications { get; set; } = new List<Notification>();
        private List<string> userList = new List<string>();
        private UserRepository userRepository = new UserRepository();
        private UserService userService = new UserService();
        private List<User> users = new List<User>();
        private NotificationService notificationService = new NotificationService();

        public EditNotificationWindow(Notification oldNotification)
        {
            InitializeComponent();
            this.oldNotification = oldNotification;
        }

        private void cancelEditing(object sender, RoutedEventArgs e)
        {
            this.Close();

            Secretary.NotificationListWindow nlw = new Secretary.NotificationListWindow();
            nlw.Show();
        }

        private void editNotification(object sender, RoutedEventArgs e)
        {

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

        private void Button_Add_Clicked(object sender, RoutedEventArgs e)
        {
            addExistingIdsInList();
            string userId = idBox.Text;

            if (!isBoxEmpty(userId) && /*userService.UserExists(userId) &&**/ !existsInList(userList, userId))
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

        private bool existsInList(List<string> idList, string id)
        {
            foreach (string i in idList)
            {
                if (i.Equals(id))
                {
                    MessageBox.Show("Korisnik već postoji u listi!");
                    return true;
                }
            }
            return false;
        }

        private bool isBoxEmpty(string id)
        {
            if (id.Equals(""))
            {
                MessageBox.Show("Niste uneli id korisnika");
                return true;
            }
            return false;
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
    }
}
