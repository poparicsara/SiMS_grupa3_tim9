using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IS_Bolnica.Services;

namespace IS_Bolnica.DoctorUI
{
    public class Adaptee
    {
        private AppointmentService appointmentService = new AppointmentService();
        public void ScheduleUrgentOperation(DateTime date)
        {
            appointmentService.ScheduleUrgentOperation(date);
        }
    }
}
