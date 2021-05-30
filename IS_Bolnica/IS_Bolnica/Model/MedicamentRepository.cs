using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IS_Bolnica.Model
{
    class MedicamentRepository
    {
        private List<Medicament> meds;

        public MedicamentRepository()
        {
            meds = GetMedicaments();
        }

        public void AddMedicament(Medicament newMedicament)
        {
            meds.Add(newMedicament);
            SaveToFile(meds);
        }

        public Medicament GetMedicament(string name)
        {
            Medicament medicament = new Medicament();
            foreach (var m in meds)
            {
                if (m.Name.Equals(name))
                {
                    medicament = m;
                }
            }
            return medicament;
        }

        public void EditMedicament(int index, Medicament newMedicament)
        {
            meds.RemoveAt(index);
            meds.Insert(index, newMedicament);
            SaveToFile(meds);
        }

        public List<Medicament> GetMedicaments()
        {
            var medicaments = new List<Medicament>();

            using (StreamReader file = File.OpenText("Lekovi.json"))
            {
                var serializer = new JsonSerializer();
                medicaments = (List<Medicament>)serializer.Deserialize(file, typeof(List<Medicament>));
            }

            return medicaments;
        }

        public List<Ingredient> GetIngredients(Medicament medicament)
        {
            medicament = GetMedicament(medicament.Name);
            List<Ingredient> ingredients = new List<Ingredient>();
            foreach (var i in medicament.Ingredients)
            {
                ingredients.Add(i);
            }
            return ingredients;
        }

        public void AddIngredient(Medicament medicament, Ingredient ingredient)
        {
            medicament = GetMedicament(medicament.Name);
            CheckMedicamentIngredients(medicament);
            medicament.Ingredients.Add(ingredient);
            SaveToFile(meds);
        }

        private void CheckMedicamentIngredients(Medicament medicament)
        {
            if (medicament.Ingredients == null)
            {
                medicament.Ingredients = new List<Ingredient>();
            }
        }

        public void DeleteIngredient(Medicament medicament, int index)
        {
            medicament = GetMedicament(medicament.Name);
            medicament.Ingredients.RemoveAt(index);
            SaveToFile(meds);
        }

        public void EditIngredient(Medicament medicament, int index, Ingredient newIngredient)
        {
            medicament = GetMedicament(medicament.Name);
            medicament.Ingredients.RemoveAt(index);
            medicament.Ingredients.Insert(index, newIngredient);
            SaveToFile(meds);
        }

        public void SaveToFile(List<Medicament> medicaments)
        {
            string jsonString = JsonConvert.SerializeObject(medicaments, Formatting.Indented);
            File.WriteAllText("Lekovi.json", jsonString);
        }
    }
}
