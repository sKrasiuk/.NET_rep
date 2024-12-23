using System;
using System.Collections.Generic;
using System.Linq;

namespace RestoranoSistema.Models;

public class OrderService
{
    private OrderRepository orderRepository;
    private TableRepository tableRepository;
    private ProductRepository productRepository;

    public OrderService(OrderRepository orderRepository, TableRepository tableRepository, ProductRepository productRepository)
    {
        this.orderRepository = orderRepository;
        this.tableRepository = tableRepository;
        this.productRepository = productRepository;
    }

    public void TakeOrder(int tableId, List<Product> products)
    {
        var tables = tableRepository.GetTables();
        var table = tables.FirstOrDefault(t => t.Id == tableId);
        if (table != null)
        {
            var orderId = orderRepository.GetOrders().Count + 1;
            var order = new Order(tableId, table, products);
            orderRepository.AddOrder(order);
            MarkTableAsOccupied(tableId);
        }
    }

    public void MarkTableAsOccupied(int tableId)
    {
        tableRepository.UpdateTableStatus(tableId, true);
    }

    public void MarkTableAsFree(int tableId)
    {
        tableRepository.UpdateTableStatus(tableId, false);
    }

    public List<Order> GetActiveOrders()
    {
        return orderRepository.GetOrders().Where(o => tableRepository.IsTableOccupied(o.TableNumber)).ToList();
    }
}

