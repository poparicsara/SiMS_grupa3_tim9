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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace IS_Bolnica.Secretary
{
    /// <summary>
    /// Interaction logic for NotificationList.xaml
    /// </summary>
    public partial class NotificationList : Page
    {
        public NotificationList()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ActionBar ab = new ActionBar();
            this.NavigationService.Navigate(ab);
        }

        private void addNotification(object sender, RoutedEventArgs e)
        {

        }

        private void editNotification(object sender, RoutedEventArgs e)
        {

        }

        private void deleteNotification(object sender, RoutedEventArgs e)
        {

        }
    }
}
