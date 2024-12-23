using System;

namespace Restoranas.Models;

public class Waiter
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<Order> Orders { get; set; } = new List<Order>();

    public Order CreateOrder(Table table)
    {
        var order = new Order { AssignedWaiter = this, AssignedTable = table };
        Orders.Add(order);
        return order;
    }

    public void CloseOrder(Order order)
    {
        order.IsActive = false;
    }
}

