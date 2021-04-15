using Model;
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

namespace IS_Bolnica.DoctorsWindows
{
    public partial class UpdateOperationWindow : Window
    {
        private int selectedOperation;
        public UpdateOperationWindow(int selectedIndex)
        {
            InitializeComponent();

            OperationsFileStorage operationsFileStorage = new OperationsFileStorage();
            List<Operation> operations = operationsFileStorage.loadFromFile("operations.json");

            dateTxt.Text = operations.ElementAt(selectedIndex).Date.ToString();
            roomTxt.Text = operations.ElementAt(selectedIndex).RoomName;
            patientTxt.Text = operations.ElementAt(selectedIndex).NameSurname;

            selectedOperation = selectedIndex;
        }

        private void saveButtonClicked(object sender, RoutedEventArgs e)
        {
            Operation operation = new Operation();
            operation.Date = DateTime.Parse(dateTxt.Text);
            operation.RoomName = roomTxt.Text;
            operation.NameSurname = patientTxt.Text;

            OperationsFileStorage operationsFileStorage = new OperationsFileStorage();
            List<Operation> operations = operationsFileStorage.loadFromFile("operations.json");
            operations.ElementAt(selectedOperation).Date = operation.Date;
            operations.ElementAt(selectedOperation).RoomName = operation.RoomName;
            operations.ElementAt(selectedOperation).NameSurname = operation.NameSurname;

            operationsFileStorage.saveToFile(operations, "operations.json");

            DoctorWindow doctorWindow = new DoctorWindow();
            doctorWindow.dataGridOperations.Items.Refresh();
            doctorWindow.Show();
            this.Close();
        }

        private void cancelButtonClicked(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBox = MessageBox.Show("Are you sure you want to discard your changes?",
                                                "Scheduling", MessageBoxButton.YesNo);

            switch (messageBox)
            {
                case MessageBoxResult.Yes:
                    this.Close();
                    break;
                case MessageBoxResult.No:
                    break;
            }
        }
    }
}
