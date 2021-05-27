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
        private List<Room> rooms = new List<Room>();
        private RoomRepository repository = new RoomRepository();

        public RoomService()
        {
            rooms = repository.GetRooms();
        }

        public void AddRoom(Room newRoom)
        {
            repository.AddRoom(newRoom);
        }

        public void DeleteRoom(Room selectedRoom)
        {
            repository.DeleteRoom(selectedRoom);
        }

        public void EditRoom(Room oldRoom, Room newRoom)
        {
            repository.EditRoom(oldRoom, newRoom);
        }

        public List<Room> GetRooms()
        {
            return repository.GetRooms();
        }

    }
}
