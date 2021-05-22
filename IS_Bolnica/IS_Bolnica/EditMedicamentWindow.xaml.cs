using IS_Bolnica.Model;
using Model;
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
    
    public partial class EditMedicamentWindow : Window
    {
        private Request request = new Request();
        private Medicament oldMedicament = new Medicament();
        private Medicament newMedicament = new Medicament();
        private List<Medicament> meds = new List<Medicament>();
        private MedicamentFileStorage medStorage = new MedicamentFileStorage();
        private string replacement;
        private List<Request> requests = new List<Request>();
        private RequestFileStorage storage = new RequestFileStorage();

        public EditMedicamentWindow(Medicament selected)
        {
            InitializeComponent();

            oldMedicament = selected;

            FillTextBoxes();
            
            meds = medStorage.loadFromFile("Lekovi.json");           

            replacementBox.ItemsSource = GetReplacements();
            SetOldReplacement();

            requests = storage.LoadFromFile("Zahtevi.json");
        }

        private void FillTextBoxes()
        {
            idBox.Text = oldMedicament.Id.ToString();
            nameBox.Text = oldMedicament.Name;
            producerBox.Text = oldMedicament.Producer;
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

        private void SetOldReplacement()
        {
            if (oldMedicament.Replacement != null)
            {
                replacementBox.SelectedItem = oldMedicament.Replacement.Name;
            }
        }

        private void MedCompositionButtonClicked(object sender, RoutedEventArgs e)
        {
            IngredientsWindow compositionWindow = new IngredientsWindow(oldMedicament);
            compositionWindow.Show();
            this.Close();
        }

        private void DoneButtonClicked(object sender, RoutedEventArgs e)
        {
            SetNewMedicament();
            int index = GetIndexOfOldMedicament();
            meds.RemoveAt(index);
            meds.Insert(index, newMedicament);
            medStorage.saveToFile(meds, "Lekovi.json");

            SendEditRequest();

            this.Close();
        }

        private void SendEditRequest()
        {
            SetRequestAttributtes();
            requests.Add(request);
            storage.SaveToFile(requests, "Zahtevi.json");
        }

        private void SetRequestAttributtes()
        {
            request.Title = "Dodavanje leka u bazu";
            SetRequestContent();
            request.Recipient = NotificationType.doctor;
            request.Sender = UserType.director;
        }

        private void SetRequestContent()
        {
            string content = idBox.Text + "|" + nameBox.Text + "|" + replacement + "|" + producerBox.Text + "|";
            if(oldMedicament.Ingredients != null)
            {
                foreach (Ingredient i in oldMedicament.Ingredients)
                {
                    content += i.Name + "\n";
                }
            }
            request.Content = content;
        }

        private void SetNewMedicament()
        {
            newMedicament.Id = (int)Int64.Parse(idBox.Text);
            newMedicament.Name = nameBox.Text;
            newMedicament.Producer = producerBox.Text;
            SetReplacement();
            newMedicament.Ingredients = oldMedicament.Ingredients;
            newMedicament.Status = oldMedicament.Status;
        }

        private void SetReplacement()
        {
            foreach (Medicament m in meds)
            {
                if (m.Name.Equals(replacement))
                {
                    newMedicament.Replacement = m;
                    break;
                }
            }
        }

        private int GetIndexOfOldMedicament()
        {
            int index = 0;
            foreach (Medicament m in meds)
            {
                if (m.Id == oldMedicament.Id)
                {
                    break;
                }
                index++;
            }
            return index;
        }

        private void replacementSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var combo = sender as ComboBox;
            replacement = (string)combo.SelectedItem;
        }

        private void DeleteReplacementButtonClicked(object sender, RoutedEventArgs e)
        {
            DeleteReplacement();
            medStorage.saveToFile(meds, "Lekovi.json");
            MedicamentWindow mw = new MedicamentWindow();
            mw.Show();
            this.Close();
        }

        private void DeleteReplacement()
        {
            foreach (Medicament m in meds)
            {
                if (m.Id == oldMedicament.Id)
                {
                    m.Replacement = null;
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