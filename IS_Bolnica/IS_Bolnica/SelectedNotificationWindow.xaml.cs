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

        public SelectedNotificationWindow(Notification notification)
        {
            SelectedNotificationViewModel viewModel = new SelectedNotificationViewModel(notification);
            InitializeComponent();
            this.DataContext = viewModel;

        }

    }
}
