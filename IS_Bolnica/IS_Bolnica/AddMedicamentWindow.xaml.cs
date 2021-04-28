using IS_Bolnica.Model;
using Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        private ObservableCollection<Request> requests = new ObservableCollection<Request>();
        public AddMedicamentWindow()
        {
            InitializeComponent();

        }

        private void DoneButton(object sender, RoutedEventArgs e)
        {
            request.Title = "Dodavanje leka u bazu";

            string content = idBox.Text + "\n" + nameBox.Text + "\n" + replacementBox.Text + "\n" + producerBox.Text;
            request.Content = content;

            if (toBox.SelectedIndex == 0)
            {
                request.Recipient = NotificationType.doctor;
            }

            request.Sender = UserType.director;

            requests = storage.LoadFromFile("Zahtevi.json");
            requests.Add(request);
            storage.SaveToFile(requests, "Zahtevi.json");

            MedicamentFileStorage medStorage = new MedicamentFileStorage();
            List<Medicament> meds = medStorage.loadFromFile("Lekovi.json");

            //Medicament replacement = new Medicament { Id = 101, Name = ""}
            Medicament med = new Medicament { Id = (int)Int64.Parse(idBox.Text), Name = nameBox.Text, Producer = producerBox.Text };
            //med.Replacement.Name = replacementBox.Text;
            med.Status = MedicamentStatus.dissapproved;

            meds.Add(med);
            medStorage.saveToFile(meds, "Lekovi.json");

            MedicamentWindow mw = new MedicamentWindow();
            mw.Show();
            this.Close();
        }
    }
}
