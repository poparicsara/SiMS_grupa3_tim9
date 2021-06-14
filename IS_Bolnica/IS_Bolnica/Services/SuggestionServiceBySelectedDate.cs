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
    public class SuggestionServiceBySelectedDate : ISuggestionService
    {
        private AppointmentRepository appointmentRepository = new AppointmentRepository();
        private DoctorRepository doctorRepository = new DoctorRepository();

        public SuggestionServiceBySelectedDate()
        {
        }

        public List<Suggestion> getSuggestions()
        {
            List<Suggestion> suggestions = new List<Suggestion>();
            List<Appointment> appointments = appointmentRepository.GetAll();

            while (suggestions.Count < 6)
            {
                if (AddNewAppointment.selectedDate.Hour == 19)
                    AddNewAppointment.selectedDate.AddDays(1);

                Doctor doctor = findRandDoctor();

                if (checkSuggestion(AddNewAppointment.selectedDate, doctor))
                {
                    Suggestion suggestion = new Suggestion();
                    suggestion.Doctor = doctor;
                    suggestion.DateOfAppointment = AddNewAppointment.selectedDate;
                    suggestions.Add(suggestion);
                }
                AddNewAppointment.selectedDate = AddNewAppointment.selectedDate + TimeSpan.FromHours(1);
            }

            return suggestions;
        }

        private Doctor findRandDoctor()
        {
            List<Doctor> doctors = doctorRepository.GetAll();
            Random rnd = new Random();
            int index = rnd.Next(0, doctors.Count - 1);
            return doctors[index];
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
