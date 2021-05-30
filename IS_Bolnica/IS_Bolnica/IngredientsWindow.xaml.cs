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
    public partial class IngredientsWindow : Window
    {
        private Medicament selectedMedicament;
        private MedicamentService medService = new MedicamentService();
        private IngredientService ingService = new IngredientService();
        private string medicamentName;
        private Ingredient selectedIngredient = new Ingredient();

        public IngredientsWindow(Medicament selected)
        {
            InitializeComponent();

            medicamentName = selected.Name;
            selectedMedicament = medService.GetMedicament(selected.Name);

            ingredientDataGrid.ItemsSource = ingService.GetIngredients(selected);
        }

        private void AddButtonClicked(object sender, RoutedEventArgs e)
        {
            AddIngredientByDirectorWindow addWindow = new AddIngredientByDirectorWindow(selectedMedicament);
            addWindow.Show();
            this.Close();
        }

        private bool IsAnyMedicamentSelected()
        {
            if (ingredientDataGrid.SelectedIndex < 0)
            {
                MessageBox.Show("Niste izabrali nijedan lek!");
                return false;
            }
            else
            {
                selectedIngredient = (Ingredient)ingredientDataGrid.SelectedItem;
                return true;
            }
        }

        private void EditButtonClicked(object sender, RoutedEventArgs e)
        {
            if (IsAnyMedicamentSelected())
            {
                EditIngredientWindow ew = new EditIngredientWindow(selectedMedicament, selectedIngredient);
                ew.Show();
                this.Close();
            }
        }

        private void DeleteButtonClicked(object sender, RoutedEventArgs e)
        {
            if (IsAnyMedicamentSelected())
            {
                ingService.DeleteIngredient(selectedMedicament, selectedIngredient);
                RefreshDataGrid();
            }
        }

        private void RefreshDataGrid()
        {
            selectedMedicament = medService.GetMedicament(medicamentName);
            ingredientDataGrid.ItemsSource = ingService.GetIngredients(selectedMedicament);
        }

    }
}