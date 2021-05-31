
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
        EvaluationFileStorage evaluationRepository = new EvaluationFileStorage();

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

        public void sendNotifications(List<Prescription> patientPrescriptions)
        {
            Evaluation lastPatientNote = findLastPatientNote();
            foreach (Prescription prescription in patientPrescriptions)
            {
                if (prescription.Therapy.Dose == 1)
                {
                    notificationByOneDose(prescription);
                }
                else if (prescription.Therapy.Dose == 2)
                {
                    notificationByTwoDose(prescription);
                }
                else if (prescription.Therapy.Dose == 3)
                {
                    notificationByThreeDose(prescription);
                }

            }
        }

        private void notificationByOneDose(Prescription prescription)
        {
            Evaluation lastPatientNote = findLastPatientNote();
            string[] pom = DateTime.Now.ToString().Split(' ');
            string[] time = pom[1].Split(':');
            int hours = returnHours();

            if (hours == 14 && (Convert.ToInt32(time[1]) + lastPatientNote.numOfMinutes) >= 57 && (Convert.ToInt32(time[1]) + lastPatientNote.numOfMinutes) <= 59)
                MessageBox.Show("U 15:00 treba da popijete lek: " + prescription.Therapy.MedicationName, "Podsetnik");
            
        }

        private void notificationByTwoDose(Prescription prescription)
        {
            Evaluation lastPatientNote = findLastPatientNote();
            string[] pom = DateTime.Now.ToString().Split(' ');
            string[] time = pom[1].Split(':');
            int hours = returnHours();

            if (hours == 7 && (Convert.ToInt32(time[1]) + lastPatientNote.numOfMinutes) >= 57 && (Convert.ToInt32(time[1]) + lastPatientNote.numOfMinutes) <= 59)
                MessageBox.Show("U 08:00 treba da popijete lek: " + prescription.Therapy.MedicationName, "Podsetnik");
            else if (hours == 14 && (Convert.ToInt32(time[1]) + lastPatientNote.numOfMinutes) >= 57 && (Convert.ToInt32(time[1]) + lastPatientNote.numOfMinutes) <= 59)
                MessageBox.Show("U 20:00 treba da popijete lek: " + prescription.Therapy.MedicationName, "Podsetnik");
 
        }

        private void notificationByThreeDose(Prescription prescription) {
            Evaluation lastPatientNote = findLastPatientNote();
            string[] pom = DateTime.Now.ToString().Split(' ');
            string[] time = pom[1].Split(':');
            int hours = returnHours();

            if (hours == 6 && (Convert.ToInt32(time[1]) + lastPatientNote.numOfMinutes) >= 57 && (Convert.ToInt32(time[1]) + lastPatientNote.numOfMinutes) <= 59)
                MessageBox.Show("U 07:00 treba da popijete lek: " + prescription.Therapy.MedicationName, "Podsetnik");
            else if (hours == 14 && (Convert.ToInt32(time[1]) + lastPatientNote.numOfMinutes) >= 57 && (Convert.ToInt32(time[1]) + lastPatientNote.numOfMinutes) <= 59)
                MessageBox.Show("U 15:00 treba da popijete lek: " + prescription.Therapy.MedicationName, "Podsetnik");
            else if (hours == 22 && (Convert.ToInt32(time[1]) + lastPatientNote.numOfMinutes) >= 57 && (Convert.ToInt32(time[1]) + lastPatientNote.numOfMinutes) <= 59)
                MessageBox.Show("U 23:00 treba da popijete lek: " + prescription.Therapy.MedicationName, "Podsetnik");

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

            return patientEvaluations[patientEvaluations.Count - 1];
        }
    }

}
