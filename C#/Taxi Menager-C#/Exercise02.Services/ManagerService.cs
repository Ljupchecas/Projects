using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise02.Services
{
    public static class ManagerService
    {
        public static void Menu()
        {
            Console.WriteLine("1) List Drivers");
            Console.WriteLine("2) List Driver Licenses");
            Console.WriteLine("3) Driver Manager");
            Console.WriteLine("4) Change Password");
            Console.WriteLine("5) Exit");
        }
    }
}
