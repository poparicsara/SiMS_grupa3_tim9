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
        private Appointment operation;
        public List<RoomRecord> Rooms { get; set; }
        public List<int> RoomId { get; set; } = new List<int>();
        private RoomRecordFileStorage roomStorage = new RoomRecordFileStorage();
        public List<int> Hours { get; set; } = new List<int>();
        public List<Doctor> Doctors { get; set; }
        private DoctorRepository doctorStorage = new DoctorRepository();
        private List<string> doctorNameAndSurname = new List<string>();
        private List<Appointment> operations = new List<Appointment>();
        private OperationsFileStorage operationStorage = new OperationsFileStorage();
        private AppointmentRepository appointmentRepository = new AppointmentRepository();
        public UpdateOperationWindow(int selectedIndex, List<Appointment> loggedDoctorOperations)

        {
            InitializeComponent();

            Rooms = roomStorage.loadFromFile("Sobe.json");
            List<Appointment> operations = loggedDoctorOperations;

            this.operation = operations.ElementAt(selectedIndex);

            datePicker.SelectedDate = operation.StartTime;
            hourBox.SelectedItem = operation.StartTime.Hour;
            minuteBox.SelectedItem = operation.StartTime.Minute;
            patientTxt.Text = operation.Patient.Name + ' ' + operation.Patient.Surname;
            jmbgTxt.Text = operation.Patient.Id;
            healthCardNumberTxt.Text = operation.Patient.HealthCardNumber;
            doctorsComboBox.SelectedItem = operation.Doctor.Name + ' ' + operation.Doctor.Surname;

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
            operations = appointmentRepository.LoadFromFile("Appointments.json ");

            List<Patient> patients = new List<Patient>();
            PatientRecordFileStorage patientStorage = new PatientRecordFileStorage();

            for (int i = 0; i < operations.Count; i++)
            {
                if (operations[i].StartTime.Equals(operation.StartTime) && operations[i].Patient.Id.Equals(operation.Patient.Id) 
                    && operations[i].AppointmentType == AppointmentType.operation)
                {
                    operations.RemoveAt(i);
                }
            }

            appointmentRepository.SaveToFile(operations, "Appointments.json");

            patients = patientStorage.loadFromFile("PatientRecordFileStorage.json");
            Doctors = doctorStorage.loadFromFile("Doctors.json");
            int cnt = 0;
            string[] patientNameAndSurname = patientTxt.Text.Split(' ');

            foreach (Doctor doctor in Doctors)
            {
                string drNameSurname = doctor.Name + ' ' + doctor.Surname;

                if (drNameSurname.Equals(doctorsComboBox.SelectedItem.ToString()))
                {
                    operation.Doctor = doctor;
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
                operation.StartTime = new DateTime(date.Year, date.Month, date.Day, hour, minute, 0);
                operation.RoomRecord = new RoomRecord();

                foreach (RoomRecord room in Rooms)
                {
                    if (room.Id == Convert.ToInt32(roomsComboBox.SelectedItem))
                    {
                        operation.RoomRecord = room;
                    }
                }

                if (isRoomAvailable(operation.RoomRecord, operation.StartTime) && isDoctorAvailable(operation.StartTime)
                         && isPatientAvailable(operation.Patient, operation.StartTime))
                {
                    operations.Add(operation);
                    appointmentRepository.SaveToFile(operations, "Appointments.json");
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
        private bool isRoomAvailable(RoomRecord room, DateTime dateAndTime)
        {
            operations = appointmentRepository.LoadFromFile("Appointments.json");

            foreach (Appointment operation in operations)
            {
                if (operation.RoomRecord.Id == room.Id && operation.StartTime == dateAndTime)
                {
                    return false;
                }
            }

            return true;
        }

        private bool isDoctorAvailable(DateTime dateAndTime)
        {
            operations = appointmentRepository.LoadFromFile("Appointments.json");

            foreach (Appointment operation in operations)
            {
                string drNameSurname = operation.Doctor.Name + ' ' + operation.Doctor.Surname;

                if (drNameSurname.Equals(doctorsComboBox.SelectedItem.ToString()) && operation.StartTime.Equals(dateAndTime))
                {
                    return false;
                }
            }

            return true;
        }

        private bool isPatientAvailable(Patient patient, DateTime dateAndTime)
        {
            operations = appointmentRepository.LoadFromFile("Appointments.json");

            foreach (Appointment operation in operations)
            {
                if (operation.Patient.Id == patient.Id && operation.StartTime == dateAndTime)
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