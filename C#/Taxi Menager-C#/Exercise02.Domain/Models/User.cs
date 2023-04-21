using Exercise02.Domain.Enums;

namespace Exercise02.Domain.Models
{
    public class User
    {
        public User() { }

        public User(int id, string username, string password, Role role)
        {
            Id = id;
            Username = username;
            Password = password;
            Role = role;
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }
    }
}
