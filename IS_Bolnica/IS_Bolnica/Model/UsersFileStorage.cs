﻿using Model;
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
        public ObservableCollection<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public void saveToFile(ObservableCollection<User> users, string fileName)
        {
            string jsonString = JsonConvert.SerializeObject(users, Formatting.Indented);
            File.WriteAllText(fileName, jsonString);
        }

        public ObservableCollection<User> loadFromFile(string fileName)
        {
            var usersList = new ObservableCollection<User>();

            using (StreamReader file = File.OpenText(fileName))
            {
                var serializer = new JsonSerializer();
                usersList = (ObservableCollection<User>)serializer.Deserialize(file, typeof(ObservableCollection<User>));
            }

            return usersList;
        }
    }
}