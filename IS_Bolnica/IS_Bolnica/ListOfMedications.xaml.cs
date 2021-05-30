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

namespace IS_Bolnica
{
    public partial class ListOfMedications : Window
    {
        private List<Medicament> meds = new List<Medicament>();
        public ListOfMedications()
        {
            InitializeComponent();

            MedicamentRepository medStorage = new MedicamentRepository();
            List<Medicament> medicaments = medStorage.GetMedicaments();

            foreach (Medicament medicament in medicaments)
            {
                if (medicament.Status == MedicamentStatus.approved)
                {
                    meds.Add(medicament);
                }
            }

            medicationsDataGrid.ItemsSource = meds;
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
