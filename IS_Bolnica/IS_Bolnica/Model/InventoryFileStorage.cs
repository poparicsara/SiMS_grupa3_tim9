

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
            List<Room> rooms = roomStorage.GetRooms();
            AddInMagacin(newInventory, rooms);
            roomStorage.saveToFile(rooms);
        }

        private static void AddInMagacin(Inventory newInventory, List<Room> rooms)
        {
            foreach (Room room in rooms)
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
            List<Room> rooms = GetRooms(roomStorage);
            Room magacin = GetMagacin(rooms);
            magacin.inventory.RemoveAt(GetIndexOfInventory(selected, magacin));
            roomStorage.saveToFile(rooms);
        }

        private List<Room> GetRooms(RoomRepository storage)
        {
            List<Room> rooms = storage.GetRooms();
            return rooms;
        }

        private Room GetMagacin(List<Room> rooms)
        {                        
            foreach (Room r in rooms)
            {
                if (r.HospitalWard.Equals("Magacin"))
                {
                    return r;
                }
            }
            return null;
        }

        private int GetIndexOfInventory(Inventory selected, Room room)
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
            List<Room> rooms = GetRooms(roomStorage);
            Room magacin = GetMagacin(rooms);
            int index = GetIndexOfInventory(oldInventory, magacin);
            magacin.inventory.RemoveAt(index);
            magacin.inventory.Insert(index, newInventory);
            roomStorage.saveToFile(rooms);
        }

        public void AddInventoryInRoom(Room room, Inventory newInventory)
        {
            RoomRepository roomStorage = new RoomRepository();
            List<Room> rooms = roomStorage.GetRooms();
            newInventory.CurrentAmount = 0;
            room.inventory.Add(newInventory);
            roomStorage.saveToFile(rooms);
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