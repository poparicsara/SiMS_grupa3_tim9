using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IS_Bolnica.IRepository;

namespace IS_Bolnica.Model
{
    public class RequestRepository : IRequestRepository
    {
        private List<Request> requests;

        public RequestRepository()
        {
            requests = GetAll();
        }

        public List<Request> GetAll()
        {
            var requests = new List<Request>();

            using (StreamReader file = File.OpenText("Zahtevi.json"))
            {
                var serializer = new JsonSerializer();
                requests = (List<Request>)serializer.Deserialize(file, typeof(List<Request>));
            }

            return requests;
        }

        public void SaveToFile(List<Request> requests)
        {
            string jsonString = JsonConvert.SerializeObject(requests, Formatting.Indented);
            File.WriteAllText("Zahtevi.json", jsonString);
        }

        public void Add(Request newEntity)
        {
            requests = GetAll();
            requests.Add(newEntity);
            SaveToFile(requests);
        }

        public void Delete(int index)
        {
            requests = GetAll();
            requests.RemoveAt(index);
            SaveToFile(requests);
        }

        public Request FindById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(int index, Request newEntity)
        {
            throw new NotImplementedException();
        }

    }
}
