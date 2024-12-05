using _15_oop_Interfaces.Interfaces;

namespace _15_oop_Interfaces.Models
{
    internal class Carp : IAnimal, IFish
    {
        public int Age { get; set; }
        public Carp(int age)
        {
            Age = age;
        }

        public void Eat()
        {
            Console.WriteLine("Carp - Eat.");
        }

        public void Swim()
        {
            Console.WriteLine("Carp - Swim.");
        }
    }
}
