using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IS_Bolnica.IRepository;

namespace IS_Bolnica.Model
{
    class RenovationRepository : IRenovationRepository
    {
        private List<Renovation> renovations = new List<Renovation>();

        public RenovationRepository()
        {
            renovations = GetAll();
        }

        public List<Renovation> GetAll()
        {
            var renovations = new List<Renovation>();

            using (StreamReader file = File.OpenText("Renovations.json"))
            {
                var serializer = new JsonSerializer();
                renovations = (List<Renovation>)serializer.Deserialize(file, typeof(List<Renovation>));
            }

            return renovations;
        }

        public Renovation FindById(int id)
        {
            throw new NotImplementedException();
        }

        public void SaveToFile(List<Renovation> entities)
        {
            string jsonString = JsonConvert.SerializeObject(renovations, Formatting.Indented);
            File.WriteAllText("Renovations.json", jsonString);
        }

        public void Add(Renovation newEntity)
        {
            renovations.Add(newEntity);
            SaveToFile(renovations);
        }

        public void Update(int index, Renovation newEntity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int index)
        {
            throw new NotImplementedException();
        }
    }
}
