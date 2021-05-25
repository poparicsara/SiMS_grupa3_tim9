using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace IS_Bolnica.Services
{
    class RoomService
    {
        private List<RoomRecord> rooms = new List<RoomRecord>();
        private RoomRepository storage = new RoomRepository();

        public RoomService()
        {
            rooms = GetRooms();
        }

        public void AddRoom(RoomRecord newRoom)
        {
            rooms.Add(newRoom);
            storage.saveToFile(rooms, "Sobe.json");
        }

        public void DeleteRoom(RoomRecord selectedRoom)
        {
            int index = FindRoomIndex(selectedRoom);
            rooms.RemoveAt(index);
            storage.saveToFile(rooms, "Sobe.json");
        }

        private int FindRoomIndex(RoomRecord room)
        {
            int index = 0;
            foreach (RoomRecord r in rooms)
            {
                if (r.Id == room.Id)
                {
                    break;
                }
                index++;
            }
            return index;
        }

        public void EditRoom(RoomRecord oldRoom, RoomRecord newRoom)
        {
            int index = FindRoomIndex(oldRoom);
            rooms.RemoveAt(index);
            rooms.Insert(index, newRoom);
            storage.saveToFile(rooms, "Sobe.json");
        }

        public List<RoomRecord> GetRooms()
        {
            return storage.loadFromFile("Sobe.json");
        }

    }
}
