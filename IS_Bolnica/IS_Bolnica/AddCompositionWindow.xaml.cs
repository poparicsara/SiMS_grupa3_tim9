﻿using IS_Bolnica.Model;
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
        private Medicament selectedMedicament;
        private Ingredient ingredient = new Ingredient();
        private MedicamentFileStorage medStorage = new MedicamentFileStorage();
        private List<Medicament> meds = new List<Medicament>();

        public AddCompositionWindow(Medicament selected)
        {
            InitializeComponent();

            selectedMedicament = selected;

            List<Medicament> meds = medStorage.loadFromFile("Lekovi.json");
        }

        private void DoneButtonClicked(object sender, RoutedEventArgs e)
        {
            ingredient = new Ingredient { Name = ingredientNameTxt.Text };
            AddToMedicament();

            IngredientsWindow iw = new IngredientsWindow(selectedMedicament);

            /*foreach(Medicament m in meds)
            {
                if(m.Id == selectedMedicament.Id)
                {
                    cw.compositionData.ItemsSource = m.Ingredients;
                }
            }*/

            //MedicamentWindow ew = new MedicamentWindow();
            iw.Show();
            this.Close();
        }

        private void AddToMedicament()
        {
            foreach (Medicament m in meds)
            {
                if (m.Id == selectedMedicament.Id)
                {
                    m.Ingredients.Add(ingredient);
                }
            }
            medStorage.saveToFile(meds, "Lekovi.json");
        }
    }
}
