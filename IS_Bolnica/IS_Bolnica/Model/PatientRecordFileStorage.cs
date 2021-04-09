

using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;
using System.IO;

namespace Model
{
    public class PatientRecordFileStorage
    {

        public ObservableCollection<Patient> GetAll()
        {
            throw new NotImplementedException();
        }

        public void saveToFile(ObservableCollection<Patient> patients, string fileName)
        {
            string jsonString = JsonConvert.SerializeObject(patients, Formatting.Indented);
            File.WriteAllText(fileName, jsonString);
        }

        public void saveToFileObject(Patient patient, string fileName)
        {
            string jsonString = JsonConvert.SerializeObject(patient, Formatting.Indented);
            File.WriteAllText(fileName, jsonString);
        }

        public ObservableCollection<Patient> loadFromFile(string fileName)
        {
            var patientsList = new ObservableCollection<Patient>();

            using (StreamReader file = File.OpenText(fileName))
            {
                var serializer = new JsonSerializer();
                patientsList = (ObservableCollection<Patient>)serializer.Deserialize(file, typeof(ObservableCollection<Patient>));
            }

            return patientsList;
        }

    }
}