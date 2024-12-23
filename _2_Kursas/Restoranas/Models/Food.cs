using System;

namespace Restoranas.Models;

public class Food : MenuItem
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string Category { get; set; } = "Food";
}
