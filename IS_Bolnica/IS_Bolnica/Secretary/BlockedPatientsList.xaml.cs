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
using IS_Bolnica.Services;
using Model;

namespace IS_Bolnica.Secretary
{
    public partial class BlockedPatientsList : Page
    {
        private PatientService patientService = new PatientService();
        private Patient patient = new Patient(); 
        public BlockedPatientsList()
        {
            InitializeComponent();
            BlockedPatientList.ItemsSource = patientService.GetBlockedPatients();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ActionBar ab = new ActionBar();
            this.NavigationService.Navigate(ab);
        }

        private void Unblock_Patient_clicked(object sender, RoutedEventArgs e)
        {
            int i = BlockedPatientList.SelectedIndex;
            patient = (Patient)BlockedPatientList.SelectedItem;

            if (i == -1)
            {
                MessageBox.Show("Niste izabrali pacijenta kojeg želite da odblokirate!");
                return;
            }
            else
            {
                patientService.UnblockPatient(patient);
            }
        }
    }
}
