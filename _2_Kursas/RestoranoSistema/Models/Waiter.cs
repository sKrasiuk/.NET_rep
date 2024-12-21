using System;
using System.Collections.Generic;

namespace RestoranoSistema.Models;

public class Waiter
{
    public string Name { get; set; }
    public List<Order> Orders { get; set; }

    public Waiter(string name)
    {
        Name = name;
        Orders = new List<Order>();
    }

    public void TakeOrder(Order order)
    {
        Orders.Add(order);
    }

    public void RemoveOrder(Order order)
    {
        Orders.Remove(order);
    }

    public void ManageOrders(Restaurant restaurant)
    {
        // Implement managing orders, e.g., assigning tables, taking orders, etc.
    }
}

