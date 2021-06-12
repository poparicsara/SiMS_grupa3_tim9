using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using IS_Bolnica.IRepository;

namespace IS_Bolnica
{
    public class IngredientRepository : IIngredientRepository
    {
        private string fileName = "Sastojci.json";
        private List<Ingredient> ingredients;

        public Ingredient FindById(string id)
        {
            throw new NotImplementedException();
        }

        public void SaveToFile(List<Ingredient> ingredients)
        {
            string jsonString = JsonConvert.SerializeObject(ingredients, Formatting.Indented);
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


    }
}
