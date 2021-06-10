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

            notifications = storage.LoadFromFile("NotificationsFileStorage.json");

            notificationDataGrid.ItemsSource = GetDirectorNotifications();

            this.PreviewKeyDown += new KeyEventHandler(HandleEsc);
        }

        private void HandleEsc(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                MessageBoxResult messageBox = MessageBox.Show("Da li ste sigurni da želite da se odjavite?",
                    "Odjava", MessageBoxButton.YesNo);
                switch (messageBox)
                {
                    case MessageBoxResult.Yes:
                        this.Close();
                        break;
                    case MessageBoxResult.No:
                        break;
                }
            }
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
            Notification selectedNotification = (Notification)notificationDataGrid.SelectedItem;
            SelectedNotificationWindow selected = new SelectedNotificationWindow(selectedNotification);
            selected.Show();
            this.Close();
        }

        private void OpenNotification(object sender, RoutedEventArgs e)
        {
            Notification selectedNotification = (Notification)notificationDataGrid.SelectedItem;
            SelectedNotificationWindow selected = new SelectedNotificationWindow(selectedNotification);
            selected.Show();
            this.Close();
        }

        private void ProfileButtonClicked(object sender, RoutedEventArgs e)
        {
            DirectorProfileWindow dw = new DirectorProfileWindow("", "");
            dw.Show();
            this.Close();
        }

        private void RoomButtonClicked(object sender, RoutedEventArgs e)
        {
            Director director = new Director();
            RoomWindow rw = new RoomWindow(director);
            rw.Show();
            this.Close();
        }

        private void InventoryButtonClicked(object sender, RoutedEventArgs e)
        {
            InventoryWindow iw = new InventoryWindow();
            iw.Show();
            this.Close();
        }

        private void MedicamentButtonClicked(object sender, RoutedEventArgs e)
        {
            MedicamentWindow mw = new MedicamentWindow();
            mw.Show();
            this.Close();
        }

        private void SignOutButtonClicked(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBox = MessageBox.Show("Da li ste sigurni da želite da se odjavite?",
                "Odjava", MessageBoxButton.YesNo);
            switch (messageBox)
            {
                case MessageBoxResult.Yes:
                    this.Close();
                    break;
                case MessageBoxResult.No:
                    break;
            }
        }

        private void ReportButtonClicked(object sender, RoutedEventArgs e)
        {
            ReportWindow rw = new ReportWindow();
            rw.Show();
            this.Close();
        }
    }
}
