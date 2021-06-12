using System.Collections.Generic;
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
            doctorRepository.AddShift(shift);
        }

        public void AddVacation(Vacation vacation)
        {
            doctorRepository.AddVacation(vacation);
        }

        public List<string> GetDoctorNamesList()
        {
            List<string> docNames = new List<string>();
            doctors = doctorRepository.GetAll();
            for (int i = 0; i < doctors.Count; i++)
            {
                docNames.Add(doctors[i].Name + " " + doctors[i].Surname);
            }
            return docNames;
        }

        public List<Doctor> GetSearchedDoctors(string text)
        {
            doctors = doctorRepository.GetAll();
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

        public Doctor FindDoctorByName(string drNameSurname)
        {
            Doctor doctor = new Doctor();
            List<Doctor> doctors = doctorRepository.GetAll();
            foreach (Doctor dr in doctors)
            {
                string doctorsNameAndSurname = dr.Name + ' ' + dr.Surname;
                if (doctorsNameAndSurname.Equals(drNameSurname))
                {
                    doctor = dr;
                }
            }

            return doctor;
        }

        public List<string> GetDoctorsNameSurname()
        {
            List<string> doctorsNameSurname = new List<string>();
            foreach (Doctor doctor in doctorRepository.GetAll())
            {
                if (doctor.Specialization.Name == " ")
                {
                    doctorsNameSurname.Add(doctor.Name + ' ' + doctor.Surname);
                }
            }
            return doctorsNameSurname;
        }


        public int ShowDoctorsOrdination(string doctorsNameSurname)
        {
            int ordinationNumber = 0;
            foreach (Doctor doctor in doctorRepository.GetAll())
            {
                string drNameSurname = doctor.Name + ' ' + doctor.Surname;
                if (drNameSurname.Equals(doctorsNameSurname))
                {
                    ordinationNumber = doctor.Ordination;
                }
            }

            return ordinationNumber;
        }


        public List<string> GetSpecialistsNameSurname()
        {
            List<string> specialistsNameSurname = new List<string>();
            foreach (Doctor doctor in doctorRepository.GetAll())
            {
                if (doctor.Specialization != null)
                {
                    specialistsNameSurname.Add(doctor.Name + ' ' + doctor.Surname);
                }
            }
            return specialistsNameSurname;
        }

        public List<Doctor> GetAllDoctors()
        {
            return doctorRepository.GetAll();
        }

        public List<string> GetDoctorNamesWithSpecialization()
        {
            List<string> docNames = new List<string>();
            doctors = doctorRepository.GetAll();

            foreach (Doctor doctor in doctors)
            {
                docNames.Add(doctor.Name + " " + doctor.Surname + "(" + doctor.Specialization.Name + ")");
            }

            return docNames;
        }
    }
}
