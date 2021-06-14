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
using Model;

namespace IS_Bolnica.Secretary
{
    /// <summary>
    /// Interaction logic for SelectedNotification.xaml
    /// </summary>
    public partial class SelectedNotification : Page
    {
        private Page previousPage;
        private Notification notification;

        public SelectedNotification(Page previousPage)
        {
            InitializeComponent();
            this.previousPage = previousPage;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(previousPage);
        }
    }
}
