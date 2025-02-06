using System;
using Kartojimas.Entities.Interfaces;

namespace Kartojimas.Entities;

public class Order : IEntity
{
    public int Id { get; set; }
    public Guid Number { get; set; }
    public string ShippingAddress { get; set; }
    public bool IsCompleted { get; set; }
    public DateTime DateCreated { get; set; }

    List<OrderItem> OrderItems { get; set; }
}
