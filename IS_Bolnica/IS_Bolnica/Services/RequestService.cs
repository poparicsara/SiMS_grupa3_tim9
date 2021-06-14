using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using IS_Bolnica.IRepository;
using IS_Bolnica.Model;

namespace IS_Bolnica.Services
{
    public class RequestService
    {
        public IRequestRepository Repository { get; set; }
        //private RequestRepository repository = new RequestRepository();

        public RequestService(IRequestRepository repository)
        {
            Repository = repository;
        }

        public void SendRequest(Request newRequest)
        {
            Repository.Add(newRequest);
        }

        public List<Request> GetRequests()
        {
            return Repository.GetAll();
        }

        private int FindIndex(Request request)
        {
            int index = 0;
            foreach (Request r in Repository.GetAll())
            {
                if (r.Title.Equals(request.Title) && r.Content.Equals(request.Content))
                {
                    break;
                }

                index++;
            }
            return index;
        }

        public void DeleteRequest(Request selectedRequest)
        {
            int index = FindIndex(selectedRequest);
            Repository.Delete(index);
        }
    }
}
