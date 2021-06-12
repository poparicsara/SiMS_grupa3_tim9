using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IS_Bolnica.IRepository;

namespace IS_Bolnica.Model
{
    public class PrescriptionRepository : IPrescriptionRepository
    {
        private string fileName = "prescriptions.json";
        private List<Prescription> prescriptions;

        public void SaveToFile(List<Prescription> prescriptions)
        {
            string jsonString = JsonConvert.SerializeObject(prescriptions, Formatting.Indented);
            File.WriteAllText(fileName, jsonString);
        }

        public List<Prescription> GetAll()
        {
            var prescriptionssList = new List<Prescription>();

            using (StreamReader file = File.OpenText(fileName))
            {
                var serializer = new JsonSerializer();
                prescriptionssList = (List<Prescription>)serializer.Deserialize(file, typeof(List<Prescription>));
            }

            return prescriptionssList;
        }

        public void Add(Prescription newEntity)
        {
            prescriptions = GetAll();
            prescriptions.Add(newEntity);
            SaveToFile(prescriptions);
        }

        public void Update(int index, Prescription newEntity)
        {
            prescriptions = GetAll();
            prescriptions.RemoveAt(index);
            SaveToFile(prescriptions);
        }

        public void Delete(int index)
        {
            prescriptions = GetAll();                   
            prescriptions.RemoveAt(index);
            SaveToFile(prescriptions);
        }

        public Prescription FindById(string id)
        {
            throw new NotImplementedException();
        }

    }
}
