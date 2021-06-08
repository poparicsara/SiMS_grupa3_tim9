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
    public partial class AddIngredientByDirectorWindow : Window
    {
        private Medicament selectedMedicament;
        private Ingredient ingredient = new Ingredient();
        private MedicamentRepository medStorage = new MedicamentRepository();
        private List<Medicament> meds = new List<Medicament>();

        public AddIngredientByDirectorWindow(Medicament selected)
        {
            InitializeComponent();

            selectedMedicament = selected;

            meds = medStorage.GetMedicaments();
        }

        private void DoneButtonClicked(object sender, RoutedEventArgs e)
        {
            ingredient = new Ingredient { Name = ingredientNameTxt.Text };
            AddToMedicament();

            IngredientsWindow iw = new IngredientsWindow(selectedMedicament);
            iw.Show();
            this.Close();



            /*foreach(Medicament m in meds)
            {
                if(m.Id == selectedMedicament.Id)
                {
                    cw.compositionData.ItemsSource = m.Ingredients;
                }
            }*/

            //MedicamentWindow ew = new MedicamentWindow();

        }

        private void AddToMedicament()
        {
            foreach (Medicament m in meds)
            {
                if (m.Id == selectedMedicament.Id)
                {
                    IsException(m);
                    m.Ingredients.Add(ingredient);
                }
            }
            medStorage.saveToFile(meds);
        }

        private void IsException(Medicament med)
        {
            if (med.Ingredients == null)
            {
                med.Ingredients = new List<Ingredient>();
            }
        }
    }
}
