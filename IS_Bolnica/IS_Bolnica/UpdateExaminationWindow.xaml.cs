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
    public partial class UpdateExaminationWindow : Window
    {
        private int selectedExamination;
        private Examination examination;
        public List<RoomRecord> Rooms
        {
            get;
            set;
        }
        public List<int> RoomId { get; set; } = new List<int>();
        private RoomRecordFileStorage roomStorage = new RoomRecordFileStorage();
        public List<int> Hours { get; set; } = new List<int>();
        public List<Doctor> Doctors { get; set; }
        private DoctorFileStorage doctorStorage = new DoctorFileStorage();
        private List<string> doctorNameAndSurname = new List<string>();
        private List<string> specialistNameAndSurname = new List<string>();
        public UpdateExaminationWindow(int selectedIndex, List<Examination> loggedDoctorExaminations)
        {
            InitializeComponent();

            ExaminationsRecordFileStorage examinationsRecordFileStorage = new ExaminationsRecordFileStorage();
            List<Examination> examinations = loggedDoctorExaminations;

            this.examination = examinations.ElementAt(selectedIndex);

            datePicker.SelectedDate = examination.Date;
            hourBox.SelectedItem = examination.Date.Hour;
            minuteBox.SelectedItem = examination.Date.Minute;
            patientTxt.Text = examination.Patient.Name + ' ' + examination.Patient.Surname;
            jmbgTxt.Text = examination.Patient.Id;
            healthCardNumberTxt.Text = examination.Patient.HealthCardNumber;

            Rooms = roomStorage.loadFromFile("Sobe.json");

            foreach (RoomRecord room in Rooms)
            {
                if (room.roomPurpose.Name.Equals("Ordinacija"))
                {
                    RoomId.Add(room.Id);
                }
            }

            roomComboBox.ItemsSource = RoomId;
            roomComboBox.SelectedItem = examination.RoomRecord.Id;

            if (examination.Doctor.Specialization == null)
            {
                opstaPraksaRadioBtn.IsChecked = true;
                specijalistiRadioBtn.IsChecked = false;
                doctorsComboBox.SelectedItem = examination.Doctor.Name + ' ' + examination.Doctor.Surname;
            }
            if (examination.Doctor.Specialization != null)
            {
                specijalistiRadioBtn.IsChecked = true;
                opstaPraksaRadioBtn.IsChecked = false;
                doctorsComboBox.SelectedItem = examination.Doctor.Name + ' ' + examination.Doctor.Surname;
            }

            for (int i = 7; i < 20; i++)
            {
                Hours.Add(i);
            }

            hourBox.ItemsSource = Hours;

            List<int> Minutes = new List<int>();
            Minutes.Add(00);
            Minutes.Add(30);
            minuteBox.ItemsSource = Minutes;

            selectedExamination = selectedIndex;
        }

        private void saveButtonClicked(object sender, RoutedEventArgs e)
        {
            ExaminationsRecordFileStorage examinationsRecordFileStorage = new ExaminationsRecordFileStorage();
            List<Examination> examinations = examinationsRecordFileStorage.loadFromFile("examinations.json");

            ObservableCollection<Patient> Patients = new ObservableCollection<Patient>();
            PatientRecordFileStorage patientStorage = new PatientRecordFileStorage();

            List<Doctor> doctors = new List<Doctor>();
            DoctorFileStorage doctorStorage = new DoctorFileStorage();

            for (int i = 0; i < examinations.Count; i++)
            {
                if (examinations[i].Date.Equals(examination.Date) && examinations[i].Patient.Id.Equals(examination.Patient.Id))
                {
                    examinations.RemoveAt(i);
                }
            }

            Patients = patientStorage.loadFromFile("PatientRecordFileStorage.json");
            doctors = doctorStorage.loadFromFile("Doctors.json");
            int cnt = 0;
            string[] patientNameAndSurname = patientTxt.Text.Split(' ');

            foreach (Doctor doctor in doctors)
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
                MessageBox.Show("Pacijent sa unetim JMBG-om ne postoji!");
            }
            else
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

                if (isRoomAvailable(examinations, examination.RoomRecord, examination.Date) && isPatientAvailable(examinations, examination.Patient, examination.Date)
                    && isDoctorAvailable(examinations, examination.Doctor, examination.Date))
                {
                    examinations.Add(examination);
                    examinationsRecordFileStorage.saveToFile(examinations, "examinations.json");
                }
                else
                {
                    MessageBox.Show("Termin je zauzet");
                }

                DoctorWindow doctorWindow = new DoctorWindow();
                doctorWindow.dataGridExaminations.Items.Refresh();
                doctorWindow.Show();
                this.Close();
            }
        }

        private void cancelButtonClicked(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBox = MessageBox.Show("Are you sure you want to discard your changes?",
                                                "Update examination", MessageBoxButton.YesNo);

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
    }
    
}
