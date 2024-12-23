using System;
using System.Collections.Generic;

namespace RestoranoSistema.Models;

public class Order
{
    public int Id { get; set; }
    public Table Table { get; set; }
    public List<Product> Products { get; set; }
    public decimal Total { get; set; }
    public DateTime OrderDate { get; set; }

    public Order(int id, Table table, List<Product> products)
    {
        Id = id;
        Table = table;
        Products = products;
        OrderDate = DateTime.Now;
        Total = CalculateTotal();
    }

    private decimal CalculateTotal()
    {
        decimal total = 0;
        foreach (var product in Products)
        {
            total += product.Price;
        }
        return total;
    }

    public void AddProduct(Product product)
    {
        Products.Add(product);
        Total = CalculateTotal();
    }

    public void RemoveProduct(Product product)
    {
        Products.Remove(product);
        Total = CalculateTotal();
    }

    public void UpdateOrderDate(DateTime orderDate)
    {
        OrderDate = orderDate;
    }
}


