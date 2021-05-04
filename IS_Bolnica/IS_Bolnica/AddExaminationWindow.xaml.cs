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
    public partial class AddExaminationWindow : Window
    {
        public List<RoomRecord> Rooms
        {
            get;
            set;
        }
        public List<int> RoomId { get; set; } = new List<int>();
        private RoomRecordFileStorage roomStorage = new RoomRecordFileStorage();
        private Examination examination = new Examination();
        private ExaminationsRecordFileStorage examinationStorage = new ExaminationsRecordFileStorage();
        public List<Examination> Examinations { get; set; } = new List<Examination>();
        public List<Patient> Patients { get; set; } = new List<Patient>();
        private PatientRecordFileStorage patientStorage = new PatientRecordFileStorage();
        public List<int> Hours { get; set; } = new List<int>();
        public List<Doctor> Doctors { get; set; }
        private DoctorFileStorage doctorStorage = new DoctorFileStorage();
        private List<string> doctorNameAndSurname = new List<string>();
        private List<string> specialistNameAndSurname = new List<string>();
        public AddExaminationWindow()
        {
            InitializeComponent();

            Rooms = roomStorage.loadFromFile("Sobe.json");

            foreach (RoomRecord room in Rooms)
            {
                if (room.roomPurpose.Name == "Ordinacija")
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
        }

        private void cancelButtonClicked(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBox = MessageBox.Show("Are you sure you want to discard your changes?",
                "Scheduling", MessageBoxButton.YesNo);

            switch(messageBox)
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
            Examinations = examinationStorage.loadFromFile("examinations.json");
            Patients = patientStorage.loadFromFile("PatientRecordFileStorage.json");
            Doctors = doctorStorage.loadFromFile("Doctors.json");

            int cnt = 0;
            string[] patientNameAndSurname = patientTxt.Text.Split(' ');

            foreach (Doctor doctor in Doctors)
            {
                string drNameSurname = doctor.Name + ' ' + doctor.Surname;

                if (drNameSurname.Equals(doctorsComboBox.SelectedItem.ToString()))
                {
                    examination.Doctor = doctor;
                }
            }

            foreach (Patient patient in Patients)
            {
                if (patient.Id.Equals(jmbgTxt.Text))
                {
                    examination.Patient = patient;
                    cnt++;
                }
            }

            if ((patientNameAndSurname[0] != examination.Patient.Name) || (patientNameAndSurname[1] != examination.Patient.Surname))
            {
                MessageBox.Show("Pogresno ime ili prezime!");
            } 
            else if (cnt == 0)
            {
                MessageBox.Show("Pacijent sa ovim JMBG-om ne postoji!");
            } else
            {
                DateTime date = new DateTime();
                date = (DateTime)datePicker.SelectedDate;
                int hour = Convert.ToInt32(hourBox.Text);
                int minute = Convert.ToInt32(minuteBox.Text);
                examination.Date = new DateTime(date.Year, date.Month, date.Day, hour, minute, 0);
                examination.RoomRecord = new RoomRecord();

                foreach (RoomRecord room in Rooms)
                {
                    if (room.Id == Convert.ToInt32(roomComboBox.SelectedItem))
                    {
                        examination.RoomRecord = room;
                    }
                }

                if (isRoomAvailable(Examinations, examination.RoomRecord, examination.Date) && isDoctorAvailable(Examinations, examination.Doctor, examination.Date)
                    && isPatientAvailable(Examinations, examination.Patient, examination.Date))
                {
                    Examinations.Add(examination);
                    examinationStorage.saveToFile(Examinations, "examinations.json");
                } 
                else
                {
                    MessageBox.Show("Nije moguce zakazati pregled u zadatom terminu!");
                }

                DoctorWindow doctorWindow = new DoctorWindow();
                doctorWindow.dataGridExaminations.Items.Refresh();
                doctorWindow.Show();

                this.Close();
            }
        }

        // da li je nesto vec zakazano u tom terminu
        //private bool isAppointmentAvailable(List<Examination> examinations, DateTime dateAndTime)   
        //{
        //    foreach (Examination examination in examinations)
        //    {
        //        if (examination.Date == dateAndTime)
        //        {
        //            return false;
        //        }
        //    }

        //    return true;
        //}

        // da li je nesto vec zakazano u toj sobi u tom terminu
        private bool isRoomAvailable(List<Examination> examinations, RoomRecord room, DateTime dateAndTime)   
        {
            foreach (Examination examination in examinations)
            {
                if (examination.RoomRecord.Id == room.Id && examination.Date == dateAndTime)
                {
                    return false;
                }
            }

            return true;
        }

        // da li je izabrani lekar slobodan u tom terminu
        private bool isDoctorAvailable(List<Examination> examinations, Doctor doctor, DateTime dateAndTime) 
        {
            foreach (Examination examination in examinations)
            {
                string drNameSurname = doctor.Name + ' ' + doctor.Surname;

                if (drNameSurname.Equals(doctorsComboBox.SelectedItem.ToString()) && examination.Date.Equals(dateAndTime))
                {
                    return false;
                }
            }

            return true;
        }

        // da li je pacijent slobodan u tom terminu
        private bool isPatientAvailable(List<Examination> examinations, Patient patient, DateTime dateAndTime)
        {
            foreach (Examination examination in examinations)
            {
                if (examination.Patient.Id == patient.Id && examination.Date == dateAndTime)
                {
                    return false;
                }
            }

            return true;
        }

        private void specijalistiRadioBtn_Checked(object sender, RoutedEventArgs e)
        {
            Doctors = doctorStorage.loadFromFile("Doctors.json");
            string dr;

            foreach (Doctor doctor in Doctors)
            {
                if (doctor.Specialization != null)
                {
                    dr = doctor.Name + ' ' + doctor.Surname;
                    specialistNameAndSurname.Add(dr);
                }
            }

            doctorsComboBox.ItemsSource = specialistNameAndSurname;
        }

        private void opstaPraksaRadioBtn_Checked(object sender, RoutedEventArgs e)
        {
            Doctors = doctorStorage.loadFromFile("Doctors.json");
            string dr;

            foreach (Doctor doctor in Doctors)
            {
                if (doctor.Specialization == null)
                {
                    dr = doctor.Name + ' ' + doctor.Surname;
                    doctorNameAndSurname.Add(dr);
                }
            }

            doctorsComboBox.ItemsSource = doctorNameAndSurname;
        }

        private void opstaPraksaRadioBtn_Unchecked(object sender, RoutedEventArgs e)
        {
            Doctors = doctorStorage.loadFromFile("Doctors.json");
            string dr;

            foreach (Doctor doctor in Doctors)
            {
                if (doctor.Specialization == null)
                {
                    dr = doctor.Name + ' ' + doctor.Surname;
                    doctorNameAndSurname.Remove(dr);
                }
            }

            doctorsComboBox.ItemsSource = doctorNameAndSurname;
        }

        private void specijalistiRadioBtn_Unchecked(object sender, RoutedEventArgs e)
        {
            Doctors = doctorStorage.loadFromFile("Doctors.json");
            string dr;

            foreach (Doctor doctor in Doctors)
            {
                if (doctor.Specialization != null)
                {
                    dr = doctor.Name + ' ' + doctor.Surname;
                    specialistNameAndSurname.Remove(dr);
                }
            }

            doctorsComboBox.ItemsSource = specialistNameAndSurname;
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
