using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IS_Bolnica.Model
{
    class PrescriptionFileStorage
    {
        public void saveToFile(List<Prescription> prescriptions, string fileName)
        {
            string jsonString = JsonConvert.SerializeObject(prescriptions, Formatting.Indented);
            File.WriteAllText(fileName, jsonString);
        }

        public void saveToFileObject(Prescription prescription, string fileName)
        {
            string jsonString = JsonConvert.SerializeObject(prescription, Formatting.Indented);
            File.WriteAllText(fileName, jsonString);
        }

        public List<Prescription> loadFromFile(string fileName)
        {
            var prescriptionssList = new List<Prescription>();

            using (StreamReader file = File.OpenText(fileName))
            {
                var serializer = new JsonSerializer();
                prescriptionssList = (List<Prescription>)serializer.Deserialize(file, typeof(List<Prescription>));
            }

            return prescriptionssList;
        }
    }
}
