using IS_Bolnica.Model;
using Model;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
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
            selectedReplacement = medService.GetMedicament(replacement);
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
