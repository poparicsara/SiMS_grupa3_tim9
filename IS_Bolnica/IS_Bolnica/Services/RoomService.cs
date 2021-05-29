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

        public RoomRecord FindOrdinationById(int id)
        {
            RoomRecord foundRoom = new RoomRecord();
            foreach (RoomRecord room in rooms)
            {
                if (room.Id.Equals(id))
                {
                    foundRoom = room;
                }
            }

            return foundRoom;
        }

        public List<int> GetOperationRoomsId()
        {
            List<int> operationRooms = new List<int>();
            foreach (RoomRecord room in rooms)
            {
                if (room.roomPurpose.Name.Equals("Operaciona sala"))
                {
                    operationRooms.Add(room.Id);
                }
            }
            return operationRooms;
        }

        public List<int> GetAvailableRoomsForHospitalization()
        {
            List<int> availableRooms = new List<int>();
            foreach (RoomRecord room in rooms)
            {
                if (room.roomPurpose.Name.Equals("Soba"))
                {
                    availableRooms.Add(room.Id);
                }
            }

            return availableRooms;
        }

        public bool DoesSelectedRoomHasEmptyBed(int roomId)
        {
            foreach (RoomRecord room in rooms)
            {
                if (room.roomPurpose.Name.Equals("Soba"))
                {
                    foreach (Inventory inventory in room.inventory)
                    {
                        if (inventory.Name.Equals("Krevet") && inventory.CurrentAmount == 0)
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }
    }
}
