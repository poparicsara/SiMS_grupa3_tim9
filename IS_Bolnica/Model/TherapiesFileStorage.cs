using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IS_Bolnica.Model
{
    class TherapiesFileStorage
    {

        public List<Therapy> GetAll()
        {
            throw new NotImplementedException();
        }

        public void saveToFile(List<Therapy> therapies, string fileName)
        {
            string jsonString = JsonConvert.SerializeObject(therapies, Formatting.Indented);
            File.WriteAllText(fileName, jsonString);
        }

        public List<Therapy> loadFromFile(string fileName)
        {
            var therapies = new List<Therapy>();

            using (StreamReader file = File.OpenText(fileName))
            {
                var serializer = new JsonSerializer();
                therapies = (List<Therapy>)serializer.Deserialize(file, typeof(List<Therapy>));
            }

            return therapies;
        }
    }
}
