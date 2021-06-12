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
    public class HospitalizationRepository : IHospitalizationRepository
    {
        private String fileName = "hospitalizedPatients.json";
        private List<Hospitalization> hospitalizations;

        public void SaveToFile(List<Hospitalization> hospitalizations)
        {
            string jsonString = JsonConvert.SerializeObject(hospitalizations, Formatting.Indented);
            File.WriteAllText(fileName, jsonString);
        }

        public List<Hospitalization> GetAll()
        {
            var hospitalizations = new List<Hospitalization>();

            using (StreamReader file = File.OpenText(fileName))
            {
                var serializer = new JsonSerializer();
                hospitalizations = (List<Hospitalization>)serializer.Deserialize(file, typeof(List<Hospitalization>));
            }

            return hospitalizations;
        }

        public void Add(Hospitalization newEntity)
        {
            hospitalizations = GetAll();
            hospitalizations.Add(newEntity);
            SaveToFile(hospitalizations);
        }

        public void Update(int index, Hospitalization newEntity)
        {
            hospitalizations = GetAll();
            hospitalizations.RemoveAt(index);
            hospitalizations.Insert(index, newEntity);
            SaveToFile(hospitalizations);
        }

        public void Delete(int index)
        {
            throw new NotImplementedException();
        }


        public Hospitalization FindById(string id)
        {
            throw new NotImplementedException();
        }

    }
}
