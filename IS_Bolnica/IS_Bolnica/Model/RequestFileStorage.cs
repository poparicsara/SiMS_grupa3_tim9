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
    class RequestFileStorage
    {
        public List<Request> GetAll()
        {
            throw new NotImplementedException();
        }

        public void SaveToFile(List<Request> requests, string fileName)
        {
            string jsonString = JsonConvert.SerializeObject(requests, Formatting.Indented);
            File.WriteAllText(fileName, jsonString);
        }

        public List<Request> LoadFromFile(string fileName)
        {
            var requests = new List<Request>();

            using (StreamReader file = File.OpenText(fileName))
            {
                var serializer = new JsonSerializer();
                requests = (List<Request>)serializer.Deserialize(file, typeof(List<Request>));
            }

            return requests;
        }
    }
}
