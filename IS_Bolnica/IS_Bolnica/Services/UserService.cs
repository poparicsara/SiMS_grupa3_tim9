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

        public User GetLoggedUser()
        {
            User loggedUser = new User();
            foreach (User user in loggedUsers)
            {
                loggedUser = user;
            }
            return loggedUser;
        }

        public void AddUser(User user)
        {
            userRepository.Add(user);
        }

        public void DeleteUser(User user)
        {
            int index = FindUserIndex(user);
            userRepository.Delete(index);
        }

        public void EditUser(User oldUser, User newUser)
        {
            int index = FindUserIndex(oldUser);
            userRepository.Update(index, newUser);
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
            users = GetUsers();
            for (int i = 0; i < users.Count; i++)
            {
                if (user.Id.Equals(users[i].Id))
                {
                    return i;
                }
            }

            return -1;
        }

        public bool UserExists(string id)
        {
            users = GetUsers();
            foreach (var u in users)
            {
                if (u.Id.Equals(id))
                {
                    return true;
                }
            }

            return false;
        }

        private List<User> GetUsers()
        {
            return userRepository.GetAll();
        }

        public List<User> GetLoggedUsers()
        {
            return userRepository.LoadFromFile("loggedUsers.json");
        }

        public void LogOut()
        {
            for (int i = 0; i < loggedUsers.Count; i++)
            {
                loggedUsers.RemoveAt(i);
            }
            userRepository.SaveToFile(loggedUsers);
        }

    }
}
