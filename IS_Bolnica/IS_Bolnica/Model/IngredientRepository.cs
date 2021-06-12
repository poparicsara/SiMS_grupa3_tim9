using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using IS_Bolnica.IRepository;
using IS_Bolnica.Model;

namespace IS_Bolnica
{
    internal class IngredientRepository : IIngredientRepository
    {
        private List<Medicament> meds = new List<Medicament>();
        private MedicamentRepository medRepository = new MedicamentRepository();

        public void saveToFile(List<Ingredient> ingredients, string fileName)
        {
            string jsonString = JsonConvert.SerializeObject(ingredients, Formatting.Indented);
            File.WriteAllText(fileName, jsonString);
        }

        public List<Ingredient> loadFromFile(string fileName)
        {
            var ingredients = new List<Ingredient>();

            using (StreamReader file = File.OpenText(fileName))
            {
                var serializer = new JsonSerializer();
                ingredients = (List<Ingredient>)serializer.Deserialize(file, typeof(List<Ingredient>));
            }

            return ingredients;
        }
        public List<Ingredient> GetAll()
        {
            throw new NotImplementedException();
        }

        public Ingredient FindById(string id)
        {
            throw new NotImplementedException();
        }

        public void SaveToFile(List<Ingredient> entities)
        {
            throw new NotImplementedException();
        }

        public void Add(Ingredient newEntity)
        {
            throw new NotImplementedException();
        }

        public void Update(int index, Ingredient newEntity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int index)
        {
            throw new NotImplementedException();
        }

        public void AddIngredient(Medicament medicament, Ingredient ingredient)
        {
            meds = medRepository.GetAll();
            medicament = medRepository.FindById(medicament.Id);
            Debug.WriteLine(medicament.Ingredients);
            medicament.Ingredients.Add(ingredient);
            Debug.WriteLine(medicament.Ingredients);
            medRepository.SaveToFile(meds);
        }

        public List<Ingredient> GetMedicamentIngredients(Medicament medicament)
        {
            medicament = medRepository.FindById(medicament.Id);
            return medicament.Ingredients;
        }
    }
}
