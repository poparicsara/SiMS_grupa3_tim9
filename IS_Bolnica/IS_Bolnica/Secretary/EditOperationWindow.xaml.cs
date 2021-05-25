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
    public partial class EditOperationWindow : Window
    {
        public List<RoomRecord> Rooms
        {
            get;
            set;
        }
        public List<int> RoomNums { get; set; } = new List<int>();
        private RoomRepository roomStorage = new RoomRepository();
        private List<Patient> Patients = new List<Patient>();
        private PatientRepository patientStorage = new PatientRepository();
        private List<Doctor> doctors = new List<Doctor>();
        private DoctorRepository doctorRepository = new DoctorRepository();
        private List<string> DocNames = new List<string>();
        private Appointment appointment = new Appointment();
        private Appointment oldAppointment = new Appointment();
        private List<Appointment> appointments = new List<Appointment>();
        private AppointmentRepository appointmentRepository = new AppointmentRepository();

        public EditOperationWindow(Appointment oldAppointment)
        {
            InitializeComponent();

            this.oldAppointment = oldAppointment;

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
            room.ItemsSource = RoomNums;
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

        private bool idExists(string id)
        {
            Patients = patientStorage.LoadFromFile("PatientRecordFileStorage.json");
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
            appointments = appointmentRepository.LoadFromFile("Appointments.json");
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

        private Patient findPatient(string id)
        {
            Patients = patientStorage.LoadFromFile("PatientRecordFileStorage.json");
            for (int i = 0; i < Patients.Count; i++)
            {
                if (Patients[i].Id.Equals(id))
                {
                    return Patients[i];
                }
            }
            return null;
        }

        private RoomRecord findRoom(int id) 
        {
            Rooms = roomStorage.loadFromFile("Sobe.json");
            for (int i = 0; i<Rooms.Count; i++)
            {
                    if (Rooms[i].Id == Convert.ToInt32(room.SelectedItem))
                    {
                        return Rooms[i];
                    }
            }
            return null;
        }

        private Doctor findDoctor(string name, string surname)
        {
            doctors = doctorRepository.loadFromFile("Doctors.json");
            for(int i = 0; i < doctors.Count; i++)
            {
                if(doctors[i].Name.Equals(name) && doctors[i].Surname.Equals(surname))
                {
                    return doctors[i];
                }
            }
            return null;
        }

        private void RemoveOldOperation()
        {
            appointments = appointmentRepository.LoadFromFile("Appointments.json");
            for (int i = 0; i < appointments.Count; i++)
            {
                if (appointments[i].StartTime.Equals(oldAppointment.StartTime) &&
                    appointments[i].Patient.Id.Equals(oldAppointment.Patient.Id))
                {
                    appointments.RemoveAt(i);
                }
            }
            appointmentRepository.SaveToFile(appointments, "Appointments.json");
        }

        private void editOperation(object sender, RoutedEventArgs e)
        {
            RemoveOldOperation();
            

            if (idExists(patientId.Text))
            {
                string[] doctorNameAndSurname = doctorBox.Text.Split(' ');
                string name = doctorNameAndSurname[0];
                string surname = doctorNameAndSurname[1];
                appointment.Doctor = findDoctor(name, surname);
                
                appointment.Patient = findPatient(patientId.Text);

                DateTime datumStart = new DateTime();
                datumStart = (DateTime)date.SelectedDate;
                int satStart = Convert.ToInt32(hourBoxStart.Text);
                int minutStart = Convert.ToInt32(minutesBoxStart.Text);
                appointment.StartTime = new DateTime(datumStart.Year, datumStart.Month, datumStart.Day, satStart, minutStart, 0);

                
                appointment.DurationInMins = Convert.ToInt32(hourBoxEnd.Text) * 60 + Convert.ToInt32(minuteBoxEnd.Text);
                appointment.EndTime = appointment.StartTime.AddMinutes(appointment.DurationInMins);

                appointment.RoomRecord = findRoom(Convert.ToInt32(room.SelectedItem));
                appointment.AppointmentType = AppointmentType.operation;

                if (isAvailable(appointments, appointment))
                {
                    appointments.Add(appointment);
                    appointmentRepository.SaveToFile(appointments, "Appointments.json");
                }
                else
                {
                    appointments.Add(oldAppointment);
                    appointmentRepository.SaveToFile(appointments, "Appointments.json");
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

        private void cancelEditingOperation(object sender, RoutedEventArgs e)
        {
            Secretary.OperationListWindow olw = new Secretary.OperationListWindow();
            olw.Show();
            this.Close();
        }
    }
}
