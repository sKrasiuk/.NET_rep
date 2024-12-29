using Restoranas.Managers;
using Restoranas.Models;
using Restoranas.Repositories;
using Restoranas.Services;
using System.Globalization;
using System.Threading;
using System.Text;

namespace Restoranas
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            var lithuanianCulture = new CultureInfo("lt-LT");
            Thread.CurrentThread.CurrentCulture = lithuanianCulture;
            Thread.CurrentThread.CurrentUICulture = lithuanianCulture;
            CultureInfo.DefaultThreadCurrentCulture = lithuanianCulture;
            CultureInfo.DefaultThreadCurrentUICulture = lithuanianCulture;

            var waitersRepository = new WaitersRepository();
            var menuRepository = new MenuRepository();
            var tablesRepository = new TablesRepository();
            var orderRepository = new OrderRepository();
            var billRepository = new BillRepository();
            var emailService = new EmailService();
            var billManager = new BillManager(billRepository, emailService);

            var loginService = new LoginService(waitersRepository);
            var orderManager = new OrderManager(tablesRepository, menuRepository, orderRepository, billManager);

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
