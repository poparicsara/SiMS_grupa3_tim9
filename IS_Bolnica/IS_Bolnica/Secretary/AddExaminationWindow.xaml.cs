using IS_Bolnica.Model;
using Model;
using System;
using System.Collections.Generic;
using System.Windows;

namespace IS_Bolnica.Secretary
{
    public partial class AddExaminationWindow : Window
    {

        public List<RoomRecord> Rooms
        {
            get;
            set;
        } = new List<RoomRecord>();
        private RoomRecord room = new RoomRecord();
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
        private Operation operation = new Operation();
        private List<Operation> operations = new List<Operation>();
        private OperationsFileStorage operationsFileStorage = new OperationsFileStorage();

        public AddExaminationWindow()
        {
            InitializeComponent();
            Rooms = roomStorage.loadFromFile("Sobe.json");

            //doctors = doctorFileStorage.loadFromFile("Doctors.json");
            //for(int i = 0; i < doctors.Count; i++)
            //{
            //    DocNames.Add(doctors[i].Name + " " + doctors[i].Surname);
            //}
            //doctorBox.ItemsSource = DocNames;
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

        private bool isPatientFree(List<Examination> exams, Examination ex)
        {
            DateTime endTimeNew = new DateTime();
            endTimeNew = ex.Date.AddMinutes(30);
            foreach (Examination exam in exams)
            {
                DateTime endTime = new DateTime();
                endTime = exam.Date.AddMinutes(30);
                if (exam.Patient.Id == ex.Patient.Id && exam.Date == ex.Date)
                {
                    if (exam.Date <= ex.Date && ex.Date < endTime)
                    {
                        MessageBox.Show("Pacijent u ovom terminu ima već zakazan pregled");
                        return false;
                    }

                    if (exam.Date < endTimeNew && endTimeNew <= endTime)
                    {
                        MessageBox.Show("Pacijent u ovom terminu ima već zakazan pregled");
                        return false;
                    }

                    if (exam.Date >= ex.Date && endTime < endTimeNew)
                    {
                        MessageBox.Show("Pacijent u ovom terminu ima već zakazan pregled");
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
                    if (exam.Date <= ex.Date && ex.Date < endTime)
                    {
                        MessageBox.Show("Soba " + ex.RoomRecord.Id + "je zauzeta u izabranom terminu");
                        return false;
                    }

                    if (exam.Date < endTimeNew && endTimeNew <= endTime)
                    {
                        MessageBox.Show("Soba " + ex.RoomRecord.Id + "je zauzeta u izabranom terminu");
                        return false;
                    }

                    if (exam.Date >= ex.Date && endTime < endTimeNew)
                    {
                        MessageBox.Show("Soba " + ex.RoomRecord.Id + "je zauzeta u izabranom terminu");
                        return false;
                    }
                }
            }
            return true;
        }

        private bool isDoctorFree(List<Examination> exams, Examination ex)
        {
            DateTime endTimeNew = new DateTime();
            endTimeNew = ex.Date.AddMinutes(30);
            foreach (Examination exam in exams)
            {
                DateTime endTime = new DateTime();
                endTime = exam.Date.AddMinutes(30);
                if (exam.Doctor.Id == ex.Doctor.Id && exam.Date == ex.Date)
                {
                    if (exam.Date <= ex.Date && ex.Date < endTime)
                    {
                        MessageBox.Show("Doktor već ima zakazan termin u isto vreme!");
                        return false;
                    }

                    if (exam.Date < endTimeNew && endTimeNew <= endTime)
                    {
                        MessageBox.Show("Doktor već ima zakazan termin u isto vreme!");
                        return false;
                    }

                    if (exam.Date >= ex.Date && endTime <= endTimeNew)
                    {
                        MessageBox.Show("Doktor već ima zakazan termin u isto vreme!");
                        return false;
                    }
                }
            }
            return true;
        }

        private bool isAvailable(List<Examination> exams , Examination ex)
        {
            if (isPatientFree(exams, ex) && isRoomFree(exams, ex) && isDoctorFree(exams, ex))
            {
                return true;
            } 
            else
            {
                return false;
            }

        }

        private Patient findPatient(string patientsId)
        {
            Patients = patientStorage.loadFromFile("PatientRecordFileStorage.json");
            for (int i = 0; i < Patients.Count; i++)
            {
                if (Patients[i].Id.Equals(idPatientBox.Text))
                {
                    patient = Patients[i];
                }
            }
            return patient;
        }

        private Doctor findDoctor(string doctorName, string doctorSurname)
        {
            doctors = doctorFileStorage.loadFromFile("Doctors.json");
            foreach (Doctor doc in doctors)
            {
                if (doc.Name.Equals(doctorName) && doc.Surname.Equals(doctorSurname))
                {
                    doctor = doc;
                }
            }
            return doctor;
        }

        private RoomRecord findRoom(Doctor doctor)
        {
            Rooms = roomStorage.loadFromFile("Sobe.json");
            for (int i = 0; i < Rooms.Count; i++)
            {
                if (Rooms[i].Id == doctor.Ordination)
                {
                    return Rooms[i];
                }
            }
            MessageBox.Show("Doktor nema ordinaciju");
            return null;
        }

        private void addExamination(object sender, RoutedEventArgs e)
        {
            Examinations = examinationStorage.loadFromFile("Pregledi.json");
            examination.DurationInMinutes = 30;

            Patients = patientStorage.loadFromFile("PatientRecordFileStorage.json");
            if(idExists(Patients, idPatientBox.Text))
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

                operations = operationsFileStorage.loadFromFile("operations.json");
                operation.Date = examination.Date;
                operation.endTime = operation.Date.AddMinutes(30);
                operation.Patient = examination.Patient;
                operation.doctor = examination.Doctor;
                operation.RoomRecord = examination.RoomRecord;
                if (isAvailable(Examinations, examination) && isAvailableOp(operations, operation))
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


        private bool isPatientFreeOp(List<Operation> operations, Operation op)
        {
            foreach (Operation operation in operations)
            {
                if (operation.Patient.Id == op.Patient.Id)
                {
                    if (operation.Date <= op.Date && op.Date < operation.endTime)
                    {
                        MessageBox.Show("Pacijent u ovom terminu ima već zakazan pregled");
                        return false;
                    }

                    if (operation.Date < op.endTime && op.endTime <= operation.endTime)
                    {
                        MessageBox.Show("Pacijent u ovom terminu ima već zakazan pregled");
                        return false;
                    }

                    if (operation.Date >= op.Date && operation.endTime <= op.endTime)
                    {
                        MessageBox.Show("Pacijent u ovom terminu ima već zakazan pregled");
                        return false;
                    }

                }

            }

            return true;
        }

        private bool isRoomFreeOp(List<Operation> operations, Operation op)
        {
            foreach (Operation operation in operations)
            {
                if (operation.RoomRecord.Id == op.RoomRecord.Id)
                {
                    if (operation.Date <= op.Date && op.Date < operation.endTime)
                    {
                        MessageBox.Show("Soba " + op.RoomRecord.Id + " je zauzeta u izabranom terminu");
                        return false;
                    }

                    if (operation.Date >= op.Date && operation.endTime <= op.endTime)
                    {
                        MessageBox.Show("Soba " + op.RoomRecord.Id + " je zauzeta u izabranom terminu");
                        return false;
                    }

                    if (operation.Date < op.endTime && op.endTime <= operation.endTime)
                    {
                        MessageBox.Show("Soba " + op.RoomRecord.Id + " je zauzeta u izabranom terminu");
                        return false;
                    }
                }

            }
            return true;
        }

        private bool isDoctorFreeOp(List<Operation> operations, Operation op)
        {
            foreach (Operation operation in operations)
            {
                if (operation.doctor.Id == op.doctor.Id)
                {
                    if (operation.Date <= op.Date && op.Date < operation.endTime)
                    {
                        MessageBox.Show("Doktor već ima zakazan termin u isto vreme!");
                        return false;
                    }

                    if (operation.Date < op.endTime && op.endTime <= operation.endTime)
                    {
                        MessageBox.Show("Doktor već ima zakazan termin u isto vreme!");
                        return false;
                    }

                    if (operation.Date >= op.Date && operation.endTime <= op.endTime)
                    {
                        MessageBox.Show("Doktor već ima zakazan termin u isto vreme!");
                        return false;
                    }
                }

            }
            return true;
        }

        private bool isAvailableOp(List<Operation> operations, Operation op)
        {
            if (isPatientFreeOp(operations, op)
                && isRoomFreeOp(operations, op)
                && isDoctorFreeOp(operations, op))
            {
                return true;
            }
            else
            {
                return false;
            }

        }

    }



}
