using Exercise02.Domain.Enums;

namespace Exercise02.Domain.Models
{
    public class User
    {
        public User() { }

        private static int _userCounter = 1;

        public User(string username, string password, Role role)
        {
            Id = _userCounter;
            Username = username;
            Password = password;
            Role = role;

            _userCounter++;
        }

        private int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }
    }
}
