using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IS_Bolnica.Annotations;
using IS_Bolnica.IRepository;

namespace IS_Bolnica.Model
{
    public class MedicamentRepository : IMedicamentRepository
    {
        private List<Medicament> meds;

        public MedicamentRepository()
        {
            meds = GetAll();
        }

        /*

        private void CheckMedicamentIngredients(Medicament medicament)
        {
            if (medicament.Ingredients == null)
            {
                medicament.Ingredients = new List<Ingredient>();
            }
        }*/


        public List<Medicament> GetAll()
        {
            var medicaments = new List<Medicament>();

            using (StreamReader file = File.OpenText("Lekovi.json"))
            {
                var serializer = new JsonSerializer();
                medicaments = (List<Medicament>)serializer.Deserialize(file, typeof(List<Medicament>));
            }

            return medicaments;
        }

        public Medicament FindById(int id)
        {
            meds = GetAll();
            foreach (var m in meds)
            {
                if (m.Id == id)
                {
                    return m;
                }
            }

        public void SaveToFile(List<Medicament> entities)
        {
            string jsonString = JsonConvert.SerializeObject(entities, Formatting.Indented);
            File.WriteAllText("Lekovi.json", jsonString);
        }

        public void Add(Medicament newEntity)
        {
            meds = GetAll();
            meds.Add(newEntity);
            SaveToFile(meds);
        }

        public void Update(int index, Medicament newEntity)
        {
            meds = GetAll();
            meds.RemoveAt(index);
            meds.Insert(index, newEntity);
            SaveToFile(meds);
        }

        public void Delete(int index)
        {
            meds = GetAll();
            meds.RemoveAt(index);
            SaveToFile(meds);
        }

        public Medicament GetMedicamentByName(string name)
        {
            meds = GetAll();
            foreach (var m in meds)
            {
                if (m.Name.Equals(name))
                {
                    return m;
                }
            }

            return null;
        }
    }
}
