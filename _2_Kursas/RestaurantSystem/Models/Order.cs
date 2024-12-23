using System;
using System.Collections.Generic;
using System.Linq;
using RestaurantSystem.Models;

namespace RestaurantSystem.Models
{
    public class Order
    {
        public int TableNumber { get; set; }
        public List<OrderItem> Items { get; } = new List<OrderItem>();
        public DateTime CreatedAt { get; set; }
        public bool IsPaid { get; set; }
        public decimal TotalAmount => Items.Sum(i => i.Quantity * i.MenuItem.Price);

        public void AddItem(MenuItem menuItem, int quantity)
        {
            Items.Add(new OrderItem
            {
                MenuItem = menuItem,
                Quantity = quantity
            });
        }
    }
}
