using IS_Bolnica.Model;
using IS_Bolnica.Services;

namespace IS_Bolnica.Patterns
{
    public abstract class EditAppointmentTemplate
    {
        private AppointmentService appointmentService = new AppointmentService();
        protected Appointment newAppointment;
        private Appointment oldAppointment;

        public EditAppointmentTemplate(Appointment newAppointment, Appointment oldAppointment)
        {
            this.newAppointment = newAppointment;
            this.oldAppointment = oldAppointment;
        }

        public void EditAppointment()
        {
            SetAppointmentType();
            DeleteOldAppointment(oldAppointment);
            AddNewAppointment(newAppointment);
        }

        protected abstract void SetAppointmentType();

        private void DeleteOldAppointment(Appointment oldAppointment)
        {
            appointmentService.DeleteAppointment(oldAppointment);
        }

        private void AddNewAppointment(Appointment appointment)
        {
            appointmentService.AddAppointment(appointment);
        }

    }
}
