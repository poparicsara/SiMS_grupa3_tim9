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
        public List<Room> Rooms
        {
            get;
            set;
        }
        public List<int> RoomId { get; set; } = new List<int>();
        private RoomRepository roomRepository = new RoomRepository();
        public List<int> Hours { get; set; } = new List<int>();
        public List<Doctor> Doctors { get; set; }
        private DoctorRepository doctorStorage = new DoctorRepository();
        private List<string> doctorNameAndSurname = new List<string>();
        private List<string> specialistNameAndSurname = new List<string>();
        private List<Specialization> specializations = new List<Specialization>();
        private List<Examination> examinations = new List<Examination>();
        private ExaminationsRecordFileStorage examinationStorage = new ExaminationsRecordFileStorage();
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

            Rooms = roomRepository.GetRooms();

            foreach (Room room in Rooms)
            {
                if (room.RoomPurpose.Name.Equals("Ordinacija"))
                {
                    RoomId.Add(room.Id);
                }
            }

            roomTxt.Text = examination.Doctor.Ordination.ToString();

            if (examination.Doctor.Specialization.Name == " ")
            {
                opstaPraksaRadioBtn.IsChecked = true;
                specijalistiRadioBtn.IsChecked = false;
                doctorsComboBox.SelectedItem = examination.Doctor.Name + ' ' + examination.Doctor.Surname;
            }
            if (examination.Doctor.Specialization.Name != " ")
            {
                specijalistiRadioBtn.IsChecked = true;
                opstaPraksaRadioBtn.IsChecked = false;
                doctorsComboBox.SelectedItem = examination.Doctor.Name + ' ' + examination.Doctor.Surname;
                chooseSpecComboBox.SelectedItem = examination.Doctor.Specialization.Name;
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
            examinations = examinationStorage.loadFromFile("examinations.json");

            List<Patient> Patients = new List<Patient>();
            PatientRepository patientStorage = new PatientRepository();

            for (int i = 0; i < examinations.Count; i++)
            {
                if (examinations[i].Date.Equals(examination.Date) && examinations[i].Patient.Id.Equals(examination.Patient.Id))
                {
                    examinations.RemoveAt(i);
                }
            }

            Patients = patientStorage.LoadFromFile("PatientRecordFileStorage.json");
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
                MessageBox.Show("Pacijent sa unetim JMBG-om ne postoji!");
            }
            else
            {
                DateTime date = new DateTime();
                date = (DateTime)datePicker.SelectedDate;
                int hour = Convert.ToInt32(hourBox.Text);
                int minute = Convert.ToInt32(minuteBox.Text);
                examination.Date = new DateTime(date.Year, date.Month, date.Day, hour, minute, 0);
                examination.Room = new Room();

                foreach (Room room in Rooms)
                {
                    if (room.Id == examination.Doctor.Ordination)
                    {
                        examination.Room = room;
                    }
                }

                if (isPatientAvailable(examination.Patient, examination.Date) && isDoctorAvailable(examination.Date))
                {
                    examinations.Add(examination);
                    examinationStorage.saveToFile(examinations, "examinations.json");
                }
                else if (!isDoctorAvailable(examination.Date))
                {
                    MessageBox.Show("Nije moguce zakazati pregled u zadatom terminu - lekar je zauzet!");
                }
                else if (!isPatientAvailable(examination.Patient, examination.Date))
                {
                    MessageBox.Show("Nije moguce zakazati pregled u zadatom terminu - pacijent je zauzet!");
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

        private bool isPatientAvailable(Patient patient, DateTime dateAndTime)
        {
            examinations = examinationStorage.loadFromFile("examinations.json");

            foreach (Examination examination in examinations)
            {
                if (examination.Patient.Id == patient.Id && examination.Date == dateAndTime)
                {
                    return false;
                }
            }

            return true;
        }

        private bool isDoctorAvailable(DateTime dateAndTime)
        {
            examinations = examinationStorage.loadFromFile("examinations.json");

            foreach (Examination examination in examinations)
            {
                string drNameSurname = examination.Doctor.Name + ' ' + examination.Doctor.Surname;

                if (drNameSurname.Equals(doctorsComboBox.SelectedItem.ToString()) && examination.Date.Equals(dateAndTime))
                {
                    return false;
                }
            }

            return true;
        }

        private void specijalistiRadioBtn_Checked(object sender, RoutedEventArgs e)
        {
            Specialization specialization = new Specialization();
            List<string> specializatonNames = new List<string>();
            specializations = specialization.getSpecializations();

            foreach (Specialization spec in specializations)
            {
                specializatonNames.Add(spec.Name);
            }

            chooseSpecComboBox.ItemsSource = specializatonNames;
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

        private void showDoctorOrdination()
        {
            Doctors = doctorStorage.loadFromFile("Doctors.json");
            foreach (Doctor doctor in Doctors)
            {
                string drNameSurname = doctor.Name + ' ' + doctor.Surname;

                if (drNameSurname.Equals(doctorsComboBox.SelectedItem.ToString()))
                {
                    roomTxt.Text = doctor.Ordination.ToString();
                }
            }
        }

        private void showDoctors(string specializationName)
        {
            Doctors = doctorStorage.loadFromFile("Doctors.json");
            string dr;

            foreach (Doctor doctor in Doctors)
            {
                if (doctor.Specialization.Name.Equals(specializationName))
                {
                    dr = doctor.Name + ' ' + doctor.Surname;
                    specialistNameAndSurname.Add(dr);
                }
                else
                {
                    dr = doctor.Name + ' ' + doctor.Surname;
                    specialistNameAndSurname.Remove(dr);
                }
            }

            doctorsComboBox.ItemsSource = specialistNameAndSurname;
        }

        private void doctorsComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (doctorsComboBox.SelectedItem != null)
            {
                showDoctorOrdination();
            }
            else if (doctorsComboBox.SelectedItem == null)
            {
                roomTxt.Text = " ";
            }
        }

        private void chooseSpecComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            doctorsComboBox.ItemsSource = null;

            showDoctors(chooseSpecComboBox.SelectedItem.ToString());
        }
    }

}