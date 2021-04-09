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

            RoomRecordFileStorage storage = new RoomRecordFileStorage();
            List<RoomRecord> rooms = storage.loadFromFile("Sobe.json");
            rooms.RemoveAt(room);
            storage.saveToFile(rooms, "Sobe.json");
        }

    }

   
}