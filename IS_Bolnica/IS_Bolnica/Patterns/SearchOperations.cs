
using System.Collections.Generic;
using IS_Bolnica.Model;

namespace IS_Bolnica.Patterns
{
    class SearchOperations : SearchGridTemplate<Appointment>
    {
        private List<Appointment> appointments = new List<Appointment>();
        private List<Appointment> operations = new List<Appointment>();
        private AppointmentRepository appointmentRepository = new AppointmentRepository();

        public override bool ISearched(string text, Appointment entity)
        {
            return entity.Patient.Id.ToLower().StartsWith(text) ||
                   entity.Doctor.Surname.ToLower().StartsWith(text);
        }

        public override List<Appointment> GetAll()
        {
            appointments = appointmentRepository.GetAll();
            foreach (var appointment in appointments)
            {
                if (appointment.AppointmentType == AppointmentType.operation)
                {
                    operations.Add(appointment);
                }
            }

            return operations;
        }
    }
}
