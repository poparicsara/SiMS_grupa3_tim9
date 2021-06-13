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
    public class AnamnesisRepository : IAnamnesisRepository
    {
        private string fileName = "anamneses.json";
        private IAnamnesisRepository anamnesisRepositoryImplementation;
        private List<Anamnesis> anamneses;

        public void SaveToFile(List<Anamnesis> anamneses)
        {
            string jsonString = JsonConvert.SerializeObject(anamneses, Formatting.Indented);
            File.WriteAllText(fileName, jsonString);
        }

        public List<Anamnesis> GetAll()
        {
            var anamneses = new List<Anamnesis>();

            using (StreamReader file = File.OpenText(fileName))
            {
                var serializer = new JsonSerializer();
                anamneses = (List<Anamnesis>)serializer.Deserialize(file, typeof(List<Anamnesis>));
            }

            return anamneses;
        }

        public void Add(Anamnesis newEntity)
        {
            anamneses = GetAll();
            anamneses.Add(newEntity);
            SaveToFile(anamneses);
        }

        public void Update(int index, Anamnesis newEntity)
        {
            anamneses = GetAll();
            anamneses.RemoveAt(index);
            anamneses.Add(newEntity);
            SaveToFile(anamneses);
        }

        public void Delete(int index)
        {
            anamneses = GetAll();
            anamneses.RemoveAt(index);
            SaveToFile(anamneses);
        }

        public Anamnesis FindById(string id)
        {
            //return anamnesisRepositoryImplementation.FindById(id);
            throw new NotImplementedException();
        }
    }
}
