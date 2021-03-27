using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;

namespace Model
{
    public class PatientRecordFileStorage
    {
        public List<Patient> GetAll()
        {
            throw new NotImplementedException();
        }

        public void saveToFile(List<Patient> patients, string fileName)
        {
            string jsonString = JsonConvert.SerializeObject(patients, Formatting.Indented);
            File.WriteAllText(fileName, jsonString);
        }

        public List<Patient> loadFromFile(string fileName)
        {
            var patientsList = new List<Patient>();

            using (StreamReader file = File.OpenText(fileName))
            {
                var serializer = new JsonSerializer();
                patientsList = (List<Patient>)serializer.Deserialize(file, typeof(List<Patient>));
            }

            return patientsList;
        }

    }
}