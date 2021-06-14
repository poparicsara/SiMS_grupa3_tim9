using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IS_Bolnica.Services;

namespace IS_Bolnica.DoctorUI
{
    
    public class Adapter : IOperation
    {
        // AppointmentService je u stvari Adaptee klasa
        private AppointmentService _appointmentService;

        public Adapter(AppointmentService appointmentService)
        {
            this._appointmentService = appointmentService;
        }

        public void ScheduleOperation(DateTime date)
        {
            this._appointmentService.ScheduleUrgentOperation(date);
        }

    }
}
