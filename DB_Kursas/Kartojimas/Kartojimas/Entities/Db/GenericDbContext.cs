using System;
using Microsoft.EntityFrameworkCore;

namespace Kartojimas.Entities.Db;

public class GenericDbContext : DbContext
{
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrdersItems { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=DB_Kartojimas;Trusted_Connection=True;");
    }
}
