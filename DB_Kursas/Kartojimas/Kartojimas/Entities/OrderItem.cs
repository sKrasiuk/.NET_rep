using System;
using Kartojimas.Entities.Interfaces;

namespace Kartojimas.Entities;

public class OrderItem : IEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public int OrderId { get; set; }

    public Order Order { get; set; }
}
