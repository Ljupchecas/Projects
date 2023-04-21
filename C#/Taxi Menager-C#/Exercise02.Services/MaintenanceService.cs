using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise02.Services
{
    public static class MaintenanceService
    {
        public static void Menu()
        {
            Console.WriteLine("1) List Vehicles");
            Console.WriteLine("2) List Vehicles Licence Plates (Statuses");
            Console.WriteLine("3) Change Password");
            Console.WriteLine("4) Exit");
        }
    }
}
