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
            rooms = repository.GetAll();
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

        public List<string> GetHospitalWards()
        {
            List<string> wards = new List<string>();
            Specialization spec = new Specialization();
            List<Specialization> specializations = spec.getSpecializations();
            foreach (var s in specializations)
            {
                wards.Add(s.Name);
            }
            return wards;
        }

        public List<int> GetAppropriateRoomNumbers(string hospitalWard, string roomPurpose)
        {
            List<int> roomNumbers = new List<int>();
            foreach (Room room in rooms)
            {
                if (room.HospitalWard.Equals(hospitalWard) && room.RoomPurpose.Name.Equals(roomPurpose))
                {
                    roomNumbers.Add(room.Id);
                }
            }
            return roomNumbers;
        }

        public List<string> GetRoomPurposes()
        {
            RoomPurpose purpose = new RoomPurpose();
            return purpose.GetPurposes();
        }

        public void AddRoom(Room newRoom)
        {
            repository.Add(newRoom);
        }

        public void DeleteRoom(Room selectedRoom)
        {
            rooms = GetRooms();
            int index = FindIndex(selectedRoom);
            repository.Delete(index);
        }

        public void EditRoom(Room oldRoom, Room newRoom)
        {
            int index = FindIndex(oldRoom);
            repository.Update(index, newRoom);
        }

        private int FindIndex(Room room)
        {
            int index = 0;
            foreach (Room r in GetRooms())
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
            for (int i = 0; i < rooms.Count; i++)
            {
                if (rooms[i].RoomPurpose.Name == "Operaciona sala")
                {
                    roomNums.Add(rooms[i].Id);
                }
            }
            return roomNums;
        }

        public List<Room> GetRooms()
        {
            return repository.GetAll();
        }

        public Room GetMagacin()
        {
            return repository.GetMagacin();
        }

        public void Save(List<Room> rooms)
        {
            repository.SaveToFile(rooms);
        }

        public Room GetRoom(int roomId)
        {
            return repository.FindById(roomId);
        }

        public bool IsRoomNumberUnique(int roomNumber)
        {
            return repository.IsRoomNumberUnique(roomNumber);
        }

        public Room FindOrdinationById(int id)
        {
            Room foundRoom = new Room();
            foreach (Room room in rooms)
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
            foreach (Room room in rooms)
            {
                if (room.RoomPurpose.Name.Equals("Operaciona sala"))
                {
                    operationRooms.Add(room.Id);
                }
            }
            return operationRooms;

        }

        public List<Room> GetSearchedRooms(string text)
        {
            return repository.GetSearchedRooms(text);
        }

        public List<int> GetAvailableRoomsForHospitalization()
        {
            List<int> availableRooms = new List<int>();
            foreach (Room room in rooms)
            {
                if (room.RoomPurpose.Name.Equals("Soba"))
                {
                    availableRooms.Add(room.Id);
                }
            }

            return availableRooms;
        }

        public bool DoesSelectedRoomHasEmptyBed(int roomId)
        {
            foreach (Room room in rooms)
            {
                if (room.RoomPurpose.Name.Equals("Soba"))
                {
                    foreach (Inventory inventory in room.Inventory)
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
