using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;

namespace Model
{
    class EvaluationFileStorage
    {
        public void saveToFile(List<Evaluation> evaluations, string fileName)
        {
            string jsonString = JsonConvert.SerializeObject(evaluations, Formatting.Indented);
            File.WriteAllText(fileName, jsonString);
        }

        public List<Evaluation> loadFromFile(string fileName)
        {
            var evaluationList = new List<Evaluation>();

            using (StreamReader file = File.OpenText(fileName))
            {
                var serializer = new JsonSerializer();
                evaluationList = (List<Evaluation>)serializer.Deserialize(file, typeof(List<Evaluation>));
            }

            return evaluationList;
        }
    }
}
