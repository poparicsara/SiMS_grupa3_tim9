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
        private DoctorRepository doctorRepository = new DoctorRepository();
        private Doctor doctor = new Doctor();
        private List<Doctor> doctors = new List<Doctor>();
        public List<string> DocNames = new List<string>();

        private Appointment appointment = new Appointment();
        private Appointment oldAppointment = new Appointment();
        private List<Appointment> appointments = new List<Appointment>();
        private AppointmentRepository appointmentRepository = new AppointmentRepository();

        public EditExaminationWindow(Appointment oldAppointment)
        {
            InitializeComponent();
            this.oldAppointment = oldAppointment;

            setDoctorBox();
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

        private bool idExists(string id)
        {
            Patients = patientStorage.loadFromFile("PatientRecordFileStorage.json");
            for (int i = 0; i < Patients.Count; i++)
            {
                if (Patients[i].Id.Equals(id))
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

                    if (app.StartTime >= appointment.StartTime && app.EndTime < appointment.EndTime)
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
                        MessageBox.Show("Soba " + appointment.RoomRecord.Id + "je zauzeta u izabranom terminu");
                        return false;
                    }

                    if (app.StartTime < appointment.EndTime && appointment.EndTime <= app.EndTime)
                    {
                        MessageBox.Show("Soba " + appointment.RoomRecord.Id + "je zauzeta u izabranom terminu");
                        return false;
                    }

                    if (app.StartTime >= appointment.StartTime && app.EndTime < appointment.EndTime)
                    {
                        MessageBox.Show("Soba " + appointment.RoomRecord.Id + "je zauzeta u izabranom terminu");
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
            if (isPatientFree(appointments, appointment) &&
                isRoomFree(appointments, appointment) &&
                isDoctorFree(appointments, appointment))
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
            doctors = doctorRepository.loadFromFile("Doctors.json");
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
            appointments = appointmentRepository.LoadFromFile("Appointments.json");

            if (idExists(idPatientBox.Text))
            {
                examination.Patient = findPatient(idPatientBox.Text);
                appointment.Patient = findPatient(idPatientBox.Text);

                string[] doctorNameAndSurname = doctorBox.Text.Split(' ');
                string name = doctorNameAndSurname[0];
                string surname = doctorNameAndSurname[1];

                examination.Doctor = findDoctor(name, surname);
                appointment.Doctor = findDoctor(name, surname);

                DateTime datum = new DateTime();
                datum = (DateTime)dateBox.SelectedDate;
                int sat = Convert.ToInt32(hourBox.Text);
                int minut = Convert.ToInt32(minutesBox.Text);
                examination.Date = new DateTime(datum.Year, datum.Month, datum.Day, sat, minut, 0);
                appointment.StartTime = new DateTime(datum.Year, datum.Month, datum.Day, sat, minut, 0);
                appointment.EndTime = appointment.StartTime.AddMinutes(30);

                examination.RoomRecord = findRoom(examination.Doctor);
                appointment.RoomRecord = findRoom(appointment.Doctor);

                for (int i = 0; i < appointments.Count; i++)
                {
                    if (appointments[i].StartTime.Equals(appointment.StartTime) &&
                                    appointments[i].Patient.Id.Equals(oldAppointment.Patient.Id))
                    {
                        examinations.RemoveAt(i);
                    }
                }


                if (isAvailable(appointments, appointment))
                {
                    examinations.Add(examination);
                    appointments.Add(appointment);
                    appointmentRepository.SaveToFile(appointments, "Appointments.json");
                    examinationStorage.saveToFile(examinations, "Pregledi.json");
                } 
                else
                {
                    //examinations.Add(oldExamination);
                    appointments.Add(oldAppointment);
                    appointmentRepository.SaveToFile(appointments, "Appointments.json");
                    //examinationStorage.saveToFile(examinations, "Pregledi.json");
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
