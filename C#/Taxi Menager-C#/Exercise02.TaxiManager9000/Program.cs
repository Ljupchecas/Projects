using Exercise02.Domain;
using Exercise02.Domain.Enums;
using Exercise02.Domain.Models;
using System.Data;

List<User> users = new List<User> {
                new User(1, "admin", "admin123", Role.Administrator),
                new User(2, "manager", "manager123", Role.Manager),
                new User(3, "maintenance", "maintenance123", Role.Maintenance)
            };


while(true)
{
    #region LogIn

    Console.Clear();
    Console.WriteLine("Taxi Manager 9000");
    Console.WriteLine("Login:");
    bool isLoggedIn = false;
    while (!isLoggedIn)
    {
        Console.Write("Username: ");
        string username = Console.ReadLine();
        Console.Write("Password: ");
        string password = Console.ReadLine();

        User user = users.FirstOrDefault(u => u.Username == username && u.Password == password);

        if (user != null)
        {
            TextHelper.WriteInColor($"Successful Login! Welcome {user.Role} user!", ConsoleColor.Green);
            isLoggedIn = false;
        }
        else
        {
            TextHelper.WriteInColor("Login unsuccessful. Please try again", ConsoleColor.Red);
        }
    }
    #endregion
}




