using System;

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
            foreach (var product in products)
            {
                order.Products.Add(product);
            }
            orderRepository.AddOrder(order);
        }
    }
}
