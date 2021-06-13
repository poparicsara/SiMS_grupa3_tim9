using IS_Bolnica.Model;
using Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
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
using IS_Bolnica.Services;

namespace IS_Bolnica
{
    public partial class SelectedRequest : Window
    {
        private Request selectedRequest;
        private int selectedId;
        private RequestService requestService = new RequestService();
        private MedicamentService medicamentService = new MedicamentService();
        private NotificationService notificationService = new NotificationService();
        private Medicament selectedMedicament = new Medicament();
        public SelectedRequest(Request selected)
        {
            InitializeComponent();

            selectedRequest = selected;
            Debug.WriteLine(selectedRequest.Content);

            string[] content = selectedRequest.Content.Split('|');

            selectedId = (int)Int64.Parse(content[0]);
            selectedMedicament = medicamentService.GetMedicamentById(selectedId);
            idBox.Text = content[0];
            nameBox.Text = content[1];
            replacementBox.Text = content[2];
            producerBox.Text = content[3];
            ingredientBox.Text = content[4];

            if(selected.Title.Equals("Dodavanje leka u bazu"))
            {
                deleteButton.IsEnabled = false;
            }
            else
            {
                sentToEditButton.IsEnabled = false;
                acceptMedButton.IsEnabled = false;
            }
            
        }

        private void AcceptMedicamentButton(object sender, RoutedEventArgs e)
        {
            medicamentService.ChangeMedicamentStatus((int)Int64.Parse(idBox.Text));
            requestService.DeleteRequest(selectedRequest);
            RequestWindow requestWindow = new RequestWindow();
            requestWindow.Show();
            this.Close();
        }

        private void SentToEditButton(object sender, RoutedEventArgs e)
        {
            Notification notification = new Notification();

            notification.Title = "Izmena zahteva za novi lek";
            string temp = selectedRequest.Content.Replace('|', '\n');
            temp += "\n";
            notification.Content = temp + "\n" + responceBox.Text.ToUpper();
            notification.notificationType = NotificationType.director;
            notification.Sender = UserType.doctor;

            notificationService.AddNotification(notification);

            requestService.DeleteRequest(selectedRequest);
            RequestWindow requestWindow = new RequestWindow();
            requestWindow.Show();
            this.Close();
            
        }

        private void ConfirmDeletingButton(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBox = MessageBox.Show("Da li ste sigurni da želite da dozvolite brisanje leka",
                "Brisanje leka", MessageBoxButton.YesNo);
            switch (messageBox)
            {
                case MessageBoxResult.Yes:
                    medicamentService.DeleteMedicament(selectedMedicament);
                    break;
                case MessageBoxResult.No:
                    break;
            }
            requestService.DeleteRequest(selectedRequest);
            this.Close();            
            
        }
    }
}
