using IS_Bolnica.Model;
using Model;
using System;
using System.Collections.Generic;
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
using IS_Bolnica.GUI.Director.ViewModel;

namespace IS_Bolnica
{

    public partial class SelectedNotificationWindow : Window
    {
        private Notification selectedNotification = new Notification();
        private List<Notification> notifications = new List<Notification>();
        private NotificationRepository storage = new NotificationRepository();
        public SelectedNotificationWindow(Notification notification)
        {
            SelectedNotificationViewModel viewModel = new SelectedNotificationViewModel(notification);
            InitializeComponent();
            this.DataContext = viewModel;

        }

    }
}
