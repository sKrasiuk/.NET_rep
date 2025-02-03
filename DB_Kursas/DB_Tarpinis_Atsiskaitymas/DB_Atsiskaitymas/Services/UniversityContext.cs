using DB_Atsiskaitymas.Models;
using Microsoft.EntityFrameworkCore;

namespace DB_Atsiskaitymas.Services;

public class UniversityContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=UniversityDB;Trusted_Connection=True;TrustServerCertificate=True");

    public DbSet<Department> Departments { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<Lecture> Lectures { get; set; }
}
