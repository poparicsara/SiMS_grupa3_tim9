using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IS_Bolnica.Model;
using Model;

namespace IS_Bolnica.IRepository
{
    public interface IDoctorRepository : IGenericRepository<Doctor, string>
    {
        void AddShift(Shift shift);
        void AddVacation(Vacation vacation);
        void DeleteShift(int index, string id);
        void DeleteVacation(int index, string id);
    }
}
