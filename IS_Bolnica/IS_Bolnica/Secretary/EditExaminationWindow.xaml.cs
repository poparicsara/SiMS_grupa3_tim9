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
        private RoomRecordFileStorage roomStorage = new RoomRecordFileStorage();
        private List<Examination> examinations = new List<Examination>();
        private ExaminationsRecordFileStorage examinationStorage = new ExaminationsRecordFileStorage();
        private List<Patient> Patients = new List<Patient>();
        private PatientRecordFileStorage patientStorage = new PatientRecordFileStorage();
        private Examination oldExamination = new Examination();
        private DoctorFileStorage doctorFileStorage = new DoctorFileStorage();
        private Doctor doctor = new Doctor();
        private List<Doctor> doctors = new List<Doctor>();
        public List<string> DocNames = new List<string>();

        public EditExaminationWindow(Examination oldExamination)
        {
            InitializeComponent();
            this.oldExamination = oldExamination;

            setDoctorBox();
        }

        private void setDoctorBox()
        {
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
                return false;
            }

        }

        private Patient findPatient(string id)
        {
            Patients = patientStorage.loadFromFile("PatientRecordFileStorage.json");
            for (int i = 0; i < Patients.Count; i++)
            {
                if (Patients[i].Id.Equals(id))
                {
                    return Patients[i];
                }

            }
            MessageBox.Show("Pacijent sa ovim JMBG-om ne postoji!");
            return null;
        }

        private Doctor findDoctor(string name, string surname)
        {
            doctors = doctorFileStorage.loadFromFile("Doctors.json");
            foreach (Doctor doc in doctors)
            {
                if (doc.Name.Equals(name) && doc.Surname.Equals(surname))
                {
                    return doc;
                }
            }

            return null;
        }

        private RoomRecord findRoom(Doctor doc)
        {
            Rooms = roomStorage.loadFromFile("Sobe.json");
            for (int i = 0; i < Rooms.Count; i++)
            {
                if (Rooms[i].Id == doc.Ordination)
                {
                    return Rooms[i];
                }
            }
            return null;
        }

        private void editExamination(object sender, RoutedEventArgs e)
        {
            examinations = examinationStorage.loadFromFile("Pregledi.json");
            Patients = patientStorage.loadFromFile("PatientRecordFileStorage.json");
            if (idExists(Patients, idPatientBox.Text))
            {
                examination.Patient = findPatient(idPatientBox.Text);

                string[] doctorNameAndSurname = doctorBox.Text.Split(' ');
                string name = doctorNameAndSurname[0];
                string surname = doctorNameAndSurname[1];

                examination.Doctor = findDoctor(name, surname);

                DateTime datum = new DateTime();
                datum = (DateTime)dateBox.SelectedDate;
                int sat = Convert.ToInt32(hourBox.Text);
                int minut = Convert.ToInt32(minutesBox.Text);
                examination.Date = new DateTime(datum.Year, datum.Month, datum.Day, sat, minut, 0);

                examination.RoomRecord = findRoom(examination.Doctor);

                for (int i = 0; i < examinations.Count; i++)
                {
                    if (examinations[i].Date.Equals(oldExamination.Date) &&
                                    examinations[i].Patient.Id.Equals(oldExamination.Patient.Id))
                    {
                        examinations.RemoveAt(i);
                    }
                }


                if (isAvailable(examinations, examination.Patient, examination.RoomRecord, examination.Doctor, examination.Date))
                {
                    examinations.Add(examination);
                    examinationStorage.saveToFile(examinations, "Pregledi.json");
                } 
                else
                {
                    examinations.Add(oldExamination);
                    examinationStorage.saveToFile(examinations, "Pregledi.json");
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
