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

        public Doctor findDoctorByName(string drNameSurname)
        {
            Doctor doctor = new Doctor();
            List<Doctor> doctors = doctorRepository.loadFromFile("Doctors.json");
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

        public List<string> getSpecializationNames()
        {
            List<string> specializationNames = new List<string>();
            Specialization specialization = new Specialization();
            List<Specialization> specializations = specialization.getSpecializations();
            foreach (Specialization spec in specializations)
            {
                specializationNames.Add(spec.Name);
            }

            return specializationNames;
        }

        public List<string> getDoctorsNameSurname()
        {
            List<string> doctorsNameSurname = new List<string>();
            foreach (Doctor doctor in doctorRepository.loadFromFile("Doctors.json"))
            {
                if (doctor.Specialization.Name == " ")
                {
                    doctorsNameSurname.Add(doctor.Name + ' ' + doctor.Surname);
                }
            }
            return doctorsNameSurname;
        }

        public List<string> removeDoctorsFromComboBox()
        {
            List<string> doctorsNameSurname = new List<string>();
            foreach (Doctor doctor in doctorRepository.loadFromFile("Doctors.json"))
            {
                if (doctor.Specialization.Name == " ")
                {
                    doctorsNameSurname.Remove(doctor.Name + ' ' + doctor.Surname);
                }
            }
            return doctorsNameSurname;
        }

        public List<string> removeSpecialistsFromComboBox()
        {
            List<string> specialistsNameSurname = new List<string>();
            foreach (Doctor doctor in doctorRepository.loadFromFile("Doctors.json"))
            {
                if (doctor.Specialization.Name != " ")
                {
                    specialistsNameSurname.Remove(doctor.Name + ' ' + doctor.Surname);
                }
            }

            return specialistsNameSurname;
        }

        public int showDoctorsOrdination(string doctorsNameSurname)
        {
            int ordinationNumber = 0;
            foreach (Doctor doctor in doctorRepository.loadFromFile("Doctors.json"))
            {
                string drNameSurname = doctor.Name + ' ' + doctor.Surname;
                if (drNameSurname.Equals(doctorsNameSurname))
                {
                    ordinationNumber = doctor.Ordination;
                }
            }

            return ordinationNumber;
        }

        public List<string> setSpecialistsInComboBox(string specializationName)
        {
            List<String> specialistsNameAndSurname = new List<string>();
            foreach (Doctor doctor in doctorRepository.loadFromFile("Doctors.json"))
            {
                if (doctor.Specialization.Name.Equals(specializationName))
                {
                    specialistsNameAndSurname.Add(doctor.Name + ' ' + doctor.Surname);
                }
                else
                {
                    specialistsNameAndSurname.Remove(doctor.Name + ' ' + doctor.Surname);
                }
            }

            return specialistsNameAndSurname;
        }

        public List<string> getSpecialistsNameSurname()
        {
            List<string> specialistsNameSurname = new List<string>();
            foreach (Doctor doctor in doctorRepository.loadFromFile("Doctors.json"))
            {
                if (doctor.Specialization != null)
                {
                    specialistsNameSurname.Add(doctor.Name + ' ' + doctor.Surname);
                }
            }
            return specialistsNameSurname;
        }


    }
}
