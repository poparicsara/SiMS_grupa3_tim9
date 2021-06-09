
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using IS_Bolnica.Model;
using IS_Bolnica.PatientPages;
using Model;

namespace IS_Bolnica.Services
{
    class NotificationService
    {
        private NotificationRepository notificationRepository = new NotificationRepository();
        private List<Notification> notifications = new List<Notification>();
        EvaluationRepository evaluationRepository = new EvaluationRepository();

        public NotificationService()
        {
            notifications = getNotifications();
        }

        public void AddNotification(Notification notification)
        {
            notifications.Add(notification);
            notificationRepository.SaveToFile(notifications, "NotificationsFileStorage.json");
        }

        public void EditNotification(Notification oldNotification, Notification newNotification)
        {
            int index = FindNotificationIndex(oldNotification);
            notifications.RemoveAt(index);
            notifications.Add(newNotification);
            notificationRepository.SaveToFile(notifications, "NotificationsFileStorage.json");
        }

        public void DeleteNotification(Notification notification)
        {
            for (int i = 0; i < notifications.Count; i++)
            {
                if (notification.Content.Equals(notifications[i].Content)
                    && notification.Title.Equals(notifications[i].Title)
                    && notification.notificationType.Equals(notifications[i].notificationType))
                {
                    notifications.RemoveAt(i);
                }
            }
            notificationRepository.SaveToFile(notifications, "NotificationsFileStorage.json");
        }

        public List<Notification> getNotifications()
        {
            return notificationRepository.LoadFromFile("NotificationsFileStorage.json");
        }

        public List<Notification> getPatientNotifications() {
            List<Notification> patientNotifications = new List<Notification>();

            foreach (Notification notification in notifications) {
                if (notification.notificationType == NotificationType.patient)
                    patientNotifications.Add(notification);

                if (notification.notificationType == NotificationType.all)
                    patientNotifications.Add(notification);

                if (notification.PersonId != null && notification.notificationType == NotificationType.specific)
                {
                    foreach (string id in notification.PersonId)
                    {
                        if (id.Equals(PatientWindow.loggedPatient.Id))
                            patientNotifications.Add(notification);
                    }
                }
            }

            return patientNotifications;
        }

        private int FindNotificationIndex(Notification notification)
        {
            for (int i = 0; i < notifications.Count; i++)
            {
                if (notifications[i].Content.Equals(notification.Content) &&
                    notifications[i].Title.Equals(notification.Title) &&
                    notifications[i].notificationType.Equals(notification.notificationType))
                {
                    return i;
                }
            }

            return -1;
        }

        public int notificationByOneDose(Prescription prescription)
        {
            Evaluation lastPatientNote = findLastPatientNote();
            string[] pom = DateTime.Now.ToString().Split(' ');
            string[] time = pom[1].Split(':');
            int hours = returnHours();

            if (hours == 14 && (Convert.ToInt32(time[1]) + lastPatientNote.numOfMinutes) >= 57 && (Convert.ToInt32(time[1]) + lastPatientNote.numOfMinutes) <= 59)
                return 1;

            return 0;
        }

        public int notificationByTwoDose(Prescription prescription)
        {
            Evaluation lastPatientNote = findLastPatientNote();
            string[] pom = DateTime.Now.ToString().Split(' ');
            string[] time = pom[1].Split(':');
            int hours = returnHours();

            if (hours == 7 && (Convert.ToInt32(time[1]) + lastPatientNote.numOfMinutes) >= 57 && (Convert.ToInt32(time[1]) + lastPatientNote.numOfMinutes) <= 59)
                return 1;
            else if (hours == 14 && (Convert.ToInt32(time[1]) + lastPatientNote.numOfMinutes) >= 57 && (Convert.ToInt32(time[1]) + lastPatientNote.numOfMinutes) <= 59)
                return 2;

            return 0;
        }

        public int notificationByThreeDose(Prescription prescription) {
            Evaluation lastPatientNote = findLastPatientNote();
            string[] pom = DateTime.Now.ToString().Split(' ');
            string[] time = pom[1].Split(':');
            int hours = returnHours();

            if (hours == 6 && (Convert.ToInt32(time[1]) + lastPatientNote.numOfMinutes) >= 57 && (Convert.ToInt32(time[1]) + lastPatientNote.numOfMinutes) <= 59)
                return 1;
            else if (hours == 14 && (Convert.ToInt32(time[1]) + lastPatientNote.numOfMinutes) >= 57 && (Convert.ToInt32(time[1]) + lastPatientNote.numOfMinutes) <= 59)
                return 2;
            else if (hours == 22 && (Convert.ToInt32(time[1]) + lastPatientNote.numOfMinutes) >= 57 && (Convert.ToInt32(time[1]) + lastPatientNote.numOfMinutes) <= 59)
                return 3;

            return 0;
        }

        private int returnHours()
        {
            string[] pom = DateTime.Now.ToString().Split(' ');
            string[] time = pom[1].Split(':');
            int hours = 0;

            if (pom[2].Equals("PM"))
                hours = Convert.ToInt32(time[0]) + 12;
            else
                hours = Convert.ToInt32(time[0]);

            return hours;
        }

        private Evaluation findLastPatientNote() {
            List<Evaluation> evaluations = evaluationRepository.loadFromFile("Ocene.json");
            List<Evaluation> patientEvaluations = new List<Evaluation>();

            foreach (Evaluation evaluation in evaluations) {
                if (evaluation.Patient.Username.Equals(PatientWindow.username_patient))
                    patientEvaluations.Add(evaluation);
            }
            if(patientEvaluations.Count != 0)
                return patientEvaluations[patientEvaluations.Count - 1];
            return null;
        }

        public Boolean checkNotificationText(String text)
        {
            if (!text.Equals(""))
                return true;

            return false;
        }
    }

}
