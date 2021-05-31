
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IS_Bolnica.Model;
using Model;

namespace IS_Bolnica.Services
{
    class NotificationService
    {
        private NotificationRepository notificationRepository = new NotificationRepository();
        private List<Notification> notifications = new List<Notification>();

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

    }

}
