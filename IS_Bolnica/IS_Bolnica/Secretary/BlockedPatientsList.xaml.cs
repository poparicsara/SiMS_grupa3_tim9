using System.Windows;
using System.Windows.Controls;
using IS_Bolnica.Services;
using Model;

namespace IS_Bolnica.Secretary
{
    public partial class BlockedPatientsList : Page
    {
        private Page previousPage;
        private PatientService patientService = new PatientService();

        public BlockedPatientsList(Page previousPage)
        {
            InitializeComponent();
            this.previousPage = previousPage;
            BlockedPatientList.ItemsSource = patientService.GetBlockedPatients();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(previousPage);
        }

        private void Unblock_Patient_clicked(object sender, RoutedEventArgs e)
        {
            int i = BlockedPatientList.SelectedIndex;
            Patient patient = (Patient) BlockedPatientList.SelectedItem;
            if (i == -1)
            {
                MessageBox.Show("Niste izabrali pacijenta kojeg želite da odblokirate!");
                return;
            }
            else
            {
                patientService.UnblockPatient(patient);
                this.NavigationService.Navigate(new BlockedPatientsList(new ActionBar()));
            }

        }
    }
}
