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
    public partial class AddOperationWindow : Window
    {
        public List<RoomRecord> Rooms
        {
            get;
            set;
        }
        public List<int> RoomNums { get; set; } = new List<int>();
        private RoomRecordFileStorage roomStorage = new RoomRecordFileStorage();
        private Operation operation = new Operation();
        private List<Operation> Operations = new List<Operation>();
        private OperationsFileStorage operationStorage = new OperationsFileStorage();
        private List<Patient> Patients = new List<Patient>();
        private PatientRecordFileStorage patientStorage = new PatientRecordFileStorage();
        private DoctorRepository doctorRepository = new DoctorRepository();
        private List<Doctor> doctors = new List<Doctor>();
        private List<string> DocNames = new List<string>();
        private Examination examination = new Examination();
        private List<Examination> examinations = new List<Examination>();
        private ExaminationsRecordFileStorage examinationsFileStorage = new ExaminationsRecordFileStorage();
        private Doctor doctor = new Doctor();
        private Patient patient = new Patient();

        private Appointment appointment = new Appointment();
        private List<Appointment> appointments = new List<Appointment>();
        private AppointmentRepository appointmentRepository = new AppointmentRepository();

        public AddOperationWindow()
        {
            InitializeComponent();

            setRoomBox();

            setDoctorBox();
        }

        private void setRoomBox()
        {
            Rooms = roomStorage.loadFromFile("Sobe.json");
            for (int i = 0; i < Rooms.Count; i++)
            {
                if (Rooms[i].roomPurpose.Name == "Operaciona sala")
                {
                    RoomNums.Add(Rooms[i].Id);
                }
            }
            roomBox.ItemsSource = RoomNums;
        }

        private void setDoctorBox()
        {
            doctors = doctorRepository.loadFromFile("Doctors.json");
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

        private bool isPatientFree(List<Appointment> appointments, Appointment appointment)
        {
            foreach (Appointment app in appointments)
            {
                if (app.Patient.Id == appointment.Patient.Id)
                {
                    if (app.StartTime <= appointment.StartTime && appointment.StartTime < app.EndTime)
                    {
                        MessageBox.Show("Pacijent u ovom terminu ima već zakazan pregled");
                        return false;
                    }

                    if (app.StartTime < appointment.EndTime && appointment.EndTime <= app.EndTime)
                    {
                        MessageBox.Show("Pacijent u ovom terminu ima već zakazan pregled");
                        return false;
                    }

                    if (app.StartTime >= appointment.StartTime && app.EndTime <= appointment.EndTime)
                    {
                        MessageBox.Show("Pacijent u ovom terminu ima već zakazan pregled");
                        return false;
                    }

                }

            }

            return true;
        }

        private bool isRoomFree(List<Appointment> appointments, Appointment appointment)
        {
            foreach (Appointment app in appointments)
            {
                if (app.RoomRecord.Id == appointment.RoomRecord.Id)
                {
                    if (app.StartTime <= appointment.StartTime && appointment.StartTime < app.EndTime)
                    {
                        MessageBox.Show("Soba " + appointment.RoomRecord.Id + " je zauzeta u izabranom terminu");
                        return false;
                    }

                    if (app.StartTime >= appointment.StartTime && app.EndTime <= appointment.EndTime)
                    {
                        MessageBox.Show("Soba " + appointment.RoomRecord.Id + " je zauzeta u izabranom terminu");
                        return false;
                    }

                    if (app.StartTime < appointment.EndTime && appointment.EndTime <= app.EndTime)
                    {
                        MessageBox.Show("Soba " + appointment.RoomRecord.Id + " je zauzeta u izabranom terminu");
                        return false;
                    }
                }

            }
            return true;
        }

        private bool isDoctorFree(List<Appointment> appointments, Appointment appointment)
        {
            foreach (Appointment app in appointments)
            {
                if (app.Doctor.Id == appointment.Doctor.Id)
                {
                    if (app.StartTime <= appointment.StartTime && appointment.StartTime < app.EndTime)
                    {
                        MessageBox.Show("Doktor već ima zakazan termin u isto vreme!");
                        return false;
                    }

                    if (app.StartTime < appointment.EndTime && appointment.EndTime <= app.EndTime)
                    {
                        MessageBox.Show("Doktor već ima zakazan termin u isto vreme!");
                        return false;
                    }

                    if (app.StartTime >= appointment.StartTime && app.EndTime <= appointment.EndTime)
                    {
                        MessageBox.Show("Doktor već ima zakazan termin u isto vreme!");
                        return false;
                    }
                }

            }
            return true;
        }

        private bool isAvailable(List<Appointment> appointments, Appointment appointment)
        {
            if (isPatientFree(appointments, appointment) 
                && isRoomFree(appointments, appointment) 
                && isDoctorFree(appointments, appointment))
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        private Doctor findDoctor(string doctorName, string doctorSurname)
        {
            doctors = doctorRepository.loadFromFile("Doctors.json");
            foreach (Doctor doc in doctors)
            {
                if (doc.Name.Equals(doctorName) && doc.Surname.Equals(doctorSurname))
                {
                    doctor = doc;
                }
            }
            return doctor;
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

        private RoomRecord findRoom(int id)
        {
            Rooms = roomStorage.loadFromFile("Sobe.json");
            for (int i = 0; i < Rooms.Count; i++)
            {
                if (Rooms[i].Id == id)
                {
                    return Rooms[i];
                }
            }
            MessageBox.Show("Operaciona sala nije pronadjena");
            return null;
        }

        private void addOperation(object sender, RoutedEventArgs e)
        {
            Operations = operationStorage.loadFromFile("operations.json");
            Patients = patientStorage.loadFromFile("PatientRecordFileStorage.json");

            appointments = appointmentRepository.LoadFromFile("Appointments.json");

            if (idExists(Patients, idPatientBox.Text))
            {
                string[] doctorNameAndSurname = doctorBox.Text.Split(' ');
                string name = doctorNameAndSurname[0];
                string surname = doctorNameAndSurname[1];

                operation.doctor = findDoctor(name, surname);
                appointment.Doctor = findDoctor(name, surname);

                operation.Patient = findPatient(idPatientBox.Text);
                appointment.Patient = findPatient(idPatientBox.Text);

                DateTime datumStart = new DateTime();
                datumStart = (DateTime)dateBox.SelectedDate;
                int satStart = Convert.ToInt32(hourBoxStart.Text);
                int minutStart = Convert.ToInt32(minuteBoxStart.Text);
                operation.Date = new DateTime(datumStart.Year, datumStart.Month, datumStart.Day, satStart, minutStart, 0);
                appointment.StartTime = new DateTime(datumStart.Year, datumStart.Month, datumStart.Day, satStart, minutStart, 0);

                /*DateTime datumEnd = new DateTime();
                datumEnd = (DateTime)dateBox.SelectedDate;
                int satEnd = satStart + Convert.ToInt32(hourBoxEnd.Text);
                if(satEnd >= 24)
                {
                    datumEnd.AddDays(1);
                    satEnd = satEnd - 24;
                }
                int minutEnd = minutStart + Convert.ToInt32(minuteBoxEnd.Text);
                if(minutEnd >= 60)
                {
                    satEnd += 1;
                    minutEnd = minutEnd - 60;
                }
                operation.endTime = new DateTime(datumEnd.Year, datumEnd.Month, datumEnd.Day, satEnd, minutEnd, 0);*/

                operation.RoomRecord = findRoom(Convert.ToInt32(roomBox.Text));
                appointment.RoomRecord = findRoom(Convert.ToInt32(roomBox.Text));

                int hours = Convert.ToInt32(hourBoxEnd.Text);
                int minutes = Convert.ToInt32(minuteBoxEnd.Text);
                operation.DurationInMins = hours * 60 + minutes;
                appointment.DurationInMins = hours * 60 + minutes;

                operation.endTime = operation.Date.AddMinutes(operation.DurationInMins);
                appointment.EndTime = appointment.StartTime.AddMinutes(appointment.DurationInMins);
                appointment.AppointmentType = AppointmentType.operation;

                /*examinations = examinationsFileStorage.loadFromFile("Pregledi.json");
                examination.Date = operation.Date;
                examination.DurationInMinutes = operation.DurationInMins;
                examination.Patient = operation.Patient;
                examination.Doctor = operation.doctor;
                examination.RoomRecord = operation.RoomRecord;*/

                if (isAvailable(appointments, appointment) /*&& isAvailableEx(examinations, examination)*/)
                {
                    Operations.Add(operation);
                    appointments.Add(appointment);
                    appointmentRepository.SaveToFile(appointments, "appointments.json");
                    operationStorage.saveToFile(Operations, "operations.json");
                }
                else
                {
                    return;
                }
            } 
            else
            {
                return;
            }

            Secretary.OperationListWindow olw = new Secretary.OperationListWindow();
            olw.Show();
            this.Close();
        }

        private void cancelAddingOperation(object sender, RoutedEventArgs e)
        {
            this.Close();
        }



        /*private bool isPatientFreeEx(List<Examination> exams, Examination ex)
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

        private bool isRoomFreeEx(List<Examination> exams, Examination ex)
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

        private bool isDoctorFreeEx(List<Examination> exams, Examination ex)
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

        private bool isAvailableEx(List<Examination> exams, Examination ex)
        {
            if (isPatientFreeEx(exams, ex) && isRoomFreeEx(exams, ex) && isDoctorFreeEx(exams, ex))
            {
                return true;
            }
            else
            {
                return false;
            }

        }*/

    }
}
