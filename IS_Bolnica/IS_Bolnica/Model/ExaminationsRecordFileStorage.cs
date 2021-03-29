using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;

namespace Model
{
    public class ExaminationsRecordFileStorage
    {
        
        public List<Examination> GetAll()
        {
            throw new NotImplementedException();
        }

        public void saveToFile(List<Examination> examinations, string fileName)
        {
            string jsonString = JsonConvert.SerializeObject(examinations, Formatting.Indented);
            File.WriteAllText(fileName, jsonString);
        }

        public List<Examination> loadFromFile(string fileName)
        {
            var examinationList = new List<Examination>();

            using (StreamReader file = File.OpenText(fileName))
            {
                var serializer = new JsonSerializer();
                examinationList = (List<Examination>)serializer.Deserialize(file, typeof(List<Examination>));
            }

            return examinationList;
        }

    }
}