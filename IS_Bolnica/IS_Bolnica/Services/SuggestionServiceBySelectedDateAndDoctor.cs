using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IS_Bolnica.Model;
using IS_Bolnica.Open_Closed_Principle;
using IS_Bolnica.PatientPages;
using Model;

namespace IS_Bolnica.Services
{
    public class SuggestionServiceBySelectedDateAndDoctor : ISuggestionService
    {
        private AppointmentRepository appointmentRepository = new AppointmentRepository();

        public SuggestionServiceBySelectedDateAndDoctor()
        {
        }

        public List<Suggestion> getSuggestions()
        {
            List<Suggestion> suggestions = new List<Suggestion>();

            while (suggestions.Count < 6)
            {
                if (AddNewAppointment.selectedDate.Hour == 19)
                    AddNewAppointment.selectedDate.AddDays(1);

                if (checkSuggestion(AddNewAppointment.selectedDate, AddNewAppointment.selectedDoctor))
                {
                    Suggestion suggestion = new Suggestion();
                    suggestion.Doctor = AddNewAppointment.selectedDoctor;
                    suggestion.DateOfAppointment = AddNewAppointment.selectedDate;
                    suggestions.Add(suggestion);
                }
                AddNewAppointment.selectedDate = AddNewAppointment.selectedDate + TimeSpan.FromHours(1);
            }

            return suggestions;
        }

        private bool checkSuggestion(DateTime date, Doctor doctor)
        {
            List<Appointment> appointments = appointmentRepository.GetAll();

            bool posible = true;
            foreach (Appointment appointment in appointments)
            {
                if (appointment.StartTime.Equals(date) && doctor.Id.Equals(appointment.Doctor.Id))
                    posible = false;
            }

            return posible;
        }
    }
}
