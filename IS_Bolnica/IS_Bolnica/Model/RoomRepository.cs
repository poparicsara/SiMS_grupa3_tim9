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

        public Room FindOrdinationById(int id)
        {
            throw new NotImplementedException();
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

        public List<int> GetAvailableRoomsForHospitalization()
        {
            throw new NotImplementedException();
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

        public List<int> GetOperationRoomNums()
        {
            throw new NotImplementedException();
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

        /*public void ReduceAmount(Room room, Inventory inventory, int amount)
        {
            foreach (var r in rooms)
            {
                if (r.Id == room.Id)
                {
                    foreach (var i in r.Inventory)
                    {
                        if (i.Id == inventory.Id)
                        {
                            i.CurrentAmount -= amount;
                            SaveToFile(rooms);
                        }
                    }
                }
            }
        }

        public void IncreaseAmount(Room room, Inventory inventory, int amount)
        {
            foreach (var r in rooms)
            {
                if (r.Id == room.Id)
                {
                    foreach (var i in r.Inventory)
                    {
                        if (i.Id == inventory.Id)
                        {
                            i.CurrentAmount += amount;
                            SaveToFile(rooms);
                        }
                    }
                }
            }
        }*/




        /* 

         public void AddInventory(Inventory newInvenotory, Room room)
         {
             List<Inventory> inventories = GetRoomInvenotory(room);
             inventories.Add(newInvenotory);
             saveToFile(rooms);
         }

         public void DeleteInventory(int index, Room room)
         {
             List<Inventory> inventories = GetRoomInvenotory(room);
             inventories.RemoveAt(index);
             saveToFile(rooms);
         }

         public void EditInventory(int index, Inventory newInventory, Room room)
         {
             List<Inventory> inventories = GetRoomInvenotory(room);
             inventories.RemoveAt(index);
             inventories.Insert(index, newInventory);
             saveToFile(rooms);
         }

         public bool HasRoomSelectedInventory(Room room, Inventory selectedInventory)
         {
             foreach (var r in rooms)
             {
                 if (r.Id == room.Id)
                 {
                     if (r.Inventory != null)
                     {
                         foreach (var i in r.Inventory)
                         {
                             if (i.Id == selectedInventory.Id)
                             {
                                 return true;
                             }
                         }
                     }
                     else
                     {
                         return false;
                     }

                 }
             }

             return false;
         }

         public void AddInventoryToRoom(Room room, Inventory newInventory)
         {
             foreach (var r in rooms)
             {
                 if (r.Id == room.Id)
                 {
                     if (r.Inventory == null)
                     {
                         r.Inventory = new List<Inventory>();
                     }
                     newInventory.CurrentAmount = 0;
                     r.Inventory.Add(newInventory);
                     saveToFile(rooms);
                 }
             }

         }

         public List<Inventory> GetDynamicInventory(Room room)
         {
             List<Inventory> dynamicInventory = new List<Inventory>();
             foreach (var i in GetRoomInvenotory(room))
             {
                 if (i.InventoryType == InventoryType.dinamicki)
                 {
                     dynamicInventory.Add(i);
                 }
             }
             return dynamicInventory;
         }

         public List<Inventory> GetStaticInventory(Room room)
         {
             List<Inventory> staticInventory = new List<Inventory>();
             foreach (var i in GetRoomInvenotory(room))
             {
                 if (i.InventoryType == InventoryType.staticki)
                 {
                     staticInventory.Add(i);
                 }
             }
             return staticInventory;
         }

         public List<Inventory> GetRoomInvenotory(Room room)
         {
             foreach (var r in rooms)
             {
                 if (r.Id == room.Id)
                 {
                     return r.Inventory;
                 }
             }
             return null;
         }



         public bool IsInventoryIdUnique(Room room, int id)
         {
             foreach (var i in GetRoomInvenotory(room))
             {
                 if (i.Id == id)
                 {
                     return false;
                 }
             }
             return true;
         }
 */

    }
}