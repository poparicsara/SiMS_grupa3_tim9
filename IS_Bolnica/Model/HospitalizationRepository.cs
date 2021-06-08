using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IS_Bolnica.Model
{
    class HospitalizationRepository
    {
        private String fileName = "hospitalizedPatients.json";
        public List<Hospitalization> GetAll()
        {
            throw new NotImplementedException();
        }

        public void SaveToFile(List<Hospitalization> hospitalizations)
        {
            string jsonString = JsonConvert.SerializeObject(hospitalizations, Formatting.Indented);
            File.WriteAllText(fileName, jsonString);
        }

        public List<Hospitalization> LoadFromFile()
        {
            var hospitalizations = new List<Hospitalization>();

            using (StreamReader file = File.OpenText(fileName))
            {
                var serializer = new JsonSerializer();
                hospitalizations = (List<Hospitalization>)serializer.Deserialize(file, typeof(List<Hospitalization>));
            }

            return hospitalizations;
        }
    }
}
