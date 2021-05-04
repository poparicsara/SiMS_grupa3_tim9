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
        public ObservableCollection<Request> GetAll()
        {
            throw new NotImplementedException();
        }

        public void SaveToFile(ObservableCollection<Request> requests, string fileName)
        {
            string jsonString = JsonConvert.SerializeObject(requests, Formatting.Indented);
            File.WriteAllText(fileName, jsonString);
        }

        public ObservableCollection<Request> LoadFromFile(string fileName)
        {
            var requests = new ObservableCollection<Request>();

            using (StreamReader file = File.OpenText(fileName))
            {
                var serializer = new JsonSerializer();
                requests = (ObservableCollection<Request>)serializer.Deserialize(file, typeof(ObservableCollection<Request>));
            }

            return requests;
        }
    }
}
