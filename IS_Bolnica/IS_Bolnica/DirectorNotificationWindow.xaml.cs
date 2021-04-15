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
    /// <summary>
    /// Interaction logic for DirectorNotificationWindow.xaml
    /// </summary>
    public partial class DirectorNotificationWindow : Window, INotifyPropertyChanged
    {
        public ObservableCollection<Notification> Notifications { get; set; }
        private Model.NotificationsFileStorage storage = new NotificationsFileStorage();

        public event PropertyChangedEventHandler PropertyChanged;

        public DirectorNotificationWindow()
        {
            InitializeComponent();
            this.DataContext = this;

            Notifications = new ObservableCollection<Notification>();
            Notifications = storage.LoadFromFile("NotificationsFileStorage.json");
            NotificationList.ItemsSource = Notifications;
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
