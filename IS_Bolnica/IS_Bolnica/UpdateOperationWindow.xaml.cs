using IS_Bolnica.Model;
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
        public List<Room> Rooms
        {
            get;
            set;
        }
        public List<int> RoomId { get; set; } = new List<int>();
        private RoomRepository roomStorage = new RoomRepository();
        public List<int> Hours { get; set; } = new List<int>();
        public List<Doctor> Doctors { get; set; }
        private DoctorRepository doctorStorage = new DoctorRepository();
        private List<string> doctorNameAndSurname = new List<string>();
        private List<Operation> operations = new List<Operation>();
        private OperationsFileStorage operationStorage = new OperationsFileStorage();
        public UpdateOperationWindow(int selectedIndex, List<Operation> loggedDoctorOperations)

        {
            InitializeComponent();

            OperationsFileStorage operationsFileStorage = new OperationsFileStorage();
            Rooms = roomStorage.GetRooms();
            List<Operation> operations = loggedDoctorOperations;

            this.operation = operations.ElementAt(selectedIndex);

            datePicker.SelectedDate = operation.Date;
            hourBox.SelectedItem = operation.Date.Hour;
            minuteBox.SelectedItem = operation.Date.Minute;
            patientTxt.Text = operation.Patient.Name + ' ' + operation.Patient.Surname;
            jmbgTxt.Text = operation.Patient.Id;
            healthCardNumberTxt.Text = operation.Patient.HealthCardNumber;
            doctorsComboBox.SelectedItem = operation.doctor.Name + ' ' + operation.doctor.Surname;

            foreach (Room room in Rooms)
            {
                if (room.roomPurpose.Name.Equals("Operaciona sala"))
                {
                    RoomId.Add(room.Id);
                }
            }

            roomsComboBox.ItemsSource = RoomId;
            roomsComboBox.SelectedItem = operation.Room.Id;

            for (int i = 7; i < 20; i++)
            {
                Hours.Add(i);
            }

            hourBox.ItemsSource = Hours;

            List<int> Minutes = new List<int>();
            Minutes.Add(00);
            Minutes.Add(30);
            minuteBox.ItemsSource = Minutes;

            Doctors = doctorStorage.loadFromFile("Doctors.json");
            string dr;

            foreach (Doctor doctor in Doctors)
            {
                if (doctor.Specialization != null)
                {
                    dr = doctor.Name + ' ' + doctor.Surname;
                    doctorNameAndSurname.Add(dr);
                }
            }

            doctorsComboBox.ItemsSource = doctorNameAndSurname;
            selectedOperation = selectedIndex;
        }

        private void saveButtonClicked(object sender, RoutedEventArgs e)
        {           
            operations = operationStorage.loadFromFile("operations.json");

            List<Patient> patients = new List<Patient>();
            PatientRepository patientStorage = new PatientRepository();

            for (int i = 0; i < operations.Count; i++)
            {
                if (operations[i].Date.Equals(operation.Date) && operations[i].Patient.Id.Equals(operation.Patient.Id))
                {
                    operations.RemoveAt(i);
                }
            }

            patients = patientStorage.LoadFromFile("PatientRecordFileStorage.json");
            Doctors = doctorStorage.loadFromFile("Doctors.json");
            int cnt = 0;
            string[] patientNameAndSurname = patientTxt.Text.Split(' ');

            foreach (Doctor doctor in Doctors)
            {
                string drNameSurname = doctor.Name + ' ' + doctor.Surname;

                if (drNameSurname.Equals(doctorsComboBox.SelectedItem.ToString()))
                {
                    operation.doctor = doctor;
                }
            }

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
                operation.Room = new Room();

                foreach (Room room in Rooms)
                {
                    if (room.Id == Convert.ToInt32(roomsComboBox.SelectedItem))
                    {
                        operation.Room = room;
                    }
                }

                if (isRoomAvailable(operation.Room, operation.Date) && isDoctorAvailable(operation.Date)
                         && isPatientAvailable(operation.Patient, operation.Date))
                {
                    operations.Add(operation);
                    operationStorage.saveToFile(operations, "operations.json");
                }
                else
                {
                    MessageBox.Show("Nije moguce zakazati operaciju u zadatom terminu!");
                }

                DoctorWindow doctorWindow = new DoctorWindow();
                doctorWindow.tabs.SelectedItem = doctorWindow.operationsTab;
                doctorWindow.dataGridOperations.Items.Refresh();
                doctorWindow.Show();
                this.Close();
            }
        }
        private bool isRoomAvailable(Room room, DateTime dateAndTime)
        {
            operations = operationStorage.loadFromFile("operations.json");

            foreach (Operation operation in operations)
            {
                if (operation.Room.Id == room.Id && operation.Date == dateAndTime)
                {
                    return false;
                }
            }

            return true;
        }

        private bool isDoctorAvailable(DateTime dateAndTime)
        {
            operations = operationStorage.loadFromFile("operations.json");

            foreach (Operation operation in operations)
            {
                string drNameSurname = operation.doctor.Name + ' ' + operation.doctor.Surname;

                if (drNameSurname.Equals(doctorsComboBox.SelectedItem.ToString()) && operation.Date.Equals(dateAndTime))
                {
                    return false;
                }
            }

            return true;
        }

        private bool isPatientAvailable(Patient patient, DateTime dateAndTime)
        {
            operations = operationStorage.loadFromFile("operations.json");

            foreach (Operation operation in operations)
            {
                if (operation.Patient.Id == patient.Id && operation.Date == dateAndTime)
                {
                    return false;
                }
            }

            return true;

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