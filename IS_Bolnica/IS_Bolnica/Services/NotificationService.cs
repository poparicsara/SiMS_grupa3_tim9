
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
    class NotificationService
    {
        private NotificationRepository notificationRepository = new NotificationRepository();
        private List<Notification> notifications = new List<Notification>();
        private EvaluationRepository evaluationRepository = new EvaluationRepository();
        public NotificationService()
        {
            notifications = getNotifications();
        }

        public void AddNotification(Notification notification)
        {
            notificationRepository.Add(notification);
        }

        public void EditNotification(Notification oldNotification, Notification newNotification)
        {
            int index = FindNotificationIndex(oldNotification);
            notificationRepository.Update(index, newNotification);
        }

        public void DeleteNotification(Notification notification)
        {
            int index = FindNotificationIndex(notification);
            notificationRepository.Delete(index);
        }

        public List<Notification> getNotifications()
        {
            return notificationRepository.GetAll();
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

        public bool ExistsInList(List<string> idList, string id)
        {
            foreach (string i in idList)
            {
                if (i.Equals(id))
                {
                    return true;
                }
            }
            return false;
        }

        public bool IsBoxEmpty(string id)
        {
            if (id.Equals(""))
            {
                return true;
            }
            return false;
        }

        public List<Notification> GetSearchedNotifications(string text)
        {
            notifications = notificationRepository.GetAll();
            List<Notification> searchedNotifications = new List<Notification>();
            foreach (Notification notification in notifications)
            {
                if (ISearched(text, notification))
                {
                    searchedNotifications.Add(notification);
                }
            }

            return searchedNotifications;
        }

        private static bool ISearched(string text, Notification n)
        {
            return n.Title.ToLower().Contains(text) ||
                   n.Content.ToLower().Contains(text) ||
                   n.notificationType.ToString().ToLower().StartsWith(text) ;
        }

        public List<Notification> getPatientNotifications()
        {
            List<Notification> patientNotifications = new List<Notification>();

            foreach (Notification notification in notifications)
            {
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

        public int notificationByThreeDose(Prescription prescription)
        {
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

        private Evaluation findLastPatientNote()
        {
            List<Evaluation> evaluations = evaluationRepository.loadFromFile();
            List<Evaluation> patientEvaluations = new List<Evaluation>();

            foreach (Evaluation evaluation in evaluations)
            {
                if (evaluation.Patient.Username.Equals(PatientWindow.loggedPatient.Username))
                    patientEvaluations.Add(evaluation);
            }
            if (patientEvaluations.Count != 0)
                return patientEvaluations[patientEvaluations.Count - 1];
            return null;
        }

    }

}
