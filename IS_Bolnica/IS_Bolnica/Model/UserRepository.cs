using Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using IS_Bolnica.IRepository;

namespace IS_Bolnica.Model
{
    class UserRepository : IUserRepository
    {
        private string fileName = "UsersFileStorage.json";
        private List<User> users = new List<User>();

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

        public List<User> GetAll()
        {
            var usersList = new List<User>();

            using (StreamReader file = File.OpenText(fileName))
            {
                var serializer = new JsonSerializer();
                usersList = (List<User>)serializer.Deserialize(file, typeof(List<User>));
            }

            return usersList;
        }

        public User FindById(string id)
        {
            throw new NotImplementedException();
        }

        public void SaveToFile(List<User> entities)
        {
            string jsonString = JsonConvert.SerializeObject(entities, Formatting.Indented);
            File.WriteAllText(fileName, jsonString);
        }

        public void Add(User newEntity)
        {
            users = GetAll();
            users.Add(newEntity);
            SaveToFile(users);
        }

        public void Update(int index, User newEntity)
        {
            users = GetAll();
            users.RemoveAt(index);
            users.Add(newEntity);
            SaveToFile(users);
        }

        public void Delete(int index)
        {
            users = GetAll();
            users.RemoveAt(index);
            SaveToFile(users);
        }

        public void SaveToFile(List<User> entities, string fileName)
        {
            string jsonString = JsonConvert.SerializeObject(entities, Formatting.Indented);
            File.WriteAllText(fileName, jsonString);
        }
    }
}
