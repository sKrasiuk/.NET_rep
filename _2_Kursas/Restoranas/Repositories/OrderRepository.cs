using System;
using Restoranas.Models;

namespace Restoranas.Repositories;

public class OrderRepository
{
    private static readonly List<Order> activeOrders = new List<Order>();
    private static int nextOrderId = 1;

    public void AddOrder(Order order)
    {
        activeOrders.Add(order);
    }

    public void SetOrderId(Order order)
    {
        if (!order.IsIdAssigned && order.IsActive)
        {
            order.Id = nextOrderId++;
            order.IsIdAssigned = true;
        }
    }

    public void CloseOrder(Order order)
    {
        order.IsActive = false;
        order.AssignedTable.IsOccupied = false;
        order.ClosedAt = DateTime.Now;
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

    public void RemoveOrder(Order order)
    {
        if (order.IsIdAssigned)
        {
            nextOrderId--;
        }

        activeOrders.Remove(order);

        if (order.AssignedTable != null)
        {
            order.AssignedTable.IsOccupied = false;
        }

        order.IsActive = false;
        order.IsIdAssigned = false;
    }

    public int GetNextOrderId()
    {
        return nextOrderId;
    }
}
