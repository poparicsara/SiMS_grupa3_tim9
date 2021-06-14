using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using IS_Bolnica.DoctorUI;
using IS_Bolnica.GUI.Doctor.ViewModel;
using IS_Bolnica.Model;
using IS_Bolnica.Services;
using Model;

namespace IS_Bolnica.GUI.Doctor.View
{
    public partial class NotificationsWindow : Window
    {
        public NotificationsWindow()
        {
            InitializeComponent();
            DataContext = new NotificationsWindowVM();
        }
        private void RowDoubleClik(object sender, MouseButtonEventArgs e)
        {
            Request selectedRequest = (Request)requestsDataGrid.SelectedItem;
            ReviewMedRequestWindow reviewMedRequest = new ReviewMedRequestWindow(selectedRequest);
            reviewMedRequest.Show();
            this.Close();
        }
    }
}
