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
    public partial class MedicamentWindow : Window
    {
        private Request request = new Request();
        private RequestFileStorage requestStorage = new RequestFileStorage();

        public MedicamentWindow()
        {
            InitializeComponent();

            MedicamentFileStorage medStorage = new MedicamentFileStorage();
            List<Medicament> meds = medStorage.loadFromFile("Lekovi.json");

            /*Medicament r1 = new Medicament { Id = 102, Name = "AspirinPlusC", Producer = "Bayer" };
            Medicament m = new Medicament { Name = "Aspirin", Id = 101, Replacement = r1, Producer = "Bayer" };
            List<Medicament> meds = new List<Medicament>();
            meds.Add(m);
            medStorage.saveToFile(meds, "Lekovi.json");*/

            medicamentData.ItemsSource = meds;

        }

        private void Row_DoubleClik(object sender, MouseButtonEventArgs e)
        {
            Medicament selectedMedicament = (Medicament)medicamentData.SelectedItem;
            MedicamentInfoWindow medWindow = new MedicamentInfoWindow(selectedMedicament);
            medWindow.Show();
            this.Close();
        }

        private void AddMedicamentButton(object sender, RoutedEventArgs e)
        {
            AddMedicamentWindow addMed = new AddMedicamentWindow();
            addMed.Show();
            this.Close();
        }

        private void DeleteButtonClicked(object sender, RoutedEventArgs e)
        {
            int index = medicamentData.SelectedIndex;
            if(index < 0)
            {
                MessageBox.Show("Niste označili nijedan lek!");
            }
            else
            {
                MessageBoxResult messageBox = MessageBox.Show("Da li ste sigurni da želite da pošaljete zahtev za brisanje leka",
                "Brisanje leka", MessageBoxButton.YesNo);
                switch (messageBox)
                {
                    case MessageBoxResult.Yes:
                        List<Request> requests = requestStorage.LoadFromFile("Zahtevi.json");
                        Medicament selectedMed = (Medicament)medicamentData.SelectedItem;
                        request.Title = "Brisanje leka iz baze";

                        string content = selectedMed.Id + "|" + selectedMed.Name + "|" + selectedMed.Replacement.Name + "|" + selectedMed.Producer + "|";

                        foreach (Ingredient i in selectedMed.Ingredients)
                        {
                            content += i.Name + "\n";
                        }

                        request.Content = content;
                        request.Recipient = NotificationType.doctor;
                        request.Sender = UserType.director;

                        requests.Add(request);
                        requestStorage.SaveToFile(requests, "Zahtevi.json");
                        break;
                    case MessageBoxResult.No:
                        break;
                }
            }  
        }

        private void EditButton(object sender, RoutedEventArgs e)
        {
            int index = medicamentData.SelectedIndex;
            if (index < 0)
            {
                MessageBox.Show("Niste označili nijedan lek!");
            }
            else
            {
                Medicament med = (Medicament)medicamentData.SelectedItem;
                MedicamentInfoWindow medicamentInfo = new MedicamentInfoWindow(med);
                medicamentInfo.Show();
                this.Close();
            }
        }
    }
}