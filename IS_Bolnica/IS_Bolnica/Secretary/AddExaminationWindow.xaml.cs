﻿using IS_Bolnica.Model;
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
    public partial class AddExaminationWindow : Window
    {

        public List<RoomRecord> Rooms
        {
            get;
            set;
        } = new List<RoomRecord>();
        public List<int> RoomNums { get; set; } = new List<int>();
        private RoomRecordFileStorage roomStorage = new RoomRecordFileStorage();
        private ExaminationsRecordFileStorage examinationStorage = new ExaminationsRecordFileStorage();
        public List<Examination> Examinations { get; set; } = new List<Examination>();
        private Examination examination = new Examination();
        private Patient patient = new Patient();
        private PatientRecordFileStorage patientStorage = new PatientRecordFileStorage();
        public List<Patient> Patients { get; set; } = new List<Patient>();
        private DoctorFileStorage doctorFileStorage = new DoctorFileStorage();
        private Doctor doctor = new Doctor();
        private List<Doctor> doctors = new List<Doctor>();
        public List<string> DocNames = new List<string>();

        public AddExaminationWindow()
        {
            InitializeComponent();
            Rooms = roomStorage.loadFromFile("Sobe.json");
            for(int i = 0; i < Rooms.Count; i++)
            {
                if (Rooms[i].roomPurpose.Name == "Ordinacija")
                {
                    RoomNums.Add(Rooms[i].Id);
                }
            }
            room.ItemsSource = RoomNums;

            doctors = doctorFileStorage.loadFromFile("Doctors.json");
            for(int i = 0; i < doctors.Count; i++)
            {
                DocNames.Add(doctors[i].Name + " " + doctors[i].Surname);
            }
            doctorBox.ItemsSource = DocNames;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Secretary.ActionBarWindow abw = new Secretary.ActionBarWindow();
            abw.Show();
            this.Close();
        }

        private void cancelAddingExamination(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private bool idExists(List<Patient> patients, string id )
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
            DateTime endTimeNew = new DateTime();
            endTimeNew = dateAndTime.AddMinutes(30);
            foreach (Examination exam in exams)
            {
                DateTime endTime = new DateTime();
                endTime = exam.Date.AddMinutes(30);
                if (exam.Patient.Id == patient.Id && exam.Date == dateAndTime)
                {
                    if (exam.Date <= dateAndTime && dateAndTime < endTime)
                    {
                        MessageBox.Show("Pacijent u ovom terminu ima već zakazan pregled");
                        return false;
                    }

                    if (exam.Date < endTimeNew && endTimeNew <= endTime)
                    {
                        MessageBox.Show("Pacijent u ovom terminu ima već zakazan pregled");
                        return false;
                    }

                    if (exam.Date >= dateAndTime && endTime < endTimeNew)
                    {
                        MessageBox.Show("Pacijent u ovom terminu ima već zakazan pregled");
                        return false;
                    }
                }

            }

            return true;
        }

        private bool isRoomFree(List<Examination> exams, RoomRecord room, DateTime dateAndTime)
        {
            DateTime endTimeNew = new DateTime();
            endTimeNew = dateAndTime.AddMinutes(30);
            foreach (Examination exam in exams)
            {
                DateTime endTime = new DateTime();
                endTime = exam.Date.AddMinutes(30);
                if (exam.RoomRecord.Id == room.Id)
                {
                    if (exam.Date <= dateAndTime && dateAndTime < endTime)
                    {
                        MessageBox.Show("Soba " + room.Id + "je zauzeta u izabranom terminu");
                        return false;
                    }

                    if (exam.Date < endTimeNew && endTimeNew <= endTime)
                    {
                        MessageBox.Show("Soba " + room.Id + "je zauzeta u izabranom terminu");
                        return false;
                    }

                    if (exam.Date >= dateAndTime && endTime < endTimeNew)
                    {
                        MessageBox.Show("Soba " + room.Id + "je zauzeta u izabranom terminu");
                        return false;
                    }
                }
            }
            return true;
        }

        private bool isDoctorFree(List<Examination> exams, Doctor doc, DateTime dateAndTime)
        {
            DateTime endTimeNew = new DateTime();
            endTimeNew = dateAndTime.AddMinutes(30);
            foreach (Examination exam in exams)
            {
                DateTime endTime = new DateTime();
                endTime = exam.Date.AddMinutes(30);
                if (exam.Doctor.Name == doc.Name && exam.Doctor.Surname == doc.Surname && exam.Date == dateAndTime)
                {
                    if (exam.Date <= dateAndTime && dateAndTime < endTime)
                    {
                        MessageBox.Show("Doktor već ima zakazan termin u isto vreme!");
                        return false;
                    }

                    if (exam.Date < endTimeNew && endTimeNew <= endTime)
                    {
                        MessageBox.Show("Doktor već ima zakazan termin u isto vreme!");
                        return false;
                    }

                    if (exam.Date >= dateAndTime && endTime <= endTimeNew)
                    {
                        MessageBox.Show("Doktor već ima zakazan termin u isto vreme!");
                        return false;
                    }
                }
            }
            return true;
        }

        private bool isAvailable(List<Examination> exams , Patient patient, RoomRecord room, Doctor doctor, DateTime dateAndTime)
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

        private void addExamination(object sender, RoutedEventArgs e)
        {
            Examinations = examinationStorage.loadFromFile("Pregledi.json");
            examination.DurationInMinutes = 30;

            Patients = patientStorage.loadFromFile("PatientRecordFileStorage.json");
            if(idExists(Patients, idPatientBox.Text))
            {
                for (int i = 0; i < Patients.Count; i++)
                {
                    if (Patients[i].Id.Equals(idPatientBox.Text))
                    {
                        examination.Patient = Patients[i];
                    }
                }

                string[] doctorNameAndSurname = doctorBox.Text.Split(' ');
                string name = doctorNameAndSurname[0];
                string surname = doctorNameAndSurname[1];

                foreach (Doctor doc in doctors)
                {
                    if(doc.Name.Equals(name) && doc.Surname.Equals(surname))
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

                if (isAvailable(Examinations, examination.Patient, examination.RoomRecord, examination.Doctor, examination.Date))
                {
                    Examinations.Add(examination);
                    examinationStorage.saveToFile(Examinations, "Pregledi.json");
                } else
                {
                    return;
                }
            } else
            {
                return;
            }

            Secretary.ExaminationListWindow elw = new Secretary.ExaminationListWindow();
            elw.Show();
            this.Close();
        }
    }
}
