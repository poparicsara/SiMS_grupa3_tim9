using IS_Bolnica.Model;
using Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

            idBox.Focusable = true;
            idBox.Focus();

            this.PreviewKeyDown += new KeyEventHandler(HandleEsc);
        }

        private void HandleEsc(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                MedicamentWindow mw = new MedicamentWindow();
                mw.Show();
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
        }

        private void DoneButtonClicked(object sender, RoutedEventArgs e)
        {
            if (!IsAnythingNull())
            {
                SetNewMedicament();
                DoEditing();
            }
            else
            {
                MessageBox.Show("Sva polja moraju biti popunjena!");
            }
        }

        private void DoEditing()
        {
            Debug.WriteLine(oldMedicament.Id);
            Debug.WriteLine(newMedicament.Id);
            if (IsIdChanged())
            {
                CheckRoomId();
            }
            else
            {
                medService.EditMedicament(oldMedicament, newMedicament);
                SendEditRequest();
                MedicamentWindow mw = new MedicamentWindow();
                mw.Show();
                this.Close();
            }
        }

        private void CheckRoomId()
        {
            if (medService.IsMedNumberUnique(newMedicament.Id))
            {
                medService.EditMedicament(oldMedicament, newMedicament);
                SendEditRequest();
                MedicamentWindow mw = new MedicamentWindow();
                mw.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Već postoji soba sa unetim brojem!");
            }
        }

        private bool IsIdChanged()
        {
            return oldMedicament.Id != newMedicament.Id;
        }

        private bool IsAnythingNull()
        {
            return idBox.Text.Equals("") || nameBox.Text.Equals("") || replacementBox.SelectedItem == null ||
                   producerBox.Text.Equals("");
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

        private void CancelButtonClicked(object sender, RoutedEventArgs e)
        {
            MedicamentWindow mw = new MedicamentWindow();
            mw.Show();
            this.Close();
        }
    }
}