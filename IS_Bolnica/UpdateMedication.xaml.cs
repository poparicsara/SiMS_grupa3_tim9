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
    public partial class UpdateMedication : Window
    {
        private Medicament selectedMedication;
        private Medicament updatedMedicament = new Medicament();
        private MedicamentService medicamentService = new MedicamentService();
        private IngredientService ingredientService = new IngredientService();
        public UpdateMedication(Medicament medicament)
        {
            InitializeComponent();

            this.selectedMedication = medicament;
            medIdTxt.Text = selectedMedication.Id.ToString();
            medNameTxt.Text = selectedMedication.Name;
            producerTxt.Text = selectedMedication.Producer;

            if (selectedMedication.Replacement != null)
            {
                replacementBox.SelectedItem = selectedMedication.Replacement.Name;
            }

            replacementBox.ItemsSource = medicamentService.showMedicamentReplacements();
            ingredientsData.ItemsSource = selectedMedication.Ingredients;
        }

        private void potvrdiButtonClicked(object sender, RoutedEventArgs e)
        {
            updatedMedicament.Id = (int) Int64.Parse(medIdTxt.Text);
            updatedMedicament.Name = medNameTxt.Text;
            updatedMedicament.Producer = producerTxt.Text;
            updatedMedicament.Replacement = medicamentService.setMedicamentReplacement(replacementBox.SelectedItem.ToString());

            int index = medicamentService.getIndexOfOldMedicament(selectedMedication);
            medicamentService.updateMedicament(updatedMedicament, index);

            ListOfMedications listOfMedicationsWindow = new ListOfMedications();
            listOfMedicationsWindow.Show();
            this.Close();
        }

        private void odustaniButtonClicked(object sender, RoutedEventArgs e)
        {
            ListOfMedications listOfMedicationsWindow = new ListOfMedications();
            listOfMedicationsWindow.Show();
            this.Close();
        }

        private void removeIngredientButtonClicked(object sender, RoutedEventArgs e)
        {
            int index = ingredientsData.SelectedIndex;
            Ingredient ingredient = (Ingredient)ingredientsData.SelectedItem;
            Medicament newMedicament = new Medicament();

            if (index == -1)
            {
                MessageBox.Show("Niste izabrali sastojak koji zelite da obrisete!");
            }
            else
            {
                ingredientService.removeIngredientFromMedicament(selectedMedication, ingredient);
                newMedicament = selectedMedication;
                int idx = medicamentService.getIndexOfOldMedicament(selectedMedication);
                medicamentService.updateMedicament(newMedicament, idx);
            }

            this.Close();

        }

        private void addIngredientButtonClicked(object sender, RoutedEventArgs e)
        {
            AddIngredientWindow addIngredientWindow = new AddIngredientWindow(selectedMedication);
            addIngredientWindow.Show();
        }

        private void DeleteReplacementButton(object sender, RoutedEventArgs e)
        {
            medicamentService.deleteMedReplacement(selectedMedication);
            ListOfMedications listOfMedicationsWindow = new ListOfMedications();
            listOfMedicationsWindow.Show();
            this.Close();
        }

    }
}
