using System.Runtime.CompilerServices;

namespace _5_OPP_Modifiers.Models
{
    public class Person
    {
        protected string Name { get; private set; }
        protected int Age { get; private set; }

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        protected void PrintInfo()
        {
            Console.WriteLine($"Name: {Name} | Age: {Age}");
        }
    }
}
