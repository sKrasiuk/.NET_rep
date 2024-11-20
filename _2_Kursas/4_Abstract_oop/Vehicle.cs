namespace _4_Abstract_oop
{
    public abstract class Vehicle
    {
        public required string FuelType { get; set; }
        public double EngineVolume { get; set; }
        public int NumberOfSeats { get; set; }
        public int NumberOfWheels { get; set; }
    }
}
