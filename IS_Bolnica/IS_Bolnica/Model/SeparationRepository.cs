using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IS_Bolnica.IRepository;
using Newtonsoft.Json;

namespace IS_Bolnica.Model
{
    class SeparationRepository : ISeparationRepository
    {
        private List<Separation> separations = new List<Separation>();

        public List<Separation> GetAll()
        {
            var separations = new List<Separation>();
            using (StreamReader file = File.OpenText("Separations.json"))
            {
                var serializer = new JsonSerializer();
                separations = (List<Separation>)serializer.Deserialize(file, typeof(List<Separation>));
            }
            return separations;
        }

        public Separation FindById(int id)
        {
            throw new NotImplementedException();
        }

        public void SaveToFile(List<Separation> entities)
        {
            string jsonString = JsonConvert.SerializeObject(entities, Formatting.Indented);
            File.WriteAllText("Separations.json", jsonString);
        }

        public void Add(Separation newEntity)
        {
            separations = GetAll();
            separations.Add(newEntity);
            SaveToFile(separations);
        }

        public void Update(int index, Separation newEntity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int index)
        {
            throw new NotImplementedException();
        }

        public void EditSeparation(int index)
        {
            separations = GetAll();
            separations.ElementAt(index).Executed = true;
            SaveToFile(separations);
        }
    }
}
