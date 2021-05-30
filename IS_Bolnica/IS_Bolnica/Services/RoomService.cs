using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace IS_Bolnica.Services
{
    class RoomService
    {
        private List<Room> rooms = new List<Room>();
        private RoomRepository repository = new RoomRepository();

        public RoomService()
        {
            rooms = repository.GetRooms();
        }

        public List<int> GetRoomNumbers()
        {
            List<int> roomNumbers = new List<int>();
            foreach (var r in rooms)
            {
                roomNumbers.Add(r.Id);
            }
            return roomNumbers;
        }

        public void AddRoom(Room newRoom)
        {
            repository.AddRoom(newRoom);
        }

        public void DeleteRoom(Room selectedRoom)
        {
            int index = FindIndex(selectedRoom);
            repository.DeleteRoom(index);
        }

        public void EditRoom(Room oldRoom, Room newRoom)
        {
            int index = FindIndex(oldRoom);
            repository.EditRoom(index, newRoom);
        }

        private int FindIndex(Room room)
        {
            rooms = GetRooms();
            int index = 0;
            foreach (Room r in rooms)
            {
                if (r.Id == room.Id)
                {
                    break;
                }
                index++;
            }
            return index;
        }

        public List<int> GetOperationRoomNums()
        {
            List<int> roomNums = new List<int>();
            for (int i = 0; i <rooms.Count; i++)
            {
                if (rooms[i].roomPurpose.Name == "Operaciona sala")
                {
                    roomNums.Add(rooms[i].Id);
                }
            }
            return roomNums;
        }

        public List<Room> GetRooms()
        {
            return repository.GetRooms();
        }

        public Room GetMagacin()
        {
            return repository.GetMagacin();
        }

        public void Save(List<Room> rooms)
        {
            repository.saveToFile(rooms);
        }

        public Room GetRoom(int roomId)
        {
            return repository.GetRoom(roomId);
        }

    }
}
