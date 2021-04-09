

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Model
{
    public class OperationsFileStorage
    {
        public List<Operation> GetAll()
        {
            throw new NotImplementedException();
        }

        public void saveToFile(List<Operation> operations, string fileName)
        {
            string jsonString = JsonConvert.SerializeObject(operations, Formatting.Indented);
            File.WriteAllText(fileName, jsonString);
        }

        public List<Operation> loadFromFile(string fileName)
        {
            var operationList = new List<Operation>();

            using (StreamReader file = File.OpenText(fileName))
            {
                var serializer = new JsonSerializer();
                operationList = (List<Operation>)serializer.Deserialize(file, typeof(List<Operation>));
            }

            return operationList;
        }

    }
}