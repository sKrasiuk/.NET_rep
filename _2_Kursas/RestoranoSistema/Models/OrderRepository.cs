using System;

namespace RestoranoSistema.Models;

public class OrderRepository
{
    private List<Order> orders = new List<Order>();

    public void AddOrder(Order order)
    {
        orders.Add(order);
    }

    public List<Order> GetOrders()
    {
        return orders;
    }

    public void AddProductToOrder(int orderId, Product product)
    {
        var order = orders.FirstOrDefault(o => o.Id == orderId);
        if (order != null)
        {
            order.AddProduct(product);
        }
    }
}
