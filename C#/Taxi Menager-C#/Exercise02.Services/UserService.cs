using Exercise02.Domain.Models;

namespace Exercise02.Services
{
    public class UserService
    {
        public static void ChangePassword()
        {
            Console.Clear();
            Console.WriteLine("Change Password:");
            Console.WriteLine();
            Console.Write("Old Password: ");
            string oldPassword = Console.ReadLine();

            //if(currentUser.Password != oldPassword) // Kako da dojdam do currentUser od Program.cs? Kako da ja nparavam ovaa logika, i posle samo UserService.ChangePassword() da go stavam vo AdminService i drugite 2.
            //{
            //    // logika
            //}
            //else
            //{
            //    // logika
            //}

        }
    }
}
