using System;
using M2M_EF.Models;
using Microsoft.EntityFrameworkCore;

namespace M2M_EF.Data;

public class FileContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=M2M_EF;Trusted_Connection=True;TrustServerCertificate=True");

    public DbSet<FileModel> Files { get; set; }
    public DbSet<FolderModel> Folders { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<FileModel>(entity =>
        {
            entity.HasIndex(e => e.FullPath).IsUnique();
            
            entity.HasOne(d => d.Folder)
                .WithMany(p => p.Files)
                .HasForeignKey(d => d.FolderId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<FolderModel>(entity =>
        {
            entity.HasIndex(e => e.FullPath).IsUnique();

            // entity.HasOne(d => d.ParentFolder)
            //     .WithMany(p => p.SubFolders)
            //     .HasForeignKey(d => d.ParentFolderId)
            //     .IsRequired(false)
            //     .OnDelete(DeleteBehavior.Restrict);
        });
    }
}
