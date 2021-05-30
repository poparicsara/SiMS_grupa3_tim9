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
    public partial class AddIngredientWindow : Window
    {
        private Medicament med;
        private MedicamentService medicamentService = new MedicamentService();
        public AddIngredientWindow(Medicament medicament)
        {
            InitializeComponent();
            this.med = medicament;
        }

        private void confirmButtonClicked(object sender, RoutedEventArgs e)
        {
            Ingredient ingredient = new Ingredient();
            ingredient.Name = ingredientNameTxt.Text;
            medicamentService.addIngredientInMedicament(ingredient, med.Id);

            ListOfMedications listOfMedications = new ListOfMedications();
            listOfMedications.Show();
            this.Close();
        }
    }
}
