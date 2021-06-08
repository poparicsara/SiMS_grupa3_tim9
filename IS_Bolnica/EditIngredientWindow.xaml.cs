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
    public partial class EditIngredientWindow : Window
    {
        private Ingredient oldIngredient;
        private Ingredient newIngredient = new Ingredient();
        private Medicament selectedMedicament = new Medicament();
        private MedicamentRepository storage = new MedicamentRepository();
        private List<Medicament> meds = new List<Medicament>();

        public EditIngredientWindow(Medicament med, Ingredient ingredient)
        {
            InitializeComponent();

            meds = storage.GetMedicaments();
            oldIngredient = ingredient;
            SetSelectedMedicament(med.Id);
            ingredientNameTxt.Text = ingredient.Name; 
        }

        private void DoneButtonClicked(object sender, RoutedEventArgs e)
        {
            SetNewIngredient();
            IngredientsWindow iw = new IngredientsWindow(selectedMedicament);
            iw.Show();
            this.Close();
        }

        private void SetNewIngredient()
        {
            newIngredient.Name = ingredientNameTxt.Text;
            SaveChange();
        }

        private void SaveChange()
        {
            int index = GetOldIngredientIndex(selectedMedicament);
            selectedMedicament.Ingredients.RemoveAt(index);
            selectedMedicament.Ingredients.Insert(index, newIngredient);
            storage.saveToFile(meds);
        }

        private int GetOldIngredientIndex(Medicament med)
        {
            int index = 0;
            foreach(Ingredient i in med.Ingredients)
            {
                if (i.Name.Equals(oldIngredient.Name))
                {
                    break;
                }
                index++;
            }
            return index;
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
    }
}
