using Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IS_Bolnica.Model
{
    class UsersFileStorage
    {
        public List<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public void saveToFile(List<User> users, string fileName)
        {
            string jsonString = JsonConvert.SerializeObject(users, Formatting.Indented);
            File.WriteAllText(fileName, jsonString);
        }

        public List<User> loadFromFile(string fileName)
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
