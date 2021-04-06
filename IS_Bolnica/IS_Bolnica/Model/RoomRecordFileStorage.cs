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

        public void AddRoom(RoomRecord newRoom)
        {
            rooms = loadFromFile("Sobe.json");
            rooms.Add(newRoom);
            saveToFile(rooms, "Sobe.json");
        }

        public void DeleteRoom(int room)
        {
            if (room < 0)
                return;

            rooms = loadFromFile("Sobe.json");
            rooms.RemoveAt(room);
            saveToFile(rooms, "Sobe.json");
        }

        public void EditRoom(int selectedRoom, RoomRecord newRoom)
        {
            rooms = loadFromFile("Sobe.json");
            rooms.RemoveAt(selectedRoom);
            rooms.Insert(selectedRoom, newRoom);
            saveToFile(rooms, "Sobe.json");

            //int index = rooms.IndexOf(oldRoom);


            /*for (int j = 0; j < rooms.Count; j++)
            {
                if (j == index)
                {
                    rooms.RemoveAt(j);
                    rooms.Insert(j, newRoom);

                    return;
                }
            }*/

           /* int index;
            foreach(RoomRecord room in rooms)
            {
                if(room.Id == oldRoom.Id)
                {
                    index = rooms.IndexOf(room);
                    rooms.RemoveAt(index);
                    rooms.Insert(index, newRoom);
                }
            }*/

            //saveToFile(rooms, "Sobe.json");
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