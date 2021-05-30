using Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IS_Bolnica.Model
{
    class DoctorRepository
    {
        private string fileName = "Doctors.json";
        public List<Doctor> GetAll()
        {
            throw new NotImplementedException();
        }

        public void SaveToFile(List<Doctor> doctors)
        {
            string jsonString = JsonConvert.SerializeObject(doctors, Formatting.Indented);
            File.WriteAllText(fileName, jsonString);
        }

        public List<Doctor> LoadFromFile()
        {
            var doctors = new List<Doctor>();

            using (StreamReader file = File.OpenText(fileName))
            {
                var serializer = new JsonSerializer();
                doctors = (List<Doctor>)serializer.Deserialize(file, typeof(List<Doctor>));
            }

            return doctors;
        }
    }
}
