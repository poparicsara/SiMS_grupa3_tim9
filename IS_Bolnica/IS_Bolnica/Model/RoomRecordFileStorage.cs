using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        public void Save(RoomRecord newRoom)
        {
            rooms.Add(newRoom);
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