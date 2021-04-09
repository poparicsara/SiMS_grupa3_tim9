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

namespace IS_Bolnica.Secretary
{
    /// <summary>
    /// Interaction logic for ActionBarWindow.xaml
    /// </summary>
    public partial class ActionBarWindow : Window
    {
        public ActionBarWindow()
        {
            InitializeComponent();
        }

        private void SpisakPacijenata_Selected(object sender, RoutedEventArgs e)
        {
            Secretary.PatientListWindow plw = new Secretary.PatientListWindow();
            plw.Show();
            this.Close();
        }

        private void DodajPacijenta_Selected(object sender, RoutedEventArgs e)
        {
            Secretary.AddPatient ap = new Secretary.AddPatient();
            ap.Show();
            this.Close();
        }

        private void SpisakGuestNaloga_Selected(object sender, RoutedEventArgs e)
        {
            Secretary.GuestUserListWindow guw = new Secretary.GuestUserListWindow();
            guw.Show();
            this.Close();
        }

        private void DodajGuestNalog_Selected(object sender, RoutedEventArgs e)
        {
            Secretary.GuestUserAccount gua = new Secretary.GuestUserAccount();
            this.Close();
            gua.Show();
        }

        private void Profil_Selected(object sender, RoutedEventArgs e)
        {
            SekretarWindow sw = new SekretarWindow();
            sw.Show();
            this.Close();
        }
    }
}
