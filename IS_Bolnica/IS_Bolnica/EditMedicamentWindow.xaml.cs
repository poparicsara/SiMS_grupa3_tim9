using IS_Bolnica.Model;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using IS_Bolnica.Services;

namespace IS_Bolnica
{
    
    public partial class EditMedicamentWindow : Window
    {
        private Request request = new Request();
        private Medicament oldMedicament = new Medicament();
        private Medicament newMedicament = new Medicament();
        private MedicamentService medService = new MedicamentService();
        private string replacement;
        private RequestService requestService = new RequestService();


        public EditMedicamentWindow(Medicament selected)
        {
            InitializeComponent();

            oldMedicament = selected;

            FillTextBoxes();

            replacementBox.ItemsSource = medService.GetReplacementNames();
            SetOldReplacement();

            this.PreviewKeyDown += new KeyEventHandler(HandleEsc);
        }

        private void HandleEsc(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                this.Close();
            }
        }

        private void FillTextBoxes()
        {
            idBox.Text = oldMedicament.Id.ToString();
            nameBox.Text = oldMedicament.Name;
            producerBox.Text = oldMedicament.Producer;
        }

        private void SetOldReplacement()
        {
            if (oldMedicament.Replacement != null)
            {
                replacementBox.SelectedItem = oldMedicament.Replacement.Name;
            }
        }

        private void IngredientButtonClicked(object sender, RoutedEventArgs e)
        {
            IngredientsWindow compositionWindow = new IngredientsWindow(oldMedicament);
            compositionWindow.Show();
            this.Close();
        }

        private void DoneButtonClicked(object sender, RoutedEventArgs e)
        {
            SetNewMedicament();
            medService.EditMedicament(oldMedicament, newMedicament);

            SendEditRequest();

            this.Close();
        }

        private void SendEditRequest()
        {
            SetRequestAttributtes();
            requestService.SendRequest(request);
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
            newMedicament.Replacement = medService.GetMedicament(replacement);
            newMedicament.Ingredients = oldMedicament.Ingredients;
            newMedicament.Status = oldMedicament.Status;
        }

        private void replacementSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var combo = sender as ComboBox;
            replacement = (string)combo.SelectedItem;
        }

        private void NumberValidation(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}