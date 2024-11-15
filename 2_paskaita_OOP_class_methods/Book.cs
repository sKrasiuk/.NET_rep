using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_paskaita_OOP_class_methods
{
    internal class Book
    {
        public string bookName { get; set; }
        public string bookAuthor { get; set; }
        public int bookReleaseYear { get; set; }

        public Book(string bookName, string bookAuthor,int bookReleaseYear)
        {
            this.bookName = bookName;
            this.bookAuthor = bookAuthor;
            this.bookReleaseYear = bookReleaseYear;
        }
    }
}
