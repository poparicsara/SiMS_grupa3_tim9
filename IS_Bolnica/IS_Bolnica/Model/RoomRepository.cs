using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using IS_Bolnica.Model;

namespace Model
{
    public class RoomRepository
    {
        private List<Room> rooms;

        public RoomRepository()
        {
            rooms = GetRooms();
        }

        public Room GetMagacin()
        {
            int id = 1;  // magacin id = 1
            Room magacin = GetRoom(id);
            return magacin;
        }

        public Room GetRoom(int id)
        {
            foreach (var r in rooms)
            {
                if (r.Id == id)
                {
                    return r;
                }
            }
            return null;
        }

        public void AddRoom(Room newRoom)
        {
            rooms = GetRooms();
            rooms.Add(newRoom);
            saveToFile(rooms);
        }

        public void DeleteRoom(int index)
        {
            rooms = GetRooms();
            rooms.RemoveAt(index);
            saveToFile(rooms);
        }

        public void EditRoom(int index, Room newRoom)
        {
            rooms.RemoveAt(index);
            rooms.Insert(index, newRoom);
            saveToFile(rooms);
        }

        public void saveToFile(List<Room> rooms)
        {
            string jsonString = JsonConvert.SerializeObject(rooms, Formatting.Indented);
            File.WriteAllText("Sobe.json", jsonString);
        }

        public List<Room> GetRooms()
        {
            var roomList = new List<Room>();
            using (StreamReader file = File.OpenText("Sobe.json"))
            {
                var serializer = new JsonSerializer();
                roomList = (List<Room>)serializer.Deserialize(file, typeof(List<Room>));
            }
            return roomList;
        }

        

    }
}