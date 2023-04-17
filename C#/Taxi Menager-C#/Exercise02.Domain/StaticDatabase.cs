using Exercise02.Domain.Models;

namespace Exercise02.Domain
{
    public static class StaticDatabase
    {
        static StaticDatabase()
        {
            TextHelper.WriteInColor("Database initializet", ConsoleColor.Green);
        }

        //public static List<User> users { get; set; } new List<User>
    }
}
