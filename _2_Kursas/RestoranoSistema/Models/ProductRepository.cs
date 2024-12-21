using System;

namespace RestoranoSistema.Models;

public class ProductRepository
{
    private List<Product> products = new List<Product>();

    public ProductRepository()
    {
        string[] foodLines = File.ReadAllLines("food.txt");
        foreach (string line in foodLines)
        {
            string[] parts = line.Split(',');
            int id = int.Parse(parts[0]);
            string name = parts[1];
            decimal price = decimal.Parse(parts[2]);
            products.Add(new Food(name, price));
        }

        string[] beverageLines = File.ReadAllLines("beverage.txt");
        foreach (string line in beverageLines)
        {
            string[] parts = line.Split(',');
            int id = int.Parse(parts[0]);
            string name = parts[1];
            decimal price = decimal.Parse(parts[2]);
            products.Add(new Beverage(name, price));
        }
    }

    public List<Product> GetProducts()
    {
        return products;
    }
}
