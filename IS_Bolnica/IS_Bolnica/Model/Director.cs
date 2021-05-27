using System;
using System.Collections.Generic;

namespace Model
{
    public class Director : Employee
    {

        public void DeleteRoom(int room)
        {
            if (room < 0)
                return;

            RoomRepository storage = new RoomRepository();

            List<Room> rooms = storage.GetRooms();

            rooms.RemoveAt(room);
            storage.saveToFile(rooms);
        }

    }


}