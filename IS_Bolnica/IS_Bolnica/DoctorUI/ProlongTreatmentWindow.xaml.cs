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
using IS_Bolnica.Model;
using IS_Bolnica.Services;

namespace IS_Bolnica.DoctorUI
{
    public partial class ProlongTreatmentWindow : Window
    {
        private Hospitalization selectedHospitalization;
        private Hospitalization updatedHospitalization = new Hospitalization();
        private HospitalizationService hospitalizationService = new HospitalizationService();
        public ProlongTreatmentWindow(int selectedIndex, List<Hospitalization> hospitalizedPatients)
        {
            InitializeComponent();
            this.selectedHospitalization = hospitalizedPatients.ElementAt(selectedIndex);
            startDateDP.SelectedDate = selectedHospitalization.StartDate;
            endDateDP.SelectedDate = selectedHospitalization.EndDate;
        }

        private void PotvrdiButtonClick(object sender, RoutedEventArgs e)
        {
            updatedHospitalization.Patient = selectedHospitalization.Patient;
            updatedHospitalization.Room = selectedHospitalization.Room;
            updatedHospitalization.StartDate = selectedHospitalization.StartDate;
            DateTime endDate = (DateTime)endDateDP.SelectedDate;
            updatedHospitalization.EndDate = new DateTime(endDate.Year, endDate.Month, endDate.Day);

            int index = hospitalizationService.GetIndexOfHospitalization(selectedHospitalization);
            hospitalizationService.UpdateHospitalization(updatedHospitalization, index);

            HospitalizedPatientsWindow hospitalizedPatientsWindow = new HospitalizedPatientsWindow();
            hospitalizedPatientsWindow.Show();
            this.Close();

        }
    }
}
