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

    public Order()
    {
        IsActive = true;
        IsIdAssigned = false;
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
