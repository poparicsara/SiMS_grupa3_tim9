using System;
using System.Collections.Generic;
using System.Diagnostics;
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

    public partial class EditMedDemo : Window
    {
        private Medicament oldMedicament = new Medicament();
        private MedicamentService medService = new MedicamentService();
        private string replacement;


        public EditMedDemo(Medicament selected)
        {
            InitializeComponent();

            oldMedicament = selected;

            FillTextBoxes();

            replacementBox.ItemsSource = medService.GetReplacementNames();
            SetOldReplacement();

            idBox.Focusable = true;
            idBox.Focus();

            this.PreviewKeyDown += new KeyEventHandler(HandleEsc);
        }

        private void HandleEsc(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                DemoMedicamentWindow mw = new DemoMedicamentWindow();
                mw.Show();
                this.Close();
            }
        }

        private void FillTextBoxes()
        {
            idBox.Text = oldMedicament.Id.ToString();
            nameBox.Text = oldMedicament.Name;
            producerBox.Text = oldMedicament.Producer;
        }

        private void SetOldReplacement()
        {
            if (oldMedicament.Replacement != null)
            {
                replacementBox.SelectedItem = oldMedicament.Replacement.Name;
            }
        }

        private void DoneButtonClicked(object sender, RoutedEventArgs e)
        {
            DemoMedicamentWindow mw = new DemoMedicamentWindow();
            mw.Show();
            this.Close();
        }


        private void replacementSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var combo = sender as ComboBox;
            replacement = (string)combo.SelectedItem;
        }

        private void NumberValidation(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void CancelButtonClicked(object sender, RoutedEventArgs e)
        {
            DemoMedicamentWindow mw = new DemoMedicamentWindow();
            mw.Show();
            this.Close();
        }
    }
}
