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
        List<int> GetOperationRoomNums();
        Room FindOrdinationById(int id);
        List<int> GetAvailableRoomsForHospitalization();

    }
}
