using Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        private List<Operation> Operations { get; set; } = new List<Operation>();
        private OperationsFileStorage operationsFileStorage = new OperationsFileStorage();
        private Operation operation = new Operation();
     
        public event PropertyChangedEventHandler PropertyChanged;

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        public OperationListWindow()
        {
            InitializeComponent();
            this.DataContext = this;

            Operations = operationsFileStorage.loadFromFile("operations.json");
            OperationList.ItemsSource = Operations;

        }

        private void addOperation(object sender, RoutedEventArgs e)
        {
            Secretary.AddOperationWindow aow = new Secretary.AddOperationWindow();
            aow.Show();
            this.Close();
        }

        private void editOperation(object sender, RoutedEventArgs e)
        {
            int i = -1;
            i = OperationList.SelectedIndex;

            operation = (Operation)OperationList.SelectedItem;

            if(i == -1)
            {
                MessageBox.Show("Niste izabrali operaciju koju želite da izmenite!");
            }
            else
            {
                Secretary.EditOperationWindow eow = new Secretary.EditOperationWindow(operation);
                Operations = operationsFileStorage.loadFromFile("operations.json");

                eow.patientId.Text = operation.Patient.Id;
                eow.hourBoxStart.Text = operation.Date.Hour.ToString();
                eow.minutesBoxStart.Text = operation.Date.Minute.ToString();
                eow.doctorBox.Text = operation.doctor.Name + " " + operation.doctor.Surname;
                eow.date.SelectedDate = new DateTime(operation.Date.Year, operation.Date.Month, operation.Date.Day);
                eow.room.Text = operation.RoomRecord.Id.ToString();
                eow.hourBoxEnd.Text = (operation.endTime.Hour - operation.Date.Hour).ToString();
                eow.minuteBoxEnd.Text = (Math.Abs(operation.endTime.Minute - operation.Date.Minute)).ToString();

                eow.Show();
                this.Close();
            }
      
        }

        private void deleteOperation(object sender, RoutedEventArgs e)
        {
            int i = -1;
            i = OperationList.SelectedIndex;

            operation = (Operation)OperationList.SelectedItem;

            if(i == -1)
            {
                MessageBox.Show("Niste izabrali operaciju koju želita da obrišete!");
            }
            else
            {
                MessageBoxResult result = MessageBox.Show("Da li stvarno želite da obrišete datu operaciju?", "Brisanje operacije", MessageBoxButton.YesNo);
                switch(result)
                {
                    case MessageBoxResult.Yes:
                        Operations = operationsFileStorage.loadFromFile("operations.json");
                        for(int k = 0; k < Operations.Count; k++)
                        {
                            if(Operations[k].Date.Equals(operation.Date) &&
                                Operations[k].Patient.Id.Equals(operation.Patient.Id))
                            {
                                Operations.RemoveAt(k);
                            }
                        }
                        operationsFileStorage.saveToFile(Operations, "operations.json");
                        this.Close();
                        Secretary.OperationListWindow olw = new Secretary.OperationListWindow();
                        olw.Show();
                        break;
                    case MessageBoxResult.No:
                        break;
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Secretary.ActionBarWindow abw = new Secretary.ActionBarWindow();
            abw.Show();
            this.Close();
        }
    }
}
