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
    public partial class UpdateMedication : Window
    {
        private Medicament selectedMedication;
        private MedicamentFileStorage medStorage = new MedicamentFileStorage();
        private List<Medicament> meds = new List<Medicament>();
        private Ingredient ingredient;
        public UpdateMedication(Medicament medicament)
        {
            InitializeComponent();

            this.selectedMedication = medicament;
            meds = medStorage.loadFromFile("Lekovi.json");

            medIdTxt.Text = selectedMedication.Id.ToString();
            medNameTxt.Text = selectedMedication.Name;
            medReplacementTxt.Text = selectedMedication.Replacement.Name;
            producerTxt.Text = selectedMedication.Producer;

            //for (int i = 0; i < selectedMedication.Ingredients.Count; i++)
            //{
            //    ingredientsNames.Add(selectedMedication.Ingredients[i].Name);
            //    //ingredientsList.Items.Add(selectedMedication.Ingredients[i].Name);
            //}

            //for (int i = 0; i < ingredientsNames.Count; i++)
            //{
            //    ingredientsList.Items.Add(ingredientsNames[i]);
            //}

            ingredientsData.ItemsSource = selectedMedication.Ingredients;
        }

        private void potvrdiButtonClicked(object sender, RoutedEventArgs e)
        {
            meds = medStorage.loadFromFile("Lekovi.json");

            for (int i = 0; i < meds.Count; i++)
            {
                if (meds[i].Id.Equals(selectedMedication.Id))
                {
                    meds.RemoveAt(i);
                }
            }

            selectedMedication.Id = Convert.ToInt32(medIdTxt.Text);
            selectedMedication.Name = medNameTxt.Text;
            selectedMedication.Replacement.Name = medReplacementTxt.Text;
            selectedMedication.Producer = producerTxt.Text;

            meds.Add(selectedMedication);

            medStorage.saveToFile(meds, "Lekovi.json");

            ListOfMedications listOfMedicationsWindow = new ListOfMedications();
            listOfMedicationsWindow.Show();
            this.Close();
        }

        private void odustaniButtonClicked(object sender, RoutedEventArgs e)
        {
            ListOfMedications listOfMedicationsWindow = new ListOfMedications();
            listOfMedicationsWindow.Show();
            this.Close();
        }

        private void removeIngredientButtonClicked(object sender, RoutedEventArgs e)
        {
            int index = ingredientsData.SelectedIndex;
            ingredient = (Ingredient)ingredientsData.SelectedItem;
            Medicament newMedicament = new Medicament();

            if (index == -1)
            {
                MessageBox.Show("Niste izabrali sastojak koji zelite da obrisete!");
            }
            else
            {
                meds = medStorage.loadFromFile("Lekovi.json");

                for (int i = 0; i < selectedMedication.Ingredients.Count; i++)
                {
                    if (selectedMedication.Ingredients[i].Name == ingredient.Name)
                    {
                        selectedMedication.Ingredients.RemoveAt(i);
                    }
                }

                newMedicament = selectedMedication;

                for (int i = 0; i < meds.Count; i++)
                {
                    if (meds[i].Id == selectedMedication.Id)
                    {
                        meds.RemoveAt(i);
                    }
                }

                meds.Add(newMedicament);
                medStorage.saveToFile(meds, "Lekovi.json");
            }

            this.Close();

        }

        private void addIngredientButtonClicked(object sender, RoutedEventArgs e)
        {
            AddIngredientWindow addIngredientWindow = new AddIngredientWindow(selectedMedication);
            addIngredientWindow.Show();
        }
    }
}
