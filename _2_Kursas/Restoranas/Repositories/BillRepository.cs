using System;
using Restoranas.Models;

namespace Restoranas.Repositories;

public class BillRepository
{
    private static readonly string BillsDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Bills");

    public BillRepository()
    {
        Directory.CreateDirectory(BillsDirectory);
    }

    public void SaveBill(Bill bill, string content)
    {
        string filename = $"{bill.Type}_Bill_{bill.OrderId}_{bill.ClosedAt:yyyyMMdd_HHmmss}.txt";
        bill.FilePath = Path.Combine(BillsDirectory, filename);
        File.WriteAllText(bill.FilePath, content);
    }
}
