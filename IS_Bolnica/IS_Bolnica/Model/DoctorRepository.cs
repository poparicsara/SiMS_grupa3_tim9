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
        public List<Doctor> GetAll()
        {
            throw new NotImplementedException();
        }

        public void saveToFile(List<Doctor> doctors, string fileName)
        {
            string jsonString = JsonConvert.SerializeObject(doctors, Formatting.Indented);
            File.WriteAllText(fileName, jsonString);
        }

        public List<Doctor> loadFromFile(string fileName)
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
