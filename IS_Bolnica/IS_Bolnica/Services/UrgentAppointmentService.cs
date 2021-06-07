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
    public class UrgentAppointmentService
    {
        private List<Appointment> appointments = new List<Appointment>();
        private AppointmentRepository appointmentRepository = new AppointmentRepository();
        private DoctorRepository doctorRepository = new DoctorRepository();
        private List<Doctor> doctors = new List<Doctor>();
        private List<Room> rooms = new List<Room>();
        private RoomRepository roomRepository = new RoomRepository();
        private List<Appointment> scheduledAppointments = new List<Appointment>();
        private DateTime currentDate = new DateTime();
        private Appointment appointmentOption = new Appointment();

        private AppointmentService appointmentService = new AppointmentService();
        private FindAttributesService findAttributesService = new FindAttributesService();

        public UrgentAppointmentService()
        {
            this.appointments = appointmentService.GetAppointments();
        }

        public void AddUrgentExamination(Appointment appointment,Appointment selectedAppointment)
        {
            appointments = appointmentService.GetAppointments();
            foreach (Appointment ap in appointments)
            {
                if (ap.StartTime == appointment.StartTime && ap.Doctor.Id.Equals(appointment.Doctor.Id))
                {
                    MessageBox.Show("CONTAINS");

                    appointment.StartTime = selectedAppointment.StartTime;
                    appointment.EndTime = selectedAppointment.StartTime.AddMinutes(30);
                    appointment.Doctor = selectedAppointment.Doctor;
                    appointment.Room = selectedAppointment.Room;
                    appointment.DurationInMins = 30;
                    appointments.Remove(ap);
                    appointments.Add(appointment);
                    appointmentRepository.SaveToFile(appointments);
                    appointments.Add(PostponeAppointment(ap));
                    appointmentRepository.SaveToFile(appointments);
                    return;
                }
            }

            appointments.Add(appointment);
            MessageBox.Show("Okay");
            appointmentRepository.SaveToFile(appointments);
        }

        private Appointment setAppointment(Appointment appointment, Appointment selectedAppointment)
        {
            appointment.StartTime = selectedAppointment.StartTime;
            appointment.EndTime = appointment.StartTime.AddMinutes(appointment.DurationInMins);
            appointment.Doctor = selectedAppointment.Doctor;
            appointment.Room = selectedAppointment.Room;
            appointment.AppointmentType = AppointmentType.operation;
            return appointment;
        }

        public void AddUrgentOperation(Appointment appointment, List<Appointment> selectedAppointments)
        {
            appointments = appointmentRepository.LoadFromFile();
            for (int k = 0; k < appointments.Count; k++)
            {
                if (selectedAppointments.Count == 1)
                {
                    if (appointmentFound(appointments[k], selectedAppointments[0]))
                    {
                        if (selectedAppointments[0].DurationInMins < appointment.DurationInMins) return;
                        appointment = setAppointment(appointment, selectedAppointments[0]);
                        appointments.RemoveAt(k);
                        appointments.Add(appointment);
                        appointmentRepository.SaveToFile(appointments);
                        PostponeAppointment(selectedAppointments[0]);
                        return;
                    }
                }
            }

            if (selectedAppointments.Count > 1)
            {
                if (!IsAppointmentLongEnough(selectedAppointments, appointment)) return;

                appointment = setAppointment(appointment, selectedAppointments[0]);
                removeSelectedOperation(selectedAppointments[0], appointments);
                appointments.Add(appointment);
                appointmentRepository.SaveToFile(appointments);
                PostponeAppointment(selectedAppointments[0]);

                for (int k = 1; k < selectedAppointments.Count; k++)
                {
                    removeSelectedOperation(selectedAppointments[k], appointments);
                    PostponeAppointment(selectedAppointments[k]);
                }
                return;
            }
            selectedAppointments[0].AppointmentType = AppointmentType.operation;
            appointments.Add(selectedAppointments[0]);
            appointmentRepository.SaveToFile(appointments);
        }

        private bool appointmentFound(Appointment appointment, Appointment oldAppointment)
        {
            if (appointment.StartTime.Equals(oldAppointment.StartTime) && appointment.Doctor.Id.Equals(oldAppointment.Doctor.Id))
            {
                return true;
            }
            else
            {
                return false;
            }
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

        public List<Appointment> GetUrgentOperationOptions(Appointment appointment, Specialization specialization1)
        {
            List<Appointment> options = new List<Appointment>();
            doctors = doctorRepository.loadFromFile("Doctors.json");
            rooms = roomRepository.GetRooms();
            scheduledAppointments = appointmentRepository.LoadFromFile();

            currentDate = DateTime.Now;
            appointmentOption = appointment;

            DateTime temp = new DateTime();

            foreach (Doctor doc in doctors)
            {
                if (doc.Specialization.Name.Equals(specialization1.Name))
                {
                    appointmentOption.Doctor = doc;

                    appointmentOption.Room = appointment.Room;

                    for (int i = 1; i <= 90; i++)
                    {
                        temp = currentDate.AddMinutes(i);
                        appointmentOption.StartTime = new DateTime(temp.Year, temp.Month, temp.Day, temp.Hour, temp.Minute, 0);
                        appointmentOption.EndTime = appointmentOption.StartTime.AddMinutes(appointmentOption.DurationInMins);
                        if (appointmentService.IsAvailable(appointmentOption))
                        {
                            options.Add(appointmentOption);
                            break;
                        }
                    }
                }
            }

            if (options.Count == 0)
            {
                MessageBox.Show("Nema slobodnih termina, morate da odložite");
                foreach (Appointment ap in scheduledAppointments)
                {
                    if (ap.Doctor.Specialization.Name.Equals(specialization1.Name) && ap.StartTime > currentDate)
                    {
                        ap.PostponedDate = SetPostponedDate(ap).PostponedDate;
                        options.Add(ap);
                    }
                }
                options = SortByPostponeDates(options);
            }

            return options;
        }


        public List<Appointment> GetUrgentExaminationOptions(Appointment appointment, Specialization specialization1)
        {
            List<Appointment> options = new List<Appointment>();
            doctors = doctorRepository.loadFromFile("Doctors.json");
            rooms = roomRepository.GetRooms();
            scheduledAppointments = appointmentRepository.LoadFromFile();

            currentDate = DateTime.Now;
            appointmentOption = appointment;

            DateTime temp1 = new DateTime();

            foreach (Doctor doc in doctors)
            {
                if (doc.Specialization.Name.Equals(specialization1.Name))
                {
                    appointmentOption.Doctor = doc;

                    appointmentOption.DurationInMins = 30;

                    appointmentOption.Room = findAttributesService.FindRoomById(doc.Ordination);
                    for (int i = 1; i <= 90; i++)
                    {
                        temp1 = currentDate.AddMinutes(i);
                        appointmentOption.StartTime = new DateTime(temp1.Year, temp1.Month, temp1.Day, temp1.Hour, temp1.Minute, 0);
                        appointmentOption.EndTime = appointmentOption.StartTime.AddMinutes(appointmentOption.DurationInMins);
                        if (appointmentService.IsAvailable(appointmentOption))
                        {
                            MessageBox.Show("PROSLO " + i.ToString());
                            options.Add(appointmentOption);
                            break;
                        }
                    }
                }
            }

            if (options.Count == 0)
            {
                MessageBox.Show("Nema slobodnih termina, morate da odložite");
                foreach (Appointment ap in scheduledAppointments)
                {
                    if (ap.Doctor.Specialization.Name.Equals(specialization1.Name) && ap.StartTime > currentDate)
                    {
                        ap.PostponedDate = SetPostponedDate(ap).PostponedDate;
                        options.Add(ap);

                    }
                }
                options = SortByPostponeDates(options);
            }

            return options;
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

                    if (ap.StartTime <= appointment.PostponedDate && appointment.PostponedDate < ap.EndTime)
                    {
                        return false;
                    }

                    if (ap.StartTime < endTimeNew && endTimeNew <= ap.EndTime)
                    {
                        return false;
                    }

                    if (ap.StartTime >= appointment.PostponedDate && ap.EndTime <= endTimeNew)
                    {
                        return false;
                    }
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
                    if (ap.StartTime <= appointment.PostponedDate && appointment.PostponedDate < ap.EndTime)
                    {
                        return false;
                    }

                    if (ap.StartTime < endTimeNew && endTimeNew <= ap.EndTime)
                    {
                        return false;
                    }

                    if (ap.StartTime >= appointment.PostponedDate && ap.EndTime <= endTimeNew)
                    {
                        return false;
                    }
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
                    if (ap.StartTime <= appointment.PostponedDate && appointment.PostponedDate < ap.EndTime)
                    {
                        return false;
                    }

                    if (ap.StartTime < dateTimeEnd && dateTimeEnd <= ap.EndTime)
                    {
                        return false;
                    }

                    if (ap.StartTime >= appointment.PostponedDate && ap.EndTime <= dateTimeEnd)
                    {
                        return false;
                    }

                }
            }
            return true;
        }

        public bool IsAvailablePostponed(Appointment appointment)
        {
            if (appointment.Patient != null)
            {
                if (isPatientFreePostponed(appointment) && isRoomFreePostponed(appointment) && isDoctorFreePostponed(appointment))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                if (isRoomFreePostponed(appointment) && isDoctorFreePostponed(appointment))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public Appointment SetPostponedDate(Appointment appointment)
        {
            List<Appointment> exams = new List<Appointment>();
            appointments = appointmentRepository.LoadFromFile();

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

        public List<Appointment> SortByPostponeDates(List<Appointment> appointments)
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

        public Appointment PostponeAppointment(Appointment appointment)
        {
            Appointment appoint = appointment;
            appointments = appointmentRepository.LoadFromFile();

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

        public bool IsAppointmentLongEnough(List<Appointment> selectedAppointments, Appointment urgentAppointment)
        {
            int duration = 0;
            foreach (Appointment o in selectedAppointments)
            {
                duration += o.DurationInMins;
            }

            if (duration < urgentAppointment.DurationInMins)
            {
                MessageBox.Show("Operacije koje ste izabrali nisu dovoljno dugačke, izaberite još!");
                return false;
            }
            else
            {
                return true;
            }
        }

    }
}
