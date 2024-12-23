using System;
using Restoranas.Models;

namespace Restoranas.Repositories;

public class OrderRepository
{
    private static readonly List<Order> activeOrders = new List<Order>();

    public void AddOrder(Order order)
    {
        activeOrders.Add(order);
    }

    public void CloseOrder(Order order)
    {
        order.IsActive = false;
        order.AssignedTable.IsOccupied = false;
    }

    public IEnumerable<Order> GetActiveOrders(Waiter waiter)
    {
        return activeOrders.Where(o => o.IsActive && o.AssignedWaiter.Id == waiter.Id);
    }

    public IEnumerable<Order> GetAllActiveOrders()
    {
        return activeOrders.Where(o => o.IsActive);
    }

    public bool IsTableOccupied(int tableId)
    {
        return activeOrders.Any(o => o.IsActive && o.AssignedTable.Id == tableId);
    }
}
