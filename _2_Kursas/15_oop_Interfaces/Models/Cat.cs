using _15_oop_Interfaces.Interfaces;

namespace _15_oop_Interfaces.Models
{
    internal class Cat : IAnimal, IMammal
    {
        public string Name { get; set; }
        public Cat(string name)
        {
            Name = name;
        }

        public void Eat()
        {
            Console.WriteLine("Cat - Eat.");
        }

        public void GiveBirth()
        {
            Console.WriteLine("Cat - Give birth.");
        }
    }
}
