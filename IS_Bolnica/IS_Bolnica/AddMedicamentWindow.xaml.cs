using IS_Bolnica.Model;
using Model;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using IS_Bolnica.Services;

namespace IS_Bolnica
{
    public partial class AddMedicamentWindow : Window
    {
        private Request newRequest = new Request();
        private string replacement;
        private Medicament selectedReplacement = new Medicament();
        private List<Medicament> meds;
        private Medicament newMedicament = new Medicament();
        private MedicamentService medService = new MedicamentService();
        private RequestService requestService = new RequestService();

        public AddMedicamentWindow()
        {
            InitializeComponent();

            meds = medService.GetMedicaments();

            replacementBox.ItemsSource = medService.GetReplacementNames();

            idBox.Focusable = true;
            idBox.Focus();

            this.PreviewKeyDown += new KeyEventHandler(HandleEsc);
        }

        private void HandleEsc(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                this.Close();
            }
        }

        private void DoneButtonClicked(object sender, RoutedEventArgs e)
        {
            if (!IsAnythingNull())
            {
                SetMedicamentAttributes();
                DoAdding();
            }
            else
            {
                MessageBox.Show("Sva polja moraju biti popunjena!");
            }
            
        }

        private void DoAdding()
        {
            if (medService.IsMedNumberUnique(newMedicament.Id))
            {
                SendAddingRequest();
                AddMedicament();
                this.Close();
            }
            else
            {
                MessageBox.Show("Već postoji lek sa unetim brojem!");
            }
        }

        private bool IsAnythingNull()
        {
            return idBox.Text.Equals("") || nameBox.Text.Equals("") || replacementBox.SelectedItem == null ||
                   producerBox.Text.Equals("") || toBox.SelectedItem == null || ingredientBox.Text.Equals("");
        }

        private void AddMedicament()
        {
            string ingredients = ingredientBox.Text;
            medService.AddMedicament(newMedicament, ingredients);
            }

        private void SetMedicamentAttributes()
        {
            newMedicament = new Medicament { Id = (int)Int64.Parse(idBox.Text), Name = nameBox.Text, Producer = producerBox.Text };
            newMedicament.Replacement = new Medicament();
            newMedicament.Replacement = selectedReplacement;
            newMedicament.Status = MedicamentStatus.dissapproved;
        }

        private void SendAddingRequest()
        {
            SetRequestAttributes();
            requestService.SendRequest(newRequest);
        }

        private void SetRequestAttributes()
        {
            newRequest.Title = "Dodavanje leka u bazu";
            SetRequestContent();
            newRequest.Recipient = NotificationType.doctor;
            newRequest.Sender = UserType.director;
        }

        private void SetRequestContent()
        {
            newRequest.Content = idBox.Text + "|" + nameBox.Text + "|" + replacement + "|" + producerBox.Text + "|" + ingredientBox.Text;
        }

        private void ReplacementComboBoxSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var combo = sender as ComboBox;
            replacement = (string)combo.SelectedItem;
            selectedReplacement = medService.GetMedicamentByName(replacement);
        }

        private void ClosingWindow(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MedicamentWindow mw = new MedicamentWindow();
            mw.Show();
        }

        private void NumberValidation(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void CancelButtonClicked(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
