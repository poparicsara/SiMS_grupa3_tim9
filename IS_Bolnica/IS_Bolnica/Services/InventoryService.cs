using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace IS_Bolnica.Services
{
    public class InventoryService
    {
        private InventoryRepository inventoryRepository = new InventoryRepository();
        private List<Inventory> inventoryItems = new List<Inventory>();
        public InventoryService()
        {
            inventoryItems = GetInventory();
        }

        public int GetNumberOfBeds()
        {
            int numberOfBeds = 0;
            foreach (Inventory inventory in inventoryItems)
            {
                if (inventory.Name.Equals("Krevet"))
                {
                    numberOfBeds = inventory.CurrentAmount;
                }
            }
            return numberOfBeds;
        }

        public int GetNumberOfBedsInRoom(RoomRecord room)
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
        public List<Inventory> GetInventory()
        {
            return inventoryRepository.loadFromFile("Inventar.json");
        }
    }
}
