using System;
using System.Collections.Generic;

namespace Model
{
    public class RoomPurpose
    {
        public String Name { get; set; }

        public List<string> GetPurposes()
        {
            List<string> purposes = new List<string>();

            purposes.Add("Ordinacija");
            purposes.Add("Operaciona sala");
            purposes.Add("Soba");

            return purposes;
        }
    }
}