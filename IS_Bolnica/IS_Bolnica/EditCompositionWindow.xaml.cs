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
    public partial class EditCompositionWindow : Window
    {
        private string selected;
        private Medicament medicament;

        public EditCompositionWindow(Medicament med, Ingredient ingredient)
        {
            InitializeComponent();

            selected = ingredient.Name;
            medicament = med;

            ingredientNameTxt.Text = ingredient.Name;
        }

        private void DoneButton(object sender, RoutedEventArgs e)
        {
            MedicamentFileStorage storage = new MedicamentFileStorage();
            List<Medicament> meds = storage.loadFromFile("Lekovi.json");

            foreach(Medicament m in meds)
            {
                if(m.Id == medicament.Id)
                {
                    foreach(Ingredient i in m.Ingredients)
                    {
                        if (i.Name.Equals(selected))
                        {
                            i.Name = ingredientNameTxt.Text;
                        }
                    }
                }
            }
            storage.saveToFile(meds, "Lekovi.json");
            MedicamentWindow mw = new MedicamentWindow();
            mw.Show();
            this.Close();
        }
    }
}
