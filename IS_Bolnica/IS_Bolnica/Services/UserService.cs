using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IS_Bolnica.Model;
using Model;

namespace IS_Bolnica.Services
{
    public class UserService
    {
        private List<User> users = new List<User>();
        private List<User> loggedUsers = new List<User>();
        private UserRepository userRepository = new UserRepository();

        public UserService()
        {
            users = GetUsers();
            loggedUsers = GetLoggedUsers();
        }

        public void AddUser(User user)
        {
            if (IsValid(user))
            {
                users.Add(user);
                userRepository.SaveToFile(users, "UsersFileStorage.json");
            }
        }

        public void DeleteUser(User user)
        {
            if (UserExists(user))
            {
                int index = FindUserIndex(user);
                users.RemoveAt(index);
                userRepository.SaveToFile(users, "UsersFileStorage.json");
            }
        }

        public void EditUser(User oldUser, User newUser)
        {
            if (IsValid(newUser))
            {
                int index = FindUserIndex(oldUser);
                users.RemoveAt(index);
                users.Add(newUser);
                userRepository.SaveToFile(users, "UsersFileStorage.json");
            }
        }

        private bool IsValid(User user)
        {
            return true;
        }

        private bool isUsernameValid(User user)
        {
            return false;

        }

        private bool isPasswordValid(User user)
        {
            return false;

        }

        private int FindUserIndex(User user)
        {
            for(int i = 0; i < users.Count; i++)
            {
                if (user.Id.Equals(users[i].Id))
                {
                    return i;
                }
            }

            return -1;
        }

        private bool UserExists(User user)
        {
            foreach (var u in users)
            {
                if (u.Id.Equals(user.Id))
                {
                    return true;
                }
            }

            return false;
        }

        private List<User> GetUsers()
        {
            return userRepository.LoadFromFile("UsersFileStorage.json");
        }

        public List<User> GetLoggedUsers()
        {
            return userRepository.LoadFromFile("loggedUsers.json");
        }

        public void logOut()
        {
            for (int i = 0; i < loggedUsers.Count; i++)
            {
                loggedUsers.RemoveAt(i);
            }
            userRepository.SaveToFile(loggedUsers, "loggedUsers.json");
        }
    }
}
