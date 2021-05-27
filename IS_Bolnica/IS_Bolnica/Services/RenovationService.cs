using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IS_Bolnica.Model;
using Model;

namespace IS_Bolnica.Services
{
    class RenovationService
    {
        private RenovationRepository repository = new RenovationRepository();
        private List<Renovation> renovations = new List<Renovation>();
        public RenovationService()
        {
            renovations = repository.GetRenovations();
        }

        public void AddRenovation(Renovation renovation)
        {
            repository.AddRenovation(renovation);
            CheckScheduledAppointments(renovation);
        }

        public void CheckScheduledAppointments(Renovation renovation)
        {
            AppointmentService appointmentService = new AppointmentService();
            List<Appointment> appointments = appointmentService.GetAppointments();
            foreach (var a in appointments)
            {
                if (a.Room.Id == renovation.Room.Id)
                {
                    if (IsStartDateInRenovationPeriod(a, renovation) || IsEndDateInRenovationPeriod(a, renovation))
                    {
                        SendNotification(a);
                    }
                }
            }
        }

        private bool IsStartDateInRenovationPeriod(Appointment appointment, Renovation renovation)
        {
            return appointment.StartTime >= renovation.StartDate && appointment.StartTime <= renovation.EndDate;
        }

        private bool IsEndDateInRenovationPeriod(Appointment appointment, Renovation renovation)
        {
            return appointment.EndTime >= renovation.StartDate && appointment.EndTime <= renovation.EndDate;
        }

        private void SendNotification(Appointment appointment)
        {
            Notification notification = new Notification();
            SetNotificationAttributes(appointment, notification);
            NotificationService notificationService = new NotificationService();
            notificationService.AddNotification(notification);
        }

        private void SetNotificationAttributes(Appointment appointment, Notification notification)
        {
            notification.Title = "Pomeranje termina zbog renoviranja";
            SetNotificationContent(appointment, notification);
            notification.notificationType = NotificationType.secretory;
            notification.Sender = UserType.director;
        }

        private void SetNotificationContent(Appointment appointment, Notification notification)
        {
            notification.Content += "Potrebna je izmena termina: " + "\n";
            notification.Content += "\t" + "Tip termina: " + appointment.AppointmentType + "\n";
            notification.Content += "\t" + "Datum termina: " + appointment.StartTime + "\n";
            notification.Content = "\t" + "Prostorija: " + appointment.Room.Id + "\n";
            notification.Content += "\t" + "Pacijent: " + appointment.Patient.Name + " " + appointment.Patient.Surname + "\n";
            notification.Content += "\t" + "Doktor: " + appointment.Doctor.Name + " " + appointment.Patient.Surname + "\n";
        }

        public List<Renovation> GetRenovations()
        {
            return repository.GetRenovations();
        }
    }
}
