﻿using IS_Bolnica.Model;
using Model;
using System;
using System.Collections.Generic;
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
    public partial class UrgentExaminationOptionsWindow : Window
    {
        private Examination examination = new Examination();
        private Specialization specialization = new Specialization();
        private List<Examination> examinationOptions = new List<Examination>();
        private List<Examination> scheduledExaminations = new List<Examination>();
        private ExaminationsRecordFileStorage examinationsFileStorage = new ExaminationsRecordFileStorage();
        private DateTime currentDate = new DateTime();
        private Examination examOption1 = new Examination();
        private List<Doctor> doctors = new List<Doctor>();
        private DoctorFileStorage doctorFileStorage = new DoctorFileStorage();
        private List<RoomRecord> rooms = new List<RoomRecord>();
        private RoomRecordFileStorage roomFileStorage = new RoomRecordFileStorage();

        public UrgentExaminationOptionsWindow(Examination examination, Specialization specialization)
        {
            InitializeComponent();
            this.examination = examination;
            this.specialization = specialization;

            examinationOptions = getExaminationOptions(examination, specialization);
            ExaminationOptions.ItemsSource = examinationOptions;
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

        private bool isPatientFree(List<Examination> exams, Examination ex)
        {
            DateTime endTimeNew = new DateTime();
            endTimeNew = ex.Date.AddMinutes(30);
            foreach (Examination exam in exams)
            {
                if (exam.Patient.Id == ex.Patient.Id)
                {
                    DateTime endTime = new DateTime();
                    endTime = exam.Date.AddMinutes(30);

                    if (exam.Date <= ex.Date && ex.Date < endTime)
                    {
                        return false;
                    }

                    if (exam.Date < endTimeNew && endTimeNew <= endTime)
                    {
                        return false;
                    }

                    if (exam.Date >= ex.Date && endTime <= endTimeNew)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        private bool isRoomFree(List<Examination> exams, Examination ex)
        {
            DateTime endTimeNew = new DateTime();
            endTimeNew = ex.Date.AddMinutes(30);
            foreach (Examination exam in exams)
            {
                DateTime endTime = new DateTime();
                endTime = exam.Date.AddMinutes(30);
                if (exam.RoomRecord.Id == ex.RoomRecord.Id)
                {
                    if (exam.Date <= ex.Date && ex.Date < endTime ) 
                    {
                        return false;
                    }

                    if (exam.Date < endTimeNew && endTimeNew <= endTime)
                    {
                        return false;
                    }

                    if (exam.Date >= ex.Date && endTime <= endTimeNew)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private bool isDoctorFree(List<Examination> exams, Examination ex)
        {
            DateTime dateTimeEnd = new DateTime();
            dateTimeEnd = ex.Date.AddMinutes(30);
            foreach (Examination exam in exams)
            {
                DateTime endTime = new DateTime();
                endTime = exam.Date.AddMinutes(30);
                if (exam.Doctor.Id == ex.Doctor.Id)
                {
                    if (exam.Date <= ex.Date && ex.Date < endTime)
                    {
                        return false;
                    }

                    if (exam.Date < dateTimeEnd && dateTimeEnd <= endTime)
                    {
                        return false;
                    }

                    if (exam.Date >= ex.Date && endTime <= dateTimeEnd)
                    {
                        return false;
                    }

                }
            }
            return true;
        }

        private bool isAvailable(List<Examination> exams, Examination ex)
        {
            if (ex.Patient != null)
            {
                if (isPatientFree(exams, ex) && isRoomFree(exams, ex) && isDoctorFree(exams, ex))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            } else
            {
                if (isRoomFree(exams, ex) && isDoctorFree(exams, ex))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

        }

        private List<Examination> getExaminationOptions(Examination examination, Specialization specialization1)
        {
            List<Examination> options = new List<Examination>();
            doctors = doctorFileStorage.loadFromFile("Doctors.json");
            rooms = roomFileStorage.loadFromFile("Sobe.json");
            scheduledExaminations = examinationsFileStorage.loadFromFile("Pregledi.json");

            currentDate = DateTime.Now;
            examOption1 = examination;

            DateTime temp1 = new DateTime();

            foreach (Doctor doc in doctors)
            {
                if (doc.Specialization.Name.Equals(specialization1.Name))
                {
                    examOption1.Doctor = doc;

                    examOption1.DurationInMinutes = 30;

                    foreach (RoomRecord room in rooms)
                    {
                        if(room.Id.Equals(doc.Ordination))
                        {
                            examOption1.RoomRecord = room;
                        }

                    }
                    for (int i = 1; i <= 90; i++)
                    {
                        temp1 = currentDate.AddMinutes(i);
                        examOption1.Date = new DateTime(temp1.Year, temp1.Month, temp1.Day, temp1.Hour, temp1.Minute, 0);
                        if (isAvailable(scheduledExaminations, examOption1))
                        {
                            MessageBox.Show("PROSLO " + i.ToString());
                            options.Add(examOption1);
                            break;
                        }
                    }
                    
             
                }

            }

            if(options.Count == 0)
            {
                MessageBox.Show("Lista je prazna");
                foreach(Examination ex in scheduledExaminations)
                {
                    if(ex.Doctor.Specialization.Name.Equals(specialization1.Name) && ex.Date > currentDate)
                    {
                        options.Add(ex);
                    }
                }
            }

            return options;
        }




        private void postponeExamination(Examination examination1)
        {
            List<Examination> exams = new List<Examination>();
            exams = examinationsFileStorage.loadFromFile("Pregledi.json");

            DateTime dateNew = new DateTime();
            dateNew = examination1.Date;
            DateTime temp1 = new DateTime();


            MessageBox.Show("Pre for petlje");


            for (int i = 1; i < 1000; i++)
            {
                MessageBox.Show("FOR " + i);
                temp1 = dateNew.AddMinutes(i*10);
                examination1.Date = new DateTime(temp1.Year, temp1.Month, temp1.Day, temp1.Hour, temp1.Minute, 0);
                if (isAvailable(exams, examination1))
                {
                    MessageBox.Show("AVAILABLE");
                    exams.Add(examination1);
                    examinationsFileStorage.saveToFile(exams, "Pregledi.json");
                    break;
                }
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            ActionBarWindow abw = new ActionBarWindow();
            abw.Show();
        }

        private void addUrgentExamination(object sender, RoutedEventArgs e)
        {
            int i = ExaminationOptions.SelectedIndex;
            Examination ex = new Examination();
            ex = (Examination)ExaminationOptions.SelectedItem;
            List<Examination> examinations = examinationsFileStorage.loadFromFile("Pregledi.json");

            MessageBox.Show(ex.Date.ToString());

            if(i == -1)
            {
                MessageBox.Show("Niste izabrali pregled koji želite da zakažete!");
            } 
            else
            {
                foreach (Examination exami in examinations)
                {
                    MessageBox.Show(exami.Date.ToString());

                    if (exami.Date == ex.Date && exami.Doctor.Id.Equals(ex.Doctor.Id))
                    {
                        MessageBox.Show("CONTAINS");

                        examination.Date = ex.Date;
                        examination.Doctor = ex.Doctor;
                        examination.RoomRecord = ex.RoomRecord;
                        examination.DurationInMinutes = 30;
                        examinations.Remove(exami);
                        examinations.Add(examination);
                        examinationsFileStorage.saveToFile(examinations, "Pregledi.json");
                        postponeExamination(exami);
                        return;
                    }
                }

                examinations.Add(ex);
                MessageBox.Show("Okay");
                examinationsFileStorage.saveToFile(examinations, "Pregledi.json");
            }
        }



    }


 }

