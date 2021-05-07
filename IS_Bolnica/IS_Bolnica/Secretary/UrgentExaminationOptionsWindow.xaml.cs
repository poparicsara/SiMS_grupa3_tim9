using IS_Bolnica.Model;
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

        private bool isPatientFree(List<Examination> exams, Patient patient, DateTime dateAndTime)
        {
            DateTime endTimeNew = new DateTime();
            endTimeNew = dateAndTime.AddMinutes(30);
            foreach (Examination exam in exams)
            {
                if (exam.Patient.Id == patient.Id)
                {
                    DateTime endTime = new DateTime();
                    endTime = exam.Date.AddMinutes(30);

                    if (exam.Date <= dateAndTime && dateAndTime < endTime)
                    {
                        return false;
                    }

                    if (exam.Date < endTimeNew && endTimeNew <= endTime)
                    {
                        return false;
                    }

                    if (exam.Date >= dateAndTime && endTime <= endTimeNew)
                    {
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
                    if (exam.Date <= dateAndTime && dateAndTime < endTime ) 
                    {
                        return false;
                    }

                    if (exam.Date < endTimeNew && endTimeNew <= endTime)
                    {
                        return false;
                    }

                    if (exam.Date >= dateAndTime && endTime <= endTimeNew)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private bool isDoctorFree(List<Examination> exams, Doctor doc, DateTime dateTimeStart)
        {
            DateTime dateTimeEnd = new DateTime();
            dateTimeEnd = dateTimeStart.AddMinutes(30);
            foreach (Examination exam in exams)
            {
                DateTime endTime = new DateTime();
                endTime = exam.Date.AddMinutes(30);
                if (exam.Doctor.Id == doc.Id)
                {
                    if (exam.Date <= dateTimeStart && dateTimeStart < endTime)
                    {
                        return false;
                    }

                    if (exam.Date < dateTimeEnd && dateTimeEnd <= endTime)
                    {
                        return false;
                    }

                    if (exam.Date >= dateTimeStart && endTime <= dateTimeEnd)
                    {
                        return false;
                    }

                }
            }
            return true;
        }

        private bool isAvailable(List<Examination> exams, Patient patient, RoomRecord room, Doctor doctor, DateTime dateAndTime)
        {
            if (patient != null)
            {
                if (isPatientFree(exams, patient, dateAndTime) && isRoomFree(exams, room, dateAndTime) && isDoctorFree(exams, doctor, dateAndTime))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            } else
            {
                if (isRoomFree(exams, room, dateAndTime) && isDoctorFree(exams, doctor, dateAndTime))
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

                    if (currentDate.Minute <= 30)
                    {
                        for (int i = 1; i <= 90; i++)
                        {
                            temp1 = currentDate.AddMinutes(i);
                            examOption1.Date = new DateTime(temp1.Year, temp1.Month, temp1.Day, temp1.Hour, temp1.Minute, 0);
                            if (isAvailable(scheduledExaminations, examOption1.Patient, examOption1.RoomRecord, examOption1.Doctor, examOption1.Date))
                            {
                                MessageBox.Show("PROSLO " + i.ToString());
                                options.Add(examOption1);
                                break;
                            }
                        }
                    }
                    else
                    {
                        for (int i = 1; i <= 90; i++)
                        {
                            temp1 = currentDate.AddMinutes(i);
                            examOption1.Date = new DateTime(temp1.Year, temp1.Month, temp1.Day, temp1.Hour, temp1.Minute, 0);
                            if (isAvailable(scheduledExaminations, examOption1.Patient, examOption1.RoomRecord, examOption1.Doctor, examOption1.Date))
                            {
                                MessageBox.Show("PROSLO " + i.ToString());
                                options.Add(examOption1);
                                break;
                            }
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
                if (isAvailable(exams, examination1.Patient, examination1.RoomRecord, examination1.Doctor, examination1.Date))
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

