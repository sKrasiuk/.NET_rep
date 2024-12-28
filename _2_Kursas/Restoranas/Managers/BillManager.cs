using System;
using Restoranas.Models;
using Restoranas.Repositories;
using Restoranas.Services;

namespace Restoranas.Managers;

public class BillManager
{
    private readonly BillRepository billRepository;
    private readonly EmailService emailService;
    private const string RestaurantEmail = "sergej.krasiukov@codeacademylt.onmicrosoft.com";
    public const string CustomerEmail = "sergej.krasiukov@codeacademylt.onmicrosoft.com";

    public BillManager(BillRepository billRepository, EmailService emailService)
    {
        this.billRepository = billRepository;
        this.emailService = emailService;
    }

    public void GenerateBills(
        Order order,
        bool saveCustomerBill,
        bool emailCustomerBill,
        bool emailRestaurantBill,
        string customerEmail = null
        )
    {
        var restaurantBill = GenerateRestaurantBill(order);
        var restaurantContent = GetBillContent(restaurantBill);
        billRepository.SaveBill(restaurantBill, restaurantContent);

        if (emailRestaurantBill)
        {
            emailService.SendEmail(
                RestaurantEmail,
                $"Restaurant Bill - Order {order.Id}",
                restaurantContent
            );
        }

        if (saveCustomerBill || emailCustomerBill)
        {
            var customerBill = GenerateCustomerBill(order);
            var customerContent = GetBillContent(customerBill);

            if (saveCustomerBill)
            {
                billRepository.SaveBill(customerBill, customerContent);
            }

            if (emailCustomerBill && !string.IsNullOrEmpty(customerEmail))
            {
                emailService.SendEmail(
                    customerEmail,
                    $"Your Bill - Order {order.Id}",
                    customerContent
                );
            }
        }
    }

    private Bill GenerateCustomerBill(Order order)
    {
        var bill = new Bill
        {
            OrderId = order.Id,
            CreatedAt = order.CreatedAt,
            ClosedAt = order.ClosedAt.Value,
            Order = order,
            Type = Bill.BillType.Customer
        };

        var content = GetBillContent(bill);
        billRepository.SaveBill(bill, content);
        return bill;
    }

    private Bill GenerateRestaurantBill(Order order)
    {
        var bill = new Bill
        {
            OrderId = order.Id,
            CreatedAt = order.CreatedAt,
            ClosedAt = order.ClosedAt.Value,
            Order = order,
            Type = Bill.BillType.Restaurant
        };

        var content = GetBillContent(bill);
        billRepository.SaveBill(bill, content);
        return bill;
    }

    private string GetBillContent(Bill bill)
    {
        using var writer = new StringWriter();
        if (bill.Type == Bill.BillType.Customer)
        {
            WriteCustomerBill(bill, writer);
        }
        else
        {
            WriteRestaurantBill(bill, writer);
        }
        return writer.ToString();
    }

    private void WriteCustomerBill(Bill bill, TextWriter writer)
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

    private void WriteRestaurantBill(Bill bill, TextWriter writer)
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
