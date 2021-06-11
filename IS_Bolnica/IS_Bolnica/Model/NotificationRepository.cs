using Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IS_Bolnica.IRepository;

namespace IS_Bolnica.Model
{
    public class NotificationRepository : INotificationRepository
    {
        private string fileName = "NotificationsFileStorage.json";
        private List<Notification> notifications = new List<Notification>();

        public Notification FindById(int id)
        {
            throw new NotImplementedException();
        }

        public void SaveToFile(List<Notification> notifications)
        {
            string jsonString = JsonConvert.SerializeObject(notifications, Formatting.Indented);
            File.WriteAllText(fileName, jsonString);
        }

        public void Add(Notification newEntity)
        {
            notifications = GetAll();
            notifications.Add(newEntity);
            SaveToFile(notifications);
        }

        public void Update(int index, Notification newEntity)
        {
            notifications = GetAll();
            notifications.RemoveAt(index);
            notifications.Add(newEntity);
            SaveToFile(notifications);
        }

        public void Delete(int index)
        {
            notifications = GetAll();
            notifications.RemoveAt(index);
            SaveToFile(notifications);
        }

        public List<Notification> GetAll()
        {
            var notifications = new List<Notification>();

            using (StreamReader file = File.OpenText(fileName))
            {
                var serializer = new JsonSerializer();
                notifications = (List<Notification>)serializer.Deserialize(file, typeof(List<Notification>));
            }

            return notifications;
        }
    }
}
