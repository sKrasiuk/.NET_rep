using System;

namespace Restoranas.Models;

public class Bill
{
    public int OrderId { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime ClosedAt { get; set; }
    public Order Order { get; set; }
    public string FilePath { get; set; }
    public BillType Type { get; set; }

    public enum BillType
    {
        Customer,
        Restaurant
    }
}
