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
    
    public partial class MedicamentInfoWindow : Window
    {
        private Request request = new Request();
        private Medicament medicament;
        private List<Medicament> meds = new List<Medicament>();
        private MedicamentFileStorage medStorage = new MedicamentFileStorage();
        private string replacement;
        private List<Request> requests = new List<Request>();
        private RequestFileStorage storage = new RequestFileStorage();

        public MedicamentInfoWindow(Medicament selectedMedicament)
        {
            InitializeComponent();

            medicament = selectedMedicament;

            idBox.Text = selectedMedicament.Id.ToString();
            nameBox.Text = selectedMedicament.Name;
            producerBox.Text = selectedMedicament.Producer;

            
            meds = medStorage.loadFromFile("Lekovi.json");
            List<string> replacements = new List<string>();

            foreach (Medicament med in meds)
            {
                replacements.Add(med.Name);
            }

            replacementBox.ItemsSource = replacements;
            replacementBox.SelectedItem = selectedMedicament.Replacement.Name;

        }

        private void MedCompositionButtonClicked(object sender, RoutedEventArgs e)
        {
            MedicamentCompositionWindow compositionWindow = new MedicamentCompositionWindow(medicament);
            compositionWindow.Show();
            this.Close();
        }

        private void ReplacementButtonClicked(object sender, RoutedEventArgs e)
        {
            MedicamentReplacementWindow replacementWindow = new MedicamentReplacementWindow(medicament);
            replacementWindow.Show();
            this.Close();
        }

        private void DoneButton(object sender, RoutedEventArgs e)
        {
            Medicament med = new Medicament();
            med.Id = (int)Int64.Parse(idBox.Text);
            med.Name = nameBox.Text;
            med.Producer = producerBox.Text;

            foreach(Medicament m in meds)
            {
                if (m.Name.Equals(replacement))
                {
                    med.Replacement = m;
                }
            }

            int index = 0;
            foreach(Medicament m in meds)
            {
                if(m.Id == medicament.Id)
                {
                    break;
                }
                index++;
            }

            meds.RemoveAt(index);
            meds.Insert(index, med);

            medStorage.saveToFile(meds, "Lekovi.json");

            request.Title = "Dodavanje leka u bazu";

            string content = idBox.Text + "|" + nameBox.Text + "|" + replacement + "|" + producerBox.Text + "|";

            foreach(Medicament m in meds)
            {
                if(m.Id == medicament.Id)
                {
                    if(m.Ingredients != null)
                    {
                        foreach (Ingredient i in m.Ingredients)
                        {
                            content += i.Name + "\n";
                        }
                    }
                    
                }
            }

            request.Content = content;
            request.Recipient = NotificationType.doctor;
            request.Sender = UserType.director;

            requests = storage.LoadFromFile("Zahtevi.json");
            requests.Add(request);
            storage.SaveToFile(requests, "Zahtevi.json");

            MedicamentWindow mw = new MedicamentWindow();
            mw.Show();
            this.Close();
        }

        private void replacementSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var combo = sender as ComboBox;
            replacement = (string)combo.SelectedItem;
        }
    }
}