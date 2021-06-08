using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IS_Bolnica.Model;

namespace IS_Bolnica.Services
{
    class RequestService
    {
        private RequestRepository repository = new RequestRepository();

        public void AddRequest(Request newRequest)
        {
            repository.AddRequest(newRequest);
        }
    }
}
