using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IS_Bolnica.DoctorUI
{
    public interface IOperation
    {
        void ScheduleOperation(DateTime date);
    }
}
