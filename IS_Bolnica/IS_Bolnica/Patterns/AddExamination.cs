using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IS_Bolnica.Model;

namespace IS_Bolnica.Patterns
{
    class AddExamination : AddAppointmentTemplate
    {
        private Appointment appointment = new Appointment();
        public AddExamination(Appointment appointment) : base(appointment)
        {
            this.appointment = appointment;
        }

        protected override void SetAppointmentType()
        {
            appointment.AppointmentType = AppointmentType.examination;
        }
    }
}
