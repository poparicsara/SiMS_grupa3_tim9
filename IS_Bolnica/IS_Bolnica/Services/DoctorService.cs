using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using IS_Bolnica.Model;
using Model;

namespace IS_Bolnica.Services
{
    class DoctorService
    {
        private DoctorRepository doctorRepository = new DoctorRepository();
        private List<Doctor> doctors = new List<Doctor>();

        public DoctorService()
        {

        }

        public void AddShift(Shift shift)
        {
            doctors = doctorRepository.loadFromFile("Doctors.json");
            for (int i = 0; i < doctors.Count; i++)
            {
                if (doctors[i].Id.Equals(shift.DoctorsId))
                {
                    //if (doctors[i].Shifts == null)
                    //{
                        //List<Shift> shifts = new List<Shift>();
                        //shifts.Add(shift);
                    doctors[i].Shifts.Add(shift);
                    //}
                }
            }
            doctorRepository.saveToFile(doctors, "Doctors.json");
        }

        public void AddVacation(Vacation vacation)
        {
            doctors = doctorRepository.loadFromFile("Doctors.json");
            for (int i = 0; i < doctors.Count; i++)
            {
                if (doctors[i].Id.Equals(vacation.DoctorsId))
                {
                    doctors[i].Vacations.Add(vacation);

                }
            }

            doctorRepository.saveToFile(doctors, "Doctors.json");
        }

        public List<string> GetDoctorNamesList()
        {
            List<string> docNames = new List<string>();
            doctors = doctorRepository.loadFromFile("Doctors.json");
            for (int i = 0; i < doctors.Count; i++)
            {
                docNames.Add(doctors[i].Name + " " + doctors[i].Surname);
            }
            return docNames;
        }

        public List<Doctor> GetDoctors()
        {
            List<Doctor> doctorList = new List<Doctor>();
            doctors = doctorRepository.loadFromFile("Doctors.json");
            foreach (var doctor in doctors)
            {
                doctorList.Add(doctor);
            }

            return doctorList;
        }

        public List<Doctor> GetSearchedDoctors(string text)
        {
            doctors = doctorRepository.loadFromFile("Doctors.json");
            List<Doctor> searchedDoctors = new List<Doctor>();
            foreach (Doctor doctor in doctors)
            {
                if (ISearched(text, doctor))
                {
                    searchedDoctors.Add(doctor);
                }
            }

            return searchedDoctors;
        }

        private static bool ISearched(string text, Doctor d)
        {
            return d.Name.ToLower().Contains(text) ||
                   d.Surname.ToLower().Contains(text) ||
                   d.Username.ToLower().Contains(text) ||
                   d.Id.ToLower().StartsWith(text);
        }


    }
}
