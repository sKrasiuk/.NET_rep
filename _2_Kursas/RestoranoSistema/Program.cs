using System;
using RestoranoSistema.Models;

namespace RestoranoSistema
{
    public class Program
    {
        static void Main(string[] args)
        {
            var products = new ProductRepository();
            var tables = new TableRepository();
            var waiters = new WaiterRepository();

            foreach (var waiter in waiters.GetWaiters())
            {
                Console.WriteLine($"{waiter.Name}");
            }
        }
    }
}

