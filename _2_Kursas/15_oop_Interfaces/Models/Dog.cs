using _15_oop_Interfaces.Interfaces;

namespace _15_oop_Interfaces.Models
{
    internal class Dog : IAnimal, IMammal
    {
        public string Name { get; set; }
        public Dog(string name)
        {
            Name = name;
        }

        public void Eat()
        {
            Console.WriteLine("Dog - Eat.");
        }

        public void GiveBirth()
        {
            Console.WriteLine("Dog - Give birth.");
        }
    }
}
