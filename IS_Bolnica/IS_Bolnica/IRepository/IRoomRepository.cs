using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace IS_Bolnica.IRepository
{
    interface IRoomRepository : IGenericRepository<Room, int>
    {
        List<int> GetRoomNumbers();
        List<int> GetAppropriateNumbers(string hospitalWard, string roomPurpose);
        int FindIndex(Room room);
        List<int> GetOperationRoomNums();
        Room GetMagacin();
        bool IsRoomNumberUnique(int roomNumber);
        Room FindOrdinationById(int id);
        List<Room> GetSearchedRooms(string text);
        List<int> GetAvailableRoomRoomsForHospitalization();
        void ReduceAmount(Room room, Inventory inventory, int amount);
        void IncreaseAmount(Room room, Inventory inventory, int amount);

    }
}
