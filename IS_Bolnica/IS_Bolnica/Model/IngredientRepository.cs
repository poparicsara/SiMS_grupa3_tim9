using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using IS_Bolnica.IRepository;

namespace IS_Bolnica
{
    public class IngredientRepository : IIngredientRepository
    {
        private List<Medicament> meds = new List<Medicament>();
        private MedicamentRepository medRepository = new MedicamentRepository();
        private string fileName = "Sastojci.json";
        private List<Ingredient> ingredients;

        public void AddIngredient(Medicament medicament, Ingredient ingredient)
        {
            meds = medRepository.GetAll();
            foreach (var m in meds)
            {
                if (m.Id == medicament.Id)
                {
                    m.Ingredients.Add(ingredient);
                    medRepository.SaveToFile(meds);
                }
            }
        }

        public void DeleteIngredient(Medicament medicament, int index)
        {
            meds = medRepository.GetAll();
            foreach (var m in meds)
            {
                if (m.Id == medicament.Id)
                {
                    m.Ingredients.RemoveAt(index);
                    medRepository.SaveToFile(meds);
                }
            }
        }

        public void EditIngredient(Medicament medicament, int index, Ingredient newIngredient)
        {
            meds = medRepository.GetAll();
            foreach (var m in meds)
            {
                if (m.Id == medicament.Id)
                {
                    m.Ingredients.RemoveAt(index);
                    m.Ingredients.Insert(index, newIngredient);
                    medRepository.SaveToFile(meds);
                }
            }
        }

        public List<Ingredient> GetMedicamentIngredients(Medicament medicament)
        {
            medicament = medRepository.FindById(medicament.Id);
            return medicament.Ingredients;
        }

        public List<Ingredient> GetAll()
        {
            var ingredients = new List<Ingredient>();

            using (StreamReader file = File.OpenText(fileName))
            {
                var serializer = new JsonSerializer();
                ingredients = (List<Ingredient>)serializer.Deserialize(file, typeof(List<Ingredient>));
            }

            return ingredients;
        }

        public Ingredient FindById(string id)
        {
            throw new NotImplementedException();
        }

        public void SaveToFile(List<Ingredient> entities)
        {
            string jsonString = JsonConvert.SerializeObject(entities, Formatting.Indented);
            File.WriteAllText(fileName, jsonString);
        }

        public void Add(Ingredient newEntity)
        {
            ingredients = GetAll();
            ingredients.Add(newEntity);
            SaveToFile(ingredients);
        }

        public void Update(int index, Ingredient newEntity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int index)
        {
            ingredients = GetAll();
            ingredients.RemoveAt(index);
            SaveToFile(ingredients);
        }

    }
}
