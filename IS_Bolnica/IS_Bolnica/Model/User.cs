using System;

namespace Model
{
    public class User
    {
        public String Username { get; set; }
        public String Password { get; set; }
        public String Name { get; set; }
        public String Surname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Phone { get; set; }
        public String Email { get; set; }
        public int Id { get; set; }
        public UserType UserType { get; set; }

        public Address address;

    }
}