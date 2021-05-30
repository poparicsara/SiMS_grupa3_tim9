

using IS_Bolnica;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using IS_Bolnica.Model;
using IS_Bolnica.Services;

namespace Model
{
    public class InventoryRepository
    {
        private List<Inventory> inventories = new List<Inventory>();

        public InventoryRepository()
        {

        }

        public void AddInventory(Inventory newInventory, Room room)
        {
            room.Inventory.Add(newInventory);
        }

        public void DeleteInventory(int index, Room room)
        {
            room.Inventory.RemoveAt(index);
        }

        public void EditInventory(int index, Room room, Inventory newInventory)
        {
            room.Inventory.RemoveAt(index);
            room.Inventory.Insert(index, newInventory);
        }

        public void AddInventoryToRoom(Room room, Inventory newInventory)
        {
            newInventory.CurrentAmount = 0;
            room.Inventory.Add(newInventory);
        }

        public List<Inventory> GetRoomInventory(Room room)
        {
            inventories = room.Inventory;
            return inventories;
        }

        public List<Inventory> GetDynamicInventory(Room room)
        {
            List<Inventory> dynamicInventory = new List<Inventory>();
            foreach (var i in room.Inventory)
            {
                if (i.InventoryType == InventoryType.dinamicki)
                {
                    dynamicInventory.Add(i);
                }
            }
            return dynamicInventory;
        }

        public bool HasRoomSelectedInventory(Room room, Inventory selectedInventory)
        {
            foreach (var i in room.Inventory)
            {
                if (i.Id == selectedInventory.Id)
                {
                    return true;
                }
            }

            return false;
        }

        public List<Inventory> GetStaticInventory(Room room)
        {
            List<Inventory> staticInventory = new List<Inventory>();
            foreach (var i in room.Inventory)
            {
                if (i.InventoryType == InventoryType.staticki)
                {
                    staticInventory.Add(i);
                }
            }
            return staticInventory;
        }

    }
}