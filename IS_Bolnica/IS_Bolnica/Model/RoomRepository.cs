
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace Model
{
    public class RoomRepository
    {
        private List<RoomRecord> rooms;

        public RoomRepository()
        {

        }

        public List<RoomRecord> GetAll()
        {
            return rooms;
        }

        public void AddRoom(RoomRecord newRoom)
        {
            rooms = loadFromFile("Sobe.json");
            rooms.Add(newRoom);
            saveToFile(rooms, "Sobe.json");
        }

        public void DeleteRoom(RoomRecord selectedRoom)
        {
            rooms = loadFromFile("Sobe.json");
            int index = FindIndex(selectedRoom);
            rooms.RemoveAt(index);
            saveToFile(rooms, "Sobe.json");
        }

        private int FindIndex(RoomRecord room)
        {
            int index = 0;
            foreach(RoomRecord r in rooms)
            {
                if(r.Id == room.Id)
                {
                    break;
                }
                index++;
            }
            return index;
        }

        public void EditRoom(RoomRecord oldRoom, RoomRecord newRoom)
        {
            rooms = loadFromFile("Sobe.json");
            int index = FindIndex(oldRoom);
            rooms.RemoveAt(index);
            rooms.Insert(index, newRoom);
            saveToFile(rooms, "Sobe.json");
        }

        public void saveToFile(List<RoomRecord> rooms, string fileName)
        {
            string jsonString = JsonConvert.SerializeObject(rooms, Formatting.Indented);
            File.WriteAllText(fileName, jsonString);
        }

        public List<RoomRecord> loadFromFile(string fileName)
        {
            var roomList = new List<RoomRecord>();
            using (StreamReader file = File.OpenText(fileName))
            {
                var serializer = new JsonSerializer();
                roomList = (List<RoomRecord>)serializer.Deserialize(file, typeof(List<RoomRecord>));
            }
            return roomList;
        }

    }
}