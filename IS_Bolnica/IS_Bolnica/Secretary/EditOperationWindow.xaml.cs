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

namespace IS_Bolnica.Secretary
{
    /// <summary>
    /// Interaction logic for EditOperationWindow.xaml
    /// </summary>
    public partial class EditOperationWindow : Window
    {
        public List<RoomRecord> Rooms
        {
            get;
            set;
        }
        public List<int> RoomNums { get; set; } = new List<int>();
        private RoomRecordFileStorage roomStorage = new RoomRecordFileStorage();
        private Operation operation = new Operation();
        private List<Operation> Operations = new List<Operation>();
        private OperationsFileStorage operationStorage = new OperationsFileStorage();
        private ObservableCollection<Patient> patients = new ObservableCollection<Patient>();
        private PatientRecordFileStorage patientStorage = new PatientRecordFileStorage();

        public EditOperationWindow(Operation operation)
        {
            InitializeComponent();

            this.operation = operation;

            Rooms = roomStorage.loadFromFile("Sobe.json");
            for (int i = 0; i < Rooms.Count; i++)
            {
                if (Rooms[i].roomPurpose.Name == "Operaciona sala")
                {
                    RoomNums.Add(Rooms[i].Id);
                }
            }
            room.ItemsSource = RoomNums;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void editOperation(object sender, RoutedEventArgs e)
        {
            Operations = operationStorage.loadFromFile("operations.json");
            for (int i = 0; i < Operations.Count; i++)
            {
                if (Operations[i].Date.Equals(operation.Date) &&
                    Operations[i].Patient.Id.Equals(operation.Patient.Id))
                {
                    Operations.RemoveAt(i);
                }
            }

            patients = patientStorage.loadFromFile("PatientRecordFileStorage.json");
            int brojac = 0;
            for(int i = 0; i < patients.Count; i++)
            {
                if(patients[i].Id.Equals(patientId.Text))
                {
                    operation.Patient = patients[i];
                    brojac++;
                }
            }
            if (brojac == 0)
            {
                MessageBox.Show("Pacijent sa ovim JMBG-om ne postoji!");
            }

            string[] doctorNameAndSurname = doctorBox.Text.Split(' ');
            operation.doctor = new Doctor();
            operation.doctor.Name = doctorNameAndSurname[0];
            operation.doctor.Surname = doctorNameAndSurname[1];

            DateTime datum = new DateTime();
            datum = (DateTime)date.SelectedDate;
            int sat = Convert.ToInt32(hour.Text);
            int minut = Convert.ToInt32(minutes.Text);
            operation.Date = new DateTime(datum.Year, datum.Month, datum.Day, sat, minut, 0);

            operation.RoomRecord = new RoomRecord();
            for(int i = 0; i < Rooms.Count; i++)
            {
                if(Rooms[i].Id == Convert.ToInt32(room.SelectedItem))
                {
                    operation.RoomRecord = Rooms[i];
                }
            }

            Operations.Add(operation);
            operationStorage.saveToFile(Operations, "operations.json");


            Secretary.OperationListWindow olw = new Secretary.OperationListWindow();
            olw.Show();
            this.Close();
        }

        private void cancelEditingOperation(object sender, RoutedEventArgs e)
        {
            Secretary.OperationListWindow olw = new Secretary.OperationListWindow();
            olw.Show();
            this.Close();
        }
    }
}
