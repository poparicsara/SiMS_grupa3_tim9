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
    class RequestRepository
    {
        private List<Request> requests;

        public RequestRepository()
        {
            requests = GetRequests();
        }

        public void AddRequest(Request newRequest)
        {
            requests.Add(newRequest);
            SaveToFile(requests);
        }

        public void SaveToFile(List<Request> requests)
        {
            string jsonString = JsonConvert.SerializeObject(requests, Formatting.Indented);
            File.WriteAllText("Zahtevi.json", jsonString);
        }

        public List<Request> GetRequests()
        {
            var requests = new List<Request>();

            using (StreamReader file = File.OpenText("Zahtevi.json"))
            {
                var serializer = new JsonSerializer();
                requests = (List<Request>)serializer.Deserialize(file, typeof(List<Request>));
            }

            return requests;
        }
    }
}
