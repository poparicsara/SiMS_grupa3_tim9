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
        private List<User> users = new List<User>();
        private UsersFileStorage usersFileStorage = new UsersFileStorage();
        private List<string> userList = new List<string>();

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
            else if(comboBox.SelectedIndex == 2)
            {
                notification.notificationType = NotificationType.all;
            }
            else
            {
                notification.PersonId = idListBox.Items.Cast<String>().ToList();
                notification.notificationType = NotificationType.specific;

            }

            notification.Sender = UserType.patient;

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
            string userId = idBox.Text;
            
            if(!isBoxEmpty(userId) && isUserValid(userId) && !existsInList(userList, userId))
            {
                userList.Add(userId);
                refreshListBox(userList);
            } else
            {
                return;
            }
            
        }

        private void refreshListBox(List<string> idList)
        {
            idListBox.Items.Clear();
            foreach(string id in idList)
            {
                idListBox.Items.Add(id);
            }
        }

        private bool existsInList(List<string> idList, string id)
        {
            foreach(string i in idList)
            {
                if(i.Equals(id))
                {
                    MessageBox.Show("Korisnik već postoji u listi!");
                    return true;
                }
            }
            return false;
        }

        private bool isBoxEmpty(string id)
        {
            if(id.Equals(""))
            {
                MessageBox.Show("Niste uneli id korisnika");
                return true;
            }
            return false;
        }

        private bool isUserValid(string id)
        {
            users = usersFileStorage.loadFromFile("UsersFileStorage.json");
            foreach(User u in users)
            {
                if(u.Id.Equals(id))
                {
                    return true;
                }
            }
            MessageBox.Show("Niste uneli postojeći id");
            return false;
        }
    }
}
