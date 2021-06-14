using IS_Bolnica.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
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
    public partial class AddIngredientByDirectorWindow : Window
    {
        private Medicament selectedMedicament;
        private Ingredient ingredient = new Ingredient();
        private IngredientService service = new IngredientService();
        private MedicamentService medService = new MedicamentService();

        public AddIngredientByDirectorWindow(Medicament selected)
        {
            InitializeComponent();

            selectedMedicament = selected;

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
            Debug.WriteLine("done clicked");
            if (SetNewIngredient())
            {
                service.AddIngredient(selectedMedicament, ingredient);
                this.Close();
            }
        }

        private bool SetNewIngredient()
        {
            if (ingredientNameTxt.Text.Equals(""))
            {
                Debug.WriteLine("nije unet naziv");
                MessageBox.Show("Morate uneti naziv sastojka");
                return false;
            }
            else
            {
                Debug.WriteLine(" unet naziv");
                return CheckMedicamentIngredients();
            }
        }

        private bool CheckMedicamentIngredients()
        {
            if (!medService.HasMedicamentIngredient(selectedMedicament, ingredientNameTxt.Text))
            {
                Debug.WriteLine("nema taj sastojak");
                ingredient = new Ingredient {Name = ingredientNameTxt.Text};
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

        private void CancelButtonClicked(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
