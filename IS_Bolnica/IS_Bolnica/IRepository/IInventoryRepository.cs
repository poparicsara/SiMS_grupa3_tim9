using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace IS_Bolnica.IRepository
{
    interface IInventoryRepository : IGenericRepository<Inventory, int>
    {
        List<Inventory> GetRoomInventory(Room room);
        void AddInventoryToRoom(Room room, Inventory inventory);
        void ReduceAmount(Room room, Inventory inventory, int amount);
        void IncreaseAmount(Room room, Inventory inventory, int amount);
        
    }
}
