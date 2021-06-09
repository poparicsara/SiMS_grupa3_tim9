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
    /// Interaction logic for Options.xaml
    /// </summary>
    public partial class Options : Page
    {
        public Options()
        {
            InitializeComponent();
        }

        private void Black_mode_checked(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.ColorMode = "Black";
            Properties.Settings.Default.Save();
        }

        private void Light_mode_checked(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.ColorMode = "White";
            Properties.Settings.Default.Save();
        }

        private void Button_clicked(object sender, RoutedEventArgs e)
        {
            ActionBar ab = new ActionBar();
            this.NavigationService.Navigate(ab);
        }
    }
}
