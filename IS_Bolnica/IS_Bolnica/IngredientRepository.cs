using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace IS_Bolnica
{
    internal class IngredientRepository
    {
        public List<Ingredient> GetAll()
        {
            throw new NotImplementedException();
        }

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
    }
}