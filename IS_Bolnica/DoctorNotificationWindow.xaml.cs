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

    public partial class DoctorNotificationWindow : Window, INotifyPropertyChanged
    {
        public List<Notification> Notifications { get; set; }
        private Model.NotificationRepository storage = new NotificationRepository();
        private User doctor = new User();


        public DoctorNotificationWindow(User doctor)
        {
            InitializeComponent();
            this.DataContext = this;
            this.doctor = doctor;

            Notifications = new List<Notification>();

            List<Notification> notifications = storage.LoadFromFile("NotificationsFileStorage.json");

            foreach (Notification notification in notifications)
            {
                if (notification.notificationType == NotificationType.all)
                {
                    Notifications.Add(notification);
                }

                if (notification.notificationType == NotificationType.doctor)
                {
                    Notifications.Add(notification);

                }

                if (notification.PersonId != null && notification.notificationType == NotificationType.specific)
                {
                    foreach(string id in notification.PersonId)
                    {
                        if(id.Equals(doctor.Id))
                        {
                            Notifications.Add(notification);
                        }
                    }
                }
            }

            NotificationList.ItemsSource = Notifications;

        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
