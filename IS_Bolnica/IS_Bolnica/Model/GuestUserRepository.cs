using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using System.Collections.ObjectModel;
using IS_Bolnica.IRepository;

namespace Model
{
    public class GuestUserRepository: IGuestUserRepository
    {
        private string fileName = "GuestUsersFile.json";

        private List<GuestUser> guestUsers = new List<GuestUser>();

        public List<GuestUser> GetAll()
        {
            var guestUsersList = new List<GuestUser>();

            using (StreamReader file = File.OpenText(fileName))
            {
                var serializer = new JsonSerializer();
                guestUsersList = (List<GuestUser>)serializer.Deserialize(file, typeof(List<GuestUser>));
            }

            return guestUsersList;
        }

        public GuestUser FindById(string systemName)
        {
            guestUsers = GetAll();
            for (int i = 0; i < guestUsers.Count; i++)
            {
                if (systemName.Equals(guestUsers[i].SystemName))
                {
                    return guestUsers[i];
                }
            }

            return null;
        }

        public void SaveToFile(List<GuestUser> entities)
        {
            string jsonString = JsonConvert.SerializeObject(entities, Formatting.Indented);
            File.WriteAllText(fileName, jsonString);
        }

        public void Add(GuestUser newEntity)
        {
            guestUsers = GetAll();
            guestUsers.Add(newEntity);
            SaveToFile(guestUsers);
        }

        public void Update(int index, GuestUser newEntity)
        {
            guestUsers = GetAll();
            guestUsers.RemoveAt(index);
            guestUsers.Add(newEntity);
            SaveToFile(guestUsers);
        }

        public void Delete(int index)
        {
            guestUsers = GetAll();
            guestUsers.RemoveAt(index);
            SaveToFile(guestUsers);
        }
    }
}
