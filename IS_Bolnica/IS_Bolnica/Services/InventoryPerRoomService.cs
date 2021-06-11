using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace IS_Bolnica.Services
{
    class InventoryPerRoomService
    {
        private RoomRepository roomRepository = new RoomRepository();
        private List<Room> rooms = new List<Room>();
        private List<InventoryInRoom> ordinationsWithInventory = new List<InventoryInRoom>();
        private List<InventoryInRoom> operationRoomsWithInventory = new List<InventoryInRoom>();
        private List<InventoryInRoom> roomsWithInventory = new List<InventoryInRoom>();
        private InventoryInRoom inventory;
        private string magacinAmount = "";
        private string magacinMinimum = "";

        public InventoryPerRoomService(Inventory selected)
        {
            rooms = roomRepository.GetAll();
            CheckAllRooms(selected);
        }

        public List<InventoryInRoom> GetOrdinationsWithInventory()
        {
            return ordinationsWithInventory;
        }

        public List<InventoryInRoom> GetOperationRoomWithInventory()
        {
            return operationRoomsWithInventory;
        }

        public List<InventoryInRoom> GetRoomsWithInventory()
        {
            return roomsWithInventory;
        }

        public string GetMagacinAmount()
        {
            return magacinAmount;
        }

        public string GetMagacinMinimum()
        {
            return magacinMinimum;
        }

        private void CheckAllRooms(Inventory selectedInventory)
        {
            foreach (var room in rooms)
            {
                SetInventoryAttributes(room, selectedInventory);
            }
        }

        private void SetInventoryAttributes(Room room, Inventory selectedInventory)
        {
            inventory = new InventoryInRoom();
            inventory.Room = room;
            if (HasInventory())
            {
                if (HasSelectedInventory(selectedInventory))
                {
                    AddToRightList();
                }
            }
        }

        private bool HasInventory()
        {
            if (inventory.Room.Inventory != null)
            {
                return true;
            }
            return false;
        }

        private bool HasSelectedInventory(Inventory selectedInventory)
        {
            foreach (Inventory i in inventory.Room.Inventory)
            {
                if (i.Id == selectedInventory.Id)
                {
                    inventory.Inventory = i;
                    return true;
                }
            }
            return false;
        }

        private void AddToRightList()
        {
            String purpose = inventory.Room.RoomPurpose.Name;
            if (purpose.Equals("Ordinacija"))
            {
                ordinationsWithInventory.Add(inventory);
            }
            else if (purpose.Equals("Operaciona sala"))
            {
                operationRoomsWithInventory.Add(inventory);
            }
            else if (purpose.Equals("Soba"))
            {
                roomsWithInventory.Add(inventory);
            }
            else
            {
                magacinAmount = inventory.Inventory.CurrentAmount.ToString();
                magacinMinimum = inventory.Inventory.Minimum.ToString();
            }
        }
    }
}
