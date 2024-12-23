using System;

namespace Restoranas.Models;

public class Drink : MenuItem
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string Category { get; set; } = "Drink";
}
