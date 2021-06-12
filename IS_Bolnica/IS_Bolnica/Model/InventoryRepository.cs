

using IS_Bolnica;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using IS_Bolnica.IRepository;
using IS_Bolnica.Model;
using IS_Bolnica.Services;

namespace Model
{
    public class InventoryRepository : IInventoryRepository
    {
        private List<Room> rooms = new List<Room>();
        private RoomRepository repository = new RoomRepository();
        private Room room = new Room();
        private int MAGACIN_ID = 1;

        public InventoryRepository()
        {
            rooms = repository.GetAll();
        }

        public List<Inventory> GetRoomInventory(Room room)
        {
            room = repository.FindById(room.Id);
            return room.Inventory;
        }

        public void AddInventoryToRoom(Room room, Inventory inventory)
        {
            rooms = repository.GetAll();
            room = repository.FindById(room.Id);
            HasRoomAnyInventory(room);
            Inventory newInventory = new Inventory
                {Id = inventory.Id, Minimum = 0, CurrentAmount = 0, InventoryType = inventory.InventoryType};
            room.Inventory.Add(newInventory);
            repository.SaveToFile(rooms);
        }

        private static void HasRoomAnyInventory(Room room)
        {
            if (room.Inventory == null)
            {
                room.Inventory = new List<Inventory>();
            }
        }

        public List<Inventory> GetAll()
        {
            room = repository.FindById(MAGACIN_ID);
            return room.Inventory;
        }

        public Inventory FindById(int id)
        {
            throw new NotImplementedException();
        }

        public void SaveToFile(List<Inventory> entities)
        {
            string jsonString = JsonConvert.SerializeObject(rooms, Formatting.Indented);
            File.WriteAllText("Sobe.json", jsonString);
        }

        public void Add(Inventory newEntity)
        {
            rooms = repository.GetAll();
            room = repository.FindById(MAGACIN_ID);
            List<Inventory> inventories = room.Inventory;
            inventories.Add(newEntity);
            repository.SaveToFile(rooms);
        }

        public void Update(int index, Inventory newEntity)
        {
            rooms = repository.GetAll();
            room = repository.FindById(MAGACIN_ID);
            List<Inventory> inventories = room.Inventory;
            inventories.RemoveAt(index);
            inventories.Insert(index, newEntity);
            repository.SaveToFile(rooms);
        }

        public void Delete(int index)
        {
            rooms = repository.GetAll();
            room = repository.FindById(MAGACIN_ID);
            List<Inventory> inventories = room.Inventory;
            inventories.RemoveAt(index);
            repository.SaveToFile(rooms);
        }

        public void ReduceAmount(Room room, Inventory inventory, int amount)
        {
            rooms = repository.GetAll();
            room = repository.FindById(room.Id);
            foreach (var i in room.Inventory)
            {
                if (i.Id == inventory.Id)
                {
                    i.CurrentAmount -= amount;
                    repository.SaveToFile(rooms);
                }
            }
        }

        public void IncreaseAmount(Room room, Inventory inventory, int amount)
        {
            rooms = repository.GetAll();
            room = repository.FindById(room.Id);
            foreach (var i in room.Inventory)
            {
                if (i.Id == inventory.Id)
                {
                    i.CurrentAmount += amount;
                    repository.SaveToFile(rooms);
                }
            }
        }
    }
}