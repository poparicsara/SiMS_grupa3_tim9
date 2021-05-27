

using IS_Bolnica;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using IS_Bolnica.Model;
using IS_Bolnica.Services;

namespace Model
{
    public class InventoryRepository
    {
        private List<Inventory> inventories = new List<Inventory>();
        private Room magacin = new Room();

        public InventoryRepository()
        {
            RoomService service = new RoomService();
            magacin = service.GetMagacin();
            inventories = magacin.inventory;
        }

        public List<Inventory> GetAll()
        {
            throw new NotImplementedException();
        }

        public void AddInventory(Inventory newInventory)
        {
            RoomRepository roomRepository = new RoomRepository();
            List<Room> rooms = roomRepository.GetRooms();
            AddInMagacin(newInventory, rooms);
            roomRepository.saveToFile(rooms);
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
            RoomRepository roomRepository = new RoomRepository();
            List<Room> rooms = GetRooms(roomRepository);
            Room magacin = GetMagacin(rooms);
            magacin.inventory.RemoveAt(GetIndexOfInventory(selected, magacin));
            roomRepository.saveToFile(rooms);
        }

        private List<Room> GetRooms(RoomRepository roomRepository)
        {
            List<Room> rooms = roomRepository.GetRooms();
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
            RoomRepository roomRepository = new RoomRepository();
            List<Room> rooms = GetRooms(roomRepository);
            Room magacin = GetMagacin(rooms);
            int index = GetIndexOfInventory(oldInventory, magacin);
            magacin.inventory.RemoveAt(index);
            magacin.inventory.Insert(index, newInventory);
            roomRepository.saveToFile(rooms);
        }

        public void AddInventoryInRoom(Room room, Inventory newInventory)
        {
            RoomRepository roomRepository = new RoomRepository();
            List<Room> rooms = roomRepository.GetRooms();
            newInventory.CurrentAmount = 0;
            room.inventory.Add(newInventory);
            roomRepository.saveToFile(rooms);
        }

        public List<Inventory> GetRoomInventory(Room room)
        {
            inventories = room.inventory;
            return inventories;
        }

        public List<Inventory> GetDynamicInventory()
        {
            List<Inventory> dynamicInventory = new List<Inventory>();
            foreach (var i in inventories)
            {
                if (i.InventoryType == InventoryType.dinamicki)
                {
                    dynamicInventory.Add(i);
                }
            }
            return dynamicInventory;
        }

        public List<Inventory> GetStaticInventory()
        {
            List<Inventory> staticInventory = new List<Inventory>();
            foreach (var i in inventories)
            {
                if (i.InventoryType == InventoryType.staticki)
                {
                    staticInventory.Add(i);
                }
            }
            return staticInventory;
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