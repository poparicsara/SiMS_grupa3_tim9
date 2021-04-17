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
            roomTxt.Text = operations.ElementAt(selectedIndex).RoomRecord.roomPurpose.Name;
            patientNameTxt.Text = operations.ElementAt(selectedIndex).Patient.Name;
            patientSurnameTxt.Text = operations.ElementAt(selectedIndex).Patient.Surname;

            selectedOperation = selectedIndex;
        }

        private void saveButtonClicked(object sender, RoutedEventArgs e)
        {
            Patient patient = new Patient();
            Operation operation = new Operation();
            RoomRecord room = new RoomRecord();
            RoomPurpose purpose = new RoomPurpose();
            operation.Date = DateTime.Parse(dateTxt.Text);
            patient.Name = patientNameTxt.Text;
            patient.Surname = patientSurnameTxt.Text;
            purpose.Name = roomTxt.Text;
            room.roomPurpose = purpose;

            OperationsFileStorage operationsFileStorage = new OperationsFileStorage();
            List<Operation> operations = operationsFileStorage.loadFromFile("operations.json");
            operations.ElementAt(selectedOperation).Date = operation.Date;
            operations.ElementAt(selectedOperation).RoomRecord.roomPurpose = room.roomPurpose;
            operations.ElementAt(selectedOperation).Patient.Name = patient.Name;
            operations.ElementAt(selectedOperation).Patient.Surname = patient.Surname;

            operationsFileStorage.saveToFile(operations, "operations.json");

            DoctorWindow doctorWindow = new DoctorWindow();
            doctorWindow.dataGridOperations.Items.Refresh();
            doctorWindow.Show();
            this.Close();
        }

        private void cancelButtonClicked(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBox = MessageBox.Show("Are you sure you want to discard your changes?",
                                                "Update operation", MessageBoxButton.YesNo);

            switch (messageBox)
            {
                case MessageBoxResult.Yes:
                    DoctorWindow doctorWindow = new DoctorWindow();
                    doctorWindow.Show();
                    this.Close();
                    break;
                case MessageBoxResult.No:
                    break;
            }
        }
    }
}
