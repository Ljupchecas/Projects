using Exercise02.Domain;
using Exercise02.Domain.Models;

namespace Exercise02.Services
{
    public static class UserService
    {
        public static void ChangePassword(User user)
        {
            Console.Clear();

            Console.Write("Before change :");
            StaticDatabase.Users.ForEach(u => Console.WriteLine($"{u.Username} - {u.Password}"));

            Console.WriteLine("Change Password:");
            Console.WriteLine();
            Console.Write("Old Password: ");
            string oldPassword = Console.ReadLine();
            Console.Write("New Password: ");
            string newPassword = Console.ReadLine();


            if (user.Password != oldPassword)
            {
                Console.WriteLine("You entered an incorrect password");
            }
            else
            {
                user.Password = newPassword;
            }

            Console.Write("After change :");
            StaticDatabase.Users.ForEach(u => Console.WriteLine($"{u.Username} - {u.Password}"));

        }
    }
}


