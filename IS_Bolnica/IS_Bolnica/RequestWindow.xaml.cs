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
        private RequestFileStorage requestStorage = new RequestFileStorage();
        private ObservableCollection<Request> requests = new ObservableCollection<Request>();
        public RequestWindow()
        {
            InitializeComponent();

            requests = requestStorage.LoadFromFile("Zahtevi.json");

            requestData.ItemsSource = requests;
        }
    }
}
