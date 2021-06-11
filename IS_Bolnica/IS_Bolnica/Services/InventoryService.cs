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
        private RoomRepository roomRepository = new RoomRepository();
        private Room magacin = new Room();
        private RoomService roomService = new RoomService();
        private List<Room> rooms = new List<Room>();

        public InventoryService()
        {
            rooms = roomService.GetRooms();
            magacin = roomService.GetMagacin();
            //inventoryItems = GetInventory();
        }

        public List<Inventory> GetDynamicInventory()
        {
            return roomRepository.GetDynamicInventory(magacin);
        }

        public List<Inventory> GetStaticInventory()
        {
            return roomRepository.GetStaticInventory(magacin);
        }

        public void AddInventory(Inventory newInventory)
        {
            roomRepository.AddInventory(newInventory, magacin);
        }

        public void DeleteInventory(Inventory selectedInventory)
        {
            int index = FindInventoryIndex(selectedInventory);
            roomRepository.DeleteInventory(index, magacin);
        }

        public void EditInventory(Inventory oldInventory, Inventory newInventory)
        {
            int index = FindInventoryIndex(oldInventory);
            roomRepository.EditInventory(index, newInventory, magacin);
        }

        public bool IsInventoryIdUnique(int id)
        {
            return roomRepository.IsInventoryIdUnique(magacin, id);
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
