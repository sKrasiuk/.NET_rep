using System;
using Restoranas.Models;
using Restoranas.Repositories;

namespace Restoranas.Managers;

public class BillManager
{
    private readonly BillRepository billRepository;

    public BillManager(BillRepository billRepository)
    {
        this.billRepository = billRepository;
    }

    public void GenerateBills(Order order)
    {
        GenerateCustomerBill(order);
        GenerateRestaurantBill(order);
    }

    private void GenerateCustomerBill(Order order)
    {
        var bill = new Bill
        {
            OrderId = order.Id,
            CreatedAt = order.CreatedAt,
            ClosedAt = order.ClosedAt.Value,
            Order = order,
            Type = Bill.BillType.Customer
        };

        billRepository.SaveBill(bill);
        WriteCustomerBill(bill);
    }

    private void GenerateRestaurantBill(Order order)
    {
        var bill = new Bill
        {
            OrderId = order.Id,
            CreatedAt = order.CreatedAt,
            ClosedAt = order.ClosedAt.Value,
            Order = order,
            Type = Bill.BillType.Restaurant
        };

        billRepository.SaveBill(bill);
        WriteRestaurantBill(bill);
    }

    private void WriteCustomerBill(Bill bill)
    {
        using (StreamWriter writer = new StreamWriter(bill.FilePath))
        {
            writer.WriteLine("=== CUSTOMER BILL ===");
            writer.WriteLine($"Date: {bill.ClosedAt:yyyy-MM-dd HH:mm:ss}");
            writer.WriteLine($"Order ID: {bill.OrderId}");
            writer.WriteLine($"Waiter: {bill.Order.AssignedWaiter.Name}");
            writer.WriteLine("\nItems:");
            foreach (var item in bill.Order.Items)
            {
                writer.WriteLine($"{item.Quantity} x {item.Item.Name} - {item.Item.Price:C}");
            }
            writer.WriteLine($"\nTotal: {bill.Order.Items.Sum(i => i.Item.Price * i.Quantity):C}");
        }
    }

    private void WriteRestaurantBill(Bill bill)
    {
        using (StreamWriter writer = new StreamWriter(bill.FilePath))
        {
            writer.WriteLine("=== RESTAURANT BILL ===");
            writer.WriteLine($"Order ID: {bill.OrderId}");
            writer.WriteLine($"Created: {bill.CreatedAt:yyyy-MM-dd HH:mm:ss}");
            writer.WriteLine($"Closed: {bill.ClosedAt:yyyy-MM-dd HH:mm:ss}");
            writer.WriteLine($"Table: {bill.Order.AssignedTable.Id}");
            writer.WriteLine($"Waiter: {bill.Order.AssignedWaiter.Name} (ID: {bill.Order.AssignedWaiter.Id})");
            writer.WriteLine("\nDetailed Items:");
            foreach (var item in bill.Order.Items)
            {
                decimal itemTotal = item.Item.Price * item.Quantity;
                writer.WriteLine($"{item.Quantity} x {item.Item.Name} - {item.Item.Price:C} = {itemTotal:C}");
            }
            writer.WriteLine("\nSummary:");
            writer.WriteLine($"Total Items: {bill.Order.Items.Count}");
            writer.WriteLine($"Total Quantity: {bill.Order.Items.Sum(i => i.Quantity)}");
            writer.WriteLine($"Total Amount: {bill.Order.Items.Sum(i => i.Item.Price * i.Quantity):C}");
        }
    }
}
