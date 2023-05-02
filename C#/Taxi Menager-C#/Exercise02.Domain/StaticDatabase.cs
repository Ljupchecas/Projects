using Exercise02.Domain.Enums;
using Exercise02.Domain.Models;
using System.Data;

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

        private static void SeedData()
        {
            Users = new List<User>()
            {
                new User("Admin", "admin123", Role.Administrator),
                new User("Manager", "manager123", Role.Manager),
                new User("Maintenance", "maintenance123", Role.Maintenance)
            };

            Drivers = new List<Driver>()
            {
                new Driver("Ljubomir", "Joldashev", Shift.Morning, "Yes", new DateOnly(2023,09,23));
            }
        }
    }
}
