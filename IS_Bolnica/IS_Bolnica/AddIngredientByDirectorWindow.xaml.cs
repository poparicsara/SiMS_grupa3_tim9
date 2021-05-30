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
    public partial class AddIngredientByDirectorWindow : Window
    {
        private Medicament selectedMedicament;
        private Ingredient ingredient = new Ingredient();
        private IngredientService service = new IngredientService();

        public AddIngredientByDirectorWindow(Medicament selected)
        {
            InitializeComponent();

            selectedMedicament = selected;
        }

        private void DoneButtonClicked(object sender, RoutedEventArgs e)
        {
            ingredient = new Ingredient { Name = ingredientNameTxt.Text };
            service.AddIngredient(selectedMedicament, ingredient);

            this.Close();
        }

        private void ClosingWindow(object sender, System.ComponentModel.CancelEventArgs e)
        {
            IngredientsWindow iw = new IngredientsWindow(selectedMedicament);
            iw.Show();
        }
    }
}
