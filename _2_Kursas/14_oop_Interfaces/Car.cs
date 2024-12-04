namespace _14_oop_Interfaces
{
    internal abstract class Car : IVehicle
    {
        public string Model { get; set; }
        public int Fuel { get; set; }

        public Car(string model, int fuel)
        {
            Model = model;
            Fuel = fuel;
        }

        public string Drive()
        {
            if (!Fuel.Equals(0))
            {
                return "I Drive.";
            }
            return "No Fuel.";
        }

        public string Refuel(int amount)
        {
            if (amount > 0)
            {
                Fuel += amount;
                return "I Refuel.";
            }
            return "Incorrect amount to refuel.";
        }
    }
}
