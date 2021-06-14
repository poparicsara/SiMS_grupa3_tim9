using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IS_Bolnica.Model;
using IS_Bolnica.Services;
using Model;

namespace IS_Bolnica.Patterns
{
    public abstract class AddAppointmentTemplate
    {
        private AppointmentRepository appointmentRepository = new AppointmentRepository();
        private AppointmentService appointmentService = new AppointmentService();
        protected Appointment appointment;

        public AddAppointmentTemplate(Appointment appointment)
        {
            this.appointment = appointment;
        }

        public void AddAppointment()
        {
            SetAppointmentType();
            Add();
        }

        protected abstract void SetAppointmentType();

        private void Add()
        {
            if (appointmentService.IsAvailable(appointment))
            {
                appointmentRepository.Add(appointment);
            }
        }
    }
}
