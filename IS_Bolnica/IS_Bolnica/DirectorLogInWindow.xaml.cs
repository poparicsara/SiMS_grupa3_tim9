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
using IS_Bolnica.DemoMode;

namespace IS_Bolnica
{
    public partial class DirectorLogInWindow : Window
    {
        public DirectorLogInWindow()
        {
            InitializeComponent();
        }

        private void LogInButtonClicked(object sender, RoutedEventArgs e)
        {
            DirectorProfileWindow dw = new DirectorProfileWindow();
            dw.Show();
        }

        private void DemoButtonClicked(object sender, RoutedEventArgs e)
        {
            DemoRoomWindow rw = new DemoRoomWindow();
            rw.Show();
        }
    }
}
