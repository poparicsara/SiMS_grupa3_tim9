﻿using System;
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
    class FindAttributesService
    {
        private AppointmentRepository appointmentRepository = new AppointmentRepository();
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

        public FindAttributesService()
        {

        }

        public Patient FindPatient(string id)
        {
            patients = patientRepository.LoadFromFile("PatientRecordFileStorage.json");
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

        public GuestUser FindGuest(string systemName)
        {
            guestUsers = guestUserRepository.LoadFromFile("GuestUsersFile.json");
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
            rooms = roomRepository.GetRooms();
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
            rooms = roomRepository.GetRooms();
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

        public Patient findPatientByUsername(string username)
        {
            patients = patientRepository.LoadFromFile("PatientRecordFileStorage.json");
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

        public Boolean checkSelectedIndex(int index, Boolean value)
        {
            if (index == -1 && value)
            {
                MessageBox.Show("Oznacite pregled koji zelite da izmenite!");
                return true;
            }
            else if (index == -1 && !value)
            {
                MessageBox.Show("Oznacite pregled koji zelite da otkazete!");
                return true;
            }
            return false;
        }

        public DateTime returnSelectedDateByIndex(int index)
        {
            List<Appointment> patientAppointments = FindPatientAppointments(findPatientByUsername(PatientWindow.username_patient));
            //2.3.2020. 09:15:00 
            DateTime selectedDate = patientAppointments.ElementAt(index).StartTime;
            string[] pom = selectedDate.ToString().Split(' ');
            string[] date = pom[0].Split('/');
            DateTime returnDate = new DateTime(Int32.Parse(date[2]), Int32.Parse(date[0]), Int32.Parse(date[1]));

            return returnDate;
        }

        public String returnDoctorsNameAndSurnameByIndex(int index)
        {
            List<Appointment> patientAppointments = FindPatientAppointments(findPatientByUsername(PatientWindow.username_patient));
            return patientAppointments.ElementAt(index).Doctor.Name + " " + patientAppointments.ElementAt(index).Doctor.Surname;
        }

        public String returnSelectedHourByIndex(int index)
        {
            List<Appointment> patientAppointments = FindPatientAppointments(findPatientByUsername(PatientWindow.username_patient));

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
            List<Appointment> patientAppointments = FindPatientAppointments(findPatientByUsername(PatientWindow.username_patient));

            DateTime selectedDate = patientAppointments.ElementAt(index).StartTime;
            string[] pom = selectedDate.ToString().Split(' ');
            string[] time = pom[1].Split(':');

            return time[1];
        }

        public int findActions(String username)
        {
            Patient patient = findPatientByUsername(username);
            return patient.Akcije;
        }

        public int findNumOfEvaluations(String username)
        {
            Patient patient = findPatientByUsername(username);
            return patient.brojOcenjenihPregleda;
        }

        public List<Appointment> FindPatientAppointments(Patient patient)
        {
            List<Appointment> appointments = appointmentRepository.LoadFromFile("Appointments.json");
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
            rooms = roomRepository.GetRooms();
            for (int i = 0; i < rooms.Count; i++)
            {
                if (rooms[i].roomPurpose.Name == "Operaciona sala")
                {
                    roomNums.Add(rooms[i].Id);
                }
            }
            return roomNums;
        }

        public int GetDurationInMinutes(int hours, int minutes)
        {
            return hours * 60 + minutes;
        }


    }
}
