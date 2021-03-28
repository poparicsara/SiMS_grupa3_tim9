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

        public void UpdateUser(String username, String password, String name, String surname, DateTime dateOfBirth, int phone, String email)
        {
            throw new NotImplementedException();
        }

        public Address address;

    }
}