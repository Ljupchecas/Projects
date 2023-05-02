using Exercise02.Domain.Enums;
using System.ComponentModel;
namespace Exercise02.Domain.Models
{
    public class Driver
    {
        private static int _driverCounter = 1;

        public Driver(string name, string lastName, Shift shift,string license, DateOnly licenseExpiryDate)
        {
            Id = _driverCounter;
            Name = name;
            LastName = lastName;
            Shift = shift;
            Car = null;
            License = license;
            LicenseExpiryDate = licenseExpiryDate;

            _driverCounter++;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public Shift Shift { get; set; }
        public Car Car { get; set; }
        public string License { get; set; }
        public DateOnly LicenseExpiryDate { get; set; }
    }
}
