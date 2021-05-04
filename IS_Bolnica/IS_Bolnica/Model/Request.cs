using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IS_Bolnica.Model
{
    public class Request
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public UserType Sender { get; set; }
        public NotificationType Recipient { get; set; }
    }
}
