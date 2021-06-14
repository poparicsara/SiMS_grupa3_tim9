using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IS_Bolnica.Model;

namespace IS_Bolnica.Patterns
{
    class SearchExamination : SearchGridTemplate<Appointment>
    {
        private List<Appointment> appointments = new List<Appointment>();
        private AppointmentRepository appointmentRepository = new AppointmentRepository();

        public override bool ISearched(string text, Appointment entity)
        {
            return entity.Patient.Id.ToLower().StartsWith(text) ||
                   entity.Doctor.Surname.ToLower().StartsWith(text);
        }

        public override List<Appointment> GetSearchedEntities(string text)
        {
            appointments = appointmentRepository.GetAll();
            List<Appointment> searchedAppointments = new List<Appointment>();
            foreach (Appointment appointment in appointments)
            {
                if (ISearched(text, appointment))
                {
                    if (appointment.AppointmentType == AppointmentType.examination)
                    {
                        searchedAppointments.Add(appointment);
                    }
                }
            }

            return searchedAppointments;
        }
    }
}
