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
using IS_Bolnica.Services;

namespace IS_Bolnica
{
    public partial class HospitalizedPatients : Window
    {
        private HospitalizationService hospitalizationService = new HospitalizationService();
        public HospitalizedPatients()
        {
            InitializeComponent();
            hospitalizedPatientsDataGrid.ItemsSource = hospitalizationService.GetAllHospitalizedPatients();
        }

        private void ProlongTreatmentClick(object sender, RoutedEventArgs e)
        {
            int selectedIndex = hospitalizedPatientsDataGrid.SelectedIndex;
            ProlongTreatment prolongTreatment = new ProlongTreatment(selectedIndex, hospitalizationService.GetAllHospitalizedPatients());
            prolongTreatment.Show();
        }

        private void HospitalizedPatientDoubleClick(object sender, MouseButtonEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
