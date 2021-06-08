using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace IS_Bolnica.Services
{
    public class GuestUserService
    {
        private List<GuestUser> guestUsers = new List<GuestUser>();
        private GuestUserRepository guestUserRepository = new GuestUserRepository();

        public GuestUserService()
        {
            guestUsers = GetGuestUsers();
        }

        public void AddGuestUser(GuestUser guestUser)
        {
            guestUsers.Add(guestUser);
            guestUserRepository.SaveToFile(guestUsers,"GuestUsersFile.json");
        }

        public void EditGuestUser(GuestUser oldGuestUser, GuestUser newGuestUser)
        {
            int index = FindGuestUserIndex(oldGuestUser);
            guestUsers.RemoveAt(index);
            guestUsers.Add(newGuestUser);
            guestUserRepository.SaveToFile(guestUsers, "GuestUsersFile.json");
        }

        public void DeleteGuestUser(GuestUser guestUser)
        {
            int index = FindGuestUserIndex(guestUser);
            guestUsers.RemoveAt(index);
            guestUserRepository.SaveToFile(guestUsers, "GuestUsersFile.json");
        }

        public List<GuestUser> GetGuestUsers()
        {
            return guestUserRepository.LoadFromFile("GuestUsersFile.json");
        }

        private int FindGuestUserIndex(GuestUser guestUser)
        {
            for (int i = 0; i < guestUsers.Count; i++)
            {
                if (guestUser.SystemName.Equals(guestUsers[i].SystemName) &&
                    guestUser.InjuryDescription.Equals(guestUsers[i].InjuryDescription))
                {
                    return i;
                }
            }

            return -1;
        }

        public List<GuestUser> GetSearchedGuests(string text)
        {
            guestUsers = guestUserRepository.LoadFromFile("GuestUsersFile.json");
            List<GuestUser> searchedGuest = new List<GuestUser>();
            foreach (GuestUser guestUser in guestUsers)
            {
                if (ISearched(text, guestUser))
                {
                    searchedGuest.Add(guestUser);
                }
            }

            return searchedGuest;
        }

        private static bool ISearched(string text, GuestUser g)
        {
            return g.SystemName.ToLower().StartsWith(text) ||
                   g.InjuryDescription.ToLower().StartsWith(text);
        }
    }
}
