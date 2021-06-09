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
    /// Interaction logic for ActionBar.xaml
    /// </summary>
    public partial class ActionBar : Page
    {
        public ActionBar()
        {
            InitializeComponent();
        }

        private void SpisakPacijenata_Selected(object sender, RoutedEventArgs e)
        {

        }

        private void DodajPacijenta_Selected(object sender, RoutedEventArgs e)
        {

        }

        private void SpisakGuestNaloga_Selected(object sender, RoutedEventArgs e)
        {

        }

        private void DodajGuestNalog_Selected(object sender, RoutedEventArgs e)
        {

        }

        private void SpisakObavestenja_Selected(object sender, RoutedEventArgs e)
        {

        }

        private void DodajObavestenje_Selected(object sender, RoutedEventArgs e)
        {

        }

        private void SpisakPregleda_Selected(object sender, RoutedEventArgs e)
        {

        }

        private void ZakaziPregled_Selected(object sender, RoutedEventArgs e)
        {

        }

        private void SpisakOperacija_Selected(object sender, RoutedEventArgs e)
        {

        }

        private void ZakaziOperaciju_Selected(object sender, RoutedEventArgs e)
        {

        }

        private void ZakaziHitanPregled_Selected(object sender, RoutedEventArgs e)
        {

        }

        private void ZakaziHitnuOperaciju_Selected(object sender, RoutedEventArgs e)
        {

        }

        private void Profil_Selected(object sender, RoutedEventArgs e)
        {

        }

        private void Opcije_Selected(object sender, RoutedEventArgs e)
        {
            Options o = new Options();
            this.NavigationService.Navigate(o);
        }
    }
}
