using System;
using System.Collections.Generic;

namespace RestoranoSistema.Models;

public class Bill
{
    public Order Order { get; set; }
    public List<Product> Items { get; set; }

    public Bill(Order order)
    {
        Order = order;
        Items = new List<Product>();
    }

    public void AddItem(Product item)
    {
        Items.Add(item);
    }

    public void RemoveItem(Product item)
    {
        Items.Remove(item);
    }
}
