using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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
        private List<RoomRecord> rooms = new List<RoomRecord>();
        private RoomRepository roomRepository = new RoomRepository();

        public FindAttributesService()
        {

        }

        public Patient findPatient(string id)
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

        public Doctor findDoctor(string name, string surname)
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

        public RoomRecord findRoomByDoctor(Doctor doc)
        {
            rooms = roomRepository.loadFromFile("Sobe.json");
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

        public RoomRecord findRoomById(int id)
        {
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

        //public 
    }
}
