using System.Text;
using EF_Test.Models;
using Microsoft.EntityFrameworkCore;

namespace EF_Test;

class Program
{
    static void Main(string[] args)
    {
        using var dbContext = new BookContext();

        // var page = new Page(1, "First page.");
        // dbContext.Add(page);
        // dbContext.SaveChanges();

        // var pRemove = new Page(new Guid("3AB2C587-AA77-454B-AAEF-C1E63C15F49E")); // REMOVE DOESN'T WORK 
        // dbContext.Pages.Remove(pRemove);
        // dbContext.SaveChanges();

        // var book = new Book("ABC");
        // for (int i = 0; i < 565; i++)
        // {
        //     book.Pages.Add(new Page(i, $"content - {i}"));
        // }
        // dbContext.Books.Add(book);
        // dbContext.SaveChanges();

        // var book = dbContext.Books.Where(x => x.Id == new Guid("06404CB1-01A6-40BC-B5A8-D4958792C5FE")).Include(x => x.Pages).First();
        // dbContext.Remove(book);
        // dbContext.SaveChanges();

        // var pId = Guid.Parse("E56849B7-38DD-40DF-88C5-8A7C4CD29388");
        // var page = new Page(pId);
        // dbContext.Remove(page);
        // dbContext.SaveChanges();
    }
}
