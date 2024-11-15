using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace _2_paskaita_OOP_class_methods
{
    internal class Library
    {
        public List<Book> Books { get; set; } = new();

        public void AddBook(string bookName, string bookAuthor, int bookReleaseYear)
        {
            foreach (var book in Books)
            {
                if (book.bookName == bookName)
                {
                    continue;
                }
            }
            Books.Add(new Book(bookName, bookAuthor, bookReleaseYear));
        }

        public void RemoveBook(string bookName)
        {
            foreach (var book in Books)
            {
                if (book.bookName == bookName)
                {
                    Books.Remove(book);
                }
            }
        }
    }
}
