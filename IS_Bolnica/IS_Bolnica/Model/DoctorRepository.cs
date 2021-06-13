using Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IS_Bolnica.IRepository;

namespace IS_Bolnica.Model
{
    class DoctorRepository : IDoctorRepository
    {
        private string fileName = "Doctors.json";
        private List<Doctor> doctors = new List<Doctor>();

        public List<Doctor> GetAll()
        {
            var doctors = new List<Doctor>();

            using (StreamReader file = File.OpenText(fileName))
            {
                var serializer = new JsonSerializer();
                doctors = (List<Doctor>)serializer.Deserialize(file, typeof(List<Doctor>));
            }

            return doctors;
        }

        public Doctor FindById(string id)
        {
            doctors = GetAll();
            foreach (var doctor in doctors)
            {
                if (doctor.Id.Equals(id))
                {
                    return doctor;
                }
            }

            return null;
        }

        public void DeleteShift(int index, string id)
        {
            Doctor doctor = FindById(id);
            doctor.Shifts.RemoveAt(index);
            SaveShifts(doctor.Shifts, id);
        }

        public void DeleteVacation(int index, string id)
        {
            Doctor doctor = FindById(id);
            doctor.Vacations.RemoveAt(index);
            SaveVacations(doctor.Vacations, id);
        }


        private void SaveShifts(List<Shift> shifts, string id)
        {
            doctors = GetAll();
            foreach (var doctor in doctors)
            {
                if (doctor.Id.Equals(id))
                {
                    doctor.Shifts = shifts;
                    break;
                }
            }
            SaveToFile(doctors);
        }

        private void SaveVacations(List<Vacation> vacations, string id)
        {
            doctors = GetAll();
            foreach (var doctor in doctors)
            {
                if (doctor.Id.Equals(id))
                {
                    doctor.Vacations = vacations;
                    break;
                }
            }
            SaveToFile(doctors);
        }

        public void Delete(int index)
        {
            doctors = GetAll();
            doctors.RemoveAt(index);
            SaveToFile(doctors);
        }


        public void SaveToFile(List<Doctor> doctors)
        {
            string jsonString = JsonConvert.SerializeObject(doctors, Formatting.Indented);
            File.WriteAllText(fileName, jsonString);
        }

        public void Add(Doctor newEntity)
        {
            doctors = GetAll();
            doctors.Add(newEntity);
            SaveToFile(doctors);
        }

        public void Update(int index, Doctor newEntity)
        {
            throw new NotImplementedException();
        }

        public void AddShift(Shift shift)
        {
            doctors = GetAll();
            for (int i = 0; i < doctors.Count; i++)
            {
                if (doctors[i].Id.Equals(shift.DoctorsId))
                {
                    doctors[i].Shifts.Add(shift);
                }
            }
            SaveToFile(doctors);
        }

        public void AddVacation(Vacation vacation)
        {
            doctors = GetAll();
            for (int i = 0; i < doctors.Count; i++)
            {
                if (doctors[i].Id.Equals(vacation.DoctorsId))
                {
                    doctors[i].Vacations.Add(vacation);

                }
            }

            SaveToFile(doctors);
        }
    }
}
