using System;
using System.Collections.Generic;

namespace RestoranoSistema.Models;

public class Waiter
{
    public string Name { get; set; }
    public List<Order> Orders { get; set; }

    public Waiter(string name)
    {
        Name = name;
        Orders = new List<Order>();
    }

    public void TakeOrder(Order order)
    {
        Orders.Add(order);
    }

    public void RemoveOrder(Order order)
    {
        Orders.Remove(order);
    }

    public void ManageOrders(Restaurant restaurant)
    {
        // Implement managing orders, e.g., assigning tables, taking orders, etc.
        Console.WriteLine("Choose a table from the list below:");
        var tables = restaurant.Tables;
        for (int i = 0; i < tables.Count; i++)
        {
            Console.WriteLine($"{i + 1}. Table {tables[i].Number} - {(tables[i].IsAvailable ? "Available" : "Occupied")}");
        }

        int choice;
        do
        {
            Console.Write("Enter the number of the table you want to manage: ");
        } while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > tables.Count);

        var selectedTable = tables[choice - 1];
        if (selectedTable.IsAvailable)
        {
            // Assign table to the waiter
            selectedTable.AssignWaiter(this);
            // Take orders from the table
            foreach (var order in selectedTable.Orders)
            {
                TakeOrder(order);
            }
        }
        else
        {
            Console.WriteLine("The selected table is currently occupied.");
        }
    }
}

