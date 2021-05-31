using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace IS_Bolnica.Model
{
    public class Shifting
    {
        public Room RoomFrom { get; set; }
        public Room RoomTo { get; set; }
        public Inventory Inventory { get; set; }
        public int Amount { get; set; }
        public string Date { get; set; }
        public int Hour { get; set; }
        public int Minute { get; set; }
        public bool Executed { get; set; } = false;
    }
}
