using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IS_Bolnica.Model;
using Model;

namespace IS_Bolnica.Services
{
    public class SuggestionService
    {
        private AppointmentRepository appointmentRepository = new AppointmentRepository();
        private DoctorRepository doctorRepository = new DoctorRepository();
        public SuggestionService() { }

        public List<Suggestion> getSuggestionsBySelectedDate(String selectedDate)
        {
            List<Suggestion> suggestions = new List<Suggestion>();
            List<Appointment> appointments = GetAppointments();
            DateTime startDate = getDate(selectedDate);


            while (suggestions.Count < 6)
            {
                if (startDate.Hour == 19)
                    startDate.AddDays(1);

                Doctor doctor = findRandDoctor();
                Boolean posible = true;
                foreach (Appointment appointment in appointments)
                {
                    if (appointment.StartTime.Equals(startDate) && doctor.Id.Equals(appointment.Doctor.Id))
                        posible = false;
                }

                if (posible)
                {
                    Suggestion suggestion = new Suggestion();
                    suggestion.Doctor = doctor;
                    suggestion.DateOfAppointment = startDate;
                    suggestions.Add(suggestion);
                }
                startDate = startDate + TimeSpan.FromHours(1);
            }

            return suggestions;
        }

        public List<Suggestion> getSuggestionsBySelectedDoctor(String selectedDoctor)
        {
            List<Suggestion> suggestions = new List<Suggestion>();
            List<Appointment> appointments = GetAppointments();
            DateTime startDate = getDate("");
            Doctor doctor = findDoctorByName(selectedDoctor);

            while (suggestions.Count < 6)
            {
                if (startDate.Hour == 19)
                    startDate.AddDays(1);

                Boolean posible = true;
                foreach (Appointment appointment in appointments)
                {
                    if (appointment.StartTime.Equals(startDate) && doctor.Id.Equals(appointment.Doctor.Id))
                        posible = false;
                }

                if (posible)
                {
                    Suggestion suggestion = new Suggestion();
                    suggestion.Doctor = doctor;
                    suggestion.DateOfAppointment = startDate;
                    suggestions.Add(suggestion);
                }
                startDate = startDate + TimeSpan.FromHours(1);
            }

            return suggestions;
        }

        public List<Suggestion> getSuggestions()
        {
            List<Suggestion> suggestions = new List<Suggestion>();
            List<Appointment> appointments = GetAppointments();
            DateTime startDate = getDate("");

            while (suggestions.Count < 6)
            {
                if (startDate.Hour == 19)
                    startDate.AddDays(1);

                Doctor doctor = findRandDoctor();

                Boolean posible = true;
                foreach (Appointment appointment in appointments)
                {
                    if (appointment.StartTime.Equals(startDate) && doctor.Id.Equals(appointment.Doctor.Id))
                        posible = false;
                }

                if (posible)
                {
                    Suggestion suggestion = new Suggestion();
                    suggestion.Doctor = doctor;
                    suggestion.DateOfAppointment = startDate;
                    suggestions.Add(suggestion);
                }
                startDate = startDate + TimeSpan.FromHours(1);
            }

            return suggestions;
        }

        public List<Suggestion> getSuggestionsBySelectedDateAndDoctor(String selectedDoctor, String selectedDate)
        {
            List<Suggestion> suggestions = new List<Suggestion>();
            List<Appointment> appointments = GetAppointments();
            DateTime startDate = getDate(selectedDate);
            Doctor doctor = findDoctorByName(selectedDoctor);

            while (suggestions.Count < 6)
            {
                if (startDate.Hour == 19)
                    startDate.AddDays(1);

                Boolean posible = true;
                foreach (Appointment appointment in appointments)
                {
                    if (appointment.StartTime.Equals(startDate) && doctor.Id.Equals(appointment.Doctor.Id))
                        posible = false;
                }

                if (posible)
                {
                    Suggestion suggestion = new Suggestion();
                    suggestion.Doctor = doctor;
                    suggestion.DateOfAppointment = startDate;
                    suggestions.Add(suggestion);
                }
                startDate = startDate + TimeSpan.FromHours(1);
            }

            return suggestions;
        }

        private Doctor findDoctorByName(string drNameSurname)
        {
            Doctor doctor = new Doctor();
            List<Doctor> doctors = doctorRepository.GetAll();
            foreach (Doctor dr in doctors)
            {
                string doctorsNameAndSurname = dr.Name + ' ' + dr.Surname;
                if (doctorsNameAndSurname.Equals(drNameSurname))
                {
                    doctor = dr;
                }
            }

            return doctor;
        }

        private Doctor findRandDoctor()
        {
            List<Doctor> doctors = doctorRepository.GetAll();
            Random rnd = new Random();
            int index = rnd.Next(0, doctors.Count - 1);
            return doctors[index];
        }

        private DateTime getDate(String dateFromPage)
        {
            DateTime date = DateTime.Now.AddDays(2);
            int year = date.Year;
            int month = date.Month;
            int day = date.Day;
            DateTime startDate = new DateTime(year, month, day, 07, 00, 00);

            if (!dateFromPage.Equals(""))
            {
                string[] partsOfDate = dateFromPage.Split(' ')[0].Split('/');
                DateTime selectedDate = new DateTime(Convert.ToInt32(partsOfDate[2]), Convert.ToInt32(partsOfDate[0]), Convert.ToInt32(partsOfDate[1]),
                    07, 00, 00);
                return selectedDate;
            }

            return startDate;
        }

        private List<Appointment> GetAppointments()
        {
            return appointmentRepository.GetAll();
        }
    }
}
