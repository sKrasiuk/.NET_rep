using System;

namespace RestoranoSistema.Models;

public class Order
{
    public int Id { get; set; }
    public Table Table { get; set; }
    public List<Product> Products { get; set; }
    public decimal TotalPrice { get; set; }
    public DateTime OrderDate { get; set; }

    public Order(Table table)
    {
        Table = table;
        Products = new List<Product>();
        TotalPrice = 0;
        OrderDate = DateTime.Now;
    }

    public void AddProduct(Product product)
    {
        Products.Add(product);
        TotalPrice += product.Price;
    }

    public void RemoveProduct(Product product)
    {
        Products.Remove(product);
        TotalPrice -= product.Price;
    }

    public decimal CalculateTotalPrice()
    {
        return Products.Sum(p => p.Price);
    }

    public override string ToString()
    {
        return $"Order {Id} - Table {Table.Number} - Total Price: {TotalPrice}";
    }
}
