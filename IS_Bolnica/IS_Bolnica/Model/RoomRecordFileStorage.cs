using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Model
{
    public class RoomRecordFileStorage
    {
        public List<RoomRecord> GetAll()
        {
            throw new NotImplementedException();
        }

        public void saveToFile(List<Examination> rooms, string fileName)
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