

using IS_Bolnica;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using IS_Bolnica.Model;
using IS_Bolnica.Services;

namespace Model
{
    public class InventoryRepository
    {
        private List<Inventory> inventories = new List<Inventory>();
        private List<Shifting> shiftings = new List<Shifting>();
        public InventoryRepository()
        {
            shiftings = GetShiftings();
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

        public void AddShifting(Shifting newShifting)
        {
            shiftings.Add(newShifting);
            SaveShiftings(shiftings);
        }

        public void DeleteShifting(int index)
        {
            shiftings.RemoveAt(index);
            SaveShiftings(shiftings);
        }

        public void EditShifting(int index)
        {
            Shifting s = shiftings.ElementAt(index);
            s.Executed = true;
            shiftings.RemoveAt(index);
            shiftings.Insert(index, s);
            SaveShiftings(shiftings);
        }

        public void SaveShiftings(List<Shifting> shiftings)
        {
            string jsonString = JsonConvert.SerializeObject(shiftings, Formatting.Indented);
            File.WriteAllText("Shiftings.json", jsonString);
        }

        public List<Shifting> GetShiftings()
        {
            var shiftings = new List<Shifting>();
            using (StreamReader file = File.OpenText("Shiftings.json"))
            {
                var serializer = new JsonSerializer();
                shiftings = (List<Shifting>)serializer.Deserialize(file, typeof(List<Shifting>));
            }
            return shiftings;
        }

    }
}