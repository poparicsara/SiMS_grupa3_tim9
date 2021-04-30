using Model;
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

namespace IS_Bolnica.DoctorsWindows
{
    public partial class UpdateOperationWindow : Window
    {
        private int selectedOperation;
        private Operation operation;
        public List<RoomRecord> Rooms
        {
            get;
            set;
        }
        public List<int> RoomId { get; set; } = new List<int>();
        private RoomRecordFileStorage roomStorage = new RoomRecordFileStorage();
        public List<int> Hours { get; set; } = new List<int>();
        public UpdateOperationWindow(int selectedIndex)
        {
            InitializeComponent();

            OperationsFileStorage operationsFileStorage = new OperationsFileStorage();
            List<Operation> operations = operationsFileStorage.loadFromFile("operations.json");
            Rooms = roomStorage.loadFromFile("Sobe.json");

            this.operation = operations.ElementAt(selectedIndex);

            datePicker.SelectedDate = operation.Date;
            patientTxt.Text = operation.Patient.Name + ' ' + operation.Patient.Surname;
            jmbgTxt.Text = operation.Patient.Id;

            foreach (RoomRecord room in Rooms)
            {
                if (room.roomPurpose.Name.Equals("Operaciona sala")) 
                {
                    RoomId.Add(room.Id);
                }
            }

            roomsComboBox.ItemsSource = RoomId;
            roomsComboBox.SelectedItem = operation.RoomRecord.Id;

            for (int i = 7; i < 20; i++)
            {
                Hours.Add(i);
            }

            hourBox.ItemsSource = Hours;

            selectedOperation = selectedIndex;
        }

        private void saveButtonClicked(object sender, RoutedEventArgs e)
        {
            OperationsFileStorage operationStorage = new OperationsFileStorage();
            List<Operation> operations = operationStorage.loadFromFile("operations.json");

            ObservableCollection<Patient> patients = new ObservableCollection<Patient>();
            PatientRecordFileStorage patientStorage = new PatientRecordFileStorage();

            for (int i = 0; i < operations.Count; i++)
            {
                if (operations[i].Date.Equals(operation.Date) && operations[i].Patient.Id.Equals(operation.Patient.Id))
                {
                    operations.RemoveAt(i);
                }
            }

            patients = patientStorage.loadFromFile("PatientRecordFileStorage.json");
            int cnt = 0;
            string[] patientNameAndSurname = patientTxt.Text.Split(' ');

            foreach (Patient patient in patients)
            {
                if (patient.Id.Equals(jmbgTxt.Text))
                {
                    operation.Patient = patient;
                    cnt++;
                }
            }

            if ((patientNameAndSurname[0] != operation.Patient.Name) || (patientNameAndSurname[1] != operation.Patient.Surname))
            {
                MessageBox.Show("Pogresno ime ili prezime!");
            }
            else if (cnt == 0)
            {
                MessageBox.Show("Pacijent sa unetim JMBG-om ne postoji!");
            }
            else
            {
                DateTime date = new DateTime();
                date = (DateTime)datePicker.SelectedDate;
                int hour = Convert.ToInt32(hourBox.Text);
                int minute = Convert.ToInt32(minuteBox.Text);
                operation.Date = new DateTime(date.Year, date.Month, date.Day, hour, minute, 0);
                operation.RoomRecord = new RoomRecord();

                foreach (RoomRecord room in Rooms)
                {
                    if (room.Id == Convert.ToInt32(roomsComboBox.SelectedItem))
                    {
                        operation.RoomRecord = room;
                    }
                }

                operations.Add(operation);
                operationStorage.saveToFile(operations, "operations.json");

                DoctorWindow doctorWindow = new DoctorWindow();
                doctorWindow.tabs.SelectedItem = doctorWindow.operationsTab;
                doctorWindow.dataGridOperations.Items.Refresh();
                doctorWindow.Show();
                this.Close();
            }
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
