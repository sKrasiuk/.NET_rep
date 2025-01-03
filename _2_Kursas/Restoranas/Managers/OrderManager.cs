using System;
using System.Runtime.CompilerServices;
using Restoranas.Models;
using Restoranas.Repositories;
using System.Globalization;

namespace Restoranas.Managers;

public class OrderManager
{
    private readonly IEnumerable<Table> tables;
    private readonly IEnumerable<MenuItem> menuItems;
    private readonly OrderRepository orderRepository;
    private readonly BillManager billManager;
    public OrderManager(IEnumerable<Table> tables,
        IEnumerable<MenuItem> menuItems,
        OrderRepository orderRepository,
        BillManager billManager)
    {
        this.tables = tables;
        this.menuItems = menuItems;
        this.orderRepository = orderRepository;
        this.billManager = billManager;
    }

    public void ShowMenu(Waiter waiter)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine($"Waiter: {waiter.Name}\n");
            Console.WriteLine("1. Create Order");
            Console.WriteLine("2. Manage Orders");
            Console.WriteLine("3. Close Order");
            Console.WriteLine("4. View Active Orders");
            Console.WriteLine("5. Logout");
            Console.Write("\nSelect an option: ");
            var option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    CreateOrder(waiter);
                    break;
                case "2":
                    AddItemToOrder(waiter);
                    break;
                case "3":
                    CloseOrder(waiter);
                    break;
                case "4":
                    ViewActiveOrders(waiter);
                    break;
                case "5":
                    return;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    Console.ReadKey();
                    break;
            }
        }
    }

    private void CreateOrder(Waiter waiter)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine($"Available Tables:\n");
            foreach (var t in tables)
            {
                bool isOccupied = orderRepository.IsTableOccupied(t.Id);
                Console.WriteLine($"{t.Id}. Seats: {t.Seats}, Status: {(isOccupied ? "Occupied" : "Available")}");
            }
            Console.WriteLine($"\n0. Cancel");

            Console.Write("\nEnter table ID (0 to cancel): ");
            var input = Console.ReadLine();

            if (input == "0")
            {
                return;
            }

            if (!int.TryParse(input, out int tableId))
            {
                Console.WriteLine("Invalid input. Please enter a number.");
                Console.ReadKey();
                continue;
            }

            var table = tables.FirstOrDefault(t => t.Id == tableId);

            if (table == null)
            {
                Console.WriteLine("Invalid table ID.");
                Console.ReadKey();
                continue;
            }

            if (orderRepository.IsTableOccupied(table.Id))
            {
                Console.WriteLine("Table is already occupied.");
                Console.ReadKey();
                continue;
            }

            var order = waiter.CreateOrder(table);
            orderRepository.AddOrder(order);
            Console.WriteLine($"Order created and awaiting confirmation...");
            ShowMenuAndAddItems(order);
            return;
        }
    }

    private void ShowMenuAndAddItems(Order order)
    {
        bool orderAccepted = false;
        while (!orderAccepted)
        {
            Console.Clear();
            Console.WriteLine($"Current Order (ID: {(order.IsIdAssigned ? order.Id : orderRepository.GetNextOrderId())}):");
            ShowOrderSummary(order);

            Console.WriteLine("\nSelect category:");
            Console.WriteLine("1. Food");
            Console.WriteLine("2. Drinks");
            Console.WriteLine("3. Remove Item");
            Console.WriteLine("4. Accept Order");
            Console.WriteLine("0. Cancel Order");

            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    ShowCategoryItems(order, "Food");
                    break;
                case "2":
                    ShowCategoryItems(order, "Drink");
                    break;
                case "3":
                    RemoveItemFromOrder(order);
                    break;
                case "4":
                    if (order.Items.Any())
                    {
                        AcceptOrder(order);
                        orderAccepted = true;
                    }
                    else
                    {
                        Console.WriteLine("Cannot accept empty order. Please add items first.");
                        Console.ReadKey();
                    }
                    break;
                case "0":
                    CancelOrder(order);
                    return;
                default:
                    Console.WriteLine("Invalid option");
                    Console.ReadKey();
                    break;
            }
        }
    }

    private void RemoveItemFromOrder(Order order)
    {
        if (!order.Items.Any())
        {
            Console.WriteLine("No items to remove.");
            Console.ReadKey();
            return;
        }

        Console.Clear();
        Console.WriteLine("Select item to remove:");
        for (int i = 0; i < order.Items.Count; i++)
        {
            var item = order.Items[i];
            Console.WriteLine($"{i + 1}. {item.Quantity} x {item.Item.Name} - {item.Item.Price:C}");
        }
        Console.WriteLine("0. Back");

        Console.Write($"\nEnter item ID to remove: ");
        if (int.TryParse(Console.ReadLine(), out int choice) && choice > 0 && choice <= order.Items.Count)
        {
            order.RemoveItem(choice - 1);
            Console.WriteLine("Item removed successfully.");
            Console.ReadKey();
        }
    }

    private void ShowCategoryItems(Order order, string category)
    {
        Console.Clear();
        var items = menuItems.Where(i => i.Category == category).ToList();

        Console.WriteLine($"{category} items:\n");
        for (int i = 0; i < items.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {items[i].Name} - {items[i].Price:C}");
        }
        Console.WriteLine($"\n0. Back to categories");

        Console.Write("\nSelect item number: ");
        var choice = Console.ReadLine();

        if (choice == "0") return;

        if (int.TryParse(choice, out int itemNumber) && itemNumber <= items.Count)
        {
            var selectedItem = items[itemNumber - 1];
            Console.Write("Enter quantity: ");
            if (int.TryParse(Console.ReadLine(), out int quantity))
            {
                order.AddItem(selectedItem, quantity);
                Console.WriteLine($"Item added to order. Total: {selectedItem.Price * quantity:C}");
                Console.ReadKey();
            }
        }
    }

    private void AddItemToOrder(Waiter waiter)
    {
        while (true)
        {
            Console.Clear();
            var activeOrders = orderRepository.GetActiveOrders(waiter);
            if (!activeOrders.Any())
            {
                Console.WriteLine("No active orders.");
                Console.WriteLine("\nPress any key to return to main menu...");
                Console.ReadKey();
                return;
            }

            Console.WriteLine($"Active Orders for Waiter {waiter.Name}:");
            foreach (var order in activeOrders)
            {
                ShowOrderDetails(order);
            }
            Console.WriteLine("\n0. Cancel");

            Console.Write("\nEnter order ID to modify (0 to cancel): ");
            var input = Console.ReadLine();

            if (input == "0")
            {
                return;
            }

            if (!int.TryParse(input, out int orderId))
            {
                Console.WriteLine("Invalid input. Please enter a number.");
                Console.ReadKey();
                continue;
            }

            var orderToModify = activeOrders.FirstOrDefault(o => o.Id == orderId);
            if (orderToModify == null)
            {
                Console.WriteLine("Invalid order ID.");
                Console.ReadKey();
                continue;
            }

            ShowMenuAndAddItems(orderToModify);
            return;
        }
    }

    private void CloseOrder(Waiter waiter)
    {
        Console.Clear();
        var activeOrders = orderRepository.GetActiveOrders(waiter);
        if (!activeOrders.Any())
        {
            Console.WriteLine("No active orders to close.");
            Console.WriteLine("\nPress any key to return to main menu...");
            Console.ReadKey();
            return;
        }

        Console.WriteLine($"Active Orders for Waiter {waiter.Name}:");

        foreach (var order in activeOrders)
        {
            ShowOrderDetails(order);
        }

        Console.WriteLine("\nEnter order ID to close (0 to cancel): ");
        var input = Console.ReadLine();

        if (input == "0")
        {
            return;
        }

        if (int.TryParse(input, out int orderId))
        {
            var orderToClose = activeOrders.FirstOrDefault(o => o.Id == orderId);
            if (orderToClose != null)
            {
                if (ConfirmAction(orderToClose, "Close"))
                {
                    Console.WriteLine("\nBill Generation Options:");

                    Console.Write("Save customer bill to file? (Y/N): ");
                    bool saveCustomerBill = Console.ReadLine().ToUpper() == "Y";

                    Console.Write("Send customer bill via email? (Y/N): ");
                    bool emailCustomerBill = Console.ReadLine().ToUpper() == "Y";

                    string customerEmail = BillManager.CustomerEmail;

                    Console.Write("Send restaurant bill via email? (Y/N): ");
                    bool emailRestaurantBill = Console.ReadLine().ToUpper() == "Y";


                    orderRepository.CloseOrder(orderToClose);
                    billManager.GenerateBills(
                        orderToClose,
                        saveCustomerBill,
                        emailCustomerBill,
                        emailRestaurantBill,
                        customerEmail
                        );
                    Console.WriteLine("Order closed successfully and bills generated.");
                }
                else
                {
                    Console.WriteLine("Order closure cancelled.");
                }
            }
            else
            {
                Console.WriteLine("Invalid order ID.");
            }
        }
        else
        {
            Console.WriteLine("Invalid input.");
        }

        Console.WriteLine("\nPress any key to return to main menu...");
        Console.ReadKey();
    }

    private void ShowOrderSummary(Order order)
    {
        if (!order.Items.Any())
        {
            Console.WriteLine("No items in order yet");
            return;
        }

        foreach (var item in order.Items)
        {
            Console.WriteLine($"{item.Quantity} x {item.Item.Name} - {item.Item.Price:C}");
        }
        Console.WriteLine($"Total: {order.Items.Sum(i => i.Item.Price * i.Quantity):C}");
    }

    private bool ConfirmAction(Order order, string action)
    {
        Console.Clear();
        Console.WriteLine($"=== {action} Order ===");
        ShowOrderSummary(order);

        Console.WriteLine($"\nDo you want to {action.ToLower()} this order? (Y/N)");
        var response = Console.ReadLine();
        return response != null && string.Equals(response, "Y", StringComparison.OrdinalIgnoreCase);
    }

    private bool AcceptOrder(Order order)
    {
        if (ConfirmAction(order, "Accept"))
        {
            order.IsActive = true;
            orderRepository.SetOrderId(order);
            order.AssignedTable.IsOccupied = true;
            Console.WriteLine("Order accepted!");
            Console.ReadKey();
            return true;
        }
        CancelOrder(order);
        return false;
    }

    private void CancelOrder(Order order)
    {
        if (order.IsIdAssigned)
        {
            if (!ConfirmAction(order, "Cancel"))
            {
                Console.WriteLine("Order cancellation denied.");
                Console.ReadKey();
                return;
            }
        }

        order.AssignedTable.IsOccupied = false;
        orderRepository.RemoveOrder(order);
        Console.WriteLine("Order cancelled successfully.");
        Console.ReadKey();
    }

    private void ViewActiveOrders(Waiter waiter)
    {
        Console.Clear();
        var activeOrders = orderRepository.GetActiveOrders(waiter);

        if (!activeOrders.Any())
        {
            Console.WriteLine("No active orders.");
            Console.WriteLine("\nPress any key to return to main menu...");
            Console.ReadKey();
            return;
        }

        Console.WriteLine($"Active Orders for Waiter {waiter.Name}:");
        foreach (var order in activeOrders)
        {
            ShowOrderDetails(order);
        }

        Console.WriteLine("\nPress any key to return to main menu...");
        Console.ReadKey();
    }

    private void ShowOrderDetails(Order order)
    {
        Console.WriteLine($"\nOrder ID: {order.Id}");
        Console.WriteLine($"Table ID: {order.AssignedTable.Id}");
        Console.WriteLine($"Created: {order.CreatedAt:yyyy-MM-dd HH:mm:ss}");
        Console.WriteLine("Items:");
        foreach (var item in order.Items)
        {
            Console.WriteLine($"  {item.Quantity} x {item.Item.Name} - {item.Item.Price:C}");
        }
        var total = order.Items.Sum(i => i.Item.Price * i.Quantity);
        Console.WriteLine($"Total: {total:C}");

        if (order.ClosedAt != null)
        {
            Console.WriteLine($"Closed: {order.ClosedAt: yyyy-MM-dd HH:mm:ss}");
        }
    }
}
