using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks; // Added for async methods
using RestaurantSystem.Services;
using RestaurantSystem.Models;

namespace RestaurantSystem
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var menuService = new MenuService();
            var orderService = new OrderService();
            var billService = new BillService();

            try
            {
                menuService.LoadMenuItems("food.txt", "drinks.txt");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading menu items: {ex.Message}");
                return;
            }

            while (true)
            {
                Console.Clear();
                Console.WriteLine("\n1. View Tables");
                Console.WriteLine("2. Create Order");
                Console.WriteLine("3. Mark Table as Free");
                Console.WriteLine("4. Exit");
                Console.Write("Select option: ");

                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Clear();
                        DisplayTables(orderService);
                        Console.WriteLine("\nPress any key to continue...");
                        Console.ReadKey();
                        break;
                    case "2":
                        Console.Clear();
                        await CreateOrderAsync(orderService, menuService);
                        break;
                    case "3":
                        Console.Clear();
                        FreeTable(orderService, billService);
                        Console.WriteLine("\nPress any key to continue...");
                        Console.ReadKey();
                        break;
                    case "4":
                        return;
                }
            }
        }

        static void DisplayTables(OrderService orderService)
        {
            var tables = orderService.GetAllTables();
            Console.WriteLine("\nTables Status:");
            foreach (var table in tables)
            {
                Console.WriteLine($"Table {table.TableNumber} ({table.Seats} seats): {(table.IsOccupied ? "Occupied" : "Free")}");
            }
        }

        static async Task CreateOrderAsync(OrderService orderService, MenuService menuService)
        {
            Console.WriteLine("\nCreate New Order");
            Console.Write("Enter table number: ");
            if (!int.TryParse(Console.ReadLine(), out int tableNumber))
            {
                Console.WriteLine("Invalid table number.");
                return;
            }

            if (!orderService.IsTableAvailable(tableNumber))
            {
                Console.WriteLine("Table is not available.");
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
                return;
            }

            var order = new Order { TableNumber = tableNumber };

            while (true)
            {
                Console.Clear();
                Console.WriteLine($"\nCurrent Order for Table {tableNumber}");
                Console.WriteLine($"Total Items: {order.Items.Count}");
                Console.WriteLine($"Total Amount: ${order.TotalAmount}");
                Console.WriteLine("\n1. Add Food Item");
                Console.WriteLine("2. Add Drink Item");
                Console.WriteLine("3. Finish Order");
                Console.WriteLine("4. Cancel Order");
                Console.Write("\nSelect option: ");

                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddItemToOrder(order, menuService, MenuItemType.Food);
                        break;
                    case "2":
                        AddItemToOrder(order, menuService, MenuItemType.Drink);
                        break;
                    case "3":
                        if (order.Items.Any())
                        {
                            await orderService.CreateOrderAsync(order);
                            Console.WriteLine("Order created successfully!");
                            Console.WriteLine("\nPress any key to continue...");
                            Console.ReadKey();
                            return;
                        }
                        Console.WriteLine("Cannot create empty order!");
                        break;
                    case "4":
                        return;
                }
            }
        }

        static void AddItemToOrder(Order order, MenuService menuService, MenuItemType type)
        {
            Console.Clear();
            var items = menuService.GetMenuItems(type);
            Console.WriteLine($"\n{type} Menu:");
            foreach (var item in items)
            {
                Console.WriteLine($"{item.Name} - ${item.Price}");
            }

            Console.Write("\nEnter item number (0 to cancel): ");
            if (!int.TryParse(Console.ReadLine(), out int itemId) || itemId == 0)
                return;

            var menuItem = items.FirstOrDefault(i => i.Id == itemId);
            if (menuItem == null)
            {
                Console.WriteLine("Invalid item number.");
                return;
            }

            Console.Write("Enter quantity: ");
            if (!int.TryParse(Console.ReadLine(), out int quantity) || quantity <= 0)
            {
                Console.WriteLine("Invalid quantity.");
                return;
            }

            order.AddItem(menuItem, quantity);
        }

        static void FreeTable(OrderService orderService, BillService billService)
        {
            Console.Write("Enter table number to free: ");
            if (int.TryParse(Console.ReadLine(), out int tableNumber))
            {
                try
                {
                    orderService.FreeTable(tableNumber, billService);
                    Console.WriteLine("Table marked as free and bill printed.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }
    }
}
