using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IS_Bolnica.Model;

namespace IS_Bolnica.Patterns
{
    class AppointmentOperation : EditAppointmentTemplate
    {
        public AppointmentOperation(Appointment newAppointment, Appointment oldAppointment) : base(newAppointment, oldAppointment)
        {

        }

        protected override void SetAppointmentType()
        {
            newAppointment.AppointmentType = AppointmentType.operation;
        }
    }
}
