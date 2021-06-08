using System;
using System.Collections.Generic;
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
using IS_Bolnica.Model;
using IS_Bolnica.Services;
using Model;

namespace IS_Bolnica.DoctorUI
{
    public partial class ReviewMedRequestWindow : Window
    {
        private Request request;
        private UserService userService = new UserService();
        private MedicamentService medicamentService = new MedicamentService();
        private NotificationService notificationService = new NotificationService();
        private RequestService requestService = new RequestService();
        private int selectedId;
        public ReviewMedRequestWindow(Request selectedRequest)
        {
            InitializeComponent();
            this.request = selectedRequest;

            Debug.WriteLine(selectedRequest.Content);

            string[] content = selectedRequest.Content.Split('|');

            selectedId = (int)Int64.Parse(content[0]);
            idTxt.Text = content[0];
            nameTxt.Text = content[1];
            replacementTxt.Text = content[2];
            producerTxt.Text = content[3];
            ingredientsTxt.Text = content[4];

            if (selectedRequest.Title.Equals("Dodavanje leka u bazu"))
            {
                approveDeleting.IsEnabled = false;
            }
            else
            {
                sendOnUpdate.IsEnabled = false;
                approveMed.IsEnabled = false;
            }
        }

        private void ExaminationsButtonClick(object sender, RoutedEventArgs e)
        {
            DoctorStartWindow doctorStartWindow = new DoctorStartWindow();
            doctorStartWindow.Show();
            this.Close();
        }

        private void OperationButtonClick(object sender, RoutedEventArgs e)
        {
            OperationsWindow operationsWindow = new OperationsWindow();
            operationsWindow.Show();
            this.Close();
        }

        private void NotificationsButtonClick(object sender, RoutedEventArgs e)
        {
            NotificationsWindow notificationsWindow = new NotificationsWindow();
            notificationsWindow.Show();
            this.Close();
        }

        private void StatisticsButtonClick(object sender, RoutedEventArgs e)
        {
            ChartWindow chartWindow = new ChartWindow();
            chartWindow.Show();
            this.Close();
        }

        private void SingOutButtonClick(object sender, RoutedEventArgs e)
        {
            userService.LogOut();
            this.Close();
        }

        private void SettingsButtonClick(object sender, RoutedEventArgs e)
        {

        }

        private void MedicamentsButtonClick(object sender, RoutedEventArgs e)
        {
            MedicamentsWindow medicamentsWindow = new MedicamentsWindow();
            medicamentsWindow.Show();
            this.Close();
        }

        private void BackButtonClick(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBox = MessageBox.Show("Da li ste sigurni da želite da izađete?",
                "Zahtev za lekove", MessageBoxButton.YesNo);

            switch (messageBox)
            {
                case MessageBoxResult.Yes:
                    NotificationsWindow notificationsWindow = new NotificationsWindow();
                    notificationsWindow.Show();
                    this.Close();
                    break;
                case MessageBoxResult.No:
                    break;
            }
        }

        private void ApproveDeletingButtonClick(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBox = MessageBox.Show("Da li ste sigurni da želite da dozvolite brisanje leka?",
                "Brisanje leka", MessageBoxButton.YesNo);
            switch (messageBox)
            {
                case MessageBoxResult.Yes:
                    medicamentService.DeleteMedicament(selectedId);
                    break;
                case MessageBoxResult.No:
                    break;
            }
            requestService.DeleteRequest(request);
            this.Close();
        }

        private void ApproveMedButtonClick(object sender, RoutedEventArgs e)
        {
            medicamentService.ChangeMedicamentStatus((int)Int64.Parse(idTxt.Text));
            requestService.DeleteRequest(request);
            NotificationsWindow notificationsWindow = new NotificationsWindow();
            notificationsWindow.Show();
            this.Close();
        }

        private void SendOnUpdateButtonClick(object sender, RoutedEventArgs e)
        {
            Notification notification = new Notification();

            notification.Title = "Izmena zahteva za novi lek";
            string temp = request.Content.Replace('|', '\n');
            temp += "\n";
            notification.Content = temp + "\n" + responseTxt.Text.ToUpper();
            notification.notificationType = NotificationType.director;
            notification.Sender = UserType.doctor;

            notificationService.AddNotification(notification);
            requestService.DeleteRequest(request);

            NotificationsWindow notificationsWindow = new NotificationsWindow();
            notificationsWindow.Show();
            this.Close();
        }
    }
}
