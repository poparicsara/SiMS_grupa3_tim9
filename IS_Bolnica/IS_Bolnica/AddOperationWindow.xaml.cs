using IS_Bolnica.Model;
using Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
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
        public List<RoomRecord> Rooms
        {
            get;
            set;
        }
        public List<int> RoomId { get; set; } = new List<int>();
        private RoomRecordFileStorage roomStorage = new RoomRecordFileStorage();
        public List<Patient> Patients { get; set; } = new List<Patient>();
        private PatientRecordFileStorage patientStorage = new PatientRecordFileStorage();
        public List<int> Hours { get; set; } = new List<int>();
        private List<string> doctorNameAndSurname = new List<string>();
        public List<Doctor> Doctors { get; set; }
        private DoctorRepository doctorStorage = new DoctorRepository();
        private DateTime dateTime;
        private AppointmentRepository appointmentRepository = new AppointmentRepository();
        private Appointment appointment = new Appointment();
        public List<Appointment> Appointments { get; set; }
        public AddOperationWindow()
        {
            InitializeComponent();

            Rooms = roomStorage.loadFromFile("Sobe.json");

            foreach (RoomRecord room in Rooms)
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
            Appointments = appointmentRepository.LoadFromFile("Appointments.json");
            Patients = patientStorage.loadFromFile("PatientRecordFileStorage.json");
            Doctors = doctorStorage.loadFromFile("Doctors.json");

            string[] patientNameAndSurname = patientTxt.Text.Split(' ');
            int cnt = 0;

            foreach (Doctor doctor in Doctors)
            {
                string drNameSurname = doctor.Name + ' ' + doctor.Surname;

                if (drNameSurname.Equals(doctorsComboBox.SelectedItem.ToString()))
                {
                    appointment.Doctor = doctor;
                }
            }

            foreach (Patient patient in Patients)
            {
                if (patient.Id.Equals(jmbgTxt.Text))
                {
                    appointment.Patient = patient;
                    cnt++;
                }
            }

            if ((patientNameAndSurname[0] != appointment.Patient.Name) || (patientNameAndSurname[1] != appointment.Patient.Surname))
            {
                MessageBox.Show("Pogresno ime ili prezime!");
            }
            else if (cnt == 0)
            {
                MessageBox.Show("Pacijent sa unetim JMBG-om ne postoji!");
            }
            else
            {
                appointment.RoomRecord = new RoomRecord();

                foreach (RoomRecord room in Rooms)
                {
                    if (room.Id == Convert.ToInt32(roomComboBox.SelectedItem))
                    {
                        appointment.RoomRecord = room;
                    }
                }

                if (urgentRadioBtn.IsChecked == true)
                {
                    appointment.IsUrgent = true;
                }
                else
                {
                    appointment.IsUrgent = false;
                }

                DateTime date = new DateTime();
                date = (DateTime)datePicker.SelectedDate;
                int hour = Convert.ToInt32(hourBox.Text);
                int minute = Convert.ToInt32(minuteBox.Text);
                dateTime = new DateTime(date.Year, date.Month, date.Day, hour, minute, 0);
                appointment.AppointmentType = AppointmentType.operation;

                if (urgentRadioBtn.IsChecked == true)
                {
                    foreach (Appointment a in Appointments)
                    {
                        if (dateTime == a.StartTime && a.AppointmentType == AppointmentType.operation)
                        {
                            a.StartTime = a.StartTime.AddDays(1);
                            break;
                        }
                    }
                    appointment.StartTime = dateTime;

                }
                else
                {
                    appointment.StartTime = dateTime;
                }

                if (isRoomAvailable(appointment.RoomRecord, appointment.StartTime) && isDoctorAvailable(appointment.Doctor, appointment.StartTime)                  
                    && isPatientAvailable(appointment.Patient, appointment.StartTime))
                {
                    Appointments.Add(appointment);
                    appointmentRepository.SaveToFile(Appointments, "Appointments.json");
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
            Appointments = appointmentRepository.LoadFromFile("Appointments.json");

            foreach (Appointment appointment in Appointments)
            {
                if (appointment.StartTime == dateAndTime && appointment.RoomRecord.Id == room.Id && urgentRadioBtn.IsChecked == false)
                {
                    return false;
                }
            }

            return true;
        }

        private bool isDoctorAvailable(Doctor doctor, DateTime dateAndTime)
        {
            Appointments = appointmentRepository.LoadFromFile("Appointments.json");

            foreach (Appointment appointment in Appointments)
            {
                string drNameSurname = doctor.Name + ' ' + doctor.Surname;
                if (drNameSurname.Equals(doctorsComboBox.SelectedItem.ToString()) &&
                    appointment.StartTime.Equals(dateAndTime) && urgentRadioBtn.IsChecked == false)
                {
                    return false;
                }
            }

            return true;
        }

        private bool isPatientAvailable(Patient patient, DateTime dateAndTime)
        {
            Appointments = appointmentRepository.LoadFromFile("Appointments.json");
            foreach (Appointment appointment in Appointments)
            {
                if (appointment.Patient.Id == patient.Id && appointment.StartTime == dateAndTime && urgentRadioBtn.IsChecked == false)
                {
                    return false;
                }
            }

            return true;
        }

        private void jmbgTxt_LostFocus(object sender, RoutedEventArgs e)
        {
            Patients = patientStorage.loadFromFile("PatientRecordFileStorage.json");

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
