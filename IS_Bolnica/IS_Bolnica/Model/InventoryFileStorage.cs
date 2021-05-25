

using IS_Bolnica;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Model
{
    public class InventoryFileStorage
    {
        private List<Inventory> inventories;
        public InventoryFileStorage()
        {

        }

        public List<Inventory> GetAll()
        {
            throw new NotImplementedException();
        }

        public void AddInventory(Inventory newInventory)
        {
            RoomRepository roomStorage = new RoomRepository();
            List<RoomRecord> rooms = roomStorage.loadFromFile("Sobe.json");
            AddInMagacin(newInventory, rooms);
            roomStorage.saveToFile(rooms, "Sobe.json");
        }

        private static void AddInMagacin(Inventory newInventory, List<RoomRecord> rooms)
        {
            foreach (RoomRecord room in rooms)
            {
                if (room.HospitalWard == "Magacin")
                {
                    room.inventory.Add(newInventory);
                }
            }
        }

        public void DeleteInventory(Inventory selected)
        {
            RoomRepository roomStorage = new RoomRepository();
            List<RoomRecord> rooms = GetRooms(roomStorage);
            RoomRecord magacin = GetMagacin(rooms);
            magacin.inventory.RemoveAt(GetIndexOfInventory(selected, magacin));
            roomStorage.saveToFile(rooms, "Sobe.json");
        }

        private List<RoomRecord> GetRooms(RoomRepository storage)
        {
            List<RoomRecord> rooms = storage.loadFromFile("Sobe.json");
            return rooms;
        }

        private RoomRecord GetMagacin(List<RoomRecord> rooms)
        {                        
            foreach (RoomRecord r in rooms)
            {
                if (r.HospitalWard.Equals("Magacin"))
                {
                    return r;
                }
            }
            return null;
        }

        private int GetIndexOfInventory(Inventory selected, RoomRecord room)
        {
            int index = 0;
            foreach (Inventory i in room.inventory)
            {
                if (i.Id == selected.Id)
                {
                    break;
                }
                index++;
            }
            return index;
        }

        public void EditInventory(Inventory oldInventory, Inventory newInventory)
        {
            RoomRepository roomStorage = new RoomRepository();
            List<RoomRecord> rooms = GetRooms(roomStorage);
            RoomRecord magacin = GetMagacin(rooms);
            int index = GetIndexOfInventory(oldInventory, magacin);
            magacin.inventory.RemoveAt(index);
            magacin.inventory.Insert(index, newInventory);
            roomStorage.saveToFile(rooms, "Sobe.json");
        }

        public void AddInventoryInRoom(RoomRecord room, Inventory newInventory)
        {
            RoomRepository roomStorage = new RoomRepository();
            List<RoomRecord> rooms = roomStorage.loadFromFile("Sobe.json");
            newInventory.CurrentAmount = 0;
            room.inventory.Add(newInventory);
            roomStorage.saveToFile(rooms, "Sobe.json");
        }

        public void saveToFile(List<Inventory> inventories, string fileName)
        {
            string jsonString = JsonConvert.SerializeObject(inventories, Formatting.Indented);
            File.WriteAllText(fileName, jsonString);
        }

        public List<Inventory> loadFromFile(string fileName)
        {
            var inventoryList = new List<Inventory>();

            using (StreamReader file = File.OpenText(fileName))
            {
                var serializer = new JsonSerializer();
                inventoryList = (List<Inventory>)serializer.Deserialize(file, typeof(List<Inventory>));
            }

            return inventoryList;
        }

    }
}