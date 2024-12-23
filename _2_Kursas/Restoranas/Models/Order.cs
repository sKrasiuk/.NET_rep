using System;

namespace Restoranas.Models;

public class Order
{
    private static int nextId = 1;

    public int Id { get; private set; }
    public Waiter AssignedWaiter { get; set; }
    public Table AssignedTable { get; set; }
    public List<OrderItem> Items { get; set; } = new List<OrderItem>();
    public bool IsActive { get; set; }

    public Order()
    {
        Id = nextId++;
        IsActive = true;
    }

    public void AddItem(MenuItem item, int quantity)
    {
        Items.Add(new OrderItem { Item = item, Quantity = quantity });
    }

    public void RemoveItem(MenuItem item)
    {
        Items.RemoveAll(i => i.Item == item);
    }

    public void UodateItemQuantity(MenuItem item, int quantity)
    {
        var orderItem = Items.Find(i => i.Item == item);
        if (orderItem != null)
        {
            orderItem.Quantity = quantity;
        }
    }
}
