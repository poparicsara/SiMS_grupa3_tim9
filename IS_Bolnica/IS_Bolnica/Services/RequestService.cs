using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using IS_Bolnica.Model;

namespace IS_Bolnica.Services
{
    class RequestService
    {
        private RequestRepository repository = new RequestRepository();
        private List<Request> requests = new List<Request>();

        public RequestService()
        {
            requests = repository.GetRequests();
        }

        public void SendRequest(Request newRequest)
        {
            repository.AddRequest(newRequest);
        }

        public List<Request> GetRequests()
        {
            return repository.GetRequests();
        }

        public void DeleteRequest(Request selectedRequest)
        {
            int i = 0;
            foreach (Request request in requests)
            {
                if (request.Title.Equals(selectedRequest.Title) && request.Content.Equals(selectedRequest.Content))
                {
                    break;
                }

                i++;
            }
            requests.RemoveAt(i);
            repository.SaveToFile(requests);
        }
    }
}
