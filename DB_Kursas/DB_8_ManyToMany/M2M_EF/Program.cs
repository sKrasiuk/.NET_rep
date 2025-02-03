using M2M_EF.Data;
using M2M_EF.Services;
using Microsoft.EntityFrameworkCore;

namespace M2M_EF;

class Program
{
    static void Main(string[] args)
    {
        // // var connectionString = "Server=localhost\\SQLEXPRESS;Database=M2M_EF;Trusted_Connection=True;TrustServerCertificate=True";
        // var options = new DbContextOptionsBuilder<FileContext>()
        //     .UseSqlServer(connectionString)
        //     .Options;

        var scanner = new FileScanner();

        Console.WriteLine("Enter directory path to scan:");
        // var directoryPath = Console.ReadLine();
        var directoryPath = @"C:\DEV_\GitHub\.NET_rep";

        if (string.IsNullOrEmpty(directoryPath))
        {
            Console.WriteLine("Directory path cannot be empty.");
            return;
        }

        try
        {
            using var context = new FileContext();

            var (files, folders) = scanner.ScanDirectory(directoryPath);

            Console.WriteLine($"Found {folders.Count} folders and {files.Count} files");

            using var transaction = context.Database.BeginTransaction();
            try
            {
                foreach (var folder in folders)
                {
                    context.Add(folder);
                    // context.SaveChanges();
                }
                // context.Folders.AddRange(folders);

                foreach (var file in files)
                {
                    context.Add(file);
                }
                // context.Files.AddRange(files);
                context.SaveChanges();

                transaction.Commit();
                Console.WriteLine("Successfully saved to database");
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw new Exception("Failed to save to database", ex);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            if (ex.InnerException != null)
            {
                Console.WriteLine($"Inner error: {ex.InnerException.Message}");
            }
        }
    }
}
