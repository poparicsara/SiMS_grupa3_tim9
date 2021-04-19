using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using System.Collections.ObjectModel;

namespace Model
{
    public class GuestUsersFileStorage
    {
        public void saveToFile(ObservableCollection<GuestUser> guestUsers, string fileName)
        {
            string jsonString = JsonConvert.SerializeObject(guestUsers, Formatting.Indented);
            File.WriteAllText(fileName, jsonString);
        }

        public ObservableCollection<GuestUser> loadFromFile(string fileName) 
        {
            var guestUsersList = new ObservableCollection<GuestUser>();

            using (StreamReader file = File.OpenText(fileName))
            {
                var serializer = new JsonSerializer();
                guestUsersList = (ObservableCollection<GuestUser>)serializer.Deserialize(file, typeof(ObservableCollection<GuestUser>));
            }

            return guestUsersList;
        }


    }
}
