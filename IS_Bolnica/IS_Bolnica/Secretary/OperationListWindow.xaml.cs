using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace IS_Bolnica.Secretary
{
    /// <summary>
    /// Interaction logic for OperationListWindow.xaml
    /// </summary>
    public partial class OperationListWindow : Window, INotifyPropertyChanged
    {
        List<Operation> Operacije { get; set; }
        OperationsFileStorage operationsFileStorage = new OperationsFileStorage();

        public event PropertyChangedEventHandler PropertyChanged;

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        public OperationListWindow()
        {
            InitializeComponent();
            this.DataContext = this;

            Operacije = operationsFileStorage.loadFromFile("operations.json");
            OperationList.ItemsSource = Operacije;

        }

        private void addOperation(object sender, RoutedEventArgs e)
        {
            Secretary.AddOperationWindow aow = new Secretary.AddOperationWindow();
            aow.Show();
            this.Close();
        }

        private void editOperation(object sender, RoutedEventArgs e)
        {

        }

        private void deleteOperation(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Secretary.ActionBarWindow abw = new Secretary.ActionBarWindow();
            abw.Show();
            this.Close();
        }
    }
}
