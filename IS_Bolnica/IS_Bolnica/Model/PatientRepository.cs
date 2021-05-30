using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;
using System.Collections.ObjectModel;

namespace Model
{
    public class PatientRepository
    {
        private string fileName = "PatientRecordFileStorage.json";
        public List<Patient> GetAll()
        {
            throw new NotImplementedException();
        }

        public void SaveToFile(List<Patient> patients)
        {
            string jsonString = JsonConvert.SerializeObject(patients, Formatting.Indented);
            File.WriteAllText(fileName, jsonString);
        }

        public List<Patient> LoadFromFile()
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