namespace Exercise02.Domain.Models
{
    public class Car
    {
        private static int _driverCounter = 1;

        public Car(string model, int licensePlate, DateTime licensePlateExpiryDate, List<Driver> assignedDrivers)
        {
            Id = _driverCounter;
            Model = model;
            LicensePlate = licensePlate;
            LicensePlateExpiryDate = licensePlateExpiryDate;
            AssignedDrivers = assignedDrivers;

            _driverCounter++;
        }

        public int Id { get; set; }
        public string Model { get; set; }
        public int LicensePlate { get; set; }
        public DateTime LicensePlateExpiryDate { get; set; }
        public List<Driver> AssignedDrivers { get; set; } = new List<Driver>();

    }
}
