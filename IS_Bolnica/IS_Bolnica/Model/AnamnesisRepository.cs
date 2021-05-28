﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IS_Bolnica.Model
{
    class AnamnesisRepository
    {
        public List<Anamnesis> GetAll()
        {
            throw new NotImplementedException();
        }

        public void saveToFile(List<Anamnesis> anamneses, string fileName)
        {
            string jsonString = JsonConvert.SerializeObject(anamneses, Formatting.Indented);
            File.WriteAllText(fileName, jsonString);
        }

        public List<Anamnesis> loadFromFile(string fileName)
        {
            var anamneses = new List<Anamnesis>();

            using (StreamReader file = File.OpenText(fileName))
            {
                var serializer = new JsonSerializer();
                anamneses = (List<Anamnesis>)serializer.Deserialize(file, typeof(List<Anamnesis>));
            }

            return anamneses;
        }
    }
}
