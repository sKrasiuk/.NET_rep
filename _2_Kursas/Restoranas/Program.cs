﻿using Restoranas.Managers;
using Restoranas.Models;
using Restoranas.Repositories;
using Restoranas.Services;

namespace Restoranas
{
    public class Program
    {
        static void Main(string[] args)
        {
            var waitersRepository = new WaitersRepository();
            var menuRepository = new MenuRepository();
            var tablesRepository = new TablesRepository();
            var orderRepository = new OrderRepository();

            var loginService = new LoginService(waitersRepository);
            var orderManager = new OrderManager(tablesRepository, menuRepository, orderRepository);

            while (true)
            {
                var waiter = loginService.LogIn();
                if (waiter == null)
                {
                    break;
                }

                orderManager.ShowMenu(waiter);
            }
        }
    }
}
