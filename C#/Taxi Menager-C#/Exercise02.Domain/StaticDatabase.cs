using Exercise02.Domain.Enums;
using Exercise02.Domain.Models;

namespace Exercise02.Domain
{
    public static class StaticDatabase
    {
        static StaticDatabase()
        {
            SeedData();
            TextHelper.WriteInColor("Database initializet", ConsoleColor.Green);
            CurrentUserId = Users.Count;
        }

        private static int CurrentUserId { get; set; }
        public static List<User> Users { get; set; } = new List<User>();
        public static List<Driver> Drivers { get; set; } = new List<Driver>();
        public static List<Car> Cars { get; set; } = new List<Car>();
        public static void InsertUser(User user)
        {
            user.Id = ++CurrentUserId;
            Users.Add(user);
        }
        public static void TerminateUser(User user)
        {
            user.Id = --CurrentUserId;
            Users.Remove(user);
        }

        private static void SeedData()
        {
            Users = new List<User>()
            {
                new User(1, "Admin", "admin123", Role.Administrator),
                new User(2, "Manager", "manager123", Role.Manager),
                new User(3, "Maintenance", "maintenance123", Role.Maintenance)
            };
        }
                       
    }
}
