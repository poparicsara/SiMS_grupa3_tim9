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
    public partial class MedicamentCompositionWindow : Window
    {
        private Medicament selectedMedicament;
        public MedicamentCompositionWindow(Medicament selected)
        {
            InitializeComponent();

            selectedMedicament = selected;

            MedicamentFileStorage storage = new MedicamentFileStorage();
            List<Medicament> meds = storage.loadFromFile("Lekovi.json");

            foreach(Medicament m in meds)
            {
                if(m.Id == selectedMedicament.Id)
                {
                    compositionData.ItemsSource = selectedMedicament.Ingredients;
                    break;
                }
            }
        }

        private void AddIngredientButton(object sender, RoutedEventArgs e)
        {
            AddCompositionWindow compositionWindow = new AddCompositionWindow(selectedMedicament);
            compositionWindow.Show();
            this.Close();
        }

        private void ClosingWndow(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void EditButton(object sender, RoutedEventArgs e)
        {
            Ingredient ing = (Ingredient)compositionData.SelectedItem;
            EditCompositionWindow ew = new EditCompositionWindow(selectedMedicament, ing);
            ew.Show();
            this.Close();
        }

        private void DeleteButton(object sender, RoutedEventArgs e)
        {
            Ingredient ing = (Ingredient)compositionData.SelectedItem;
            MedicamentFileStorage storage = new MedicamentFileStorage();
            List<Medicament> meds = storage.loadFromFile("Lekovi.json");
            int index = 0;
            foreach(Medicament m in meds)
            {
                if(m.Id == selectedMedicament.Id)
                {
                    foreach(Ingredient i in m.Ingredients)
                    {
                        if(i.Name == ing.Name)
                        {
                            m.Ingredients.RemoveAt(index);
                            break;
                        }
                        index++;
                    }
                }
            }
            storage.saveToFile(meds, "Lekovi.json");
            
            foreach(Medicament m in meds)
            {
                if(m.Id == selectedMedicament.Id)
                {
                    compositionData.ItemsSource = m.Ingredients;
                }
            }
        }
    }
}