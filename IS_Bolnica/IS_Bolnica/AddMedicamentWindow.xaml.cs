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
        private RequestFileStorage storage = new RequestFileStorage();
        private List<Request> requests = new List<Request>();
        private string replacement;
        private Medicament selectedReplacement = new Medicament();
        private List<Medicament> meds = new List<Medicament>();

        public AddMedicamentWindow()
        {
            InitializeComponent();

            MedicamentFileStorage medStorage = new MedicamentFileStorage();
            meds = medStorage.loadFromFile("Lekovi.json");
            List<string> replacements = new List<string>();

            foreach(Medicament med in meds)
            {
                replacements.Add(med.Name);
            }

            replacementBox.ItemsSource = replacements;

        }

        private void DoneButton(object sender, RoutedEventArgs e)
        {
            request.Title = "Dodavanje leka u bazu";

            request.Content = idBox.Text + "\n" + nameBox.Text + "\n" + replacement + "\n" + producerBox.Text;

            if (toBox.SelectedIndex == 0)
            {
                request.Recipient = NotificationType.doctor;
            }

            request.Sender = UserType.director;

            requests = storage.LoadFromFile("Zahtevi.json");
            requests.Add(request);
            storage.SaveToFile(requests, "Zahtevi.json");

            //dodaje se svakako u bazu
            MedicamentFileStorage medStorage = new MedicamentFileStorage();
            List<Medicament> meds = medStorage.loadFromFile("Lekovi.json");

            Medicament med = new Medicament { Id = (int)Int64.Parse(idBox.Text), Name = nameBox.Text, Producer = producerBox.Text };
            med.Replacement = new Medicament();
            med.Replacement = selectedReplacement;
            med.Status = MedicamentStatus.dissapproved;

            List<Ingredient> ings = new List<Ingredient>();
            string[] ingredients = ingredientBox.Text.Split('\n');
            for(int i = 0; i < ingredients.Length; i++)
            {
                string temp = ingredients[i];
                if (ingredients[i].Contains('\r'))
                {
                    int index = ingredients[i].IndexOf('\r');
                    temp = ingredients[i].Substring(0, index);
                }
                Ingredient ing = new Ingredient { Name = temp };
                ings.Add(ing);
            }

            med.Ingredients = ings;

            meds.Add(med);
            medStorage.saveToFile(meds, "Lekovi.json");

            MedicamentWindow mw = new MedicamentWindow();
            mw.Show();
            this.Close();
        }

        private void ReplacementComboBoxSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var combo = sender as ComboBox;
            replacement = (string)combo.SelectedItem;

            foreach(Medicament med in meds)
            {
                if (med.Name.Equals(replacement))
                {
                    selectedReplacement = med;
                }
            }
        }
    }
}
