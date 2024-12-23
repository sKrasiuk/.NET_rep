using System;
using RestoranoSistema.Models;

namespace RestoranoSistema
{
    public class Program
    {
        static void Main(string[] args)
        {
            var orderService = new OrderService(new OrderRepository(), new TableRepository(), new ProductRepository());
            var waiterRepository = new WaiterRepository();

        }
    }
}

