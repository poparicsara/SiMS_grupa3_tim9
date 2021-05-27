using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IS_Bolnica.Model
{
    class RenovationRepository
    {
        public List<Renovation> GetAll()
        {
            throw new NotImplementedException();
        }

        public void saveToFile(List<Renovation> renovations)
        {
            string jsonString = JsonConvert.SerializeObject(renovations, Formatting.Indented);
            File.WriteAllText("Renovations.json", jsonString);
        }

        public List<Renovation> GetRenovations()
        {
            var renovations = new List<Renovation>();

            using (StreamReader file = File.OpenText("Renovations.json"))
            {
                var serializer = new JsonSerializer();
                renovations = (List<Renovation>)serializer.Deserialize(file, typeof(List<Renovation>));
            }

            return renovations;
        }
    }
}
