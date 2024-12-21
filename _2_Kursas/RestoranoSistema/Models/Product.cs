using System;

namespace RestoranoSistema.Models;

public class Product
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string Type { get; set; }
    public List<Order> Orders { get; set; }

    public Product(string name, decimal price, string type)
    {
        Name = name;
        Price = price;
        Type = type;
        Orders = new List<Order>();
    }
}

