using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks; // Added for async methods
using RestaurantSystem.Models;

namespace RestaurantSystem.Services
{
    public class OrderService
    {
        private readonly List<Table> _tables;
        private readonly List<Order> _orders;

        public OrderService()
        {
            _tables = new List<Table>
            {
                new Table { TableNumber = 1, Seats = 2 },
                new Table { TableNumber = 2, Seats = 4 },
                new Table { TableNumber = 3, Seats = 4 },
                new Table { TableNumber = 4, Seats = 6 },
                new Table { TableNumber = 5, Seats = 8 }
            };
            _orders = new List<Order>();
        }

        public List<Table> GetAllTables() => _tables;

        public bool IsTableAvailable(int tableNumber)
        {
            var table = _tables.FirstOrDefault(t => t.TableNumber == tableNumber);
            return table != null && !table.IsOccupied;
        }

        public void SetTableStatus(int tableNumber, bool isOccupied)
        {
            var table = _tables.FirstOrDefault(t => t.TableNumber == tableNumber);
            if (table == null)
            {
                throw new InvalidOperationException($"Table {tableNumber} does not exist");
            }
            table.IsOccupied = isOccupied;
        }

        public async Task CreateOrderAsync(Order order)
        {
            var table = _tables.FirstOrDefault(t => t.TableNumber == order.TableNumber);
            if (table == null)
            {
                throw new InvalidOperationException($"Table {order.TableNumber} does not exist");
            }

            if (table.IsOccupied)
            {
                throw new InvalidOperationException($"Table {order.TableNumber} is already occupied");
            }

            if (!order.Items.Any())
            {
                throw new InvalidOperationException("Cannot create empty order");
            }

            order.CreatedAt = DateTime.Now;
            _orders.Add(order);
            SetTableStatus(order.TableNumber, true);
            SaveOrderToFile(order);
        }

        private void SaveOrderToFile(Order order)
        {
            var orderDetails = new[]
            {
                $"Order Details - {DateTime.Now:yyyy-MM-dd HH:mm:ss}",
                $"Table: {order.TableNumber}",
                "Items:",
                string.join("\n", order.Items.Select(i =>
                    $"- {i.MenuItem.Name} x{i.Quantity} = ${i.MenuItem.Price * i.Quantity:F2}")),
                $"Total Amount: ${order.TotalAmount:F2}",
                "----------------------------------------"
            };

            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "orders.txt");
            File.AppendAllLines(path, orderDetails);
        }

        public void FreeTable(int tableNumber, BillService billService)
        {
            var order = _orders.FirstOrDefault(o => o.TableNumber == tableNumber && !o.IsPaid);
            if (order == null)
            {
                throw new InvalidOperationException($"No active order found for table {tableNumber}");
            }

            billService.PrintBill(order);
            order.IsPaid = true;
            SetTableStatus(tableNumber, false);
        }
    }
}
