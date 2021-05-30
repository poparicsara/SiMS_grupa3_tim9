using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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
        private UserService userService = new UserService();

        public AppointmentService()
        {
            appointments = GetAppointments();
        }

        public List<Appointment> GetAppointments()
        {
            return appointmentRepository.LoadFromFile();
        }

        public List<Appointment> GetDoctorsExaminations()
        {
            List<Appointment> doctorsExaminations = new List<Appointment>();
            foreach (Appointment appointment in appointments)
            {
                foreach (User user in userService.GetLoggedUsers())
                {
                    if (appointment.Doctor.Username.Equals(user.Username) && appointment.AppointmentType == 0)
                    {
                        doctorsExaminations.Add(appointment);
                    }
                }
            }
            return doctorsExaminations;
        }
        public List<Appointment> GetDoctorsOperations()
        {
            List<Appointment> doctorsExaminations = new List<Appointment>();
            foreach (Appointment appointment in appointments)
            {
                foreach (User user in userService.GetLoggedUsers())
                {
                    if (appointment.Doctor.Username.Equals(user.Username) && appointment.AppointmentType == AppointmentType.operation)
                    {
                        doctorsExaminations.Add(appointment);
                    }
                }
            }
            return doctorsExaminations;
        }

        public void ScheduleAppointment(Appointment appointment)
        {
            if (IsDoctorAvailable(appointment) && IsPatientAvailable(appointment))
            {
                appointments.Add(appointment);
                appointmentRepository.SaveToFile(appointments);
            }
            else
            {
                MessageBox.Show("Nije moguce zakazati termin!");
            }
        }

        public void AddAppointment(Appointment appointment)
        {
            if (IsAppointmentValid(appointment))
            {
                if (isAvailable(appointments, appointment))
                {
                    appointments.Add(appointment);
                    appointmentRepository.SaveToFile(appointments);
                }
            }
        }

        public void DeleteAppointment(Appointment appointment)
        {
            int index = FindAppointmentIndex(appointment);
            appointments.RemoveAt(index);
            appointmentRepository.SaveToFile(appointments);
        }

        public void EditAppointment(Appointment oldAppointment, Appointment newAppointment)
        {
            if (IsAppointmentValid(newAppointment))
            {
                int indexOld = FindAppointmentIndex(oldAppointment);
                appointments.RemoveAt(indexOld);
                if (isAvailable(appointments, newAppointment))
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
            foreach (var appointment in appointments)
            {
                if (appointment.AppointmentType == 0)
                {
                    examinations.Add(appointment);
                }
            }

            return examinations;
        }

        public List<Appointment> GetOperations()
        {
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

        private bool IsAppointmentValid(Appointment appointment)
        {
            if (appointment.Room != null && appointment.Doctor != null && appointment.Patient != null)
            {
                return true;
            }
            return false;

        }

        private List<Appointment> FindPatientAppointments(Patient patient)
        {
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

        private bool isPatientFree(List<Appointment> appointments, Appointment appointment)
        {

            foreach (Appointment app in appointments)
            {
                if (app.Patient.Id == appointment.Patient.Id)
                {
                    if (app.StartTime <= appointment.StartTime && appointment.StartTime < app.EndTime)
                    {
                        MessageBox.Show("Pacijent u ovom terminu ima već zakazan pregled");
                        return false;
                    } else if (app.StartTime < appointment.EndTime && appointment.EndTime <= app.EndTime)
                    {
                        MessageBox.Show("Pacijent u ovom terminu ima već zakazan pregled");
                        return false;
                    } else if (app.StartTime >= appointment.StartTime && app.EndTime < appointment.EndTime)
                    {
                        MessageBox.Show("Pacijent u ovom terminu ima već zakazan pregled");
                        return false;
                    }
                }

            }

            return true;
        }

        private bool isRoomFree(List<Appointment> appointments, Appointment appointment)
        {
            foreach (Appointment app in appointments)
            {
                if (app.Room.Id == appointment.Room.Id)
                {
                    if (app.StartTime <= appointment.StartTime && appointment.StartTime < app.EndTime)
                    {
                        MessageBox.Show("Soba " + appointment.Room.Id + "je zauzeta u izabranom terminu");
                        return false;
                    }
                    else if (app.StartTime < appointment.EndTime && appointment.EndTime <= app.EndTime)
                    {
                        MessageBox.Show("Soba " + appointment.Room.Id + "je zauzeta u izabranom terminu");
                        return false;
                    }
                    else if (app.StartTime >= appointment.StartTime && app.EndTime < appointment.EndTime)
                    {
                        MessageBox.Show("Soba " + appointment.Room.Id + "je zauzeta u izabranom terminu");
                        return false;
                    }
                }
            }
            return true;
        }

        private bool isDoctorFree(List<Appointment> appointments, Appointment appointment)
        {
            foreach (Appointment app in appointments)
            {
                if (app.Doctor.Id == appointment.Doctor.Id)
                {
                    if (app.StartTime <= appointment.StartTime && appointment.StartTime < app.EndTime)
                    {
                        MessageBox.Show("Doktor već ima zakazan termin u isto vreme!");
                        return false;
                    }
                    else if (app.StartTime < appointment.EndTime && appointment.EndTime <= app.EndTime)
                    {
                        MessageBox.Show("Doktor već ima zakazan termin u isto vreme!");
                        return false;
                    }
                    else if (app.StartTime >= appointment.StartTime && app.EndTime <= appointment.EndTime)
                    {
                        MessageBox.Show("Doktor već ima zakazan termin u isto vreme!");
                        return false;
                    }
                }
            }
            return true;
        }

        private bool isAvailable(List<Appointment> appointments, Appointment appointment)
        {
            if (isPatientFree(appointments, appointment) &&
                isRoomFree(appointments, appointment) &&
                isDoctorFree(appointments, appointment))
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        private bool IsDoctorAvailable(Appointment appointment)
        {
            foreach (Appointment scheduledAppointment in appointments)
            {
                if (scheduledAppointment.Doctor.Id.Equals(appointment.Doctor.Id))
                {
                    if (scheduledAppointment.StartTime.Equals(appointment.StartTime))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        private bool IsPatientAvailable(Appointment appointment)
        {
            foreach (Appointment scheduledAppointment in appointments)
            {
                if (scheduledAppointment.Patient.Id.Equals(appointment.Patient.Id))
                {
                    if (scheduledAppointment.StartTime.Equals(appointment.StartTime))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

    }
}
