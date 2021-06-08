using System;
using System.Collections.Generic;
using IS_Bolnica.Model;
using Model;

namespace IS_Bolnica.Services
{
    public class AppointmentService
    {
        private AppointmentRepository appointmentRepository = new AppointmentRepository();
        private List<Appointment> appointments = new List<Appointment>();
        private List<Appointment> examinations = new List<Appointment>();
        private List<Appointment> operations = new List<Appointment>();

        public AppointmentService()
        {
            appointments = GetAppointments();
        }

        public void AddAppointment(Appointment appointment)
        {
            appointments = appointmentRepository.LoadFromFile();
            if (isAppointmentValid(appointment))
            {
                if (IsAvailable(appointment))
                {
                    appointments.Add(appointment);
                    appointmentRepository.SaveToFile(appointments);
                }
            }
        }

        public void DeleteAppointment(Appointment appointment)
        {
            appointments = appointmentRepository.LoadFromFile();
            int index = FindAppointmentIndex(appointment);
            appointments.RemoveAt(index);
            appointmentRepository.SaveToFile(appointments);
        }

        public void EditAppointment(Appointment oldAppointment, Appointment newAppointment)
        {
            appointments = appointmentRepository.LoadFromFile();
            if (isAppointmentValid(newAppointment))
            {
                int indexOld = FindAppointmentIndex(oldAppointment);
                appointments.RemoveAt(indexOld);
                if (IsAvailable(newAppointment))
                {
                    appointments.Add(newAppointment);
                    appointmentRepository.SaveToFile(appointments);
                }
                else
                {
                    appointments.Add(oldAppointment);
                    appointmentRepository.SaveToFile(appointments);
                }
            }
        }

        public List<Appointment> getExaminations()
        {
            appointments = appointmentRepository.LoadFromFile();
            foreach (var appointment in appointments)
            {
                if (appointment.AppointmentType == 0)
                {
                    examinations.Add(appointment);
                }
            }

            return examinations;
        }

        public List<Appointment> getOperations()
        {
            appointments = appointmentRepository.LoadFromFile();
            foreach (var appointment in appointments)
            {
                if (appointment.AppointmentType == AppointmentType.operation)
                {
                    operations.Add(appointment);
                }
            }

            return  operations;
        }

        public void RemovePatientsAppointments(Patient patient)
        {
            appointments = appointmentRepository.LoadFromFile();
            List<Appointment> patientAppointments = FindPatientAppointments(patient);
            for (int i = 0; i < appointments.Count; i++)
            {
                foreach (var patientAppointment in patientAppointments)
                {
                    if (patientAppointment.Patient.Id.Equals(appointments[i].Patient.Id))
                    {
                        appointments.RemoveAt(i);
                    }
                }
            }
            appointmentRepository.SaveToFile(appointments);
        }

        private bool isAppointmentValid(Appointment appointment)
        {
            if (appointment.Room != null && appointment.Doctor != null && appointment.Patient != null)
            {
                return true;
            }
            return false;

        }

        private List<Appointment> FindPatientAppointments(Patient patient)
        {
            appointments = appointmentRepository.LoadFromFile();
            List<Appointment> patientAppointments = new List<Appointment>();
            foreach (var appointment in appointments)
            {
                if (appointment.Patient.Id.Equals(patient.Id))
                {
                    patientAppointments.Add(appointment);
                }
            }

            return patientAppointments;

        }

        private int FindAppointmentIndex(Appointment appointment)
        {
            appointments = appointmentRepository.LoadFromFile();
            for (int i = 0; i < appointments.Count; i++)
            {
                if (appointment.StartTime.Equals(appointments[i].StartTime) &&
                    appointment.Patient.Id.Equals(appointments[i].Patient.Id))
                {
                    return i;
                }
            }

            return -1;
        }

        private bool isPatientFree(Appointment appointment)
        {
            appointments = appointmentRepository.LoadFromFile();
            foreach (Appointment app in appointments)
            {
                if (app.Patient.Id == appointment.Patient.Id)
                {
                    if (app.StartTime <= appointment.StartTime && appointment.StartTime < app.EndTime)
                    {
                        return false;
                    } else if (app.StartTime < appointment.EndTime && appointment.EndTime <= app.EndTime)
                    {
                        return false;
                    } else if (app.StartTime >= appointment.StartTime && app.EndTime < appointment.EndTime)
                    {
                        return false;
                    }
                }

            }

            return true;
        }

        private bool isRoomFree(Appointment appointment)
        {
            appointments = appointmentRepository.LoadFromFile();
            foreach (Appointment app in appointments)
            {
                if (app.Room.Id == appointment.Room.Id)
                {
                    if (app.StartTime <= appointment.StartTime && appointment.StartTime < app.EndTime)
                    {
                        return false;
                    }
                    else if (app.StartTime < appointment.EndTime && appointment.EndTime <= app.EndTime)
                    {
                        return false;
                    }
                    else if (app.StartTime >= appointment.StartTime && app.EndTime < appointment.EndTime)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private bool isDoctorFree(Appointment appointment)
        {
            appointments = appointmentRepository.LoadFromFile();
            foreach (Appointment app in appointments)
            {
                if (app.Doctor.Id == appointment.Doctor.Id)
                {
                    if (app.StartTime <= appointment.StartTime && appointment.StartTime < app.EndTime)
                    {
                        return false;
                    }
                    else if (app.StartTime < appointment.EndTime && appointment.EndTime <= app.EndTime)
                    {
                        return false;
                    }
                    else if (app.StartTime >= appointment.StartTime && app.EndTime <= appointment.EndTime)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        /*private bool isDoctorsShift(Appointment appointment)
        {
            doctors = doctorRepository.loadFromFile("Doctors.json");
            foreach (var doctor in doctors)
            {
                if (doctor.Id.Equals(appointment.Doctor.Id))
                {
                    foreach (var shift in doctor.Shifts)
                    {
                        //if(appointment.StartTime <= shift.ShiftStartDate)
                    }
                }
            }

            return true;
        }*/

        public bool IsAvailable(Appointment appointment)
        {
            if (isPatientFree(appointment) &&
                isRoomFree(appointment) &&
                isDoctorFree(appointment))
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public List<Appointment> GetAppointments()
        {
            return appointmentRepository.LoadFromFile();
        }

        public List<Appointment> GetSearchedExaminations(string text)
        {
            appointments = appointmentRepository.LoadFromFile();
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

        public List<Appointment> GetSearchedOperations(string text)
        {
            appointments = appointmentRepository.LoadFromFile();
            List<Appointment> searchedAppointments = new List<Appointment>();
            foreach (Appointment appointment in appointments)
            {
                if (ISearched(text, appointment))
                {
                    if (appointment.AppointmentType == AppointmentType.operation)
                    {
                        searchedAppointments.Add(appointment);
                    }
                }
            }

            return searchedAppointments;
        }

        private static bool ISearched(string text, Appointment a)
        {
            return a.Patient.Id.ToLower().StartsWith(text) ||
                   a.Doctor.Surname.ToLower().StartsWith(text);
        }

    }
}
