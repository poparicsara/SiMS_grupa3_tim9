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
    public partial class IngredientsWindow : Window
    {
        private Medicament selectedMedicament;
        private List<Medicament> meds;
        private MedicamentRepository storage = new MedicamentRepository();
        public IngredientsWindow(Medicament selected)
        {
            InitializeComponent();
            
            storage = new MedicamentRepository();
            meds = storage.GetMedicaments();
            SetSelectedMedicament(selected.Id);
            ingredientDataGrid.ItemsSource = GetSelectedMedicamentIngredients();
        }

        private void SetSelectedMedicament(int id)
        {
            foreach(Medicament m in meds)
            {
                if(m.Id == id)
                {
                    selectedMedicament = m;
                }
            }
        }

        private List<Ingredient> GetSelectedMedicamentIngredients()
        {
            List<Ingredient> ingredients = new List<Ingredient>();
            if(selectedMedicament.Ingredients != null)
            {
                foreach (Ingredient i in selectedMedicament.Ingredients)
                {
                    ingredients.Add(i);
                }
            }            
            return ingredients;
        }

        private void AddButtonClicked(object sender, RoutedEventArgs e)
        {
            AddIngredientByDirectorWindow addWindow = new AddIngredientByDirectorWindow(selectedMedicament);
            addWindow.Show();
            this.Close();
        }

        private void EditButtonClicked(object sender, RoutedEventArgs e)
        {
            Ingredient ing = (Ingredient)ingredientDataGrid.SelectedItem;
            EditIngredientWindow ew = new EditIngredientWindow(selectedMedicament, ing);
            ew.Show();
            this.Close();
        }

        private void DeleteButtonClicked(object sender, RoutedEventArgs e)
        {
            DoChange();
            ingredientDataGrid.ItemsSource = selectedMedicament.Ingredients;
        }

        private void DoChange()
        {
            Ingredient ing = (Ingredient)ingredientDataGrid.SelectedItem;
            int index = GetIngredientIndex(ing);
            selectedMedicament.Ingredients.RemoveAt(index);
            storage.saveToFile(meds);
        }

        private int GetIngredientIndex(Ingredient selectedIngredient)
        {
            int index = 0;
            foreach (Ingredient i in selectedMedicament.Ingredients)
            {
                if (i.Name.Equals(selectedIngredient.Name))
                {
                    break;
                }
                index++;
            }
            return index;
        }
    }
}