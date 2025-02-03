using System;
using Microsoft.EntityFrameworkCore;

namespace EF_Test.Models;

public class BookContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=EF_TestDB;Trusted_Connection=True;TrustServerCertificate=True");

    public DbSet<Page> Pages { get; set; }
    public DbSet<Book> Books { get; set; }
}
