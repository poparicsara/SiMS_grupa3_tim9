using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using IS_Bolnica.Model;
using Model;

namespace IS_Bolnica.Services
{
    public class FindAttributesService
    {
        private List<Patient> patients = new List<Patient>();
        private PatientRepository patientRepository = new PatientRepository();
        private List<Doctor> doctors = new List<Doctor>();
        private DoctorRepository doctorRepository = new DoctorRepository();
        private List<Room> rooms = new List<Room>();
        private RoomRepository roomRepository = new RoomRepository();
        private Specialization specialization = new Specialization();
        private List<Specialization> specializations = new List<Specialization>();
        private List<string> specializationNamesList = new List<string>();
        private GuestUser guestUser = new GuestUser();
        private GuestUserRepository guestUserRepository = new GuestUserRepository();
        private List<GuestUser> guestUsers = new List<GuestUser>();
        private List<int> roomNums = new List<int>();
        private AppointmentRepository appointmentRepository = new AppointmentRepository();

        public FindAttributesService()
        {

        }

        public Patient FindPatient(string id)
        {
            patients = patientRepository.GetAll();
            for (int i = 0; i < patients.Count; i++)
            {
                if (patients[i].Id.Equals(id))
                {
                    return patients[i];
                }

            }
            MessageBox.Show("Pacijent sa ovim JMBG-om ne postoji!");
            return null;
        }

        public Doctor FindDoctor(string name, string surname)
        {
            doctors = doctorRepository.GetAll();
            foreach (Doctor doc in doctors)
            {
                if (doc.Name.Equals(name) && doc.Surname.Equals(surname))
                {
                    return doc;
                }
            }
            return null;
        }

        public GuestUser FindGuest(string systemName)
        {
            guestUsers = guestUserRepository.GetAll();
            foreach (GuestUser guest in guestUsers)
            {
                if (guest.SystemName.Equals(systemName))
                {
                    return guest;
                }
            }
            return null;
        }

        public Room findRoomByDoctor(Doctor doc)
        {
            rooms = roomRepository.GetAll();
            for (int i = 0; i < rooms.Count; i++)
            {
                if (rooms[i].Id == doc.Ordination)
                {
                    return rooms[i];
                }
            }

            MessageBox.Show("Soba ne postoji!");
            return null;
        }

        public Room FindRoomById(int id)
        {
            rooms = roomRepository.GetAll();
            for (int i = 0; i < rooms.Count; i++)
            {
                if (rooms[i].Id == id)
                {
                    return rooms[i];
                }
            }

            MessageBox.Show("Soba ne postoji!");
            return null;
        }

        public List<string> GetSpecializationNames()
        {
            specializations = specialization.getSpecializations();

            foreach (Specialization spec in specializations)
            {
                specializationNamesList.Add(spec.Name);
            }

            return specializationNamesList;
        }

        public Specialization FindSpecialization(string spec)
        {
            foreach (Specialization s in specializations)
            {
                if (s.Name.Equals(spec))
                {
                    return s;
                }
            }

            return null;
        }

        public List<int> GetRoomIds()
        {
            rooms = roomRepository.GetAll();
            for (int i = 0; i < rooms.Count; i++)
            {
                if (rooms[i].RoomPurpose.Name == "Operaciona sala")
                {
                    roomNums.Add(rooms[i].Id);
                }
            }
            return roomNums;
        }

        public List<int> GetAllRoomIds()
        {
            rooms = roomRepository.GetAll();
            for (int i = 0; i < rooms.Count; i++)
            { 
                roomNums.Add(rooms[i].Id);
            }
            return roomNums;
        }

        public int GetDurationInMinutes(int hours, int minutes)
        {
            return hours * 60 + minutes;
        }

        public Patient findPatientByUsername(string username)
        {
            patients = patientRepository.GetAll();
            Patient returnPatient = new Patient();

            foreach (Patient patient in patients)
            {
                if (patient.Username.Equals(username))
                {
                    returnPatient = patient;
                }
            }

            return returnPatient;
        }

        public DateTime returnSelectedDate(DateTime date, String selectedHour, String selectedMin)
        {
            int days = date.Day;
            int month = date.Month;
            int year = date.Year;
            int hours = Convert.ToInt32(selectedHour);
            int minutes = Convert.ToInt32(selectedMin);

            DateTime selectedDate = new DateTime(year, month, days, hours, minutes, 0);
            return selectedDate;
        }

        public Boolean checkSelectedIndex(int index)
        {
            if (index == -1)
            {
                return true;
            }
            return false;
        }

        public DateTime returnSelectedDateByIndex(int index)
        {
            List<Appointment> patientAppointments = FindPatientAppointments(findPatientByUsername(PatientWindow.loggedPatient.Username));
            //2.3.2020. 09:15:00 
            DateTime selectedDate = patientAppointments.ElementAt(index).StartTime;
            string[] pom = selectedDate.ToString().Split(' ');
            string[] date = pom[0].Split('/');
            DateTime returnDate = new DateTime(Int32.Parse(date[2]), Int32.Parse(date[0]), Int32.Parse(date[1]));

            return returnDate;
        }

        public String returnDoctorsNameAndSurnameByIndex(int index)
        {
            List<Appointment> patientAppointments = FindPatientAppointments(findPatientByUsername(PatientWindow.loggedPatient.Username));
            return patientAppointments.ElementAt(index).Doctor.Name + " " + patientAppointments.ElementAt(index).Doctor.Surname +
                "(" + patientAppointments.ElementAt(index).Doctor.Specialization.Name + ")";
        }

        public String returnSelectedHourByIndex(int index)
        {
            List<Appointment> patientAppointments = FindPatientAppointments(findPatientByUsername(PatientWindow.loggedPatient.Username));

            DateTime selectedDate = patientAppointments.ElementAt(index).StartTime;
            string[] pom = selectedDate.ToString().Split(' ');
            string[] time = pom[1].Split(':');
            String hour = "";
            if (pom[2].Equals("PM") && Convert.ToInt32(time[0]) < 12)
            {
                hour = (Convert.ToInt32(time[0]) + 12).ToString();
            }
            else
            {
                hour = time[0];
            }

            return hour;
        }

        public String returnSelectedMinutesByIndex(int index)
        {
            List<Appointment> patientAppointments = FindPatientAppointments(findPatientByUsername(PatientWindow.loggedPatient.Username));

            DateTime selectedDate = patientAppointments.ElementAt(index).StartTime;
            string[] pom = selectedDate.ToString().Split(' ');
            string[] time = pom[1].Split(':');

            return time[1];
        }

        public List<Appointment> FindPatientAppointments(Patient patient)
        {
            List<Appointment> appointments = appointmentRepository.GetAll();
            List<Appointment> patientAppointments = new List<Appointment>();
            foreach (var appointment in appointments)
            {
                if (appointment.Patient.Id.Equals(patient.Id))
                {
                    patientAppointments.Add(appointment);
                }
            }

            return patientAppointments;
        }

        public Boolean checkComboBoxes(String doctorComboBox, String hourBox, String minuteBox)
        {

            if (!doctorComboBox.Equals("") && !hourBox.Equals("") && !minuteBox.Equals(""))
                return true;

            return false;
        }

        public Boolean checkDatePicker(String date)
        {
            if (!date.Equals(""))
                return true;

            return false;
        }

        public DateTime returnDateBySelectionInDatePicker(String selectedDate)
        {
            string[] partsOfDate = selectedDate.Split(' ')[0].Split('/');
            DateTime dateOfSelection = new DateTime(Convert.ToInt32(partsOfDate[2]), Convert.ToInt32(partsOfDate[0]), Convert.ToInt32(partsOfDate[1]),
                07, 00, 00);
            return dateOfSelection;
        }
    }
}
