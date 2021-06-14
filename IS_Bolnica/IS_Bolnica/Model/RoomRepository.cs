using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using IS_Bolnica.IRepository;
using IS_Bolnica.Model;

namespace Model
{
    public class RoomRepository : IRoomRepository
    {
        private List<Room> rooms;

        public void Delete(int index)
        {
            rooms = GetAll();
            rooms.RemoveAt(index);
            SaveToFile(rooms);
        }

        public List<Room> GetAll()
        {
            var roomList = new List<Room>();
            using (StreamReader file = File.OpenText("Sobe.json"))
            {
                var serializer = new JsonSerializer();
                roomList = (List<Room>)serializer.Deserialize(file, typeof(List<Room>));
            }
            return roomList;
        }

        public Room FindById(int id)
        {
            rooms = GetAll();
            foreach (var r in rooms)
            {
                if (r.Id == id)
                {
                    return r;
                }
            }
            return null;
        }

        public void SaveToFile(List<Room> entities)
        {
            string jsonString = JsonConvert.SerializeObject(rooms, Formatting.Indented);
            File.WriteAllText("Sobe.json", jsonString);
        }

        public void Add(Room newEntity)
        {
            rooms = GetAll();
            rooms.Add(newEntity);
            SaveToFile(rooms);
        }

        public void Update(int index, Room newEntity)
        {
            rooms = GetAll();
            rooms.RemoveAt(index);
            rooms.Insert(index, newEntity);
            SaveToFile(rooms);
        }

    }
}