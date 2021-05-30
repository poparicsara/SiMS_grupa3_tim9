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
    public partial class EditIngredientWindow : Window
    {
        private Ingredient oldIngredient;
        private Ingredient newIngredient = new Ingredient();
        private Medicament selectedMedicament = new Medicament();
        private IngredientService service = new IngredientService();
        private MedicamentService medService = new MedicamentService();

        public EditIngredientWindow(Medicament med, Ingredient ingredient)
        {
            InitializeComponent();

            selectedMedicament = medService.GetMedicament(med.Name);

            oldIngredient = ingredient;

            ingredientNameTxt.Text = ingredient.Name; 
        }

        private void DoneButtonClicked(object sender, RoutedEventArgs e)
        {
            newIngredient.Name = ingredientNameTxt.Text;
            service.EditIngredient(selectedMedicament, oldIngredient, newIngredient);
            
            this.Close();
        }

        private void ClosingWindow(object sender, System.ComponentModel.CancelEventArgs e)
        {
            IngredientsWindow iw = new IngredientsWindow(selectedMedicament);
            iw.Show();
        }
    }
}
