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
    public partial class SelectedPatient : Page
    {
        private Page previousPage;
        private Patient patient;

        public SelectedPatient(Page previousPage)
        {
            InitializeComponent();
            this.previousPage = previousPage;
            this.patient = new Patient();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(previousPage);
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            EditPatientPage epp = new EditPatientPage(patient, this);
            this.NavigationService.Navigate(epp);

        }
    }
}
