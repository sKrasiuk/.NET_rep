using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_paskaita_OOP
{
    public class Book
    {
        public string Name { get; private set; }
        public string Author { get; private set; }
        public int Year { get; private set; }
        public string CountryOfIssue { get; set; }

        public Book(string name, string author, int year, string coi)
        {
            Name = name;
            Author = author;
            Year = year;
            CountryOfIssue = coi;
        }
    }
}
