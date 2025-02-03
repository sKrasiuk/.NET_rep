using System;

namespace DB_5_paskaita;

public class Book
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public List<Page> Pages { get; set; }

    public Book(string name)
    {
        Id = Guid.NewGuid();
        Name = name;
        Pages = new List<Page>();
    }
}
