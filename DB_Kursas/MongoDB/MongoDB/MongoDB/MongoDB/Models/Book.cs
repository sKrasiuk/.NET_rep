using MongoDB.Bson;

namespace MongoDB.Models;

public class Book
{
    public ObjectId Id { get; set; }
    public string Name { get; set; }
    public List<Page> Pages { get; set; }
    public int NumberOfPages { get; set; }

    public Book(ObjectId id, string name, int numberOfPages)
    {
        Id = id;
        Name = name;
        NumberOfPages = numberOfPages;
        Pages = new List<Page>(numberOfPages);
        InitializePages();
    }

    private void AddPage()
    {
        var page = new Page(ObjectId.GenerateNewId());
        Pages.Add(page);
    }

    private void InitializePages()
    {
        for (int i = 0; i < NumberOfPages; i++)
        {
            AddPage();
        }
    }
}
