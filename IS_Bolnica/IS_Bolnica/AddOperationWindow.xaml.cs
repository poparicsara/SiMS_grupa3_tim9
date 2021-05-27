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
    public partial class AddOperationWindow : Window
    {
        public List<Room> Rooms
        {
            get;
            set;
        }
        public List<int> RoomId { get; set; } = new List<int>();
        private RoomRepository roomStorage = new RoomRepository();
        private Operation operation = new Operation();
        private OperationsFileStorage operationStorage = new OperationsFileStorage();
        public List<Operation> Operations { get; set; } = new List<Operation>();
        public List<Patient> Patients { get; set; } = new List<Patient>();
        private PatientRepository patientStorage = new PatientRepository();
        public List<int> Hours { get; set; } = new List<int>();
        private List<string> doctorNameAndSurname = new List<string>();
        public List<Doctor> Doctors { get; set; }
        private DoctorRepository doctorStorage = new DoctorRepository();
        private DateTime dateTime;

        public List<Operation> NonUrgentOperations { get; set; }
        public AddOperationWindow()
        {
            InitializeComponent();

            Rooms = roomStorage.GetRooms();

            foreach (Room room in Rooms)
            {
                if (room.roomPurpose.Name.Equals("Operaciona sala"))
                {
                    RoomId.Add(room.Id);
                }
            }

            roomComboBox.ItemsSource = RoomId;

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
        }

        private void cancelButtonClicked(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBox = MessageBox.Show("Are you sure you want to discard your changes?",
                "Scheduling", MessageBoxButton.YesNo);

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

        private void saveButtonClicked(object sender, RoutedEventArgs e)
        {
            Operations = operationStorage.loadFromFile("operations.json");
            Patients = patientStorage.LoadFromFile("PatientRecordFileStorage.json");
            Doctors = doctorStorage.loadFromFile("Doctors.json");
            NonUrgentOperations = operationStorage.loadFromFile("operations.json");

            string[] patientNameAndSurname = patientTxt.Text.Split(' ');
            int cnt = 0;

            foreach (Doctor doctor in Doctors)
            {
                string drNameSurname = doctor.Name + ' ' + doctor.Surname;

                if (drNameSurname.Equals(doctorsComboBox.SelectedItem.ToString()))
                {
                    operation.doctor = doctor;
                }
            }

            foreach (Patient patient in Patients)
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
                operation.Room = new Room();

                foreach (Room room in Rooms)
                {
                    if (room.Id == Convert.ToInt32(roomComboBox.SelectedItem))
                    {
                        operation.Room = room;
                    }
                }

                if (urgentRadioBtn.IsChecked == true)
                {
                    operation.IsUrgent = true;
                }
                else
                {
                    operation.IsUrgent = false;
                }

                DateTime date = new DateTime();
                date = (DateTime)datePicker.SelectedDate;
                int hour = Convert.ToInt32(hourBox.Text);
                int minute = Convert.ToInt32(minuteBox.Text);
                dateTime = new DateTime(date.Year, date.Month, date.Day, hour, minute, 0);

                if (urgentRadioBtn.IsChecked == true)
                {
                    foreach (Operation o in Operations)
                    {
                        if (dateTime == o.Date)
                        {
                            o.Date = o.Date.AddDays(1);
                        }
                    }

                    operation.Date = dateTime;
                }
                else
                {
                    operation.Date = dateTime;
                }

                //Operations.Add(operation); 
                //operationStorage.SaveToFile(Operations, "operations.json");

                if (isRoomAvailable(Operations, operation.Room, operation.Date) && isDoctorAvailable(Operations, operation.doctor, operation.Date)
                    && isPatientAvailable(Operations, operation.Patient, operation.Date))
                {
                    Operations.Add(operation);
                    operationStorage.saveToFile(Operations, "operations.json");
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

        private bool isRoomAvailable(List<Operation> operations, Room room, DateTime dateAndTime)
        {
            foreach (Operation operation in operations)
            {
                if (operation.Room.Id == room.Id && operation.Date == dateAndTime && operation.IsUrgent == false)
                {
                    return false;
                }
            }

            return true;
        }

        private bool isDoctorAvailable(List<Operation> operations, Doctor doctor, DateTime dateAndTime)
        {
            foreach (Operation operation in operations)
            {
                string drNameSurname = doctor.Name + ' ' + doctor.Surname;

                if (drNameSurname.Equals(doctorsComboBox.SelectedItem.ToString()) && operation.Date.Equals(dateAndTime) && operation.IsUrgent == false)
                {
                    return false;
                }
            }

            return true;
        }

        private bool isPatientAvailable(List<Operation> operations, Patient patient, DateTime dateAndTime)
        {
            foreach (Operation operation in operations)
            {
                if (operation.Patient.Id == patient.Id && operation.Date == dateAndTime && operation.IsUrgent == false)
                {
                    return false;
                }
            }

            return true;
        }

        private void jmbgTxt_LostFocus(object sender, RoutedEventArgs e)
        {
            Patients = patientStorage.LoadFromFile("PatientRecordFileStorage.json");

            foreach (Patient patient in Patients)
            {
                if (jmbgTxt.Text.Equals(patient.Id))
                {
                    healthCardNumberTxt.Text = patient.HealthCardNumber;
                }
            }
        }
    }
}
