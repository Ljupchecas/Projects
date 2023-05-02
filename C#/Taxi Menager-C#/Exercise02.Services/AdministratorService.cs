using Exercise02.Domain;
using Exercise02.Domain.Enums;
using Exercise02.Domain.Models;
using System.Security.Cryptography.X509Certificates;

namespace Exercise02.Services
{
    public static class AdministratorService
    {
        public static void InsertUser(User user)
        {
            StaticDatabase.Users.Add(user);
        }
        public static void TerminateUser(User user)
        {
            StaticDatabase.Users.Remove(user);
        }

        public static void Menu()
        {
            Console.WriteLine("1) New User");
            Console.WriteLine("2) Terminate User");
            Console.WriteLine("3) Change Password");
            Console.WriteLine("4) Exit");
        }
        
        public static bool Choice(User user)
        {
            int choice = TextHelper.ValidateNumber(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    {
                        Console.Clear();
                        Console.WriteLine("Add new user:");

                        User newUser = new User();

                        Console.Write("Enter Username >");
                        newUser.Username = Console.ReadLine();

                        Console.Write("Enter Password >");
                        newUser.Password = Console.ReadLine();

                        Console.WriteLine("Choose Role:");
                        Console.WriteLine("1) Administrator");
                        Console.WriteLine("2) Manager");
                        Console.WriteLine("3) Maintenance");

                        int choiceRole = TextHelper.ValidateNumber(Console.ReadLine());

                        newUser.Role = (Role)choiceRole;

                        if (newUser.Username.Length < 5 || newUser.Password.Length < 5 || !newUser.Password.Any(char.IsDigit))
                        {
                            TextHelper.WriteInColor("Creation unsuccessful. Please try again", ConsoleColor.Red);
                        }
                        else
                        {
                            InsertUser(newUser);
                            TextHelper.WriteInColor("Added new user", ConsoleColor.Green);
                        }


                        Console.WriteLine("Press any key to back to main manu");
                        Console.ReadKey();
                        break;
                    }

                case 2:
                    {
                        Console.Clear();
                        Console.WriteLine("Remove user:");

                        Console.WriteLine("Choose user from the list:");

                        foreach (User user in StaticDatabase.Users)
                        {
                            Console.WriteLine($"{StaticDatabase.Users.IndexOf(user) + 1}) {user.Username} ({user.Role})");
                        }

                        int userToRemove = TextHelper.ValidateNumber(Console.ReadLine());

                        TerminateUser(StaticDatabase.Users[userToRemove - 1]);

                        TextHelper.WriteInColor("User removed", ConsoleColor.Green);
                        Console.WriteLine("Press any key to back to main manu");
                        Console.ReadKey();
                        break;
                    }

                case 3:
                    {
                        UserService.ChangePassword(user);

                        break;
                    }
                    
                case 4:
                    Console.Clear();
                    return false;
            }
            return true;
        }


    }
}
