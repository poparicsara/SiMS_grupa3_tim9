

using IS_Bolnica;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Model
{
    public class InventoryFileStorage
    {
        private string fileName;
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
            RoomRecordFileStorage roomStorage = new RoomRecordFileStorage();
            List<RoomRecord> rooms = roomStorage.loadFromFile("Sobe.json");

            foreach (RoomRecord room in rooms)
            {
                if (room.HospitalWard == "Magacin")
                {
                    room.inventory.Add(newInventory);
                }
            }

            roomStorage.saveToFile(rooms, "Sobe.json");
        }

        public void DeleteInventory(Inventory selected)
        {
            int index = 0;

            RoomRecordFileStorage roomStorage = new RoomRecordFileStorage();
            List<RoomRecord> rooms = roomStorage.loadFromFile("Sobe.json");

            foreach (RoomRecord room in rooms)
            {
                if (room.HospitalWard == "Magacin")
                {
                    foreach (Inventory i in room.inventory)
                    {
                        if (i.Id == selected.Id)
                        {
                            break;
                        }
                        index++;
                    }
                    room.inventory.RemoveAt(index);
                }
            }

            roomStorage.saveToFile(rooms, "Sobe.json");

        }

        public void EditInventory(Inventory oldInventory, Inventory newInventory)
        {
            int index = 0;

            RoomRecordFileStorage roomStorage = new RoomRecordFileStorage();
            List<RoomRecord> rooms = roomStorage.loadFromFile("Sobe.json");

            foreach (RoomRecord room in rooms)
            {
                if (room.HospitalWard == "Magacin")
                {
                    foreach (Inventory i in room.inventory)
                    {
                        if (i.Id == oldInventory.Id)
                        {
                            break;
                        }
                        index++;
                    }
                    room.inventory.RemoveAt(index);
                    room.inventory.Insert(index, newInventory);
                }
            }

            roomStorage.saveToFile(rooms, "Sobe.json");

        }

        public void AddInventoryInRoom(RoomRecord room, Inventory newInventory)
        {
            RoomRecordFileStorage roomStorage = new RoomRecordFileStorage();
            List<RoomRecord> rooms = roomStorage.loadFromFile("Sobe.json");

            foreach (RoomRecord r in rooms)
            {
                if (r.Id == room.Id)
                {
                    r.inventory.Add(newInventory);
                }
            }

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