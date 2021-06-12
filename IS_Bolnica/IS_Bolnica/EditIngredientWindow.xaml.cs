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

            selectedMedicament = medService.GetMedicamentByName(med.Name);

            oldIngredient = ingredient;

            ingredientNameTxt.Text = ingredient.Name;

            ingredientNameTxt.Focusable = true;
            ingredientNameTxt.Focus();

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
            if (SetNewIngredient())
            {
                service.EditIngredient(selectedMedicament, oldIngredient, newIngredient);
                this.Close();
            }
        }

        private bool SetNewIngredient()
        {
            if (ingredientNameTxt.Text.Equals(""))
            {
                MessageBox.Show("Morate uneti naziv sastojka");
                return false;
            }
            else
            {
                return CheckMedicamentIngredients();
            }
        }

        private bool CheckMedicamentIngredients()
        {
            if (!medService.HasMedicamentIngredient(selectedMedicament, ingredientNameTxt.Text))
            {
                newIngredient.Name = ingredientNameTxt.Text;
                return true;
            }
            else
            {
                MessageBox.Show("Lek već ima uneti sastojak!");
                return false;
            }

        }

        private void ClosingWindow(object sender, System.ComponentModel.CancelEventArgs e)
        {
            IngredientsWindow iw = new IngredientsWindow(selectedMedicament);
            iw.Show();
        }
    }
}
