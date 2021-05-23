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

namespace IS_Bolnica.Secretary
{
    /// <summary>
    /// Interaction logic for EditExaminationWindow.xaml
    /// </summary>
    public partial class EditExaminationWindow : Window
    {
        private Examination examination = new Examination();
        public List<RoomRecord> Rooms
        {
            get;
            set;
        }
        public List<int> RoomNums { get; set; } = new List<int>();
        private RoomRecordFileStorage roomStorage = new RoomRecordFileStorage();
        List<Examination> examinations = new List<Examination>();
        ExaminationsRecordFileStorage examinationStorage = new ExaminationsRecordFileStorage();
        List<Patient> Patients = new List<Patient>();
        PatientRecordFileStorage patientStorage = new PatientRecordFileStorage();
        private Examination oldExamination = new Examination();
        private DoctorFileStorage doctorFileStorage = new DoctorFileStorage();
        private Doctor doctor = new Doctor();
        private List<Doctor> doctors = new List<Doctor>();
        public List<string> DocNames = new List<string>();

        public EditExaminationWindow(Examination oldExamination)
        {
            InitializeComponent();
            this.oldExamination = oldExamination;

            Rooms = roomStorage.loadFromFile("Sobe.json");
            for (int i = 0; i < Rooms.Count; i++)
            {
                if (Rooms[i].roomPurpose.Name == "Ordinacija")
                {
                    RoomNums.Add(Rooms[i].Id);
                }
            }
            room.ItemsSource = RoomNums;

            doctors = doctorFileStorage.loadFromFile("Doctors.json");
            for (int i = 0; i < doctors.Count; i++)
            {
                DocNames.Add(doctors[i].Name + " " + doctors[i].Surname);
            }
            doctorBox.ItemsSource = DocNames;
        }

        private bool idExists(List<Patient> patients, string id)
        {
            for (int i = 0; i < patients.Count; i++)
            {
                if (patients[i].Id.Equals(id))
                {
                    return true;
                }

            }

            MessageBox.Show("Pacijent sa ovim JMBG-om ne postoji!");
            return false;

        }

        private bool isPatientFree(List<Examination> exams, Patient patient, DateTime dateAndTime)
        {
            foreach (Examination exam in exams)
            {
                if (exam.Patient.Id == patient.Id && exam.Date == dateAndTime)
                {
                    MessageBox.Show("Pacijent u ovom terminu ima već zakazan pregled");

                    return false;
                }
            }

            return true;
        }

        private bool isRoomFree(List<Examination> exams, RoomRecord room, DateTime dateAndTime)
        {
            foreach (Examination exam in exams)
            {
                if (exam.RoomRecord.Id == room.Id && exam.Date == dateAndTime)
                {
                    MessageBox.Show("Soba " + room.Id + "je zauzeta u izabranom terminu");
                    return false;
                }
            }
            return true;
        }

        private bool isDoctorFree(List<Examination> exams, Doctor doc, DateTime dateAndTime)
        {
            foreach (Examination exam in exams)
            {
                if (exam.Doctor.Name == doc.Name && exam.Doctor.Surname == doc.Surname && exam.Date == dateAndTime)
                {
                    MessageBox.Show("Doktor već ima zakazan termin u isto vreme!");
                    return false;
                }
            }
            return true;
        }

        private bool isAvailable(List<Examination> exams, Patient patient, RoomRecord room, Doctor doctor, DateTime dateAndTime)
        {
            if (isPatientFree(exams, patient, dateAndTime) && isRoomFree(exams, room, dateAndTime) && isDoctorFree(exams, doctor, dateAndTime))
            {
                return true;
            }
            else
            {
                //MessageBox.Show("Ovaj pregled je vec zauzet!");

                return false;
            }

        }

        private void editExamination(object sender, RoutedEventArgs e)
        {
            examinations = examinationStorage.loadFromFile("Pregledi.json");
            Patients = patientStorage.loadFromFile("PatientRecordFileStorage.json");
            int brojac = 0;
            if (idExists(Patients, idPatientBox.Text))
            {
                for (int i = 0; i < Patients.Count; i++)
                {
                    if (Patients[i].Id.Equals(idPatientBox.Text))
                    {
                        examination.Patient = Patients[i];
                        brojac++;
                    }

                }

                string[] doctorNameAndSurname = doctorBox.Text.Split(' ');
                string name = doctorNameAndSurname[0];
                string surname = doctorNameAndSurname[1];

                foreach (Doctor doc in doctors)
                {
                    if (doc.Name.Equals(name) && doc.Surname.Equals(surname))
                    {
                        doctor = doc;
                    }
                }

                examination.Doctor = doctor;

                DateTime datum = new DateTime();
                datum = (DateTime)dateBox.SelectedDate;
                int sat = Convert.ToInt32(hourBox.Text);
                int minut = Convert.ToInt32(minutesBox.Text);
                examination.Date = new DateTime(datum.Year, datum.Month, datum.Day, sat, minut, 0);

                examination.RoomRecord = new RoomRecord();
                for (int i = 0; i < Rooms.Count; i++)
                {
                    if (Rooms[i].Id == Convert.ToInt32(room.SelectedItem))
                    {
                        examination.RoomRecord = Rooms[i];
                    }
                }

                if (isAvailable(examinations, examination.Patient, examination.RoomRecord, examination.Doctor, examination.Date))
                {
                    examinations.Add(examination);

                    for (int i = 0; i < examinations.Count; i++)
                    {
                        if (examinations[i].Date.Equals(oldExamination.Date) &&
                                        examinations[i].Patient.Id.Equals(oldExamination.Patient.Id))
                        {
                            examinations.RemoveAt(i);
                        }
                    }

                    examinationStorage.saveToFile(examinations, "Pregledi.json");
                } 
                else
                {
                    return;
                }
            } else
            {
                return;
            }

            Secretary.ExaminationListWindow elw = new ExaminationListWindow();
            elw.Show();
            this.Close();
        }

        private void cancelEditingExamination(object sender, RoutedEventArgs e)
        {
            Secretary.ExaminationListWindow elw = new ExaminationListWindow();
            elw.Show();
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Secretary.ActionBarWindow abw = new Secretary.ActionBarWindow();
            abw.Show();
            this.Close();
        }
    }
}
