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
using IS_Bolnica.Model;
using IS_Bolnica.Services;
using Model;

namespace IS_Bolnica.DoctorUI
{
    public partial class NotificationsWindow : Window
    {
        private UserService userService = new UserService();
        private RequestRepository requestRepository = new RequestRepository();
        private List<Request> requests = new List<Request>(); 
        public List<Notification> Notifications { get; set; }
        private Model.NotificationRepository storage = new NotificationRepository();
        //private User doctor = new User();
        public NotificationsWindow()
        {
            InitializeComponent();
            this.requests = requestRepository.GetRequests();
            //this.doctor = user;
            requestsDataGrid.ItemsSource = requests;

            //Notifications = new List<Notification>();

            //List<Notification> notifications = storage.LoadFromFile();

            //foreach (Notification notification in notifications)
            //{
            //    if (notification.notificationType == NotificationType.all)
            //    {
            //        Notifications.Add(notification);
            //    }

            //    if (notification.notificationType == NotificationType.doctor)
            //    {
            //        Notifications.Add(notification);

            //    }

            //    if (notification.PersonId != null && notification.notificationType == NotificationType.specific)
            //    {
            //        foreach (string id in notification.PersonId)
            //        {
            //            if (id.Equals(doctor.Id))
            //            {
            //                Notifications.Add(notification);
            //            }
            //        }
            //    }
            //}

           // notificationsDataGrid.ItemsSource = Notifications;
        }
        private void RowDoubleClik(object sender, MouseButtonEventArgs e)
        {
            Request selectedRequest = (Request)requestsDataGrid.SelectedItem;
            ReviewMedRequestWindow reviewMedRequest = new ReviewMedRequestWindow(selectedRequest);
            reviewMedRequest.Show();
            this.Close();
        }

        private void ExaminationButtonClick(object sender, RoutedEventArgs e)
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
            this.Show();
        }

        private void StatisticsButtonClick(object sender, RoutedEventArgs e)
        {
            ChartWindow chartWindow = new ChartWindow();
            chartWindow.Show();
            this.Close();
        }

        private void SingOutButtonClick(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBox = MessageBox.Show("Da li ste sigurni da želite da se odjavite?",
                "Odjavljivanje", MessageBoxButton.YesNo);

            switch (messageBox)
            {
                case MessageBoxResult.Yes:
                    userService.LogOut();
                    this.Close();
                    break;
                case MessageBoxResult.No:
                    break;
            }
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
    }
}
