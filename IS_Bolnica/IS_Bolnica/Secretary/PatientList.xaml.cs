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
    /// Interaction logic for PatientList.xaml
    /// </summary>
    public partial class PatientList : Page
    {
        public PatientList()
        {
            InitializeComponent();
        }

        private void addPatient(object sender, RoutedEventArgs e)
        {

        }

        private void editPatient(object sender, RoutedEventArgs e)
        {

        }

        private void deletePatient(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ActionBar ab = new ActionBar();
            this.NavigationService.Navigate(ab);
            
        }

        private void pretraziBox_KeyUp(object sender, KeyEventArgs e)
        {

        }
    }
}
