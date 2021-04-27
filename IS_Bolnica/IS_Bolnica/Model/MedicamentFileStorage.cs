using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IS_Bolnica.Model
{
    class MedicamentFileStorage
    {
        public List<Medicament> GetAll()
        {
            throw new NotImplementedException();
        }

        public void saveToFile(List<Medicament> medicaments, string fileName)
        {
            string jsonString = JsonConvert.SerializeObject(medicaments, Formatting.Indented);
            File.WriteAllText(fileName, jsonString);
        }

        public List<Medicament> loadFromFile(string fileName)
        {
            var medicaments = new List<Medicament>();

            using (StreamReader file = File.OpenText(fileName))
            {
                var serializer = new JsonSerializer();
                medicaments = (List<Medicament>)serializer.Deserialize(file, typeof(List<Medicament>));
            }

            return medicaments;
        }
    }
}
