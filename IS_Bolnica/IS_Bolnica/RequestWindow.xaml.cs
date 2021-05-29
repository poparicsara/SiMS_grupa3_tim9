using IS_Bolnica.Model;
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
    public partial class RequestWindow : Window
    {
        private RequestRepository requestStorage = new RequestRepository();
        private List<Request> requests = new List<Request>();
        public RequestWindow()
        {
            InitializeComponent();

            requests = requestStorage.GetRequests();

            requestData.ItemsSource = requests;
        }

        private void Row_DoubleClik(object sender, MouseButtonEventArgs e)
        {
            Request selectedRequest = (Request)requestData.SelectedItem;
            SelectedRequest selected = new SelectedRequest(selectedRequest);
            selected.Show();
            this.Close();
        }
    }
}
