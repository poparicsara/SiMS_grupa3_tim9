

using System;

namespace Model
{
    public class Room
    {
        public int Id { get; set; }
        public String HospitalWard { get; set; }

        public System.Collections.Generic.List<Inventory> Inventory { get; set; }

        public RoomPurpose RoomPurpose { get; set; }

    }
}