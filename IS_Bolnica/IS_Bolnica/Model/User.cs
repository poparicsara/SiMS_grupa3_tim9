using System;

namespace Model
{
    public class User
    {
        private String username;
        private String password;
        public String name { get; set; }
        public String surname { get; set; }
        private DateTime dateOfBirth;
        private int phone;
        private int id;
        private String email;

        public void UpdateUser(String username, String password, String name, String surname, DateTime dateOfBirth, int phone, String email)
        {
            throw new NotImplementedException();
        }

        public Address address;

        public String Name
        {
            get;
            set;
        }
        public string Surname
        {
            get;
            set;
        }

    }
}