
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Model
{
    public class RoomRecordFileStorage
    {
        private string fileName;
        private List<RoomRecord> rooms;

        public RoomRecordFileStorage()
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
            int index = 0;

            rooms = loadFromFile("Sobe.json");

            //find right index
            foreach (RoomRecord room in rooms)
            {
                if (room.Id == selectedRoom.Id)
                {
                    break;
                }
                index++;
            }

            rooms.RemoveAt(index);
            saveToFile(rooms, "Sobe.json");
        }

        public void EditRoom(RoomRecord oldRoom, RoomRecord newRoom)
        {
            int index = 0;

            rooms = loadFromFile("Sobe.json");

            //find right index
            foreach (RoomRecord room in rooms)
            {
                if (room.Id == oldRoom.Id)
                {
                    break;
                }
                index++;
            }

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