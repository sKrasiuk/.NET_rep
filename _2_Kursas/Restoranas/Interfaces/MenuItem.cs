using System;

namespace Restoranas.Models;

public interface MenuItem
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string Category { get; set; }
}
