using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_paskaita_OOP
{
    internal class School
    {
        public string City { get; private set; }
        public string Name { get; private set; }
        public int StudentsCount { get; set; }

        public School(string city, string name)
        {
            City = city;
            Name = name;
        }
        public School(string city, string name, int studentsCount) : this(city, name)
        {
            StudentsCount = studentsCount;
        }
    }
}