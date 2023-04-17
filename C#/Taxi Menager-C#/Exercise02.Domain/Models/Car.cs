namespace Exercise02.Domain.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public int LicensePlate { get; set; }
        public DateTime LicensePlateExpiryDate { get; set; }
        public List<Driver> AssignedDrivers { get; set; } = new List<Driver>();

    }
}
