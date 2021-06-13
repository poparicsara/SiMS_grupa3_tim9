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
    class MergingRepository : IMergingRepository
    {
        private List<Merging> mergings = new List<Merging>();

        public List<Merging> GetAll()
        {
            var mergings = new List<Merging>();
            using (StreamReader file = File.OpenText("Mergings.json"))
            {
                var serializer = new JsonSerializer();
                mergings = (List<Merging>)serializer.Deserialize(file, typeof(List<Merging>));
            }
            return mergings;
        }

        public Merging FindById(int id)
        {
            throw new NotImplementedException();
        }

        public void SaveToFile(List<Merging> entities)
        {
            string jsonString = JsonConvert.SerializeObject(entities, Formatting.Indented);
            File.WriteAllText("Mergings.json", jsonString);
        }

        public void Add(Merging newEntity)
        {
            mergings = GetAll();
            mergings.Add(newEntity);
            SaveToFile(mergings);
        }

        public void Update(int index, Merging newEntity)
        {
            mergings = GetAll();
            Merging newMerging = mergings.ElementAt(index);
            newMerging.Executed = true;
            mergings.RemoveAt(index);
            mergings.Insert(index, newMerging);
            SaveToFile(mergings);
        }

        public void Delete(int index)
        {
            throw new NotImplementedException();
        }

        public void EditMerging(int index)
        {
            mergings = GetAll();
            Merging newMerging = mergings.ElementAt(index);
            newMerging.Executed = true;
            mergings.RemoveAt(index);
            mergings.Insert(index, newMerging);
            SaveToFile(mergings);
        }
    }
}
