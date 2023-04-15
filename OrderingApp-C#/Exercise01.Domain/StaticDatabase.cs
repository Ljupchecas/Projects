using Exercise01.Domain.Enums;
using Exercise01.Domain.Models;

namespace Exercise01.Domain
{
    public static class StaticDatabase
    {
        static StaticDatabase()
        {
            SeedData();
            TextHelper.WriteLineInColor("DataBase initialized...", ConsoleColor.Green);
            CurrentOrderId = Orders.Count;
        }

        private static int CurrentOrderId { get; set; }
        public static List<User> Users { get; set; } = new List<User>();
        public static List<Order> Orders { get; set; } = new List<Order>();

        public static void InsertOrder(User userMakingTheOrder, Order order)
        {
            order.Id = ++CurrentOrderId;
            Orders.Add(order);
            userMakingTheOrder.Orders.Add(order);

            TextHelper.WriteLineInColor("Order successfully added!", ConsoleColor.Green);
            TextHelper.WriteLineInColor("Press any key to exit.", ConsoleColor.White);
        }

        public static void ListUsers()
        {
            Users.ForEach(user => Console.WriteLine($"{user.Id}) {user.Username}"));
        }

        private static void SeedData()
        {
            Users = new List<User>()
            {
                new User("Bob123", "Bob St. 100"),
                new User("John321", "John St. 150")
            };

            Orders = new List<Order>()
            {
                new Order(1, "book of books", "Best book ever", OrderStatus.Deliverd),
                new Order(2, "keyboard", "Mechanical", OrderStatus.DeliveryInProgress),
                new Order(3, "Shoes", "Waterproof", OrderStatus.DeliveryInProgress),
                new Order(4, "Set of Pens", "Ordinary pens", OrderStatus.Processing),
                new Order(5, "sticky Notes", "Stickiest notes in the world", OrderStatus.CouldNotDeliver)
            };

            Users[0].Orders.AddRange(Orders.Take(3));
            Users[1].Orders.AddRange(Orders.TakeLast(2));

        }
    }
}
