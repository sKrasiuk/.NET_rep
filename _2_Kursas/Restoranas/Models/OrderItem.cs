using System;

namespace Restoranas.Models;

public class OrderItem
{
    public MenuItem Item { get; set; }
    public int Quantity { get; set; }
}
