using System;
using System.Collections.Generic;
using RestaurantSystem.Models; // Added for MenuItem

namespace RestaurantSystem.Services
{
    public class BillService
    {
        private readonly List<Bill> _bills;

        public BillService()
        {
            _bills = new List<Bill>();
        }

        public Bill CreateBill(int tableNumber, List<MenuItem> items)
        {
            var bill = new Bill
            {
                Id = Guid.NewGuid(),
                TableNumber = tableNumber,
                Items = items,
                TotalAmount = CalculateTotal(items),
                CreatedAt = DateTime.Now
            };

            _bills.Add(bill);
            return bill;
        }

        public Bill GetBill(Guid billId)
        {
            return _bills.Find(b => b.Id == billId);
        }

        public List<Bill> GetAllBills()
        {
            return _bills;
        }

        public void RemoveBill(Guid billId)
        {
            var bill = GetBill(billId);
            if (bill != null)
            {
                _bills.Remove(bill);
            }
        }

        private decimal CalculateTotal(List<MenuItem> items)
        {
            decimal total = 0;
            foreach (var item in items)
            {
                total += item.Price;
            }
            return total;
        }
    }

    public class Bill
    {
        public Guid Id { get; set; }
        public int TableNumber { get; set; }
        public List<MenuItem> Items { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    public class MenuItem
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}