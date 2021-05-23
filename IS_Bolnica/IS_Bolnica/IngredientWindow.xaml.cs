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
    public partial class IngredientWindow : Window
    {
        public IngredientWindow()
        {
            InitializeComponent();

            IngredientFileStorage ingStorage = new IngredientFileStorage();
            List<Ingredient> ingredients = ingStorage.loadFromFile("Sastojci.json");

            /*Ingredient ing = new Ingredient { Name = "Alopurinol" };

            List<Ingredient> ingredients = new List<Ingredient>();
            ingredients.Add(ing);

            ingStorage.saveToFile(ingredients, "Sastojci.json");*/

            ingredientData.ItemsSource = ingredients;
        }
    }
}
