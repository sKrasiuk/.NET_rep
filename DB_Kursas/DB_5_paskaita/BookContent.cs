using System;
using Microsoft.EntityFrameworkCore;

namespace DB_5_paskaita;

public class BookContent : DbContext
{
    public DbSet<Page> Pages { get; set; }
    public DbSet<Book> Books { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=_5_Paskaita;Trusted_Connection=True;TrustServerCertificate=True");
    }
}
