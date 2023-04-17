using Exercise02.Domain.Enums;
using System.ComponentModel;
namespace Exercise02.Domain.Models
{
    public class Driver
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public Shift Shift { get; set; }
        public Car Car { get; set; }
        public string License { get; set; }
        public DateTime LicenseExpiryDate { get; set; }
    }
}
