using Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IS_Bolnica.Model
{
    public class NotificationRepository
    {
        public List<Notification> GetAll()
        {
            throw new NotImplementedException();
        }

        public void SaveToFile(List<Notification> notifications, string fileName)
        {
            string jsonString = JsonConvert.SerializeObject(notifications, Formatting.Indented);
            File.WriteAllText(fileName, jsonString);
        }

        public List<Notification> LoadFromFile(string fileName)
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
