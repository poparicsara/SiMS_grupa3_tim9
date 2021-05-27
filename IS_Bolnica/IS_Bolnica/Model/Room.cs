

using System;

namespace Model
{
    public class Room
    {
        public int Id { get; set; }
        public String HospitalWard { get; set; }

        public System.Collections.Generic.List<Inventory> inventory { get; set; }

        public RoomPurpose roomPurpose { get; set; }

    }
}