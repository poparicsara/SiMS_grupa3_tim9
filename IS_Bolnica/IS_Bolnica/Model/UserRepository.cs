using Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace IS_Bolnica.Model
{
    class UserRepository
    {
        public void SaveToFile(List<User> users, string fileName)
        {
            string jsonString = JsonConvert.SerializeObject(users, Formatting.Indented);
            File.WriteAllText(fileName, jsonString);
        }

        public List<User> LoadFromFile(string fileName)
        {
            var usersList = new List<User>();

            using (StreamReader file = File.OpenText(fileName))
            {
                var serializer = new JsonSerializer();
                usersList = (List<User>)serializer.Deserialize(file, typeof(List<User>));
            }

            return usersList;
        }
    }
}
