using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Markup.Localizer;
using IS_Bolnica.IRepository;
using IS_Bolnica.Model;
using Model;

namespace IS_Bolnica.Services
{
    class InventoryService
    {
        private InventoryRepository repository = new InventoryRepository();
        private RoomRepository roomRepository = new RoomRepository();
        private Room magacin = new Room();
        private RoomService roomService = new RoomService();
        private List<Room> rooms = new List<Room>();

        public InventoryService()
        {
            rooms = roomService.GetRooms();
            magacin = roomService.GetMagacin();
        }

        public List<Inventory> GetRoomInventory(Room room)
        {
            return repository.GetRoomInventory(room);
        }

        public List<Inventory> GetDynamicInventory()
        {
            List<Inventory> inventories = new List<Inventory>();
            foreach (var i in repository.GetAll())
            {
                if (i.InventoryType == InventoryType.dinamicki)
                {
                    inventories.Add(i);
                }
            }
            return inventories; 
        }

        public List<Inventory> GetStaticInventory()
        {
            List<Inventory> inventories = new List<Inventory>();
            foreach (var i in repository.GetAll())
            {
                if (i.InventoryType == InventoryType.staticki)
                {
                    inventories.Add(i);
                }   
            }
            return inventories;
        }

        public void AddInventory(Inventory newInventory)
        {
            repository.Add(newInventory);
        }

        public void DeleteInventory(Inventory selectedInventory)
        {
            int index = FindInventoryIndex(selectedInventory);
            repository.Delete(index);
        }

        public void EditInventory(Inventory oldInventory, Inventory newInventory)
        {
            int index = FindInventoryIndex(oldInventory);
            repository.Update(index, newInventory);
        }

        public bool IsInventoryIdUnique(int id)
        {
            foreach (var i in repository.GetAll())
            {
                if (i.Id == id)
                {
                    return false;
                }
            }
            return true; 
        }

        private int FindInventoryIndex(Inventory inventory)
        {
            int index = 0;
            foreach (var i in magacin.Inventory)
            {
                if (i.Id == inventory.Id)
                {
                    break;
                }
                index++;
            }
            return index;
        }

        public int GetNumberOfBedsInRoom(Room room)
        {
            int numberOfBeds = 0;
            foreach (Inventory inventory in room.Inventory)
            {
                if (inventory.Name.Equals("Krevet"))
                {
                    numberOfBeds = inventory.CurrentAmount;
                }
            }
            return numberOfBeds;
        }
    }
}
