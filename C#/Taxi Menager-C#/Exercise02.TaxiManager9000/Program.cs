using Exercise02.Domain;
using Exercise02.Domain.Enums;
using Exercise02.Domain.Models;
using Exercise02.Services;
using System.Data;
using System.Xml.Serialization;

User currentUser = null;

while (true)
{
    #region LogIn

    //Console.Clear();
    TextHelper.WriteInColor("Taxi Manager 9000", ConsoleColor.Yellow);
    Console.WriteLine();
    Console.WriteLine("Login:");
    Console.WriteLine();

    bool isLoggedIn = true;
    while (isLoggedIn)
    {
        Console.Write("Username: ");
        string username = Console.ReadLine();
        Console.Write("Password: ");
        string password = Console.ReadLine();

        currentUser = StaticDatabase.Users.FirstOrDefault(u => u.Username == username && u.Password == password);

        if (currentUser != null)
        {
            TextHelper.WriteInColor($"Successful Login! Welcome {currentUser.Role} user!", ConsoleColor.Green);
            isLoggedIn = false;
        }
        else
        {
            Console.Clear();
            TextHelper.WriteInColor("The user does not exist! Please try again", ConsoleColor.Red);
        }
    }
    #endregion

    #region Main Manu
    bool exitToLogIn = false;

    while (!exitToLogIn)
    {
        Console.Clear();

        Console.WriteLine("Main manu");
        Console.WriteLine();
        Console.WriteLine($"Welcome {currentUser.Username}");

        switch (currentUser.Role)
        {
            case Role.Administrator:

                AdministratorService.Menu();

                exitToLogIn = !AdministratorService.Choice(currentUser);


                break;
            case Role.Manager:

                ManagerService.Menu();


                break;
            case Role.Maintenance:

                MaintenanceService.Menu();

                break;
            default:
                break;
        }
    }
   




   
    #endregion
}
