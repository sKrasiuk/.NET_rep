using _15_oop_Interfaces.Interfaces;

namespace _15_oop_Interfaces.Models
{
    internal class Bass : IAnimal, IFish
    {
        public int Age { get; set; }
        public Bass(int age)
        {
            Age = age;
        }

        public void Eat()
        {
            Console.WriteLine("Bass - Eat.");
        }

        public void Swim()
        {
            Console.WriteLine("Bass - Swim.");
        }
    }
}
