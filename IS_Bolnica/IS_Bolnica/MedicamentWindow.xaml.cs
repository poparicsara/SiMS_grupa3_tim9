﻿using IS_Bolnica.Model;
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
    public partial class MedicamentWindow : Window
    {
        private Request request = new Request();
        private RequestRepository requestStorage = new RequestRepository();
        private Medicament selectedMedicament = new Medicament();
        private MedicamentRepository medRepository = new MedicamentRepository();
        private List<Request> requests = new List<Request>();

        public MedicamentWindow()
        {
            InitializeComponent();

            medicamentDataGrid.ItemsSource = medRepository.GetMedicaments();

            requests = requestStorage.GetRequests();
        }

        private void RowDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Medicament selectedMedicament = (Medicament)medicamentDataGrid.SelectedItem;
            EditMedicamentWindow medWindow = new EditMedicamentWindow(selectedMedicament);
            medWindow.Show();
            this.Close();
        }

        private void AddButtonClicked(object sender, RoutedEventArgs e)
        {
            AddMedicamentWindow addMed = new AddMedicamentWindow();
            addMed.Show();
            this.Close();
        }

        private void DeleteButtonClicked(object sender, RoutedEventArgs e)
        {
            if (IsAnyMedicamentSelected())
            {
                MessageBoxResult messageBox = MessageBox.Show("Da li ste sigurni da želite da pošaljete zahtev za brisanje leka",
                "Brisanje leka", MessageBoxButton.YesNo);
                switch (messageBox)
                {
                    case MessageBoxResult.Yes:
                        SendDeletingRequest();
                        break;
                    case MessageBoxResult.No:
                        break;
                }
            }
        }

        private void SendDeletingRequest()
        {           
            SetRequestAttributes();
            requests.Add(request);
            requestStorage.SaveToFile(requests);
        }

        private void SetRequestAttributes()
        {
            request.Title = "Brisanje leka iz baze";
            SetRequestContent();
            request.Recipient = NotificationType.doctor;
            request.Sender = UserType.director;
        }

        private void SetRequestContent()
        {
            string content = selectedMedicament.Id + "|" + selectedMedicament.Name + "|" + selectedMedicament.Replacement.Name + "|" + selectedMedicament.Producer + "|";
            foreach (Ingredient i in selectedMedicament.Ingredients)
            {
                content += i.Name + "\n";
            }
            request.Content = content;
        }

        private bool IsAnyMedicamentSelected()
        {
            if (medicamentDataGrid.SelectedIndex < 0)
            {
                MessageBox.Show("Niste izabrali nijedan lek!");
                return false;
            }
            else
            {
                selectedMedicament = (Medicament)medicamentDataGrid.SelectedItem;
                return true;
            }
        }

        private void EditButtonClicked(object sender, RoutedEventArgs e)
        {
            if (IsAnyMedicamentSelected())
            {
                Medicament med = (Medicament)medicamentDataGrid.SelectedItem;
                EditMedicamentWindow medicamentInfo = new EditMedicamentWindow(med);
                medicamentInfo.Show();
                this.Close();
            }
        }

        private void InventoryButtonClicked(object sender, RoutedEventArgs e)
        {
            InventoryWindow iw = new InventoryWindow();
            iw.Show();
            this.Close();
        }

        private void RoomButtonClicked(object sender, RoutedEventArgs e)
        {
            Director d = new Director();
            RoomWindow uw = new RoomWindow(d);
            uw.Show();
            this.Close();
        }

        private void ProfileButtonClicked(object sender, RoutedEventArgs e)
        {
            DirectorProfileWindow profileWindow = new DirectorProfileWindow();
            profileWindow.Show();
            this.Close();
        }
    }
}