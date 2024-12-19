using System;

namespace RestoranoSistema.Models;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string Type { get; set; }

    public Product(int id, string name, decimal price, string type)
    {
        Id = id;
        Name = name;
        Price = price;
        Type = type;
    }
}
