using Microsoft.EntityFrameworkCore;

namespace DB_5_paskaita;

class Program
{
    static void Main(string[] args)
    {
        using var dbContext = new BookContent();

        var books = dbContext.Books
            .Where(x => x.Id == new Guid("b2f871ad-c7b6-46e2-b803-4b389a2d1af3"))
            .Include(x => x.Pages)
            .ToList();

        // var book = new Book("Amazing book");

        // for (int i = 0; i < 599; i++)
        // {
        //     book.Pages.Add(new Page(i, $"content - {i}"));
        // }

        // dbContext.Books.Add(book);
        // dbContext.SaveChanges();

        // var page = new Page(1, "some page text");
        // dbContext.Pages.Add(page);
        // dbContext.SaveChanges();

        // dbContext.Pages.Remove(page);
        // dbContext.SaveChanges();

        // var result = dbContext.Pages.FirstOrDefault(x=>x.Id == new Guid("231cd554-9d57-4c23-abdd-f38ec2c2b2a2"));

        // dbContext.Pages.Remove(result);
        // dbContext.SaveChanges();
    }
}
