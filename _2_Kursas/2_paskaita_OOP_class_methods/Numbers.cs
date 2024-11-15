using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_paskaita_OOP_class_methods
{
    internal class Numbers
    {
        private List<int> numbers = new();

        private int value { get; set; }

        public void AddValue(int value)
        {
            numbers.Add(value);
        }

        public void PrintListComponents()
        {
            foreach (var number in numbers)
            {
                Console.WriteLine(number);
            }
        }
    }
}
