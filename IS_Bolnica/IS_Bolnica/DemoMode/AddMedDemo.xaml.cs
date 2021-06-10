using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using Model;

namespace IS_Bolnica.DemoMode
{

    public partial class AddMedDemo : Window
    {
        private Request newRequest = new Request();
        private string replacement;
        private Medicament selectedReplacement = new Medicament();
        private List<Medicament> meds;
        private Medicament newMedicament = new Medicament();
        private MedicamentService medService = new MedicamentService();
        private RequestService requestService = new RequestService();

        public AddMedDemo()
        {
            InitializeComponent();

            meds = medService.GetMedicaments();

            replacementBox.ItemsSource = medService.GetReplacementNames();

            idBox.Focusable = true;
            idBox.Focus();

            this.PreviewKeyDown += new KeyEventHandler(HandleEsc);
        }

        private void HandleEsc(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                this.Close();
            }
        }

        private void DoneButtonClicked(object sender, RoutedEventArgs e)
        {
            this.Close();

        }


        private void ReplacementComboBoxSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var combo = sender as ComboBox;
            replacement = (string)combo.SelectedItem;
            selectedReplacement = medService.GetMedicament(replacement);
        }

        private void ClosingWindow(object sender, System.ComponentModel.CancelEventArgs e)
        {
            DemoMedicamentWindow mw = new DemoMedicamentWindow();
            mw.Show();
        }

        private void NumberValidation(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void CancelButtonClicked(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
