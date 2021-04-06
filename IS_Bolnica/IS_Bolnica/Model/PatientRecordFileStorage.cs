using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;
using System.Collections.ObjectModel;

namespace Model
{
    public class PatientRecordFileStorage
    { 
        
        public ObservableCollection<Patient> GetAll()
        {
            throw new NotImplementedException();
        }

        public void saveToFile(ObservableCollection<User> patients, string fileName)
        {
            string jsonString = JsonConvert.SerializeObject(patients, Formatting.Indented);
            File.WriteAllText(fileName, jsonString);
        }

        public void saveToFileObject(User patient, string fileName)
        {
            string jsonString = JsonConvert.SerializeObject(patient, Formatting.Indented);
            File.WriteAllText(fileName, jsonString);
        }

        public ObservableCollection<User> loadFromFile(string fileName)
        {
            var patientsList = new ObservableCollection<User>();

            using (StreamReader file = File.OpenText(fileName))
            {
                var serializer = new JsonSerializer();
                patientsList = (ObservableCollection<User>)serializer.Deserialize(file, typeof(ObservableCollection<User>));
            }

            return patientsList;
        }

    }
}