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
    public class SuggestionServiceBySelectedDoctor : ISuggestionService
    {
        private AppointmentRepository appointmentRepository = new AppointmentRepository();
        private DoctorRepository doctorRepository = new DoctorRepository();

        public SuggestionServiceBySelectedDoctor() { }

        private DateTime getDate()
        {
            DateTime date = DateTime.Now.AddDays(2);
            int year = date.Year;
            int month = date.Month;
            int day = date.Day;
            DateTime startDate = new DateTime(year, month, day, 07, 00, 00);

            return startDate;
        }

        public List<Suggestion> getSuggestions()
        {
            List<Suggestion> suggestions = new List<Suggestion>();
            List<Appointment> appointments = appointmentRepository.GetAll();
            DateTime startDate = getDate();

            while (suggestions.Count < 6)
            {
                if (startDate.Hour == 19)
                    startDate.AddDays(1);

                if (checkSuggestion(startDate, Suggestions.selectedDoctor))
                {
                    Suggestion suggestion = new Suggestion();
                    suggestion.Doctor = Suggestions.selectedDoctor;
                    suggestion.DateOfAppointment = startDate;
                    suggestions.Add(suggestion);
                }
                startDate = startDate + TimeSpan.FromHours(1);
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
