using System;

namespace Restoranas.Models;

public class Order
{
    public int Id { get; set; }
    public Waiter AssignedWaiter { get; set; }
    public Table AssignedTable { get; set; }
    public List<OrderItem> Items { get; set; } = new List<OrderItem>();
    public bool IsActive { get; set; }
    public bool IsIdAssigned { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? ClosedAt { get; set; }

    public Order()
    {
        IsActive = true;
        IsIdAssigned = false;
        CreatedAt = DateTime.Now;
        ClosedAt = null;
    }

    public void AddItem(MenuItem item, int quantity)
    {
        Items.Add(new OrderItem { Item = item, Quantity = quantity });
    }

    public void RemoveItem(int index)
    {
        if (index >= 0 && index < Items.Count)
        {
            Items.RemoveAt(index);
        }
    }
}
