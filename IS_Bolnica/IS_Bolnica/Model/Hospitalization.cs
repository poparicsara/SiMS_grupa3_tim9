using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace IS_Bolnica.Model
{
    public class Hospitalization
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Patient Patient { get; set; }
        public RoomRecord Room { get; set; }
    }
}
