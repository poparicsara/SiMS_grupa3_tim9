using System;
using System.Collections.Generic;
using IS_Bolnica.Model;
using Model;

namespace IS_Bolnica.Services
{
    public class UrgentAppointmentService
    {
        private List<Appointment> appointments = new List<Appointment>();
        private AppointmentRepository appointmentRepository = new AppointmentRepository();
        private DoctorRepository doctorRepository = new DoctorRepository();
        private List<Doctor> doctors = new List<Doctor>();
        private List<Appointment> scheduledAppointments = new List<Appointment>();
        private DateTime currentDate;

        private AppointmentService appointmentService = new AppointmentService();
        private FindAttributesService findAttributesService = new FindAttributesService();

        public UrgentAppointmentService()
        {
            this.appointments = appointmentService.GetAppointments();
        }

        public void AddUrgentExamination(Appointment appointment,Appointment selectedAppointment)
        {
            appointments = appointmentService.GetAppointments();
            for (int i = 0; i < appointments.Count; i++)
            {
                if (appointmentFound(appointments[i], selectedAppointment))
                {
                    appointment = setExamination(appointment, selectedAppointment);
                    addSelectedExamination(appointment, selectedAppointment, i);
                    return;
                }
            }
            appointments.Add(appointment);
            appointmentRepository.SaveToFile(appointments);
        }

        public void AddUrgentOperation(Appointment appointment, List<Appointment> selectedAppointments)
        {
            appointments = appointmentRepository.GetAll();
            if (selectedAppointments.Count == 1)
            {
                oneOperationSelected(appointment, selectedAppointments);
                return;
            }
            if (selectedAppointments.Count > 1)
            {
                if (!IsAppointmentLongEnough(selectedAppointments, appointment)) return;
                moreSelectedOperations(appointment, selectedAppointments);
            }
        }

        public List<Appointment> GetUrgentOperationOptions(Appointment appointment, Specialization specialization)
        {
            List<Appointment> options = new List<Appointment>();
            doctors = doctorRepository.LoadFromFile();

            foreach (Doctor doc in doctors)
            {
                if (doc.Specialization.Name.Equals(specialization.Name))
                {
                    appointment.AppointmentType = AppointmentType.operation;
                    options = getFirstFreeAppointment(appointment, doc);
                }
            }

            if (options.Count == 0)
            {
                options = SortByPostponeDates(alreadyScheduledAppointments(specialization));
            }

            return options;
        }

        public List<Appointment> GetUrgentExaminationOptions(Appointment appointment, Specialization specialization)
        {
            List<Appointment> options = new List<Appointment>();
            doctors = doctorRepository.LoadFromFile();

            foreach (Doctor doc in doctors)
            {
                if (doc.Specialization.Name.Equals(specialization.Name))
                {
                    appointment.AppointmentType = AppointmentType.examination;
                    appointment.Room = findAttributesService.FindRoomById(doc.Ordination);
                    options = getFirstFreeAppointment(appointment, doc);
                }
            }

            if (options.Count == 0)
            {
                options = SortByPostponeDates(alreadyScheduledAppointments(specialization));
            }

            return options;
        }

        private Appointment setExamination(Appointment appointment, Appointment selectedAppointment)
        {
            appointment.StartTime = selectedAppointment.StartTime;
            appointment.EndTime = selectedAppointment.StartTime.AddMinutes(30);
            return appointment;
        }

        private void addSelectedExamination(Appointment appointment, Appointment selectedAppointment, int index)
        {
            appointments.RemoveAt(index);
            appointments.Add(appointment);
            appointmentRepository.SaveToFile(appointments);
            PostponeAppointment(selectedAppointment);
        }

        private bool IsAppointmentLongEnough(List<Appointment> selectedAppointments, Appointment urgentAppointment)
        {
            int duration = 0;
            foreach (Appointment o in selectedAppointments)
            {
                duration += o.DurationInMins;
            }

            if (duration < urgentAppointment.DurationInMins) return false;
            return true;
        }

        private Appointment setOperation(Appointment appointment, Appointment selectedAppointment)
        {
            appointment.StartTime = selectedAppointment.StartTime;
            appointment.EndTime = appointment.StartTime.AddMinutes(appointment.DurationInMins);
            return appointment;
        }

        private void addSelectedOperation(Appointment appointment, Appointment selectedAppointment, int index)
        {
            appointments = appointmentRepository.GetAll();
            if (selectedAppointment.DurationInMins < appointment.DurationInMins) return;
            appointment = setOperation(appointment, selectedAppointment);
            appointments.RemoveAt(index);
            appointments.Add(appointment);
            appointmentRepository.SaveToFile(appointments);
            PostponeAppointment(selectedAppointment);
        }

        private void moreSelectedOperations(Appointment appointment, List<Appointment> selectedAppointments)
        {
            appointments = appointmentRepository.GetAll();
            appointment = setOperation(appointment, selectedAppointments[0]);
            removeSelectedOperation(selectedAppointments[0], appointments);
            appointments.Add(appointment);
            appointmentRepository.SaveToFile(appointments);
            PostponeAppointment(selectedAppointments[0]);

            for (int k = 1; k < selectedAppointments.Count; k++)
            {
                removeSelectedOperation(selectedAppointments[k], appointments);
                PostponeAppointment(selectedAppointments[k]);
            }
        }

        private void oneOperationSelected(Appointment appointment, List<Appointment> selectedAppointments)
        {
            appointments = appointmentRepository.GetAll();
            for (int k = 0; k < appointments.Count; k++)
            {
                if (appointmentFound(appointments[k], selectedAppointments[0]))
                {
                    addSelectedOperation(appointment, selectedAppointments[0], k);
                    return;
                }
            }
            appointments.Add(selectedAppointments[0]);
            appointmentRepository.SaveToFile(appointments);
        }

        private bool appointmentFound(Appointment appointment, Appointment oldAppointment)
        {
            if (appointment.StartTime.Equals(oldAppointment.StartTime) && appointment.Doctor.Id.Equals(oldAppointment.Doctor.Id)) return true;
            return false;
        }

        private void removeSelectedOperation(Appointment appointment, List<Appointment> appointments)
        {
            for (int k = 0; k < appointments.Count; k++)
            {
                if (appointmentFound(appointments[k], appointment))
                {
                    appointments.RemoveAt(k);
                    appointmentRepository.SaveToFile(appointments);
                }
            }
        }

        private List<Appointment> getFirstFreeAppointment(Appointment appointment, Doctor doctor)
        {
            currentDate = DateTime.Now;
            DateTime newDate = new DateTime();
            List<Appointment> appointmentOptions = new List<Appointment>();
            appointment.Doctor = doctor;
            appointment.IsUrgent = true;

            for (int i = 1; i <= 90; i++)
            {
                newDate = currentDate.AddMinutes(i);
                appointment.StartTime = new DateTime(newDate.Year, newDate.Month, newDate.Day, newDate.Hour, newDate.Minute, 0);
                appointment.EndTime = appointment.StartTime.AddMinutes(appointment.DurationInMins);
                if (appointmentService.IsAvailable(appointment))
                {
                    appointmentOptions.Add(appointment);
                    return appointmentOptions;
                }
            }

            return appointmentOptions;
        }

        private List<Appointment> alreadyScheduledAppointments(Specialization specialization)
        {
            scheduledAppointments = appointmentRepository.GetAll();
            List<Appointment> appointments = new List<Appointment>();
            foreach (Appointment ap in scheduledAppointments)
            {
                if (ap.Doctor.Specialization.Name.Equals(specialization.Name) && ap.StartTime > currentDate)
                {
                    ap.PostponedDate = SetPostponedDate(ap).PostponedDate;
                    appointments.Add(ap);

                }
            }

            return appointments;
        }

        private bool isPatientFreePostponed(Appointment appointment)
        {
            appointments = appointmentService.GetAppointments();
            DateTime endTimeNew = new DateTime();
            endTimeNew = appointment.PostponedDate.AddMinutes(30);
            foreach (Appointment ap in appointments)
            {
                if (ap.Patient.Id == appointment.Patient.Id)
                {

                    if (ap.StartTime <= appointment.PostponedDate && appointment.PostponedDate < ap.EndTime) return false;
                    if (ap.StartTime < endTimeNew && endTimeNew <= ap.EndTime) return false;
                    if (ap.StartTime >= appointment.PostponedDate && ap.EndTime <= endTimeNew) return false;
                }
            }

            return true;
        }

        private bool isRoomFreePostponed(Appointment appointment)
        {
            appointments = appointmentService.GetAppointments();
            DateTime endTimeNew = new DateTime();
            endTimeNew = appointment.PostponedDate.AddMinutes(30);
            foreach (Appointment ap in appointments)
            {
                if (ap.Room.Id == appointment.Room.Id)
                {
                    if (ap.StartTime <= appointment.PostponedDate && appointment.PostponedDate < ap.EndTime) return false;
                    if (ap.StartTime < endTimeNew && endTimeNew <= ap.EndTime) return false;
                    if (ap.StartTime >= appointment.PostponedDate && ap.EndTime <= endTimeNew) return false;
                }
            }
            return true;
        }

        private bool isDoctorFreePostponed(Appointment appointment)
        {
            appointments = appointmentService.GetAppointments();
            DateTime dateTimeEnd = new DateTime();
            dateTimeEnd = appointment.PostponedDate.AddMinutes(30);
            foreach (Appointment ap in appointments)
            {
                if (ap.Doctor.Id == appointment.Doctor.Id)
                {
                    if (ap.StartTime <= appointment.PostponedDate && appointment.PostponedDate < ap.EndTime) return false;
                    if (ap.StartTime < dateTimeEnd && dateTimeEnd <= ap.EndTime) return false;
                    if (ap.StartTime >= appointment.PostponedDate && ap.EndTime <= dateTimeEnd) return false;
                }
            }
            return true;
        }

        private bool IsAvailablePostponed(Appointment appointment)
        {
            if (appointment.Patient != null)
            {
                if (isPatientFreePostponed(appointment) && isRoomFreePostponed(appointment) && isDoctorFreePostponed(appointment)) return true;
                return false;
            }
            else
            {
                if (isRoomFreePostponed(appointment) && isDoctorFreePostponed(appointment)) return true;
                return false;
            }
        }

        private Appointment SetPostponedDate(Appointment appointment)
        {
            List<Appointment> exams = new List<Appointment>();
            appointments = appointmentRepository.GetAll();

            DateTime dateNew = new DateTime();
            dateNew = appointment.StartTime;
            DateTime temp1 = new DateTime();

            for (int i = 1; i < 1000; i++)
            {
                temp1 = dateNew.AddMinutes(i * 10);
                appointment.PostponedDate = new DateTime(temp1.Year, temp1.Month, temp1.Day, temp1.Hour, temp1.Minute, 0);
                if (IsAvailablePostponed(appointment))
                {
                    break;
                }
            }
            return appointment;
        }

        private List<Appointment> SortByPostponeDates(List<Appointment> appointments)
        {
            List<Appointment> orderedAppointments = new List<Appointment>();
            DateTime minDate = new DateTime();

            while (appointments.Count != 0)
            {
                minDate = appointments[0].PostponedDate;
                foreach (Appointment ex in appointments)
                {
                    if (minDate >= ex.PostponedDate)
                    {
                        minDate = ex.PostponedDate;
                    }
                }

                for (int i = 0; i < appointments.Count; i++)
                {
                    if (minDate == appointments[i].PostponedDate)
                    {
                        orderedAppointments.Add(appointments[i]);
                        appointments.RemoveAt(i);
                    }
                }
            }

            return orderedAppointments;
        }

        private Appointment PostponeAppointment(Appointment appointment)
        {
            Appointment appoint = appointment;
            appointments = appointmentRepository.GetAll();

            DateTime dateNew = new DateTime();
            dateNew = appoint.StartTime;
            DateTime temp1 = new DateTime();

            for (int i = 1; i < 10000; i++)
            {
                temp1 = dateNew.AddMinutes(i * 10);
                appoint.StartTime = new DateTime(temp1.Year, temp1.Month, temp1.Day, temp1.Hour, temp1.Minute, 0);
                appoint.EndTime = appoint.StartTime.AddMinutes(appoint.DurationInMins);
                if (appointmentService.IsAvailable(appoint))
                {
                    appointments.Add(appoint);
                    appointmentRepository.SaveToFile(appointments);
                    break;
                }
            }
            return appoint;

        }

    }
}
