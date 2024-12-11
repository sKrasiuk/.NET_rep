using Bankomatas.Models;

namespace Bankomatas
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to ATM!");

            var manager = new BankCardManager();
            manager.Start();
        }
    }
}
