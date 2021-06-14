using System.Windows;
using System.Windows.Input;
using IS_Bolnica.DoctorUI;
using IS_Bolnica.GUI.Doctor.ViewModel;
using IS_Bolnica.Model;
using IS_Bolnica.Services;

namespace IS_Bolnica.GUI.Doctor.View
{
    public partial class MedicamentsWindow : Window
    {
        public MedicamentsWindow()
        {
            InitializeComponent();
            DataContext = new MedicamentsWindowVM();
        }

        private void MedicationDoubleClicked(object sender, MouseButtonEventArgs e)
        {
            Medicament selectedMedicament = (Medicament) medsDataGrid.SelectedItem;
            UpdateMedicamentWindow updateMedicament = new UpdateMedicamentWindow(selectedMedicament);
            updateMedicament.Show();
            this.Close();
        }
    }
}
