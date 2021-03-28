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
    /// <summary>
    /// Interaction logic for AddOperationWindow.xaml
    /// </summary>
    public partial class AddOperationWindow : Window
    {
        public AddOperationWindow()
        {
            InitializeComponent();
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

        private void saveButtonClicked(object sender, RoutedEventArgs e)
        {
            Operation operation = new Operation();
            operation.Date = DateTime.Parse(dateTxt.Text);
            operation.RoomName = roomTxt.Text;
            operation.NameSurname = patientTxt.Text;

            OperationsFileStorage operationsFileStorage = new OperationsFileStorage();
            List<Operation> operations = operationsFileStorage.loadFromFile("operations.json");
            operations.Add(operation);
            operationsFileStorage.saveToFile(operations, "operations.json");

            DoctorWindow doctorWindow = new DoctorWindow();
            doctorWindow.dataGridOperations.Items.Refresh();
            doctorWindow.Show();

            this.Close();
        }
    }
}
