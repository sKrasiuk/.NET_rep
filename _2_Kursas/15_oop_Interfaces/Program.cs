using _15_oop_Interfaces.Interfaces;
using _15_oop_Interfaces.Models;

namespace _15_oop_Interfaces
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var animals = new List<IAnimal>
            {
                new Dog("Sou1"),
                new Dog("Sou2"),
                new Cat("Cat1"),
                new Cat("Cat2"),
                new Carp(2),
                new Carp(5),
                new Bass(1),
                new Bass(7),
            };
            var mammals = new List<IMammal>();
            var fishes = new List<IFish>();

            foreach (var animal in animals)
            {
                if (animal is IMammal mammal)
                {
                    mammals.Add(mammal);
                }
                if (animal is IFish fish)
                {
                    fishes.Add(fish);
                }
            }

            foreach (var animal in animals)
            {
                animal.Eat();
            }

            foreach (var mammal in mammals)
            {
                mammal.GiveBirth();
            }

            foreach (var fish in fishes)
            {
                fish.Swim();
            }

            var gCompDogs = new GComparer<Dog>((x, y) => string.Compare(x.Name, y.Name));
            var gCompFishes = new GComparer<Carp>((x, y) => x.Age.CompareTo(y.Age));

            // 2 uzduotis

            var poligons = new List<IPoligon>
            {
                new Pentagon(5, 2),
                new Hexagon(5),
                new Quadrilateral(2, 5),
                new Triangle(2, 5),
            };

            var gCompPoligons = new GComparer<IPoligon>((x, y) => x.GetArea().CompareTo(y.GetArea()));
            poligons.Sort(gCompPoligons);
        }
    }
}
