using IS_Bolnica.Model;
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
    public partial class ListOfMedications : Window
    {
        private MedicamentService medicamentService = new MedicamentService();
        public ListOfMedications()
        {
            InitializeComponent();

            medicationsDataGrid.ItemsSource = medicamentService.ShowApprovedMedicaments();
        }

        private void medicationDoubleClicked(object sender, MouseButtonEventArgs e)
        {
            Medicament selectedMedicament = (Medicament)medicationsDataGrid.SelectedItem;
            //DataGridRow row = sender as DataGridRow;
            UpdateMedication updateMedicationWindow = new UpdateMedication(selectedMedicament);
            updateMedicationWindow.Show();
            this.Close();
        }
    }
}
