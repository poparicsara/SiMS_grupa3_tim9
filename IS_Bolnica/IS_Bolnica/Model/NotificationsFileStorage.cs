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
    public class NotificationsFileStorage
    {
        public ObservableCollection<Notification> GetAll()
        {
            throw new NotImplementedException();
        }

        public void SaveToFile(ObservableCollection<Notification> notifications, string fileName)
        {
            string jsonString = JsonConvert.SerializeObject(notifications, Formatting.Indented);
            File.WriteAllText(fileName, jsonString);
        }

        public ObservableCollection<Notification> LoadFromFile(string fileName)
        {
            var notifications = new ObservableCollection<Notification>();

            using (StreamReader file = File.OpenText(fileName))
            {
                var serializer = new JsonSerializer();
                notifications = (ObservableCollection<Notification>)serializer.Deserialize(file, typeof(ObservableCollection<Notification>));
            }

            return notifications;
        }
    }
}
