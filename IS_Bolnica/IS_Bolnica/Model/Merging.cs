using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace IS_Bolnica.Model
{
    public class Merging
    {
        public Room Room1 { get; set; }
        public Room Room2 { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public int Hour { get; set; }
        public int Minute { get; set; }
        public int NewRoomNumber { get; set; }
        public bool Executed { get; set; } = false;
    }
}
