using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_paskaita_OOP
{
    internal class Person
    {
        public string Name { get; private set; }
        public int Age { get; private set; }
        public int Tall { get; set; }

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public Person(string name, int age, int tall) : this(name, age)
        {
            Tall = tall;
        }

    }
}
