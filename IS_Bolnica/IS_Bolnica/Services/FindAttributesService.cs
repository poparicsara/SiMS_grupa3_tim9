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
    class FindAttributesService
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
