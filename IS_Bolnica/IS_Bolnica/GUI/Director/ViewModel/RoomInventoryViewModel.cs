using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IS_Bolnica.Services;
using Model;

namespace IS_Bolnica.GUI.Director.ViewModel
{
    public class RoomInventoryViewModel
    {
        public List<Inventory> RoomInventory { get; set; }
        private InventoryService service = new InventoryService();

        public RoomInventoryViewModel(Room room)
        {
            RoomInventory = service.GetRoomInventory(room);
        }
    }
}
