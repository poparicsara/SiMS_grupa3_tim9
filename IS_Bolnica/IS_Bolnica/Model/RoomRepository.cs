using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace Model
{
    public class RoomRepository
    {
        private List<Room> rooms;

        public RoomRepository()
        {
            rooms = GetRooms();
        }

        public List<Room> GetAll()
        {
            return rooms;
        }

        public void AddRoom(Room newRoom)
        {
            rooms.Add(newRoom);
            saveToFile(rooms);
        }

        public void DeleteRoom(Room selectedRoom)
        {
            int index = FindIndex(selectedRoom);
            rooms.RemoveAt(index);
            saveToFile(rooms);
        }

        private int FindIndex(Room room)
        {
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

        public void EditRoom(Room oldRoom, Room newRoom)
        {
            int index = FindIndex(oldRoom);
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