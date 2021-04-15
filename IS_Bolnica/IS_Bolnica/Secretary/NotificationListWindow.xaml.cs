﻿using IS_Bolnica.Model;
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

namespace IS_Bolnica.Secretary
{
    public partial class NotificationListWindow : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<Notification> Notifications { get; set; }
        private NotificationsFileStorage storage = new NotificationsFileStorage();

        public NotificationListWindow()
        {
            InitializeComponent();
            this.DataContext = this;

            Notifications = new ObservableCollection<Notification>();
            //Notification not = new Notification { content = "Nestoo", title = "Vazno", notificationType = NotificationType.all };
            //Notifications.Add(not);
            Notifications = storage.LoadFromFile("NotificationsFileStorage.json");
            NotificationList.ItemsSource = Notifications;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Secretary.ActionBarWindow abw = new Secretary.ActionBarWindow();
            abw.Show();
            this.Close();
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void addNotification(object sender, RoutedEventArgs e)
        {
            Secretary.AddNotificationWindow anw = new Secretary.AddNotificationWindow();
            anw.Show();
            this.Close();
        }

        private void editNotification(object sender, RoutedEventArgs e)
        {
            Notification notification = new Notification();
            notification = (Notification)NotificationList.SelectedItem;
            Notifications = storage.LoadFromFile("NotificationsFileStorage.json");

            Secretary.EditNotificationWindow enw = new Secretary.EditNotificationWindow(notification);
            enw.title.Text = notification.title;
            enw.content.Text = notification.content;
            if (notification.notificationType == NotificationType.doctor)
            {
                enw.comboBox.SelectedIndex = 0;
            }
            else if (notification.notificationType == NotificationType.patient)
            {
                enw.comboBox.SelectedIndex = 1;
            }
            else
            {
                enw.comboBox.SelectedIndex = 2;
            }

            enw.Show();
            this.Close();


        }

        private void deleteNotification(object sender, RoutedEventArgs e)
        {
            Notification notification = new Notification();
            notification = (Notification)NotificationList.SelectedItem;

            int i = -1;
            i = NotificationList.SelectedIndex;

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
                        Notifications = storage.LoadFromFile("NotificationsFileStorage.json");
                        for (int k = 0; k < Notifications.Count; k++)
                        {
                            if (notification.content.Equals(Notifications[k].content)
                                && notification.title.Equals(Notifications[k].title))
                            {
                                Notifications.RemoveAt(k);
                            }
                        }
                        storage.SaveToFile(Notifications, "NotificationsFileStorage.json");
                        this.Close();

                        break;
                    case MessageBoxResult.No:
                        this.Close();
                        break;
                }
            }




        }



    }
}
