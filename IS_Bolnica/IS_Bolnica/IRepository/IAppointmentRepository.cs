using IS_Bolnica.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IS_Bolnica.IRepository
{
    interface IAppointmentRepository : IGenericRepository<Appointment, int>
    {
        
    }
}
