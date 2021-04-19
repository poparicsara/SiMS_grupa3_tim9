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
    /// Interaction logic for AddOperationWindow.xaml
    /// </summary>
    public partial class AddOperationWindow : Window
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
        private ObservableCollection<Patient> Patients = new ObservableCollection<Patient>();
        private PatientRecordFileStorage patientStorage = new PatientRecordFileStorage();


        public AddOperationWindow()
        {
            InitializeComponent();
            Rooms = roomStorage.loadFromFile("Sobe.json");
            for (int i = 0; i < Rooms.Count; i++)
            {
                if (Rooms[i].roomPurpose.Name == "Operaciona sala")
                {
                    RoomNums.Add(Rooms[i].Id);
                }
            }
            roomBox.ItemsSource = RoomNums;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Secretary.ActionBarWindow abw = new Secretary.ActionBarWindow();
            abw.Show();
            this.Close();
        }

        private void addOperation(object sender, RoutedEventArgs e)
        {
            Operations = operationStorage.loadFromFile("operations.json");

            //System.Collections.IList items = (System.Collections.IList)doctorList.SelectedItems;
            //var doctors = items.Cast<string>().ToList();
            //for(int i = 0; i < doctors.Count; i++)
            //{
            // string[] docNameAndSurname = doctors[i].Split(' '); 
            // Doctor doc = new Doctor();
            // doc.Name = docNameAndSurname[0];
            // doc.Surname = docNameAndSurname[1];
            // operation.doctor.Add(doc);
            // }


            string[] doctorNameAndSurname = doctorBox.Text.Split(' ');
            Doctor doctor = new Doctor();
            doctor.Name = doctorNameAndSurname[0];
            doctor.Surname = doctorNameAndSurname[1];
            operation.doctor = doctor;


            Patients = patientStorage.loadFromFile("PatientRecordFileStorage.json");
            int brojac = 0;
            for(int i = 0; i < Patients.Count; i++)
            {
                if(Patients[i].Id.Equals(patientId.Text))
                {
                    operation.Patient = Patients[i];
                    brojac++;
                }
            }
            if (brojac == 0)
            {
                MessageBox.Show("Pacijent sa ovim JMBG-om ne postoji!");
            }

            DateTime datum = new DateTime();
            datum = (DateTime)dateBox.SelectedDate;
            int sat = Convert.ToInt32(hourBox.Text);
            int minut = Convert.ToInt32(minuteBox.Text);
            operation.Date = new DateTime(datum.Year, datum.Month, datum.Day,sat, minut, 0);

            operation.RoomRecord = new RoomRecord();
            for(int i = 0; i < Rooms.Count; i++)
            {
                if(Rooms[i].Id == Convert.ToInt32(roomBox.SelectedItem))
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

        private void cancelAddingOperation(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
