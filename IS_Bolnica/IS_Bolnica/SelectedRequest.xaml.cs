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
    public partial class SelectedRequest : Window
    {
        private Request selectedRequest;
        public SelectedRequest(Request selected)
        {
            InitializeComponent();

            selectedRequest = selected;

            string[] content = selectedRequest.Content.Split('\n');

            idBox.Text = content[0];
            nameBox.Text = content[1];
            replacementBox.Text = content[2];
            producerBox.Text = content[3];
            
        }

        private void AcceptMedicamentButton(object sender, RoutedEventArgs e)
        {
            MedicamentFileStorage medStorage = new MedicamentFileStorage();
            List<Medicament> meds = medStorage.loadFromFile("Lekovi.json");

            foreach(Medicament med in meds)
            {
                if(med.Id == (int)Int64.Parse(idBox.Text))
                {
                    med.Status = MedicamentStatus.approved;
                    medStorage.saveToFile(meds, "Lekovi.json");
                }
            }

            RequestWindow requestWindow = new RequestWindow();
            requestWindow.Show();
            this.Close();
        }

        private void SentToEditButton(object sender, RoutedEventArgs e)
        {
            Notification notification = new Notification();
            notification.Title = "Izmena zahteva za novi lek";
            notification.Content = selectedRequest.Content + "\n" + responceBox.Text;
            notification.notificationType = NotificationType.director;
            notification.Sender = UserType.doctor;

            NotificationsFileStorage notificationStorage = new NotificationsFileStorage();
            List<Notification> notifications = notificationStorage.LoadFromFile("NotificationsFileStorage.json");

            notifications.Add(notification);

            notificationStorage.SaveToFile(notifications, "NotificationsFileStorage.json");

            RequestWindow requestWindow = new RequestWindow();
            requestWindow.Show();
            this.Close();
        }
    }
}
