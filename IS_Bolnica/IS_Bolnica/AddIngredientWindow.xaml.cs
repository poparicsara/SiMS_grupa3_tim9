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
    public partial class AddIngredientWindow : Window
    {
        private MedicamentRepository medStorage = new MedicamentRepository();
        private Medicament med;
        private List<Medicament> medicaments = new List<Medicament>();
        public AddIngredientWindow(Medicament medicament)
        {
            InitializeComponent();

            this.med = medicament;
        }

        private void confirmButtonClicked(object sender, RoutedEventArgs e)
        {
            medicaments = medStorage.GetMedicaments();

            Ingredient ingredient = new Ingredient();
            ingredient.Name = ingredientNameTxt.Text;

            foreach (Medicament medicament in medicaments)
            {
                if (medicament.Id.Equals(med.Id))
                {
                    medicament.Ingredients.Add(ingredient);
                }
            }

            medStorage.SaveToFile(medicaments);

            ListOfMedications listOfMedications = new ListOfMedications();
            listOfMedications.Show();
            this.Close();
        }
    }
}
