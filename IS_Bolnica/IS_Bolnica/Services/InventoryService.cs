using System;
using System.Collections.Generic;

using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Markup.Localizer;

using Model;

namespace IS_Bolnica.Services
{
    class InventoryService
    {
        private InventoryRepository repository = new InventoryRepository();
        private Room magacin = new Room();
        private RoomService roomService = new RoomService();
        private List<Room> rooms = new List<Room>();
        private List<Inventory> inventoryItems = new List<Inventory>();

        public InventoryService()
        {
            rooms = roomService.GetRooms();
            magacin = roomService.GetMagacin();
            //inventoryItems = GetInventory();
        }

        public List<Inventory> GetDynamicInventory()
        {
            return repository.GetDynamicInventory(magacin);
        }

        public List<Inventory> GetStaticInventory()
        {
            return repository.GetStaticInventory(magacin);
        }

        public void AddInventory(Inventory newInventory)
        {
            repository.AddInventory(newInventory, magacin);
            roomService.Save(rooms);
        }

        public void DeleteInventory(Inventory selectedInventory)
        {
            int index = FindInventoryIndex(selectedInventory);
            repository.DeleteInventory(index, magacin);
            roomService.Save(rooms);
        }

        public void EditInventory(Inventory oldInventory, Inventory newInventory)
        {
            int index = FindInventoryIndex(oldInventory);
            repository.EditInventory(index, magacin, newInventory);
            roomService.Save(rooms);
        }

        private int FindInventoryIndex(Inventory inventory)
        {
            int index = 0;
            foreach (var i in magacin.inventory)
            {
                if (i.Id == inventory.Id)
                {
                    break;
                }
                index++;
            }
            return index;
        }

        //public int GetNumberOfBeds()
        //{
        //    int numberOfBeds = 0;
        //    foreach (Inventory inventory in inventoryItems)
        //    {
        //        if (inventory.Name.Equals("Krevet"))
        //        {
        //            numberOfBeds = inventory.CurrentAmount;
        //        }
        //    }
        //    return numberOfBeds;
        //}

        public int GetNumberOfBedsInRoom(Room room)
        {
            int numberOfBeds = 0;
            foreach (Inventory inventory in room.inventory)
            {
                if (inventory.Name.Equals("Krevet"))
                {
                    numberOfBeds = inventory.CurrentAmount;
                }
            }
            return numberOfBeds;
        }
        //public List<Inventory> GetInventory()
        //{
        //    return inventoryRepository.loadFromFile("Inventar.json");
        //}
    }
}
