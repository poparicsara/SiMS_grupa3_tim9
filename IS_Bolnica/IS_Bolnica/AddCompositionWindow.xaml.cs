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
    public partial class AddCompositionWindow : Window
    {
        private Medicament medicament;
        public AddCompositionWindow(Medicament selectedMedicament)
        {
            InitializeComponent();

            medicament = selectedMedicament;
        }

        private void DoneButtonClicked(object sender, RoutedEventArgs e)
        {
            Ingredient ingredient = new Ingredient { Name = ingredientNameTxt.Text };

            MedicamentFileStorage medStorage = new MedicamentFileStorage();
            List<Medicament> meds = medStorage.loadFromFile("Lekovi.json");
            foreach(Medicament m in meds)
            {
                if(m.Id == medicament.Id)
                {
                    m.Ingredients.Add(ingredient);
                }
            }
            medStorage.saveToFile(meds, "Lekovi.json");
            MedicamentCompositionWindow compositionWindow = new MedicamentCompositionWindow(medicament);
            compositionWindow.Show();
            this.Close();
        }
    }
}
