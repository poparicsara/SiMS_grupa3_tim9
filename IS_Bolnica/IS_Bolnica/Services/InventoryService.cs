using System;
using System.Collections.Generic;
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
        private List<Inventory> inventories = new List<Inventory>();
        private InventoryRepository repository = new InventoryRepository();

        public List<Inventory> GetMagacinInventory()
        {
            RoomService roomService = new RoomService();
            Room room = roomService.GetMagacin();
            return room.inventory;
        }

        public List<Inventory> GetDynamicInventory()
        {
            return repository.GetDynamicInventory();
        }

        public List<Inventory> GetStaticInventory()
        {
            return repository.GetStaticInventory();
        }
    }
}
