using IS_Bolnica.Model;
using Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
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
    public partial class AddMedicamentWindow : Window
    {
        private Request request = new Request();
        private RequestFileStorage requestStorage = new RequestFileStorage();
        private List<Request> requests = new List<Request>();
        private string replacement;
        private Medicament selectedReplacement = new Medicament();
        private List<Medicament> meds = new List<Medicament>();
        private MedicamentFileStorage medStorage = new MedicamentFileStorage();
        private Medicament newMedicament = new Medicament();

        public AddMedicamentWindow()
        {
            InitializeComponent();

            MedicamentFileStorage medStorage = new MedicamentFileStorage();
            meds = medStorage.loadFromFile("Lekovi.json");

            requests = requestStorage.LoadFromFile("Zahtevi.json");

            replacementBox.ItemsSource = GetReplacements();
        }

        private List<string> GetReplacements()
        {
            List<string> replacements = new List<string>();
            foreach (Medicament med in meds)
            {
                replacements.Add(med.Name);
            }
            return replacements;
        }

        private void DoneButtonClicked(object sender, RoutedEventArgs e)
        {
            SendAddingRequest();
            AddMedicament();

            this.Close();
        }

        private void AddMedicament()
        {
            SetMedicamentAttributes();
            meds.Add(newMedicament);
            medStorage.saveToFile(meds, "Lekovi.json");
        }

        private void SetMedicamentAttributes()
        {
            newMedicament = new Medicament { Id = (int)Int64.Parse(idBox.Text), Name = nameBox.Text, Producer = producerBox.Text };
            newMedicament.Replacement = new Medicament();
            newMedicament.Replacement = selectedReplacement;
            newMedicament.Status = MedicamentStatus.dissapproved;
            newMedicament.Ingredients = GetIngredients();
        }

        private List<Ingredient> GetIngredients()
        {
            List<Ingredient> ingredients = new List<Ingredient>();
            string[] ings = ingredientBox.Text.Split('\n');
            for (int i = 0; i < ings.Length; i++)
            {
                Ingredient ingredient = GetIngredient(ings, i);
                ingredients.Add(ingredient);
            }
            return ingredients;
        }

        private Ingredient GetIngredient(string[] ingredients, int index)
        {
            string temp = ingredients[index];
            if (ingredients[index].Contains('\r'))
            {
                int endIndex = ingredients[index].IndexOf('\r');
                temp = ingredients[index].Substring(0, endIndex);
            }
            Ingredient ingredient = new Ingredient { Name = temp };
            return ingredient;
        }

        private void SendAddingRequest()
        {
            SetRequestAttributes();
            requests.Add(request);
            requestStorage.SaveToFile(requests, "Zahtevi.json");
        }

        private void SetRequestAttributes()
        {
            request.Title = "Dodavanje leka u bazu";
            SetRequestContent();
            request.Recipient = NotificationType.doctor;
            request.Sender = UserType.director;
        }

        private void SetRequestContent()
        {
            request.Content = idBox.Text + "|" + nameBox.Text + "|" + replacement + "|" + producerBox.Text + "|" + ingredientBox.Text;
        }

        private void ReplacementComboBoxSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var combo = sender as ComboBox;
            replacement = (string)combo.SelectedItem;
            SetSelectedReplacemet();
        }

        private void SetSelectedReplacemet()
        {
            foreach (Medicament med in meds)
            {
                if (med.Name.Equals(replacement))
                {
                    selectedReplacement = med;
                }
            }
        }

        private void ClosingWindow(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MedicamentWindow mw = new MedicamentWindow();
            mw.Show();
        }
    }
}
