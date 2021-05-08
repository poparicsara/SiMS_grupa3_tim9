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
    public partial class MedicamentInfoWindow : Window
    {
        private Medicament medicament;
        public MedicamentInfoWindow(Medicament selectedMedicament)
        {
            InitializeComponent();

            medicament = selectedMedicament;

            idBox.Text = selectedMedicament.Id.ToString();
            nameBox.Text = selectedMedicament.Name;
            producerBox.Text = selectedMedicament.Producer;

        }

        private void MedCompositionButtonClicked(object sender, RoutedEventArgs e)
        {
            MedicamentCompositionWindow compositionWindow = new MedicamentCompositionWindow(medicament);
            compositionWindow.Show();
            this.Close();
        }

        private void ReplacementButtonClicked(object sender, RoutedEventArgs e)
        {
            MedicamentReplacementWindow replacementWindow = new MedicamentReplacementWindow(medicament);
            replacementWindow.Show();
            this.Close();
        }
    }
}
