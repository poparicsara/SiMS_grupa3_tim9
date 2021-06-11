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
    class PrescriptionRepository
    {
        private string fileName = "prescriptions.json";
        public void SaveToFile(List<Prescription> prescriptions)
        {
            string jsonString = JsonConvert.SerializeObject(prescriptions, Formatting.Indented);
            File.WriteAllText(fileName, jsonString);
        }

        public List<Prescription> LoadFromFile()
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
