namespace _14_oop_Interfaces
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //var car = new Car("ZAZ", 0);
            //car.Refuel(10);
            //car.Drive();

            var bmwCar = new BmwCar("BMW", 50, true);
            var audiCar = new AudiCar("Audi", 30, true);

            bmwCar.Drive();
            bmwCar.Refuel(10);

            audiCar.Drive();
            audiCar.Refuel(20);

            var bmwCars = new List<BmwCar>
            {
                new BmwCar("model3", 30, true),
                new BmwCar("model1", 20, true),
                new BmwCar("model2", 50, true),
            };

            //var bmwComparer = new BmwCarComparer();
            //bmwCars.Sort(bmwComparer);

            var audiCars = new List<AudiCar>
            {
                new AudiCar("a4", 60, true),
                new AudiCar("a2", 50, false),
                new AudiCar("a6", 60, true),
                new AudiCar("a1", 40, false),
            };

            //var audiComparer = new AudiCarComparer();
            //audiCars.Sort(audiComparer);

            var genComAudi = new GenericComparer<AudiCar>((x, y) => string.Compare(x.Model, y.Model));
            var genComBmw = new GenericComparer<BmwCar>((x, y) => string.Compare(x.Model, y.Model, StringComparison.Ordinal));
            audiCars.Sort(genComAudi);
            bmwCars.Sort(genComBmw);

        }
    }
}
