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
        private List<Merging> mergings = new List<Merging>();
        private List<Separation> separations = new List<Separation>();

        public RenovationRepository()
        {
            renovations = GetAll();
            mergings = GetMergings();
            separations = GetSeparations();
        }

        public void AddMerging(Merging newMerging)
        {
            mergings.Add(newMerging);
            SaveMerging(mergings);
        }

        public void EditMerging(int index)
        {
            Merging newMerging = mergings.ElementAt(index);
            newMerging.Executed = true;
            mergings.RemoveAt(index);
            mergings.Insert(index, newMerging);
            SaveMerging(mergings);
        }

        public void SaveMerging(List<Merging> mergings)
        {
            string jsonString = JsonConvert.SerializeObject(mergings, Formatting.Indented);
            File.WriteAllText("Mergings.json", jsonString);
        }

        public List<Merging> GetMergings()
        {
            var mergings = new List<Merging>();
            using (StreamReader file = File.OpenText("Mergings.json"))
            {
                var serializer = new JsonSerializer();
                mergings = (List<Merging>)serializer.Deserialize(file, typeof(List<Merging>));
            }
            return mergings;
        }

        public void AddSeparation(Separation newSeparation)
        {
            separations.Add(newSeparation);
            SaveSeparation(separations);
        }

        public void EditSeparation(int index)
        {
            Separation newSeparation = separations.ElementAt(index);
            newSeparation.Executed = true;
            separations.RemoveAt(index);
            separations.Insert(index, newSeparation);
            SaveSeparation(separations);
        }

        public void SaveSeparation(List<Separation> separations)
        {
            string jsonString = JsonConvert.SerializeObject(separations, Formatting.Indented);
            File.WriteAllText("Separations.json", jsonString);
        }

        public List<Separation> GetSeparations()
        {
            var separations = new List<Separation>();
            using (StreamReader file = File.OpenText("Separations.json"))
            {
                var serializer = new JsonSerializer();
                separations = (List<Separation>)serializer.Deserialize(file, typeof(List<Separation>));
            }
            return separations;
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
