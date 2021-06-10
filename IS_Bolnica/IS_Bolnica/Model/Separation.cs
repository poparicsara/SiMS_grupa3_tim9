using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace IS_Bolnica.Model
{
    public class Separation
    {
        public Room Room { get; set; }
        public int NewRoomNumber { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public int Hour { get; set; }
        public int Minute { get; set; }
        public bool Executed { get; set; } = false;
    }
}
